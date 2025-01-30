using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using File = System.IO.File;

namespace PetzEasyLoaderGUI
{
    internal static class Program
    {
        public static string fileSource = Path.Combine(System.AppContext.BaseDirectory, "Filez");
        public static string backupDirectory = Path.Combine(System.AppContext.BaseDirectory, "baseGameBackups");
        public static configProperties config = new configProperties();

        public static AutoLoadingManager autoSwapping = new AutoLoadingManager(config);
        public static ContentProfilesManager contentProfiles = new ContentProfilesManager(config);

        public static bool startPetz = true;
        static bool showSettings = false;

        [STAThread]
        static void Main(string[] args)
        {
            if (!Directory.Exists(fileSource)) generateFilesFolder();
            if (!File.Exists("modify_settings.bat")) generateModifySettings();

            bool loaded = false;
            string oldFilePath = Path.Combine(System.AppContext.BaseDirectory, "Files");
            if (Directory.Exists(oldFilePath)) {
                DialogResult result = MessageBox.Show("Petz EZLoader has dectected files from a previous version. Would you like to migrate your previous settings and bulk loading profiles?", "Info", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    List<string> profiles = migrateProfilesFromOldVersion();
                    StringBuilder sb = new StringBuilder();
                    if (profiles.Count > 0) {
                        sb.Append("The following Bulk Loading folders have been migrated successfully: \n");
                        foreach (string file in profiles)
                        {
                            sb.Append(file);
                            sb.Append("\n");
                        }
                    }
                    else
                    {
                        sb.Append("No bulk loading profiles found. \n");
                    }
                    sb.Append("Please manually move the files in your SeasonalArea folder and then delete the Files folder");

                    MessageBox.Show(sb.ToString(), "Info");
                    if (File.Exists(Path.Combine(oldFilePath, "config.ini"))) 
                    {
                        loadIniFile(oldFilePath);
                        loaded = true;
                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(
                                Path.Combine(oldFilePath, "config.ini"),
                                UIOption.OnlyErrorDialogs,
                                RecycleOption.SendToRecycleBin);
                    }
                }
            }
            if (!loaded) loadIniFile(fileSource);

            ApplicationConfiguration.Initialize();

            if (showSettings || (args.Length > 0 && args[0] == "settings") || config.alwaysShowSettings
                || string.IsNullOrEmpty(config.petzDir) || string.IsNullOrEmpty(config.gameVersion))
            {
                startPetz = false;
                Application.Run(new FormSettings(config));
            }
            if (config.openContProfForum)
            {
                startPetz = false;
                Application.Run(new FormContentProfiles(config));
            }
            if (startPetz)
            {
                startLoading(true);
            }
        }

        public static void startLoading(bool startPetz)
        {
            if (string.IsNullOrEmpty(config.petzDir))
            {
                MessageBox.Show("Please set a Petz or Babyz game directory first", "Error");
                return;
            }
            //first remove files to remove
            if (config.contentProfilesEnabled) contentProfiles.removeExcludedFiles();

            //then load base game files
            if(!config.disableBaseGameFallback) contentProfiles.loadBaseGameFiles();

            //then load seasons and include files based on preference
            if (config.loadProfilesFirst)
            {
                if (config.contentProfilesEnabled) contentProfiles.addIncludedFiles();
                if (config.autoSwappingEnabled) autoSwapping.loadAutoSwapping();
            }
            else
            {
                if (config.autoSwappingEnabled) autoSwapping.loadAutoSwapping();
                if (config.contentProfilesEnabled) contentProfiles.addIncludedFiles();
            }

            if (startPetz)
            {
                try { Process.Start(Path.Combine(config.petzDir, config.gameVersion)); }
                catch
                {
                    MessageBox.Show("Cannot launch Petz. The selected Petz or Babyz .exe is invalid, or some other error occured" +
                                    "\n\nTip: If your Petz exe is set to run as administrator, make sure you're also running PetzEZLoader as administrator", "Error");
                }
            } 
        }

        static void loadIniFile(string loadPath)
        { 
            string configPath = Path.Combine(loadPath, "config.ini");
            if (File.Exists(configPath))
            {
                List<string> errors = new List<string>();
                string[] iniLines = File.ReadAllLines(configPath);
                foreach (string line in iniLines)
                {
                    if (line != "" && line[0] != '[')
                    {
                        try
                        {
                            string[] kv = line.Split('=');

                            // transfer version 1 settings
                            if (kv[0].Equals("seasonsEnabled") || kv[0].Equals("sceneSwappingEnabled"))
                            {
                                config.strProp["autoSwappingEnabled"].SetProperty(kv[1]);
                                config.strProp["seasonalAreaEnabled"].SetProperty(kv[1]);
                            }
                            else if (kv[0].Equals("dayNightEnabled")) 
                            {
                                config.strProp["timeAreaEnabled"].SetProperty(kv[1]); 
                            } 
                            //tranfer version 2 settings
                            else if (kv[0].Equals("forceSeason"))
                            {
                                config.strProp["defaultSeason"].SetProperty(kv[1]);
                            }
                            else if (kv[0].Equals("forceSeasonEnabled")) 
                            {
                                string s = "false";
                                if (kv[1].Equals("false")) s = "true";
                                config.strProp["seasonalAreaEnabled"].SetProperty(s);
                            }
                            else if (kv[0].Equals("forceTime"))
                            {
                                config.strProp["defaultTime"].SetProperty(kv[1]);
                            }
                            else if (kv[0].Equals("forceTimeEnabled"))
                            {
                                string s = "false";
                                if (kv[1].Equals("false")) s = "true";
                                config.strProp["seasonalTimeEnabled"].SetProperty(s);
                            }
                            else if (kv[0].Equals("forceWeather"))
                            {
                                config.strProp["defaultWeather"].SetProperty(kv[1]);
                            }
                            else if (kv[0].Equals("forceWeatherEnabled"))
                            {
                                string s = "false";
                                if (kv[1].Equals("false")) s = "true";
                                config.strProp["seasonalWeatherEnabled"].SetProperty(s);
                            }
                            else if (kv[0].Equals("bulkLoadingEnabled"))
                            {
                                config.strProp["contentProfilesEnabled"].SetProperty(kv[1]);
                            }
                            else 
                            {
                                config.strProp[kv[0]].SetProperty(kv[1]);
                            }

                        }
                        catch
                        {
                            errors.Add("\t" + line);
                        }
                    }
                }
                if (errors.Count != 0)
                {
                    StringBuilder message = new StringBuilder("An error occurred while loading the following settings: \n\n");
                    foreach (string error in errors)
                    {
                        message.Append(error + "\n");
                    }
                    message.Append("\nAll settings with errors have been reset to their defaults.");
                    MessageBox.Show(message.ToString(), "Error");
                    showSettings = true;
                }
                config.refreshFolders();
            }
            else
            {
                MessageBox.Show("Can't find config.ini, loading with default setting", "Error");
                config.refreshFolders();
                saveIniFile();
            }
        }

        public static void saveIniFile()
        {
            string configPath = Path.Combine(fileSource, "config.ini");
            List<string> content = new List<string>();

            content.Add("[Petz Directory]");
            content.Add("petzDir=" + config.petzDir);
            content.Add("gameVersion=" + config.gameVersion);

            content.Add("[General Settings]");
            content.Add("alwaysShowSettings=" + config.alwaysShowSettings);

            content.Add("[Internal Settings]");
            content.Add("lastLoadDate=" + config.lastLoadDate);
            content.Add("lastWeather=" + config.lastWeather);

            content.Add("[Advanced Settings]");
            content.Add("openContProfForum=" + config.openContProfForum);
            content.Add("loadProfilesFirst=" + config.loadProfilesFirst);
            content.Add("disableBaseGameFallback=" + config.disableBaseGameFallback);

            content.Add("[Seasonal Settings]");
            content.Add("autoSwappingEnabled=" + config.autoSwappingEnabled);

            content.Add("defaultSeason=" + config.defaultSeason);
            content.Add("seasonalAreaEnabled=" + config.seasonalAreaEnabled);
            content.Add("seasonalACEnabled=" + config.seasonalACEnabled);
            content.Add("seasonalCaseEnabled=" + config.seasonalCaseEnabled);
            content.Add("seasonalMiceEnabled=" + config.seasonalMiceEnabled);

            content.Add("winterStart=" + config.winterStart);
            content.Add("springStart=" + config.springStart);
            content.Add("summerStart=" + config.summerStart);
            content.Add("fallStart=" + config.fallStart);

            content.Add("defaultTime=" + config.defaultTime);
            content.Add("timeAreaEnabled=" + config.timeAreaEnabled);
            content.Add("timeACEnabled=" + config.timeACEnabled);
            content.Add("timeCaseEnabled=" + config.timeCaseEnabled);
            content.Add("timeMiceEnabled=" + config.timeMiceEnabled);

            content.Add("caseMode24Hour=" + config.caseMode24Hour);

            content.Add("enableSunriseset=" + config.enableSunriseset);
            content.Add("sunriseTime=" + config.sunriseTime);
            content.Add("sunsetTime=" + config.sunsetTime);

            content.Add("defaultWeather=" + config.defaultWeather);
            content.Add("weatherAreaEnabled=" + config.weatherAreaEnabled);
            content.Add("weatherACEnabled=" + config.weatherACEnabled);
            content.Add("weatherCaseEnabled=" + config.weatherCaseEnabled);
            content.Add("weatherMiceEnabled=" + config.weatherMiceEnabled);

            content.Add("weatherRotation=" + config.weatherRotation);
            content.Add("longitude=" + config.longitude);
            content.Add("latitude=" + config.latitude);

            content.Add("[Content Profile Settings]");
            content.Add("contentProfilesEnabled=" + config.contentProfilesEnabled);

            content.Add("disableLoadingResources=" + config.disableLoadingResources);
            content.Add("disableLoadingPetz=" + config.disableLoadingPetz);

            content.Add("disableLoadingCase=" + config.disableLoadingCase);
            content.Add("disableLoadingMice=" + config.disableLoadingMice);
            content.Add("disableLoadingAC=" + config.disableLoadingAC);

            content.Add("include=" + config.listGetter(config.include));
            content.Add("exclude=" + config.listGetter(config.exclude));

            File.WriteAllLines(configPath, content);
        }

        public static void generateModifySettings()
        {
            string dir = Path.Combine(Path.GetDirectoryName(fileSource), "modify_settings.bat");
            string fileContent = "start PetzEZLoader.exe settings";

            File.WriteAllText(dir, fileContent);
        }

        public static void generateFilesFolder()
        {
            foreach (string season in config.defaultSeasonOptions)
            {
                foreach (string time in config.defaultTimeOptions)
                {
                    foreach (string weather in config.defaultWeatherOptions)
                    {
                        string areaPath = Path.Combine(fileSource, "SeasonalArea", season, time, weather);
                        Directory.CreateDirectory(areaPath);
                        string acPath = Path.Combine(fileSource, "SeasonalACSprites", season, time, weather);
                        Directory.CreateDirectory(acPath);
                        if (!(time.Equals("sunrise") || time.Equals("sunset")))
                        {
                            string casePath = Path.Combine(fileSource, "SeasonalCase", season, time, weather);
                            Directory.CreateDirectory(casePath);
                            string micePath = Path.Combine(fileSource, "SeasonalMice", season, time, weather);
                            Directory.CreateDirectory(micePath);
                        }
                    }
                }
            }

            for (int i = 0; i < 24; i++)
            {
                string casePath = Path.Combine(fileSource, "SeasonalCase", "24hour", "Case " + i);
                Directory.CreateDirectory(casePath);
            }

            Directory.CreateDirectory(Path.Combine(fileSource, "ContentProfiles"));
            
            saveIniFile();
        }

        public static void createDebugTxt()
        {
            foreach (string season in config.defaultSeasonOptions)
            {
                foreach (string time in config.defaultTimeOptions)
                {
                    foreach (string weather in config.defaultWeatherOptions)
                    {
                        string areaPath = Path.Combine(fileSource, "SeasonalArea", season, time, weather);
                        Directory.CreateDirectory(areaPath);
                        makeDebugFile(areaPath);
                        if (!(time.Equals("sunrise") || time.Equals("sunset")))
                        {
                            string casePath = Path.Combine(fileSource, "SeasonalCase", season, time, weather);
                            Directory.CreateDirectory(casePath);
                            makeDebugFile(casePath);

                            string micePath = Path.Combine(fileSource, "SeasonalMice", season, time, weather);
                            Directory.CreateDirectory(micePath);
                            makeDebugFile(micePath);
                        }
                    }
                }
            }

            for (int i = 0; i < 24; i++)
            {
                string casePath = Path.Combine(fileSource, "SeasonalCase", "24hour", "Case " + i);
                Directory.CreateDirectory(casePath);
                makeDebugFile(casePath);
            }
        }

        public static void deleteDebugTxt()
        {
            foreach (string season in config.defaultSeasonOptions)
            {
                foreach (string time in config.defaultTimeOptions)
                {
                    foreach (string weather in config.defaultWeatherOptions)
                    {
                        string areaPath = Path.Combine(fileSource, "SeasonalArea", season, time, weather);
                        Directory.CreateDirectory(areaPath);
                        
                        if (!(time.Equals("sunrise") || time.Equals("sunset")))
                        {
                            string casePath = Path.Combine(fileSource, "SeasonalCase", season, time, weather);
                            Directory.CreateDirectory(casePath);
                            deleteDebugFile(casePath);

                            string micePath = Path.Combine(fileSource, "SeasonalMice", season, time, weather);
                            Directory.CreateDirectory(micePath);
                            deleteDebugFile(micePath);
                        }
                    }
                }
            }

            for (int i = 0; i < 24; i++)
            {
                string casePath = Path.Combine(fileSource, "SeasonalCase", "24hour", "Case " + i);
                Directory.CreateDirectory(casePath);
                deleteDebugFile(casePath);
            }
        }

        static void makeDebugFile(string path)
        {
            File.WriteAllText(Path.Combine(path, "debug.txt"), path);
        }

        static void deleteDebugFile(string path)
        {
            try
            {
                File.Delete(Path.Combine(path, "debug.txt"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static List<string> getContentProfileFolders()
        {
            List<string> folders = new List<string>();
            DirectoryInfo df = new DirectoryInfo(Path.Combine(fileSource, "ContentProfiles"));
            Array.ForEach(df.GetDirectories(), (dir) => { folders.Add(dir.Name); });
            if (folders.Contains("baseGameBackup")) folders.Remove("baseGameBackup");
            return folders;
        }

        public static void deleteContentProfile(string profile)
        {
            contentProfiles.deleteContentProfile(profile);
        }

        private static List<string> migrateProfilesFromOldVersion()
        {
            List<string> copiedProfiles = new List<string>();
            string oldFileSource = Path.Combine(System.AppContext.BaseDirectory, "Files");
            if (Directory.Exists(oldFileSource)) {
                foreach (string dir in Directory.GetDirectories(oldFileSource)) {
                    if (!dir.Equals("SeasonalArea")) { 
                        string newDirName = Path.GetFileName(dir);
                        string contentProfilesPath = Path.Combine(fileSource, "ContentProfiles");
                        DirectoryInfo cpDirInfo = new DirectoryInfo(contentProfilesPath);
                        if (!Directory.Exists(Path.Combine(contentProfilesPath, newDirName)))
                        {
                            DirectoryInfo newDirInfo = cpDirInfo.CreateSubdirectory(newDirName);
                            newDirInfo.CreateSubdirectory("Resource");
                            foreach (string subDir in Directory.GetDirectories(dir))
                            {
                                string newLocation = Path.Combine(contentProfilesPath, newDirName, "Resource", Path.GetFileName(subDir));
                                Directory.Move(subDir, newLocation);
                            }
                            copiedProfiles.Add(newDirName);
                            Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(dir, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                        }
                    }
                    
                }
            }
            return copiedProfiles;
        }

        public static void regenerateBaseGameBackup(string file)
        {
            string version = file.Substring(0, file.Length - 4);
            string backupPath = Path.Combine(backupDirectory, version);
            if (Directory.Exists(backupPath)) {
                string newPath = Path.Combine(fileSource, "ContentProfiles", "baseGameBackup");
                if (Directory.Exists(newPath)) { 
                    Directory.Delete(newPath, true);
                }
                Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(backupPath, newPath);
            }
            else
            {
                MessageBox.Show("No backup folder for " + version + "found, disabling base game fallback", "Info");
                config.disableBaseGameFallback = true;
            }
        }
    }
}
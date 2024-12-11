using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
        public static string fileSource = Path.Combine(System.AppContext.BaseDirectory, "Files");
        public static configProperties config = new configProperties();

        public static bool startPetz = true;
        static bool showSettings = false;

        static string adoptedPetz = "Adopted Petz";
        static string petExtension = ".pet";

        [STAThread]
        static void Main(string[] args)
        {
            if (!Directory.Exists(fileSource)) generateFilesFolder();
            if (!File.Exists("modify_settings.bat")) generateModifySettings();
            loadIniFile();

            if (showSettings || (args.Length > 0 && args[0] == "settings") || config.alwaysShowSettings
                || string.IsNullOrEmpty(config.petzDir) || string.IsNullOrEmpty(config.gameVersion))
            {
                startPetz = false;
                ApplicationConfiguration.Initialize();
                Application.Run(new FormSettings(config));
               
            }
            if (config.openContProfForum) Application.Run(new Form2());
            if (startPetz)
            {
                startLoading();
            }
        }

        static void startLoading()
        {
            if (config.loadProfilesFirst)
            {
                if (config.contentProfilesEnabled) loadContentProfiles();
                if (config.autoSwappingEnabled) loadAutoSwapping();
            }
            else
            {
                if (config.autoSwappingEnabled) loadAutoSwapping();
                if (config.contentProfilesEnabled) loadContentProfiles();
            }

            try { Process.Start(Path.Combine(config.petzDir, config.gameVersion)); }
            catch {
                MessageBox.Show("Cannot launch Petz. The selected Petz or Babyz .exe is invalid, or some other error occured" +
                                "\n\nTip: If your Petz exe is set to run as administrator, make sure you're also running PetzEZLoader as administrator", "Error");
            }
        }

        static void loadAutoSwapping()
        {
            string curSeason = config.defaultSeason;
            string curTime = config.defaultTime;
            string curWeather = config.defaultWeather;
            if (config.seasonalAreaEnabled || config.seasonalCaseEnabled || config.seasonalMiceEnabled) curSeason = getSeason();
            if (config.timeAreaEnabled || config.timeCaseEnabled || config.timeMiceEnabled) curTime = getTime(false);
            if (config.weatherAreaEnabled || config.weatherCaseEnabled || config.weatherMiceEnabled) curWeather = getWeather();

            if (config.seasonalAreaEnabled || config.timeAreaEnabled || config.weatherAreaEnabled)
            {
                loadSeasonalArea(curSeason, getTime(config.enableSunriseset), curWeather);
            }
            if (config.seasonalCaseEnabled || config.timeCaseEnabled || config.weatherCaseEnabled)
            {
                loadSeasonalCases(curSeason, curTime, curWeather);
            }
            if (config.seasonalMiceEnabled || config.timeMiceEnabled || config.weatherMiceEnabled)
            {
                loadSeasonalMice(curSeason, curTime, curWeather);
            }
        }

        static void loadContentProfiles()
        {
            //first load petz
            if(!config.disableLoadingPetz)
            {
                removePetzFromGame();
                copyPetzToGame();
            }

            //then resource files
            if (!config.disableLoadingResources)
            {
                removeResourceFiles(mergeResourecFileFolders(config.exclude, false));
                copyResourceFiles(mergeResourecFileFolders(config.include, true));
            }

            //then external dll stuff
            if (!config.disableLoadingPetzRez)
            {
                loadLastResource("CarryingCase");
                loadLastResource("ACSprites");
                loadLastResource("Mice");
            }
        }

        static void loadIniFile()
        {
            string configPath = Path.Combine(fileSource, "config.ini");
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
            content.Add("seasonalCaseEnabled=" + config.seasonalCaseEnabled);
            content.Add("seasonalMiceEnabled=" + config.seasonalMiceEnabled);

            content.Add("winterStart=" + config.winterStart);
            content.Add("springStart=" + config.springStart);
            content.Add("summerStart=" + config.summerStart);
            content.Add("fallStart=" + config.fallStart);

            content.Add("defaultTime=" + config.defaultTime);
            content.Add("timeAreaEnabled=" + config.timeAreaEnabled);
            content.Add("timeCaseEnabled=" + config.timeCaseEnabled);
            content.Add("timeMiceEnabled=" + config.timeMiceEnabled);

            content.Add("caseMode24Hour=" + config.caseMode24Hour);

            content.Add("enableSunriseset=" + config.enableSunriseset);
            content.Add("sunriseTime=" + config.sunriseTime);
            content.Add("sunsetTime=" + config.sunsetTime);

            content.Add("defaultWeather=" + config.defaultWeather);
            content.Add("weatherAreaEnabled=" + config.weatherAreaEnabled);
            content.Add("weatherCaseEnabled=" + config.weatherCaseEnabled);
            content.Add("weatherMiceEnabled=" + config.weatherMiceEnabled);

            content.Add("weatherRotation=" + config.weatherRotation);
            content.Add("longitude=" + config.longitude);
            content.Add("latitude=" + config.latitude);

            content.Add("[Content Profile Settings]");
            content.Add("contentProfilesEnabled=" + config.contentProfilesEnabled);

            content.Add("disableLoadingResources=" + config.disableLoadingResources);
            content.Add("disableLoadingPetz=" + config.disableLoadingPetz);
            content.Add("disableLoadingPetzRez=" + config.disableLoadingPetzRez);

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

        static string getSeason()
        {
            DateTime dateTime = DateTime.Now;
            int curDate = int.Parse(dateTime.ToString("MMdd"));

            string curSeason = "summer";

            int winter = config.winterStart;
            int spring = config.springStart;
            int summer = config.summerStart;
            int fall = config.fallStart;

            if (isDateBetween(curDate, winter, spring)) curSeason = "winter";
            else if (isDateBetween(curDate, spring, summer)) curSeason = "spring";
            else if (isDateBetween(curDate, summer, fall)) curSeason = "summer";
            else curSeason = "fall";

            return curSeason;
        }

        static string getTime(bool sunEnabled)
        {
            DateTime dateTime = DateTime.Now;
            int curDate = int.Parse(dateTime.ToString("MMdd"));
            string curTime = "day";

            int sunrise = config.sunriseTime;
            int sunset = config.sunsetTime;

            int curHour = Int32.Parse(dateTime.ToString("HHmm"));
            if (curHour < sunrise || curHour >= sunset)
            {
                curTime = "night";

            }
            if (sunEnabled)
            {
                if ((curHour / 100) == (sunrise / 100)) curTime = "sunrise";
                else if ((curHour / 100) == (sunrise / 100)) curTime = "sunset";
            }
            return curTime;
        }
        static bool isDateBetween(int test, int start, int end)
        {
            if (start > end)
            {
                return test >= start || test < end;
            }
            else
            {
                return test >= start && test < end;
            }
        }

        static string getWeather()
        {
            DateTime dateTime = DateTime.Now;
            int curDate = int.Parse(dateTime.ToString("MMdd"));
            string curWeather = "clear";

            var random = new Random();
            if (config.weatherRotation == "onload")
            {
                int id = random.Next(config.weatherRotationOptions.Count);
                curWeather = config.defaultWeatherOptions[id];
            }
            else if (config.weatherRotation == "perday")
            {
                if (curDate != config.lastLoadDate)
                {
                    int id = random.Next(config.weatherRotationOptions.Count);
                    curWeather = config.defaultWeatherOptions[id];
                }
                else
                {
                    curWeather = config.lastWeather;
                }
            }
            else if (config.weatherRotation == "location")
            {
                int weatherCode = callWeatherApi(config.latitude, config.longitude);
                switch (weatherCode)
                {
                    case 0:
                    case 1:
                        curWeather = "clear";
                        break;
                    case 2:
                        curWeather = "cloudy";
                        break;
                    case 3:
                    case 45:
                    case 48:
                        curWeather = "overcast";
                        break;
                    case 51:
                    case 53:
                    case 55:
                    case 56:
                    case 57:
                    case 61:
                    case 63:
                    case 65:
                    case 66:
                    case 67:
                    case 80:
                    case 81:
                    case 82:
                        curWeather = "rain";
                        break;
                    case 71:
                    case 73:
                    case 75:
                    case 77:
                    case 85:
                    case 86:
                        curWeather = "snow";
                        break;
                    case 95:
                    case 96:
                    case 99:
                        curWeather = "thunder";
                        break;
                    default:
                        MessageBox.Show("Error connecting to Open Meteo Weather API, loading with last saved weather", "Error");
                        curWeather = config.lastWeather;
                        break;
                }
            }
            config.lastWeather = curWeather;
            config.lastLoadDate = curDate;
            saveIniFile();

            return curWeather;
        }


        static void loadSeasonalArea(string calcSeason, string calcTime, string calcWeather)
        {
            string seasonalAreaPath = Path.Combine(fileSource, "SeasonalArea");
            if (Directory.Exists(seasonalAreaPath)) {

                string curSeason = config.defaultSeason;
                if (config.seasonalAreaEnabled) curSeason = calcSeason;
                string curTime = config.defaultTime;
                if (config.timeAreaEnabled) curTime = calcTime;
                string curWeather = config.defaultWeather;
                if (config.weatherAreaEnabled) curWeather = calcWeather;

                string seasonalPath = Path.Combine(seasonalAreaPath, curSeason, curTime, curWeather);
                string petzPath = Path.Combine(config.petzDir, "Resource", "Area");
                if (Directory.Exists(seasonalPath))
                {
                    if(Directory.Exists(petzPath))
                    {
                        string[] sourceFiles = Directory.GetFiles(seasonalPath);
                        foreach (string file in sourceFiles)
                        {
                            string dest = Path.Combine(petzPath, Path.GetFileName(file));
                            System.IO.File.Copy(file, dest, true);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Can't find Resource\\Area in petz directory, loading without swapping scenes", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Can't find SeasonalArea\\" + curSeason + "\\" + curTime + "\\" + curWeather + " directory, loading without swapping scenes", "Error");
                }
            }
            else
            {
                MessageBox.Show("Can't find SeasonalArea directory, loading without swapping scenes", "Error");
                generateFilesFolder();
            }
        }

        static void loadSeasonalMice(string calcSeason, string calcTime, string calcWeather)
        {
            string seasonalMicePath = Path.Combine(fileSource, "SeasonalMice");
            if (Directory.Exists(seasonalMicePath))
            {
                string curSeason = config.defaultSeason;
                if (config.seasonalMiceEnabled) curSeason = calcSeason;
                string curTime = config.defaultTime;
                if (config.timeMiceEnabled) curTime = calcTime;
                else
                {
                    //if default time is sunrise or sunset, change
                    if (curTime.Equals("sunrise")) curTime = "day";
                    else if (curTime.Equals("sunset")) curTime = "night";
                }
                string curWeather = config.defaultWeather;
                if (config.weatherMiceEnabled) curWeather = calcWeather;

                string seasonalPath = Path.Combine(seasonalMicePath, curSeason, curTime, curWeather);
                string petzPath = Path.Combine(config.petzDir, "PtzFiles", "Mouse");
                if (Directory.Exists(seasonalPath))
                {
                    if (!Directory.Exists(petzPath)) Directory.CreateDirectory(petzPath);
                    
                    string[] sourceFiles = Directory.GetFiles(seasonalPath);
                    foreach (string file in sourceFiles)
                    {
                        string dest = Path.Combine(petzPath, Path.GetFileName(file));
                        System.IO.File.Copy(file, dest, true);
                    }
                }
                else
                {
                    MessageBox.Show("Can't find SeasonalMice\\" + curSeason + "\\" + curTime + "\\" + curWeather + " directory, loading without swapping mice", "Error");
                }
            }
            else
            {
                MessageBox.Show("Can't find SeasonalMice directory, loading without swapping mice", "Error");
                generateFilesFolder();
            }
        }

        static void loadSeasonalCases(string calcSeason, string calcTime, string calcWeather)
        {
            string seasonalCasePath = Path.Combine(fileSource, "SeasonalCase");
            if (Directory.Exists(seasonalCasePath))
            {
                string seasonalPath = seasonalCasePath;
                
                if (config.caseMode24Hour) {
                    DateTime dateTime = DateTime.Now;
                    int curHour = Int32.Parse(dateTime.ToString("HH"));
                    string folder = "Case " + (curHour - 1);

                    seasonalPath = Path.Combine(seasonalCasePath, "24hour", folder);
                }
                else
                {
                    string curSeason = config.defaultSeason;
                    if (config.seasonalCaseEnabled) curSeason = calcSeason;
                    string curTime = config.defaultTime;
                    if (config.timeCaseEnabled) curTime = calcTime;
                    else
                    {
                        //if default time is sunrise or sunset, change
                        if (curTime.Equals("sunrise")) curTime = "day";
                        else if (curTime.Equals("sunset")) curTime = "night";
                    }
                    string curWeather = config.defaultWeather;
                    if (config.weatherCaseEnabled) curWeather = calcWeather;
                    seasonalPath = Path.Combine(seasonalCasePath, curSeason, curTime, curWeather);
                }

                string petzPath = Path.Combine(config.petzDir, "Art", "Sprites", "Case");
                if (Directory.Exists(seasonalPath))
                {
                    if (!Directory.Exists(petzPath)) Directory.CreateDirectory(petzPath);

                    string[] sourceFiles = Directory.GetFiles(seasonalPath);
                    foreach (string file in sourceFiles)
                    {
                        string dest = Path.Combine(petzPath, Path.GetFileName(file));
                        System.IO.File.Copy(file, dest, true);
                    }
                }
                else
                {
                    MessageBox.Show("Can't find correct SeasonalCase directory, loading without swapping cases", "Error");
                }
            }
            else
            {
                MessageBox.Show("Can't find SeasonalCase directory, loading without swapping cases", "Error");
                generateFilesFolder();
            }
        }

        //static void old_loadSeasonalArea()
        //{
        //    string seasonalAreaPath = Path.Combine(fileSource, "SeasonalArea");
        //    if (Directory.Exists(seasonalAreaPath))
        //    {
        //        DateTime dateTime = DateTime.Now;
        //        int curDate = int.Parse(dateTime.ToString("MMdd"));
        //        string curSeason = "summer";
        //        if (config.forceSeasonEnabled)
        //        {
        //            curSeason = config.forceSeason;
        //        }
        //        else
        //        {
        //            int winter = config.winterStart;
        //            int spring = config.springStart;
        //            int summer = config.summerStart;
        //            int fall = config.fallStart;

        //            if (isDateBetween(curDate, winter, spring)) curSeason = "winter";
        //            else if (isDateBetween(curDate, spring, summer)) curSeason = "spring";
        //            else if (isDateBetween(curDate, summer, fall)) curSeason = "summer";
        //            else curSeason = "fall";
        //        }
        //        string curTime = "day";
        //        if (config.forceTimeEnabled)
        //        {
        //            curTime = config.forceTime;
        //        }
        //        else
        //        {
        //            int sunrise = config.sunriseTime;
        //            int sunset = config.sunsetTime;

        //            int curHour = Int32.Parse(dateTime.ToString("HHmm"));
        //            if (curHour < sunrise || curHour >= sunset)
        //            {
        //                curTime = "night";
        //            }
        //            if (config.enableSunriseset)
        //            {
        //                if ((curHour / 100) == (sunrise / 100)) curTime = "sunrise";
        //                else if ((curHour / 100) == (sunrise / 100)) curTime = "sunset";
        //            }
        //        }
        //        string curWeather = "clear";
        //        var random = new Random();
        //        if (config.forceWeatherEnabled)
        //        {
        //            curWeather = config.forceWeather;
        //        }
        //        else
        //        {
        //            if (config.weatherRotation == "onload")
        //            {
        //                int id = random.Next(config.weatherRotationOptions.Count);
        //                curWeather = config.forceWeatherOptions[id];
        //            }
        //            else if (config.weatherRotation == "perday")
        //            {
        //                if (curDate != config.lastLoadDate)
        //                {
        //                    int id = random.Next(config.weatherRotationOptions.Count);
        //                    curWeather = config.forceWeatherOptions[id];
        //                }
        //                else
        //                {
        //                    curWeather = config.lastWeather;
        //                }
        //            }
        //            else if (config.weatherRotation == "location")
        //            {
        //                int weatherCode = callWeatherApi(config.latitude, config.longitude);
        //                switch (weatherCode)
        //                {
        //                    case 0:
        //                    case 1:
        //                        curWeather = "clear";
        //                        break;
        //                    case 2:
        //                        curWeather = "cloudy";
        //                        break;
        //                    case 3:
        //                    case 45:
        //                    case 48:
        //                        curWeather = "overcast";
        //                        break;
        //                    case 51:
        //                    case 53:
        //                    case 55:
        //                    case 56:
        //                    case 57:
        //                    case 61:
        //                    case 63:
        //                    case 65:
        //                    case 66:
        //                    case 67:
        //                    case 80:
        //                    case 81:
        //                    case 82:
        //                        curWeather = "rain";
        //                        break;
        //                    case 71:
        //                    case 73:
        //                    case 75:
        //                    case 77:
        //                    case 85:
        //                    case 86:
        //                        curWeather = "snow";
        //                        break;
        //                    case 95:
        //                    case 96:
        //                    case 99:
        //                        curWeather = "thunder";
        //                        break;
        //                    default:
        //                        MessageBox.Show("Error connecting to Open Meteo Weather API, loading with last saved weather", "Error");
        //                        curWeather = config.lastWeather;
        //                        break;
        //                }
        //            }
        //            config.lastWeather = curWeather;
        //            config.lastLoadDate = curDate;
        //            saveIniFile();
        //        }
        //        string seasonalPath = Path.Combine(seasonalAreaPath, curSeason, curTime, curWeather);

        //        // christmas easter egg
        //        if ((curDate == 1225 || curDate == 1224))
        //        {
        //            string xmasTime = curTime;
        //            if (curTime == "sunset" || curTime == "sunrise") xmasTime = "night";
        //            string xmasDay = Path.Combine(seasonalAreaPath, "winter", xmasTime, "christmas");
        //            if (Directory.Exists(xmasDay))
        //            {
        //                seasonalPath = xmasDay;
        //            }
        //        }

        //        string petzPath = Path.Combine(config.petzDir, "Resource", "Area");
        //        if (Directory.Exists(seasonalPath))
        //        {
        //            if (Directory.Exists(petzPath))
        //            {
        //                string[] sourceFiles = Directory.GetFiles(seasonalPath);
        //                foreach (string file in sourceFiles)
        //                {
        //                    string dest = Path.Combine(petzPath, Path.GetFileName(file));
        //                    System.IO.File.Copy(file, dest, true);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Can't find Resource\\Area in petz directory, loading without swapping scenes", "Error");
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Can't find SeasonalArea\\" + curSeason + "\\" + curTime + "\\" + curWeather + " directory, loading without swapping scenes", "Error");
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Can't find SeasonalArea directory, loading without swapping scenes", "Error");
        //        generateFilesFolder();
        //    }
        //}

        public static List<string> getFolders()
        {
            List<string> folders = new List<string>();
            DirectoryInfo df = new DirectoryInfo(Path.Combine(fileSource, "ContentProfiles"));
            Array.ForEach(df.GetDirectories(), (dir) => { folders.Add(dir.Name); });
            return folders;
        }

        static void removePetzFromGame()
        {
            string gamePath = Path.Combine(config.petzDir, "Adopted Petz");
            foreach (string eFolder in config.exclude)
            {
                string excludeFolderPath = Path.Combine(fileSource, "ContentProfiles", eFolder, "Adopted Petz");
                if (Directory.Exists(excludeFolderPath))
                {
                    foreach (string fileToRemove in Directory.GetFiles(excludeFolderPath))
                    {
                        //if file is a pet, copy back into folder
                        if (Path.GetExtension(fileToRemove).ToLower().Equals(".pet"))
                        {
                            string petInGame = Path.Combine(gamePath, Path.GetFileName(fileToRemove));
                            bool foundPet = false;
                            //if pet with same name exists check that one first
                            if (File.Exists(petInGame))
                            {
                                if (comparePetz(fileToRemove, petInGame))
                                {
                                    //if same, copy pet to folder then delete pet in game
                                    File.Copy(petInGame, fileToRemove, true);

                                    FileInfo fileInfo = new FileInfo(petInGame);
                                    fileInfo.IsReadOnly = false;
                                    File.Delete(petInGame);
                                    foundPet = true;
                                }
                            }
                            if (!foundPet)
                            {
                                // if we haven't found it check every pet
                                foreach (string possiblePet in Directory.GetFiles(gamePath))
                                {
                                    if (Path.GetExtension(possiblePet).ToLower().Equals(".pet") && comparePetz(fileToRemove, possiblePet))
                                    {
                                        // if we find it, copy pet back into folder with new name
                                        string newStoragePath = Path.Combine(excludeFolderPath, Path.GetFileName(possiblePet));
                                        if (File.Exists(newStoragePath))
                                        {
                                            // if a pet with the new name exists in storage too, append guid
                                            string guid = getGuid(possiblePet);
                                            newStoragePath = Path.Combine(excludeFolderPath, Path.GetFileNameWithoutExtension(possiblePet) + "-" + guid.Substring(0, 6) + ".pet");
                                        }
                                        File.Copy(possiblePet, newStoragePath, true);

                                        // delete the old name pet from storage
                                        FileInfo fileInfo = new FileInfo(fileToRemove);
                                        fileInfo.IsReadOnly = false;
                                        File.Delete(fileToRemove);;

                                        // and delete pet with new name from game
                                        FileInfo fileInfo2 = new FileInfo(possiblePet);
                                        fileInfo2.IsReadOnly = false;
                                        File.Delete(possiblePet);
                                        break;
                                    }
                                }
                            }
                        }
                        else //if it's not a pet just delete it
                        {
                            string fileInGame = Path.Combine(gamePath, Path.GetFileName(fileToRemove));
                            if (File.Exists(fileInGame))
                            {
                                FileInfo fileInfo = new FileInfo(fileInGame);
                                fileInfo.IsReadOnly = false;
                                File.Delete(fileInGame);
                            }
                        }
                       
                        
   
                    }
                }
            }
        }

        static void copyPetzToGame()
        {
            string gamePath = Path.Combine(config.petzDir, "Adopted Petz");
            foreach (string iFolder in config.include)
            {
                string includeFolderPath = Path.Combine(fileSource, "ContentProfiles", iFolder, "Adopted Petz");
                if (Directory.Exists(includeFolderPath))
                {
                    foreach (string petInStorage in Directory.GetFiles(includeFolderPath))
                    {
                        //if pet, we gotta do lots of checks
                        if (Path.GetExtension(petInStorage).Equals(".pet")) {
                            bool matchFound = false;
                            string petInGame = Path.Combine(gamePath, Path.GetFileName(petInStorage));
                            string workingPetInStorage = petInStorage;
                            string petName = Path.GetFileName(petInStorage);
                            // if a name match, check that first
                            if (File.Exists(petInGame)) {
                                // check if they are actually the same pet
                                if (comparePetz(petInGame, petInStorage))
                                {
                                    matchFound = true;
                                }
                                else
                                {
                                    //rename the pet in storage so if it's copied in no conflict
                                    string guid = getGuid(petInStorage);
                                    petName = Path.GetFileNameWithoutExtension(petInStorage) + "-" + guid.Substring(0,6) + ".pet";
                                    workingPetInStorage = Path.Combine(includeFolderPath, petName);
                                    File.Move(petInStorage, workingPetInStorage);

                                }
                            }
                            // if we didn't match, check all the petz
                            if (!matchFound) {
                                foreach (string possiblePet in Directory.GetFiles(gamePath))
                                {
                                    if (comparePetz(workingPetInStorage, possiblePet))
                                    {
                                        // we found a match with a different name, update the name in storage
                                        string newStoragePath = Path.Combine(includeFolderPath, Path.GetFileName(possiblePet));
                                        petName = Path.GetFileName(possiblePet);

                                        // if a pet with that name is already in storage, append guid to the name of the pet we're working with
                                        if (File.Exists(newStoragePath))
                                        {
                                            string guid = getGuid(possiblePet);
                                            //append guid to in game name
                                            petName = Path.GetFileNameWithoutExtension(possiblePet) + "-" + guid.Substring(0, 6) + ".pet";
                                            newStoragePath = Path.Combine(includeFolderPath, petName);
                                            // rename the pet in game
                                            File.Move(possiblePet, Path.Combine(gamePath, petName));
                                            // delete the old pet in storage
                                            File.Delete(workingPetInStorage);
                                            workingPetInStorage = newStoragePath;
                                        }
                                        // copy the pet with the new name into storage
                                        File.Copy(Path.Combine(gamePath, petName), newStoragePath, true);

                                        matchFound = true;
                                        break;
                                    }
                                }
                            }
                            //still no match, copy the pet in
                            if (!matchFound)
                            {
                                File.Copy(workingPetInStorage, Path.Combine(gamePath, petName), false);
                            }
                        }
                        else
                        {
                            //otherwise just check if it's not there and if not copy it
                            string gameFile = Path.Combine(gamePath, Path.GetFileName(petInStorage));
                            if (!(File.Exists(gameFile) && AreSameFile(petInStorage, gameFile)))
                            {
                                File.Copy(petInStorage, gameFile, true);
                            }
                        }
                    }
                    
                }
            }
        }



        static bool duplicatePetNamesExist()
        {
            List<string> petz = new List<string>();
            foreach (string eFolder in config.exclude)
            {
                string path = Path.Combine(fileSource, eFolder, "Adopted Petz");
                if (Directory.Exists(path))
                {
                    foreach (string file in Directory.GetFiles(path))
                        if (Path.GetExtension(file).Equals("pet")) petz.Add(Path.GetFileName(file));
                }
            }
            foreach (string iFolder in config.include)
            {
                string path = Path.Combine(fileSource, iFolder, "Adopted Petz");
                if (Directory.Exists(path))
                {
                    foreach (string file in Directory.GetFiles(path))
                        if (Path.GetExtension(file).Equals("pet")) petz.Add(Path.GetFileName(file)); ;
                }
            }
            return petz.Count != petz.Distinct().Count();
        }


        static List<string> mergeResourecFileFolders(List<string> foldersToMerge, bool removeDupes)
        {
            List<string> mergedList = new List<string>();   
            foreach (string folderName in foldersToMerge)
            {
                string storageResPath = Path.Combine(fileSource, "ContentProfiles", folderName, "Resource");
                if (Directory.Exists(storageResPath))
                {
                    foreach (string resFolder in Directory.GetDirectories(Path.Combine(fileSource, "ContentProfiles", folderName, "Resource")))
                    {
                        foreach (string resFile in Directory.GetFiles(resFolder))
                        {
                            if (removeDupes)
                            {
                                IEnumerable<string> dupeFiles = mergedList.Where<string>(item => Path.GetFileName(item) == Path.GetFileName(resFile));
                                foreach (string dupe in dupeFiles.ToList())
                                {
                                    mergedList.Remove(dupe);
                                }
                            }
                            mergedList.Add(resFile);
                        }
                    }
                }
                
            }
            return mergedList;
        }

        static void removeResourceFiles(List<string> filesToRemove)
        {
            string gamePath = Path.Combine(config.petzDir, "Resource");
            foreach (string file in filesToRemove)
            {
                string fileDir = Path.GetFileName(Path.GetDirectoryName(file));
                string fileName = Path.GetFileName(file);
                string gameFile = Path.Combine(gamePath, fileDir, fileName);
                if (File.Exists(gameFile)) {
                    if(AreSameFile(file, gameFile))
                    {
                        FileInfo fileInfo = new FileInfo(gameFile);
                        fileInfo.IsReadOnly = false;
                        File.Delete(gameFile); 
                    }
                }
            }
        }

        static void copyResourceFiles(List<string> filesToCopy)
        {
            string gamePath = Path.Combine(config.petzDir, "Resource");
            foreach (string file in filesToCopy)
            {
                string fileDir = Path.GetFileName(Path.GetDirectoryName(file));
                
                if(!Directory.Exists(Path.Combine(gamePath, fileDir)))
                {
                    Directory.CreateDirectory(Path.Combine(gamePath, fileDir)); 
                }

                string fileName = Path.GetFileName(file);
                string gameFile = Path.Combine(gamePath, fileDir, fileName);
                if (!(File.Exists(gameFile) && AreSameFile(file,gameFile)))
                {
                    File.Copy(file, gameFile, true);
                }
                
            }
        }

        static bool AreSameFile(string path1, string path2)
        {
            FileInfo file1 = new FileInfo(path1);
            FileInfo file2 = new FileInfo(path2);

            return file1.Name == file2.Name && file1.Length == file2.Length && file1.LastWriteTime == file2.LastWriteTime;
        }     

        static bool DeepAreSameFile(string path1, string path2)
        {
            return File.ReadAllBytes(path1).SequenceEqual(File.ReadAllBytes(path2));
        }


        static void loadLastResource(string type)
        {
            string gamePath = "";
            if (type.Equals("CarryingCase"))
                gamePath = Path.Combine(config.petzDir, "Art", "Sprites", "Case");
            else if (type.Equals("ACSprites"))
                gamePath = Path.Combine(config.petzDir, "Art", "Sprites", "AC");
            else if (type.Equals("Mice"))
                gamePath = Path.Combine(config.petzDir, "PtzFiles", "Mouse");
            else
                return;

            Directory.CreateDirectory(gamePath);

            string lastDir = "";
            foreach (string profile in config.include)
            {
                string storagePath = Path.Combine(fileSource, "ContentProfiles", profile, type);
                if (Directory.Exists(storagePath))
                {
                    lastDir = storagePath;
                }
            }
            if(!String.IsNullOrEmpty(lastDir))
            {
                foreach (string file in Directory.GetFiles(lastDir))
                {
                    string copyPath = Path.Combine(gamePath, Path.GetFileName(file));
                    File.Copy(file, copyPath, true);
                }
            }   
        }

        static int callWeatherApi(double latitude, double longitude)
        {
            string URL = "https://api.open-meteo.com/v1/forecast";
            string urlParameters = "?latitude=" + latitude + "&longitude=" + longitude + "&current_weather=true";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            //Console.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content;
                using (StreamReader sr = new StreamReader(data.ReadAsStream()))
                {
                    var s = sr.ReadLine();
                    return s.Split(new char[] {','}).Where(a => a.Contains("weathercode")).Select(a => a.Split(':').Last()).Select(a => int.Parse(a)).First();
                }
            }
            else
            {
                return -1;
            }

        }


        static bool comparePetz(string petPath1, string petPath2)
        {
            string guid1 = getGuid(petPath1);
            string guid2 = getGuid(petPath2);
            return guid1.Equals(guid2);
        }

        static string getGuid(string petFile)
        {
            byte[] petBytes = File.ReadAllBytes(petFile);
            byte[] pfmstr = Encoding.ASCII.GetBytes("PfMaGiCpEtZIII");
            int index = searchBytes(petBytes, pfmstr);

            int guidStart = index + pfmstr.Length + 5;
            byte[] guid = new byte[16];
            for (int i = 0; i < 16; i++)
            {
                byte b = petBytes[guidStart++];
                guid[i] = b;
            }
            return new Guid(guid).ToString();
        }

        static int searchBytes(byte[] haystack, byte[] needle)
        {
            var len = needle.Length;
            var limit = haystack.Length - len;
            for (var i = 0; i <= limit; i++)
            {
                var k = 0;
                for (; k < len; k++)
                {
                    if (needle[k] != haystack[i + k]) break;
                }
                if (k == len) return i;
            }
            return -1;
        }

        public static void deleteContentProfile(string profile)
        {
            string gamePath = Path.Combine(config.petzDir, "Adopted Petz");
            string excludeFolderPath = Path.Combine(fileSource, "ContentProfiles", profile, "Adopted Petz");

           
            if (Directory.Exists(excludeFolderPath))
            {
                foreach (string fileToRemove in Directory.GetFiles(excludeFolderPath))
                {
                    //if file is a pet do extra checks
                    if (Path.GetExtension(fileToRemove).ToLower().Equals("pet"))
                    {
                        string petInGame = Path.Combine(gamePath, Path.GetFileName(fileToRemove));
                        bool foundPet = false;
                        //if pet with same name exists check that one first
                        if (File.Exists(petInGame))
                        {
                            if (comparePetz(fileToRemove, petInGame))
                            {
                                //if we found it, then send to the bin
                                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(petInGame, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                            }
                        }
                        if (!foundPet)
                        {
                            // if we haven't found it check every pet
                            foreach (string possiblePet in Directory.GetFiles(gamePath))
                            {
                                if (Path.GetExtension(possiblePet).ToLower().Equals(".pet") && comparePetz(fileToRemove, possiblePet))
                                {
                                    Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(petInGame, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                                    break;
                                }
                            }
                        }
                    }
                    else //if it's not a pet just delete it
                    {
                        string fileInGame = Path.Combine(gamePath, Path.GetFileName(fileToRemove));
                        if (File.Exists(fileInGame))
                        {
                            FileInfo fileInfo = new FileInfo(fileInGame);
                            fileInfo.IsReadOnly = false;
                            File.Delete(fileInGame);
                        }
                    }
                }
            }

            List<string> list = new List<string>();
            list.Add(profile);
            removeResourceFiles(mergeResourecFileFolders(list, false));

            //don't delete petzres resouces, they will get overwritten anyways
        }
    }


}
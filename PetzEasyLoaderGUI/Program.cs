using Microsoft.VisualBasic;
using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Text;

namespace PetzEasyLoaderGUI
{
    internal static class Program
    {
        public static string fileSource = Path.Combine(System.AppContext.BaseDirectory, "Files");
        public static configProperties config = new configProperties();

        public static bool startPetz = true;
        static bool showSettings = false;

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
                Application.Run(new Form1(config));
            }

            if (startPetz)
            {
                startLoading();
            }
        }

        static void startLoading()
        {
            if (config.dayNightEnabled || config.seasonsEnabled)
            {
                loadSeasonalArea();
            }
            if (config.bulkLoadingEnabled)
            {
                removeFiles(mergeFileFolders(config.exclude, false));
                copyFiles(mergeFileFolders(config.include, true));
            }

            try { Process.Start(Path.Combine(config.petzDir, config.gameVersion)); }
            catch {
                MessageBox.Show("Cannot launch Petz. The selected Petz or Babyz .exe is invalid, or some other error occured" +
                                "\n\nTip: If your Petz exe is set to run as administrator, make sure you're also running PetzEZLoader as administrator", "Error");
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
                            config.strProp[kv[0]].SetProperty(kv[1]);
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
            content.Add("alwaysShowSettings=" + config.alwaysShowSettings);
            content.Add("[Seasonal Settings]");
            content.Add("seasonsEnabled=" + config.seasonsEnabled);
            content.Add("dayNightEnabled=" + config.dayNightEnabled);
            content.Add("winterStart=" + config.winterStart);
            content.Add("springStart=" + config.springStart);
            content.Add("summerStart=" + config.summerStart);
            content.Add("fallStart=" + config.fallStart);
            content.Add("sunriseTime=" + config.sunriseTime);
            content.Add("sunsetTime=" + config.sunsetTime);
            content.Add("[Bulk Content Settings]");
            content.Add("bulkLoadingEnabled=" + config.bulkLoadingEnabled);
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
            DirectoryInfo fs = Directory.CreateDirectory(fileSource);
            DirectoryInfo sa = fs.CreateSubdirectory("SeasonalArea");
            List<DirectoryInfo> seasons = new List<DirectoryInfo>();
            seasons.Add(sa.CreateSubdirectory("winter"));
            seasons.Add(sa.CreateSubdirectory("spring"));
            seasons.Add(sa.CreateSubdirectory("summer"));
            seasons.Add(sa.CreateSubdirectory("fall"));
            foreach (DirectoryInfo s in seasons)
            {
                s.CreateSubdirectory("day");
                s.CreateSubdirectory("night");
            }
            saveIniFile();
        }

        static void loadSeasonalArea()
        {
            string seasonalAreaPath = Path.Combine(fileSource, "SeasonalArea");
            if (Directory.Exists(seasonalAreaPath))
            {
                DateTime dateTime = DateTime.Now;
                string curSeason = "summer";
                if (config.seasonsEnabled)
                {
                    int winter = config.winterStart;
                    int spring = config.springStart;
                    int summer = config.summerStart;
                    int fall   = config.fallStart;

                    int curDate = int.Parse(dateTime.ToString("MMdd"));

                    if(isDateBetween(curDate, winter, spring)) curSeason = "winter";
                    else if(isDateBetween(curDate, spring, summer)) curSeason = "spring";
                    else if (isDateBetween(curDate, summer, fall)) curSeason = "summer";
                    else   curSeason = "fall";
                }
                string curTime = "day";
                if (config.dayNightEnabled)
                {
                    int sunrise = config.sunriseTime;
                    int sunset = config.sunsetTime;

                    int curHour = Int32.Parse(dateTime.ToString("HHmm"));
                    if (curHour < sunrise || curHour >= sunset )
                    {
                        curTime = "night";
                    }
                }               
                string seasonalPath = Path.Combine(seasonalAreaPath, curSeason, curTime);
                string petzPath = Path.Combine(config.petzDir, "Resource", "Area");
                if (Directory.Exists(seasonalPath))
                {
                    if(Directory.Exists(petzPath))
                    {
                        string[] sourceFiles = Directory.GetFiles(seasonalPath);
                        foreach (string file in sourceFiles)
                        {
                            string dest = Path.Combine(petzPath, Path.GetFileName(file));
                            File.Copy(file, dest, true);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Can't find Resource\\Area in petz directory, loading without seasons", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Can't find SeasonalArea\\" + curSeason + "\\" + curTime + " directory, loading without seasons", "Error");
                }
            }
            else
            {
                MessageBox.Show("Can't find SeasonalArea directory, loading without seasons", "Error");
            }
        }

        public static List<string> getFolders()
        {
            List<string> folders = new List<string>();
            DirectoryInfo df = new DirectoryInfo(fileSource);
            Array.ForEach(df.GetDirectories(), (dir) => { folders.Add(dir.Name); });
            folders.Remove("SeasonalArea");
            return folders;
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

        static List<string> mergeFileFolders(List<string> foldersToMerge, bool removeDupes)
        {
            List<string> mergedList = new List<string>();   
            foreach (string folderName in foldersToMerge)
            {
                foreach(string resFolder in Directory.GetDirectories(Path.Combine(fileSource, folderName)))
                {
                    foreach(string resFile in Directory.GetFiles(resFolder))
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
            return mergedList;
        }

        static void removeFiles(List<string> filesToRemove)

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

        static void copyFiles(List<string> filesToCopy)
        {
            string gamePath = Path.Combine(config.petzDir, "Resource");
            foreach (string file in filesToCopy)
            {
                string fileDir = Path.GetFileName(Path.GetDirectoryName(file));

                if (Directory.Exists(Path.Combine(gamePath, fileDir)))
                {
                    string fileName = Path.GetFileName(file);
                    string gameFile = Path.Combine(gamePath, fileDir, fileName);
                    if (!(File.Exists(gameFile) && AreSameFile(file,gameFile)))
                    {
                        File.Copy(file, gameFile, true);
                    }
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
    }
}
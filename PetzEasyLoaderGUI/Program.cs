using Microsoft.VisualBasic;
using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Text;
using File = System.IO.File;

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
            if (config.sceneSwappingEnabled)
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
                            if (kv[0].Equals("seasonsEnabled"))
                            {
                                config.strProp["sceneSwappingEnabled"].SetProperty(kv[1]);
                            }
                            else if (kv[0].Equals("dayNightEnabled")) 
                            {
                                string s = "false";
                                if (!bool.Parse(kv[1]))
                                {
                                    s = "true";     
                                }
                                config.strProp["forceTimeEnabled"].SetProperty(s);
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
            content.Add("alwaysShowSettings=" + config.alwaysShowSettings);
            content.Add("lastLoadDate=" + config.lastLoadDate);
            content.Add("lastWeather=" + config.lastWeather);

            content.Add("[Seasonal Settings]");
            content.Add("sceneSwappingEnabled=" + config.sceneSwappingEnabled);

            content.Add("forceSeasonEnabled=" + config.forceSeasonEnabled);
            content.Add("forceSeason=" + config.forceSeason);
            content.Add("winterStart=" + config.winterStart);
            content.Add("springStart=" + config.springStart);
            content.Add("summerStart=" + config.summerStart);
            content.Add("fallStart=" + config.fallStart);

            content.Add("forceTimeEnabled=" + config.forceTimeEnabled);
            content.Add("forceTime=" + config.forceTime);
            content.Add("enableSunriseset=" + config.enableSunriseset);
            content.Add("sunriseTime=" + config.sunriseTime);
            content.Add("sunsetTime=" + config.sunsetTime);

            content.Add("forceWeatherEnabled=" + config.forceWeatherEnabled);
            content.Add("forceWeather=" + config.forceWeather);
            content.Add("weatherRotation=" + config.weatherRotation);
            content.Add("longitude=" + config.longitude);
            content.Add("latitude=" + config.latitude);

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
            List<DirectoryInfo> times = new List<DirectoryInfo>();
            foreach (DirectoryInfo s in seasons)
            {
                times.Add(s.CreateSubdirectory("day"));
                times.Add(s.CreateSubdirectory("night"));
                times.Add(s.CreateSubdirectory("sunrise"));
                times.Add(s.CreateSubdirectory("sunset"));
            }
            foreach (DirectoryInfo t in times)
            {
                foreach(string weather in config.forceWeatherOptions)
                {
                    t.CreateSubdirectory(weather);
                }
            }
            saveIniFile();
        }

        static void loadSeasonalArea()
        {
            string seasonalAreaPath = Path.Combine(fileSource, "SeasonalArea");
            if (Directory.Exists(seasonalAreaPath))
            {
                DateTime dateTime = DateTime.Now;
                int curDate = int.Parse(dateTime.ToString("MMdd"));
                string curSeason = "summer";
                if(config.forceSeasonEnabled)
                {
                    curSeason = config.forceSeason;
                }
                else
                {
                    int winter = config.winterStart;
                    int spring = config.springStart;
                    int summer = config.summerStart;
                    int fall = config.fallStart;

                    if (isDateBetween(curDate, winter, spring)) curSeason = "winter";
                    else if (isDateBetween(curDate, spring, summer)) curSeason = "spring";
                    else if (isDateBetween(curDate, summer, fall)) curSeason = "summer";
                    else curSeason = "fall";
                }
                string curTime = "day";
                if (config.forceTimeEnabled)
                {
                        curTime = config.forceTime;
                }
                else
                {
                    int sunrise = config.sunriseTime;
                    int sunset = config.sunsetTime;

                    int curHour = Int32.Parse(dateTime.ToString("HHmm"));
                    if (curHour < sunrise || curHour >= sunset)
                    {
                        curTime = "night";
                    }
                    if (config.enableSunriseset)
                    {
                        if ((curHour/100) == (sunrise/100)) curTime = "sunrise";
                        else if ((curHour/100) == (sunrise/100)) curTime = "sunset";
                    }
                }
                string curWeather = "clear";
                var random = new Random();
                if (config.forceWeatherEnabled)
                {
                    curWeather = config.forceWeather;
                }
                else
                {
                    if (config.weatherRotation == "onload")
                    {
                        int id = random.Next(config.weatherRotationOptions.Count);
                        curWeather = config.forceWeatherOptions[id];
                    }
                    else if (config.weatherRotation == "perday")
                    {
                        if (curDate != config.lastLoadDate)
                        {
                            int id = random.Next(config.weatherRotationOptions.Count);
                            curWeather = config.forceWeatherOptions[id];

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
                }
                string seasonalPath = Path.Combine(seasonalAreaPath, curSeason, curTime, curWeather);

                // christmas easter egg
                if ((curDate == 1225 || curDate == 1224))
                {
                    string xmasTime = curTime;
                    if (curTime == "sunset" || curTime == "sunrise") xmasTime = "night";
                    string xmasDay = Path.Combine(seasonalAreaPath, "winter", xmasTime, "christmas");
                    if (Directory.Exists(xmasDay))
                    {
                        seasonalPath = xmasDay;
                    }
                }

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
                        System.IO.File.Delete(gameFile); 
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

        static int callWeatherApi(double latitude, double longitude)
        {
            string URL = "https://api.open-meteo.com/v1/forecast";
            string urlParameters = "?latitude=" + latitude + "&longitude=" + longitude + "&current_weather=true";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;
            Console.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content;
                using (StreamReader sr = new StreamReader(data.ReadAsStream()))
                {
                    var s = sr.ReadLine();
                    Console.WriteLine(s);
                    return s.Split(new char[] {','}).Where(a => a.Contains("weathercode")).Select(a => a.Split(':').Last()).Select(a => int.Parse(a)).First();
                }
            }
            else
            {
                return -1;
            }

        }

    }


}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PetzEasyLoaderGUI
{
    internal class AutoLoadingManager
    {
        configProperties config;
        string fileSource = Path.Combine(System.AppContext.BaseDirectory, "Filez");
        public AutoLoadingManager(configProperties cfg) {
            config = cfg;
        }

        public void loadAutoSwapping()
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
                if(true)
                {
                    loadSeasonalAC(curSeason, getTime(config.enableSunriseset), curWeather);
                }
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

        string getSeason()
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

        string getTime(bool sunEnabled)
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

        string getWeather()
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
            Program.saveIniFile();

            return curWeather;
        }


        void loadSeasonalArea(string calcSeason, string calcTime, string calcWeather)
        {
            string seasonalAreaPath = Path.Combine(fileSource, "SeasonalArea");
            if (Directory.Exists(seasonalAreaPath))
            {

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
                    if (Directory.Exists(petzPath))
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
                Program.generateFilesFolder();
            }
        }

        void loadSeasonalAC(string calcSeason, string calcTime, string calcWeather)
        {
            string seasonalACPath = Path.Combine(fileSource, "SeasonalACSprites");
            if (Directory.Exists(seasonalACPath))
            {
                string curSeason = config.defaultSeason;
                if (config.seasonalAreaEnabled) curSeason = calcSeason;
                string curTime = config.defaultTime;
                if (config.timeAreaEnabled) curTime = calcTime;
                string curWeather = config.defaultWeather;
                if (config.weatherAreaEnabled) curWeather = calcWeather;

                string seasonalPath = Path.Combine(seasonalACPath, curSeason, curTime, curWeather);
                string petzPath = Path.Combine(config.petzDir, "Art", "Sprites", "Adpt");
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
                    MessageBox.Show("Can't find SeasonalACSprites\\" + curSeason + "\\" + curTime + "\\" + curWeather + " directory, loading without swapping sprites", "Error");
                }
            }
            else
            {
                MessageBox.Show("Can't find SeasonalACSprites directory, loading without swapping scenes", "Error");
                Program.generateFilesFolder();
            }
        }

        void loadSeasonalMice(string calcSeason, string calcTime, string calcWeather)
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
                Program.generateFilesFolder();
            }
        }

        void loadSeasonalCases(string calcSeason, string calcTime, string calcWeather)
        {
            string seasonalCasePath = Path.Combine(fileSource, "SeasonalCase");
            if (Directory.Exists(seasonalCasePath))
            {
                string seasonalPath = seasonalCasePath;

                if (config.caseMode24Hour)
                {
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
                Program.generateFilesFolder();
            }
        }

     

        private int callWeatherApi(double latitude, double longitude)
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
                    return s.Split(new char[] { ',' }).Where(a => a.Contains("weathercode")).Select(a => a.Split(':').Last()).Select(a => int.Parse(a)).First();
                }
            }
            else
            {
                return -1;
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetzEasyLoaderGUI
{
    public class configProperties
    {
        public string petzDir;
        public string gameVersion;

        public bool alwaysShowSettings;

        public bool openContProfForum;
        public bool loadProfilesFirst;
        public bool disableBaseGameFallback;

        public int lastLoadDate;
        public string lastWeather;

        public bool autoSwappingEnabled; 

        public bool seasonalAreaEnabled;
        public bool seasonalACEnabled;
        public bool seasonalCaseEnabled;
        public bool seasonalMiceEnabled;
        public string defaultSeason;

        public int winterStart;
        public int springStart;
        public int summerStart;
        public int fallStart;

        public bool timeAreaEnabled;
        public bool timeACEnabled;
        public bool timeCaseEnabled;
        public bool timeMiceEnabled;
        public string defaultTime;

        public bool caseMode24Hour; 

        public int sunriseTime;
        public int sunsetTime;
        public bool enableSunriseset;

        public bool weatherAreaEnabled;
        public bool weatherACEnabled;
        public bool weatherCaseEnabled;
        public bool weatherMiceEnabled;
        public string defaultWeather;

        public string weatherRotation;
        public double longitude;
        public double latitude;

        public bool contentProfilesEnabled;

        public bool disableLoadingResources;
        public bool disableLoadingPetz;

        public bool disableLoadingCase;
        public bool disableLoadingMice;
        public bool disableLoadingAC;


        public List<string> include;
        public List<string> exclude;

        public Dictionary<string, Property> strProp = new Dictionary<string, Property>();

        public List<string> defaultSeasonOptions = new List<string>() { "winter", "spring", "summer", "fall" };
        public List<string> defaultWeatherOptions = new List<string>() { "clear", "cloudy", "overcast", "rain", "thunder", "snow" };
        public List<string> weatherRotationOptions = new List<string>() { "onload", "perday", "location" };
        public List<string> defaultTimeOptions = new List<string>() { "day", "night", "sunrise", "sunset" };



        public class Property
        {
            public Property(propertySetter propertySetter)
            {
                this.SetProperty = propertySetter;
            }

            public delegate void propertySetter(string value);
            //public delegate string propertyGetter();

            public propertySetter SetProperty;
            //public propertyGetter GetStrProperty;
        }
        
        public configProperties()
        {
            SetToDefaults();
            strProp.Add("petzDir", new Property((value) => directorySetter(out petzDir, value, "")));
            strProp.Add("gameVersion", new Property((value) => fileSetter(out gameVersion, value, ".exe", "")));

            strProp.Add("alwaysShowSettings", new Property((value) => boolSetter(out alwaysShowSettings, value, false)));

            strProp.Add("openContProfForum", new Property((value) => boolSetter(out openContProfForum, value, false)));
            strProp.Add("loadProfilesFirst", new Property((value) => boolSetter(out loadProfilesFirst, value, false)));
            strProp.Add("disableBaseGameFallback", new Property((value) => boolSetter(out disableBaseGameFallback, value, false)));

            strProp.Add("lastLoadDate", new Property((value) => dateSetter(out lastLoadDate, value, (int.Parse(DateTime.Now.ToString("MMdd")) - 1))));
            strProp.Add("lastWeather", new Property((value) => optionSetter(out lastWeather, value, defaultWeatherOptions, "clear")));

            strProp.Add("autoSwappingEnabled", new Property((value) => boolSetter(out autoSwappingEnabled, value, false)));

            strProp.Add("defaultSeason", new Property((value) => optionSetter(out defaultSeason, value, defaultSeasonOptions, "summer")));
            strProp.Add("seasonalAreaEnabled", new Property((value) => boolSetter(out seasonalAreaEnabled, value, false)));
            strProp.Add("seasonalACEnabled", new Property((value) => boolSetter(out seasonalACEnabled, value, false)));
            strProp.Add("seasonalCaseEnabled", new Property((value) => boolSetter(out seasonalCaseEnabled, value, false)));
            strProp.Add("seasonalMiceEnabled", new Property((value) => boolSetter(out seasonalMiceEnabled, value, false)));

            strProp.Add("winterStart", new Property((value) => dateSetter(out winterStart, value, 1201)));
            strProp.Add("springStart", new Property((value) => dateSetter(out springStart, value, 301)));
            strProp.Add("summerStart", new Property((value) => dateSetter(out summerStart, value, 601)));
            strProp.Add("fallStart", new Property((value) => dateSetter(out fallStart, value, 901)));
;
            strProp.Add("defaultTime", new Property((value) => optionSetter(out defaultTime, value, defaultTimeOptions, "day")));
            strProp.Add("timeAreaEnabled", new Property((value) => boolSetter(out timeAreaEnabled, value, false)));
            strProp.Add("timeACEnabled", new Property((value) => boolSetter(out timeACEnabled, value, false)));
            strProp.Add("timeCaseEnabled", new Property((value) => boolSetter(out timeCaseEnabled, value, false)));
            strProp.Add("timeMiceEnabled", new Property((value) => boolSetter(out timeMiceEnabled, value, false)));

            strProp.Add("caseMode24Hour", new Property((value) => boolSetter(out caseMode24Hour, value, false)));

            strProp.Add("enableSunriseset", new Property((value) => boolSetter(out enableSunriseset, value, false)));
            strProp.Add("sunriseTime", new Property((value) => timeSetter(out sunriseTime, value, 700)));
            strProp.Add("sunsetTime", new Property((value) => timeSetter(out sunsetTime, value, 1900)));

            strProp.Add("defaultWeather", new Property((value) => optionSetter(out defaultWeather, value, defaultWeatherOptions, "clear")));
            strProp.Add("weatherAreaEnabled", new Property((value) => boolSetter(out weatherAreaEnabled, value, false)));
            strProp.Add("weatherACEnabled", new Property((value) => boolSetter(out weatherACEnabled, value, false)));
            strProp.Add("weatherCaseEnabled", new Property((value) => boolSetter(out weatherCaseEnabled, value, false)));
            strProp.Add("weatherMiceEnabled", new Property((value) => boolSetter(out weatherMiceEnabled, value, false)));

            strProp.Add("weatherRotation", new Property((value) => optionSetter(out weatherRotation, value, weatherRotationOptions, "onload")));
            strProp.Add("longitude", new Property((value) => coordSetter(out longitude, value, -122.4194)));
            strProp.Add("latitude", new Property((value) => coordSetter(out latitude, value, 37.7749)));

            strProp.Add("contentProfilesEnabled", new Property((value) => boolSetter(out contentProfilesEnabled, value, false)));

            strProp.Add("disableLoadingResources", new Property((value) => boolSetter(out disableLoadingResources, value, false)));
            strProp.Add("disableLoadingPetz", new Property((value) => boolSetter(out disableLoadingPetz, value, true)));

            strProp.Add("disableLoadingCase", new Property((value) => boolSetter(out disableLoadingCase, value, true)));
            strProp.Add("disableLoadingMice", new Property((value) => boolSetter(out disableLoadingMice, value, true)));
            strProp.Add("disableLoadingAC", new Property((value) => boolSetter(out disableLoadingAC, value, true)));

            strProp.Add("include", new Property((value) => listSetter(include, value, new List<string>())));
            strProp.Add("exclude", new Property((value) => listSetter(exclude, value, new List<string>())));
        }

        public void SetToDefaults()
        {
            petzDir = "";
            gameVersion = "";
            alwaysShowSettings = false;
            lastLoadDate = (int.Parse(DateTime.Now.ToString("MMdd")) - 1);
            lastWeather = "clear";

            autoSwappingEnabled = false;

            openContProfForum = false;
            loadProfilesFirst = false;
            disableBaseGameFallback = false;

            seasonalAreaEnabled = false;
            seasonalACEnabled = false;
            seasonalCaseEnabled = false;
            seasonalMiceEnabled = false;
            defaultSeason = "summer";

            winterStart = 1201;
            springStart = 301;
            summerStart = 601;
            fallStart = 901;

            timeAreaEnabled = false;
            timeACEnabled = false;
            timeCaseEnabled = false;
            timeMiceEnabled = false;
            defaultTime = "day";

            caseMode24Hour = false;

            enableSunriseset = false;
            sunriseTime = 600;
            sunsetTime = 1900;

            weatherAreaEnabled = false;
            weatherACEnabled = false;
            weatherCaseEnabled = false;
            weatherMiceEnabled = false;
            defaultWeather = "clear"; 

            weatherRotation = "onload";
            //default is San Franciso, P.F. Magic's HQ
            longitude = 37.7749;
            latitude = -122.4194;

            contentProfilesEnabled = false;

            disableLoadingResources = false;
            disableLoadingPetz = true;
            disableLoadingCase = true;
            disableLoadingMice = true;
            disableLoadingAC = true;

            include = new List<string>();
            exclude = new List<string>();
    }

        void dateSetter (out int var, string value, int defaultValue)
        {
            if (int.TryParse(value, out int date))
            { 
                int month = date / 100;
                int day = date % 100;
                new DateTime(DateTime.Now.Year, month, day);
                var = date;
            }
            else
            {
                var = defaultValue;
                throw new Exception();
            }
        }

        void timeSetter (out int var, string value, int defaultValue)
        {
            if (int.TryParse(value, out int time))
            {
                int hour = time / 100;
                int minute = time % 100;
                new DateTime(DateTime.Now.Year, 1, 1, hour, minute, 0);
                var = time;
            }
            else
            {
                var = defaultValue;
                throw new Exception();
            }
        }

        void boolSetter (out bool var, string value, bool defaultValue)
        {
            if (bool.TryParse(value, out bool result))
            {
                var = result;
            }
            else
            {
                var = defaultValue;
                throw new Exception();
            }
        }

        void directorySetter(out string var, string value, string defaultValue)
        {
            if (Directory.Exists(value) || value == "")
            {
                var = value;
            }
            else
            {
                var = defaultValue;
                throw new Exception();
            }
        }

        void fileSetter(out string var, string value, string extension, string defaultValue)
        {
            if (Path.GetExtension(value) == extension || value == "")
            {
                var = value;
            }
            else
            {
                var = defaultValue;
                throw new Exception();
            }
        }

        void optionSetter(out string var, string value, List<string> options, string defaultValue)
        {
            if (options.Contains(value))
            {
                var = value;
            }
            else
            {
                var = defaultValue;
                throw new Exception();
            }
        }

        void listSetter(List<string> var, string value, List<string> defaultValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                var = defaultValue;
            }
            else
            {
                List<string> folders = Program.getContentProfileFolders();
                List<string> missingfolders = new List<string>();
                string[] loadedFolders = value.Split(",");
                foreach (string l in loadedFolders)
                {
                    if (folders.Contains(l)) var.Add(l);
                    else missingfolders.Add(l);
                }
                if (missingfolders.Count > 0)
                {
                    MessageBox.Show("Could not find the following folders: \n\n\t" + string.Join("\n\t", missingfolders) +
                    "\n\nAny missing folders have been skipped", "Error");
                }
            }
        }

        void coordSetter(out double var, string value, double defaultValue)
        {
            if (double.TryParse(value, out double num))
            {
                var = Math.Round(num, 4);
            }
            else
            {
                var = defaultValue;
                throw new Exception();
            }
        }

        public string listGetter(List<string> var)
        {
            return string.Join(",", var);
        } 

        public void refreshFolders()
        {
            List<string> lists = Program.getContentProfileFolders();

            include.RemoveAll((s) => !(lists.Contains(s) || exclude.Contains(s)));
            exclude.RemoveAll((s) => !(lists.Contains(s) || include.Contains(s)));
            lists.RemoveAll((s) => include.Contains(s) || exclude.Contains(s));

            foreach (string l in lists)
            {
                include.Add(l);
            }
        }

    }
}

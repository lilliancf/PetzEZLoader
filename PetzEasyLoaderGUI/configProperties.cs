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
        public int lastLoadDate;
        public string lastWeather;

        public bool sceneSwappingEnabled;

        public bool forceSeasonEnabled;
        public string forceSeason;

        public int winterStart;
        public int springStart;
        public int summerStart;
        public int fallStart;

        public bool forceTimeEnabled;
        public string forceTime;
        public bool enableSunriseset;

        public int sunriseTime;
        public int sunsetTime;

        public bool forceWeatherEnabled;
        public string forceWeather;
        public string weatherRotation;
        public double longitude;
        public double latitude;

        public bool bulkLoadingEnabled;

        public List<string> include;
        public List<string> exclude;

        public Dictionary<string, Property> strProp = new Dictionary<string, Property>();

        public List<string> forceSeasonOptions = new List<string>() { "winter", "spring", "summer", "fall" };
        public List<string> forceWeatherOptions = new List<string>() { "clear", "cloudy", "overcast", "rain", "thunder", "snow" };
        public List<string> weatherRotationOptions = new List<string>() { "onload", "perday", "location" };
        public List<string> forceTimeOptions = new List<string>() { "day", "night", "sunrise", "sunset" };

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
            strProp.Add("lastLoadDate", new Property((value) => dateSetter(out lastLoadDate, value, (int.Parse(DateTime.Now.ToString("MMdd")) - 1))));
            strProp.Add("lastWeather", new Property((value) => optionSetter(out lastWeather, value, forceWeatherOptions, "clear")));

            strProp.Add("sceneSwappingEnabled", new Property((value) => boolSetter(out sceneSwappingEnabled, value, false)));

            strProp.Add("forceSeasonEnabled", new Property((value) => boolSetter(out forceSeasonEnabled, value, false)));
            strProp.Add("forceSeason", new Property((value) => optionSetter(out forceSeason, value, forceSeasonOptions, "summer")));
            strProp.Add("winterStart", new Property((value) => dateSetter(out winterStart, value, 1201)));
            strProp.Add("springStart", new Property((value) => dateSetter(out springStart, value, 301)));
            strProp.Add("summerStart", new Property((value) => dateSetter(out summerStart, value, 601)));
            strProp.Add("fallStart", new Property((value) => dateSetter(out fallStart, value, 901)));

            strProp.Add("forceTimeEnabled", new Property((value) => boolSetter(out forceTimeEnabled, value, false)));
            strProp.Add("forceTime", new Property((value) => optionSetter(out forceTime, value, forceTimeOptions, "day")));
            strProp.Add("enableSunriseset", new Property((value) => boolSetter(out enableSunriseset, value, false)));
            strProp.Add("sunriseTime", new Property((value) => timeSetter(out sunriseTime, value, 700)));
            strProp.Add("sunsetTime", new Property((value) => timeSetter(out sunsetTime, value, 1900)));

            strProp.Add("forceWeatherEnabled", new Property((value) => boolSetter(out forceWeatherEnabled, value, false)));
            strProp.Add("forceWeather", new Property((value) => optionSetter(out forceWeather, value, forceWeatherOptions, "clear")));
            strProp.Add("weatherRotation", new Property((value) => optionSetter(out weatherRotation, value, weatherRotationOptions, "onload")));
            strProp.Add("longitude", new Property((value) => coordSetter(out longitude, value, -122.4194)));
            strProp.Add("latitude", new Property((value) => coordSetter(out latitude, value, 37.7749)));

            strProp.Add("bulkLoadingEnabled", new Property((value) => boolSetter(out bulkLoadingEnabled, value, false)));

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

            sceneSwappingEnabled = false;

            forceSeasonEnabled = false;
            forceSeason = "summer";
            winterStart = 1201;
            springStart = 301;
            summerStart = 601;
            fallStart = 901;

            forceTimeEnabled = false;
            forceTime = "day";
            enableSunriseset = false;
            sunriseTime = 600;
            sunsetTime = 1900;

            forceWeatherEnabled = false;
            forceWeather = "clear"; 
            weatherRotation = "onload";
            //default is San Franciso, P.F. Magic's HQ
            longitude = 37.7749;
            latitude = -122.4194;

            bulkLoadingEnabled = false;
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
                List<string> folders = Program.getFolders();
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
            List<string> lists = Program.getFolders();

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

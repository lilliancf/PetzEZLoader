using Microsoft.VisualBasic;
using System.Text;
using static System.Windows.Forms.DataFormats;

namespace PetzEasyLoaderGUI
{
    public partial class Form1 : Form
    {
        configProperties config; 
        bool skipSave = false;
        public Form1(configProperties p)
        {
            config = p;
            InitializeComponent();
            cbAlwaySettings.Checked = config.alwaysShowSettings;
            loadPetzDir();
            loadSeasonalInfo();
            loadBulkContent();
            Program.saveIniFile();
            skipSave = true;
        }

        private void loadSeasonalInfo()
        {
            List<string> errors = new List<string>();

            cbEnableSceneSwapping.Checked = config.sceneSwappingEnabled;

            cbForceSeason.Checked= config.forceSeasonEnabled;
            ddForceSeason.SelectedIndex = ddForceSeason.FindString(config.forceSeason);
            ddForceSeason.Enabled = cbForceSeason.Checked;

            cbForceTime.Checked = config.forceTimeEnabled;
            ddForceTime.SelectedIndex = ddForceTime.FindString(config.forceTime);
            ddForceTime.Enabled = cbForceTime.Checked;

            cbEnableSunriseset.Checked = config.enableSunriseset;

            int year = DateTime.Now.Year;
            dtpWinterStart.Value = new DateTime(year, config.winterStart / 100, config.winterStart % 100);
            dtpSpringStart.Value = new DateTime(year, config.springStart / 100, config.springStart % 100);
            dtpSummerStart.Value = new DateTime(year, config.summerStart / 100, config.summerStart % 100);
            dtpFallStart.Value = new DateTime(year, config.fallStart / 100, config.fallStart % 100);


            dtpSunrise.Value = new DateTime(year, DateTime.Now.Month, DateTime.Now.Day,
                                                config.sunriseTime/100, config.sunriseTime%100, 0);
            dtpSunset.Value = new DateTime(year, DateTime.Now.Month, DateTime.Now.Day,
                                               config.sunsetTime/100, config.sunsetTime%100, 0);

            cbForceWeather.Checked = config.forceWeatherEnabled;
            ddForceWeather.SelectedIndex = ddForceWeather.FindString(config.forceWeather);
            ddForceWeather.Enabled = cbForceWeather.Checked;

            tbLatitude.Text = config.latitude.ToString();
            tbLongitude.Text = config.longitude.ToString();

            string str = "Random on load";
            if (config.weatherRotation == "perday")
            {
                str = "Random per day";
            }
            else if (config.weatherRotation == "location")
            {
                str = "Location based";
            }
            ddWeatherRotation.SelectedIndex = ddWeatherRotation.FindString(str);

            if (cbEnableSceneSwapping.Checked)
            {
                cbForceSeason.Enabled = true;
                if (cbForceSeason.Checked) ddForceSeason.Enabled = true;
                else
                {
                    dtpWinterStart.Enabled = true;
                    dtpSpringStart.Enabled = true;
                    dtpSummerStart.Enabled = true;
                    dtpFallStart.Enabled = true;
                }


                cbForceTime.Enabled = true;
                if (cbForceTime.Checked) ddForceTime.Enabled = true;
                else
                {
                    cbEnableSunriseset.Enabled = true;
                    dtpSunrise.Enabled = true;
                    dtpSunset.Enabled = true;
                }

                cbForceWeather.Enabled = true;
                if (cbForceWeather.Checked) ddForceWeather.Enabled = true;
                else
                {
                    ddWeatherRotation.Enabled = true;
                    if (ddWeatherRotation.SelectedItem != null &&
                        (ddWeatherRotation.SelectedItem.ToString() == "Location based"))
                    {
                        tbLongitude.Enabled = true;
                        tbLatitude.Enabled = true;
                    }
                }

            }
            else
            {
                cbForceSeason.Enabled = false;
                ddForceSeason.Enabled = false;
                dtpWinterStart.Enabled = false;
                dtpSpringStart.Enabled = false;
                dtpSummerStart.Enabled = false;
                dtpFallStart.Enabled = false;

                cbForceTime.Enabled = false;
                ddForceTime.Enabled = false;
                cbEnableSunriseset.Enabled = false;
                dtpSunrise.Enabled = false;
                dtpSunset.Enabled = false;

                cbForceWeather.Enabled = false;
                ddForceWeather.Enabled = false;
                ddWeatherRotation.Enabled = false;
                tbLongitude.Enabled = false;
                tbLatitude.Enabled = false;
            }
        }

        private void loadPetzDir()
        {
            if (string.IsNullOrEmpty(config.petzDir) || string.IsNullOrEmpty(config.gameVersion))
            {
                labelPetzExe.Text = "Please select Petz or Babyz .exe";
            }
            else
            {
                labelPetzExe.Text = Path.Combine(config.petzDir, config.gameVersion);
                if (labelPetzExe.Size.Width > 300)
                {
                    toolTip1.SetToolTip(labelPetzExe, Path.Combine(config.petzDir, config.gameVersion));
                }
            }

        }

        private void loadBulkContent()
        {

            cbEnableBulk.Checked = config.bulkLoadingEnabled;

            lbIncluded.DataSource = new List<string>(config.include);
            lbNotIncluded.DataSource = new List<string>(config.exclude);

            bnIncUp.Enabled = cbEnableBulk.Checked;
            bnIncDown.Enabled = cbEnableBulk.Checked;
            bnRemoveIncluded.Enabled = cbEnableBulk.Checked;
            bnAddIncluded.Enabled = cbEnableBulk.Checked;
            bnRefreshFolders.Enabled = cbEnableBulk.Checked;
            lbIncluded.Enabled = cbEnableBulk.Checked;
            lbNotIncluded.Enabled = cbEnableBulk.Checked;
        }

        // PETZ SOURCE CONTROLS 
        private void bnEditPetzSource_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult result = ofd.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))
            {
                string file = Path.GetFileName(ofd.FileName);
                string path = Path.GetDirectoryName(ofd.FileName);

                switch (file)
                {
                    case "Petz 3.exe":
                    case "Petz 4.exe":
                    case "Petz 5.exe":
                    case "Babyz.exe":
                        config.petzDir = path;
                        config.gameVersion = file;
                        skipSave = false;
                        loadPetzDir();
                        break;
                    default:
                        MessageBox.Show("Please select a valid Petz or Babyz .exe file");
                        break;
                }
            }
        }

        private void cbAlwaySettings_CheckedChanged(object sender, EventArgs e)
        {
            config.alwaysShowSettings = cbAlwaySettings.Checked;
            skipSave = false;
        }

        // AREA SWAPPING CONTROLS
        private void cbEnableSceneSwapping_CheckedChanged(object sender, EventArgs e)
        {
            config.sceneSwappingEnabled = cbEnableSceneSwapping.Checked;
            skipSave = false;

            if (cbEnableSceneSwapping.Checked)
            {
                cbForceSeason.Enabled = true;
                if (cbForceSeason.Checked) ddForceSeason.Enabled = true;
                else
                {
                    dtpWinterStart.Enabled = true;
                    dtpSpringStart.Enabled = true;
                    dtpSummerStart.Enabled = true;
                    dtpFallStart.Enabled = true;
                }


                cbForceTime.Enabled = true;
                if (cbForceTime.Checked) ddForceTime.Enabled = true;
                else
                {
                    cbEnableSunriseset.Enabled = true;
                    dtpSunrise.Enabled = true;
                    dtpSunset.Enabled = true;
                }

                cbForceWeather.Enabled = true;
                if (cbForceWeather.Checked) ddForceWeather.Enabled = true;
                else
                {
                    ddWeatherRotation.Enabled = true;
                    if (ddWeatherRotation.SelectedItem != null &&
                        (ddWeatherRotation.SelectedItem.ToString() == "Location based"))
                    {
                        tbLongitude.Enabled = true;
                        tbLatitude.Enabled = true;
                    }
                }
               
            }
            else
            {
                cbForceSeason.Enabled = false;
                ddForceSeason.Enabled = false;
                dtpWinterStart.Enabled = false;
                dtpSpringStart.Enabled = false;
                dtpSummerStart.Enabled = false;
                dtpFallStart.Enabled = false;

                cbForceTime.Enabled = false;
                ddForceTime.Enabled = false;
                cbEnableSunriseset.Enabled = false;
                dtpSunrise.Enabled = false;
                dtpSunset.Enabled = false;

                cbForceWeather.Enabled = false;
                ddForceWeather.Enabled = false;
                ddWeatherRotation.Enabled = false;
                tbLongitude.Enabled = false;
                tbLatitude.Enabled = false;
            }
             
            
        }

        // SEASONAL CONTROLS
        private void cbForceSeason_CheckedChanged(object sender, EventArgs e)
        {
            config.forceSeasonEnabled = cbForceSeason.Checked;

            ddForceSeason.Enabled = cbForceSeason.Checked;

            dtpWinterStart.Enabled = !cbForceSeason.Checked;
            dtpSpringStart.Enabled = !cbForceSeason.Checked;
            dtpSummerStart.Enabled = !cbForceSeason.Checked;
            dtpFallStart.Enabled   = !cbForceSeason.Checked;

            skipSave = false;
        }
        private void ddForceSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddForceSeason.SelectedItem != null)
            {
                config.forceSeason = ddForceSeason.SelectedItem.ToString().ToLower();
                skipSave = false;
            }
        }

        private void dtpWinterStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime newValue = dtpWinterStart.Value;
            config.winterStart = int.Parse(newValue.ToString("MMdd"));
            skipSave = false;
        }
        private void dtpSpringStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime newValue = dtpSpringStart.Value;
            config.springStart = int.Parse(newValue.ToString("MMdd"));
            skipSave = false;
        }
        private void dtpSummerStart_ValueChanged(object sender, EventArgs e)
        {
           DateTime newValue = dtpSummerStart.Value;
            config.summerStart = int.Parse(newValue.ToString("MMdd"));
            skipSave = false;
        }
        private void dtpFallStart_ValueChanged(object sender, EventArgs e)
        {
            DateTime newValue = dtpFallStart.Value;
            config.fallStart = int.Parse(newValue.ToString("MMdd"));
            skipSave = false;
        }

        // TIME CONTROLS
        private void cbForceTime_CheckedChanged(object sender, EventArgs e)
        {
            config.forceTimeEnabled = cbForceTime.Checked;

            ddForceTime.Enabled = cbForceTime.Checked;
            cbEnableSunriseset.Enabled = !cbForceTime.Checked;
            dtpSunrise.Enabled= !cbForceTime.Checked;
            dtpSunset.Enabled= !cbForceTime.Checked;

            skipSave = false;
        }
        private void ddForceTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddForceTime.SelectedItem != null)
            {
                config.forceTime = ddForceTime.SelectedItem.ToString().ToLower();
                skipSave = false;
            }
        }
        private void cbEnableSunRiseSet_CheckedChanged(object sender, EventArgs e)
        {
            config.enableSunriseset = cbEnableSunriseset.Checked;
            skipSave = false;
        }

        private void dtpSunrise_ValueChanged(object sender, EventArgs e)
        {
            DateTime newValue = dtpSunrise.Value;
            config.sunriseTime = int.Parse(newValue.ToString("HHmm"));
            skipSave = false;
        }
        private void dtpSunset_ValueChanged(object sender, EventArgs e)
        {
            DateTime newValue = dtpSunset.Value;
            config.sunsetTime = int.Parse(newValue.ToString("HHmm"));
            skipSave = false;
        }

        // WEATHER CONTROLS
        private void cbForceWeather_CheckedChanged(object sender, EventArgs e)
        {
            config.forceWeatherEnabled = cbForceWeather.Checked;

            ddForceWeather.Enabled = cbForceWeather.Checked;
            ddWeatherRotation.Enabled = !cbForceWeather.Checked;
            if (!cbForceWeather.Checked &&
                ddWeatherRotation.SelectedItem != null &&
                ddWeatherRotation.SelectedItem.ToString().Equals("Location based"))
            {
                tbLongitude.Enabled = true;
                tbLatitude.Enabled = true;
            }
            else
            {
                tbLongitude.Enabled = false;
                tbLatitude.Enabled = false;
            }

            skipSave = false;
        }
        private void ddForceWeather_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddForceWeather.SelectedItem != null)
            {
                config.forceWeather = ddForceWeather.SelectedItem.ToString().ToLower();
                skipSave = false;
            }
        }

        private void ddWeatherRotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddWeatherRotation.SelectedItem != null)
            {
                tbLatitude.Enabled = false;
                tbLongitude.Enabled = false;

                if (ddWeatherRotation.SelectedItem.ToString() == "Random on load")
                {
                    config.weatherRotation = "onload";
                }
                else if (ddWeatherRotation.SelectedItem.ToString() == "Random per day")
                {
                    config.weatherRotation = "perday";
                }
                else
                {
                    config.weatherRotation = "location";
                    tbLatitude.Enabled = true;
                    tbLongitude.Enabled = true;
                }
                skipSave = false;
            }
        }

        private void tbLongitude_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(tbLongitude.Text, out double num))
            {
                config.longitude = Math.Round(num, 4);
                skipSave = false;
            }
        }
        private void tbLatitude_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(tbLatitude.Text, out double num))
            {
                config.latitude = Math.Round(num, 4);
                skipSave = false;
            }
        }


        // BULK LOADING CONTROLS 
        private void cbEnableBulk_CheckedChanged(object sender, EventArgs e)
        {
            config.bulkLoadingEnabled = cbEnableBulk.Checked;

            bnIncUp.Enabled = cbEnableBulk.Checked;
            bnIncDown.Enabled = cbEnableBulk.Checked;
            bnRemoveIncluded.Enabled = cbEnableBulk.Checked;
            bnAddIncluded.Enabled = cbEnableBulk.Checked;
            bnRefreshFolders.Enabled= cbEnableBulk.Checked;
            lbIncluded.Enabled= cbEnableBulk.Checked;
            lbNotIncluded.Enabled= cbEnableBulk.Checked;

            skipSave = false;
        }
        private void bnIncUp_Click(object sender, EventArgs e)
        {
            int index = lbIncluded.SelectedIndex;
            if (index > 0)
            {
                string temp = config.include[index - 1];
                config.include[index - 1] = config.include[index];
                config.include[index] = temp;
                lbIncluded.DataSource = new List<string>(config.include);
                lbIncluded.SelectedIndex = index - 1;
                skipSave = false;
            }
        }

        private void bnIncDown_Click(object sender, EventArgs e)
        {
            int index = lbIncluded.SelectedIndex;
            if (index < config.include.Count - 1)
            {
                string temp = config.include[index + 1];
                config.include[index + 1] = config.include[index];
                config.include[index] = temp;
                lbIncluded.DataSource = new List<string>(config.include);
                lbIncluded.SelectedIndex = index + 1;
                skipSave = false;
            }
        }

        private void bnRemoveIncluded_Click(object sender, EventArgs e)
        {
            if (lbIncluded.SelectedItem != null)
            {
                string selectedItem = lbIncluded.SelectedItem.ToString();

                config.include.Remove(selectedItem);
                config.exclude.Add(selectedItem);

                lbIncluded.DataSource = new List<string>(config.include);
                lbNotIncluded.DataSource = new List<string>(config.exclude);
                lbNotIncluded.SelectedIndex = config.exclude.Count - 1;
                lbIncluded.SelectedIndex = config.include.Count - 1;
                skipSave = false;
            }
        }

        private void bnAddIncluded_Click(object sender, EventArgs e)
        {
            if (lbNotIncluded.SelectedItem != null)
            {
                string selectedItem = lbNotIncluded.SelectedItem.ToString();

                config.exclude.Remove(selectedItem);
                config.include.Add(selectedItem);

                lbIncluded.DataSource = new List<string>(config.include);
                lbNotIncluded.DataSource = new List<string>(config.exclude);
                lbNotIncluded.SelectedIndex = config.exclude.Count - 1;
                lbIncluded.SelectedIndex = config.include.Count-1; 
                skipSave = false;
            }
        }

        private void bnRefreshFolders_Click(object sender, EventArgs e)
        {
            config.refreshFolders();

            lbIncluded.DataSource = new List<string>(config.include);
            lbNotIncluded.DataSource = new List<string>(config.exclude);
            skipSave = false;
        }






        private void bnSave_Click(object sender, EventArgs e)
        {
            saveSettings();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("explorer.exe", "https://oodlecat.meowandsparkle.party/");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!skipSave)
            {
                DialogResult result = MessageBox.Show("Would you like to save your settings?", "Save Message", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    saveSettings();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void bnStartPetz_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(config.petzDir) || string.IsNullOrEmpty(config.gameVersion))
            {
                MessageBox.Show("Cannot launch Petz. Please select a valid Petz or Babyz .exe", "Error");
            }
            else
            {
                Program.startPetz = true;
                saveSettings();
                this.Close();
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("explorer.exe", " https://open-meteo.com/");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", @"readme.html");
        }

        private void saveSettings()
        {
            if (!double.TryParse(tbLatitude.Text, out double num) || !double.TryParse(tbLongitude.Text, out double num1))
            {
                MessageBox.Show("Latitude and/or Longitude is not a valid decimal number, it will not be saved", "Error");
            }
            Program.saveIniFile();
            skipSave = true;
        }
    }
}
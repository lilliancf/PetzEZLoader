using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;
using PetzEasyLoaderGUI.Properties;
using System;
using System.Collections.Immutable;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.DataFormats;

namespace PetzEasyLoaderGUI
{
    public partial class FormSettings : Form
    {
        configProperties config;
        bool skipSave = false;

        public FormSettings(configProperties p)
        {
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            config = p;
            InitializeComponent();

            reloadEverything();

            Program.saveIniFile();
            skipSave = true;
        }

        private void reloadEverything()
        {
            loadGeneralSettings();
            loadAutoSwappingSettings();
            loadContentProfileSettings();

            if (config.gameVersion.Equals("Babyz.exe")) changeUI("Babyz");
            else changeUI("Petz");
        }


        private void loadGeneralSettings()
        {
            loadPetzDir();
            cbAlwaySettings.Checked = config.alwaysShowSettings;
            cbOpenContProf.Checked = config.openContProfForum;

            //advanced settings
            cbLoadOrderAutoSwapFirst.Checked = !config.loadProfilesFirst;
            cbLoadOrderProfilesFirst.Checked = config.loadProfilesFirst;

            cbDisableFallback.Checked = config.disableBaseGameFallback;
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

        private void loadAutoSwappingSettings()
        {
            // setup autoswapping 
            cbEnableAutoSwapping.Checked = config.autoSwappingEnabled;
            toggleAutoSwappingControls(config.autoSwappingEnabled);

            //load seasonal settings
            ddDefaultSeason.SelectedIndex = ddDefaultSeason.FindString(config.defaultSeason);

            cbEnableSeasonalArea.Checked = config.seasonalAreaEnabled;
            cbEnableSeasonalAC.Checked = config.seasonalACEnabled;
            if (!config.seasonalAreaEnabled)
            {
                cbEnableSeasonalAC.Checked = false;
                cbEnableSeasonalAC.Enabled = false;
                config.seasonalACEnabled = false;
            }

            cbEnableSeasonalCase.Checked = config.seasonalCaseEnabled;
            cbEnableSeasonalMice.Checked = config.seasonalMiceEnabled;

            int year = DateTime.Now.Year;
            dtpWinterStart.Value = new DateTime(year, config.winterStart / 100, config.winterStart % 100);
            dtpSpringStart.Value = new DateTime(year, config.springStart / 100, config.springStart % 100);
            dtpSummerStart.Value = new DateTime(year, config.summerStart / 100, config.summerStart % 100);
            dtpFallStart.Value = new DateTime(year, config.fallStart / 100, config.fallStart % 100);

            // load time settings
            ddDefaultTime.SelectedIndex = ddDefaultTime.FindString(config.defaultTime);

            cbEnableTimeArea.Checked = config.timeAreaEnabled;
            cbEnableTimeAC.Checked = config.timeACEnabled;
            if (!config.timeAreaEnabled)
            {
                cbEnableTimeAC.Checked = false;
                cbEnableTimeAC.Enabled = false;
                config.timeACEnabled = false;
            }

            cbEnableTimeCase.Checked = config.timeCaseEnabled;
            cbEnableTimeMice.Checked = config.timeMiceEnabled;

            cb24HourCaseMode.Checked = config.caseMode24Hour;
            cb24HourCaseMode.Enabled = cbEnableTimeCase.Checked;

            cbEnableSeasonalCase.Enabled = !config.caseMode24Hour;
            cbEnableWeatherCase.Enabled = !config.caseMode24Hour;


            cbEnableSunriseset.Checked = config.enableSunriseset;
            dtpSunrise.Value = new DateTime(year, DateTime.Now.Month, DateTime.Now.Day,
                                                config.sunriseTime / 100, config.sunriseTime % 100, 0);
            dtpSunset.Value = new DateTime(year, DateTime.Now.Month, DateTime.Now.Day,
                                               config.sunsetTime / 100, config.sunsetTime % 100, 0);

            // load weather settings 
            ddDefaultWeather.SelectedIndex = ddDefaultWeather.FindString(config.defaultWeather);

            cbEnableWeatherArea.Checked = config.weatherAreaEnabled;
            cbEnableWeatherAC.Checked = config.weatherACEnabled;
            if (!config.weatherAreaEnabled)
            {
                cbEnableWeatherAC.Checked = false;
                cbEnableWeatherAC.Enabled = false;
                config.weatherACEnabled = false;
            }

            cbEnableWeatherCase.Checked = config.weatherCaseEnabled;
            cbEnableWeatherMice.Checked = config.weatherMiceEnabled;

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

            if (config.gameVersion.Equals("Babyz.exe"))
            {
                cbEnableSeasonalAC.Checked = false;
                cbEnableSeasonalAC.Enabled = false;
                config.seasonalACEnabled = false;

                cbEnableSeasonalCase.Checked = false;
                cbEnableSeasonalCase.Enabled = false;
                config.seasonalCaseEnabled = false;

                cbEnableSeasonalMice.Checked = false;
                cbEnableSeasonalMice.Enabled = false;
                config.seasonalMiceEnabled = false;


                cbEnableTimeAC.Checked = false;
                cbEnableTimeAC.Enabled = false;
                config.timeACEnabled = false;

                cbEnableTimeCase.Checked = false;
                cbEnableTimeCase.Enabled = false;
                config.timeCaseEnabled = false;

                cbEnableTimeMice.Checked = false;
                cbEnableTimeMice.Enabled = false;
                config.timeMiceEnabled = false;

                cb24HourCaseMode.Checked = false;
                cb24HourCaseMode.Enabled = false;
                config.caseMode24Hour = false;


                cbEnableWeatherAC.Checked = false;
                cbEnableWeatherAC.Enabled = false;
                config.weatherACEnabled = false;

                cbEnableWeatherCase.Checked = false;
                cbEnableWeatherCase.Enabled = false;
                config.weatherCaseEnabled = false;

                cbEnableWeatherMice.Checked = false;
                cbEnableWeatherMice.Enabled = false;
                config.weatherMiceEnabled = false;
            }
            else if (config.gameVersion.Equals("Petz 5.exe"))
            {
                cbEnableSeasonalAC.Checked = false;
                cbEnableSeasonalAC.Enabled = false;
                config.seasonalACEnabled = false;

                cbEnableSeasonalCase.Checked = false;
                cbEnableSeasonalCase.Enabled = false;
                config.seasonalCaseEnabled = false;


                cbEnableTimeAC.Checked = false;
                cbEnableTimeAC.Enabled = false;
                config.timeACEnabled = false;

                cbEnableTimeCase.Checked = false;
                cbEnableTimeCase.Enabled = false;
                config.timeCaseEnabled = false;

                cb24HourCaseMode.Checked = false;
                cb24HourCaseMode.Enabled = false;
                config.caseMode24Hour = false;


                cbEnableWeatherAC.Checked = false;
                cbEnableWeatherAC.Enabled = false;
                config.weatherACEnabled = false;

                cbEnableWeatherCase.Checked = false;
                cbEnableWeatherCase.Enabled = false;
                config.weatherCaseEnabled = false;
            }
        }

        private void loadContentProfileSettings()
        {
            cbEnableContProf.Checked = config.contentProfilesEnabled;
            toggleContentProfileControls(config.contentProfilesEnabled);

            lbIncluded.DataSource = new List<string>(config.include);
            lbNotIncluded.DataSource = new List<string>(config.exclude);

            cbDisableLoadingResources.Checked = config.disableLoadingResources;
            cbDisableLoadingPetz.Checked = config.disableLoadingPetz;

            cbDisableLoadingCase.Checked = config.disableLoadingCase;
            cbDisableLoadingMice.Checked = config.disableLoadingMice;
            cbDisableLoadingAC.Checked = config.disableLoadingAC;

            List<string> profiles = new List<string>(config.include);
            profiles.AddRange(config.exclude);
            ddDeleteProfile.DataSource = profiles;

            if (config.gameVersion.Equals("Babyz.exe"))
            {
                cbDisableLoadingCase.Enabled = false;
                cbDisableLoadingCase.Checked = true;
                config.disableLoadingCase = true;

                cbDisableLoadingMice.Enabled = false;
                cbDisableLoadingMice.Checked = true;
                config.disableLoadingMice = true;

                cbDisableLoadingAC.Enabled = false;
                cbDisableLoadingAC.Checked = true;
                config.disableLoadingAC = true;

                cbNpACSprites.Enabled = false;
                cbNpCase.Enabled = false;
                cbNpMice.Enabled = false;

                cbNpCatz.Enabled = false;
                cbNpDogz.Enabled = false;
                cbNpToyz.Enabled = false;
                cbNpWallpaper.Enabled = false;
            }
            else if (config.gameVersion.Equals("Petz 5.exe"))
            {
                cbDisableLoadingCase.Enabled = false;
                cbDisableLoadingCase.Checked = true;
                config.disableLoadingCase = true;

                cbDisableLoadingAC.Enabled = false;
                cbDisableLoadingAC.Checked = true;
                config.disableLoadingAC = true;
            }
        }


        private void changeUI(string petz)
        {
            btnStartPetz.Text = "Save and Start " + petz;
            this.Text = petz + " EZLoader Settings";

            cbNpAdoptedPetz.Text = "Include Adopted " + petz;
            cbDisableLoadingPetz.Text = "Disable Loading Adopted " + petz;
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
                        Program.saveIniFile();
                        reloadEverything();
                        skipSave = false;
                        break;
                    default:
                        MessageBox.Show("Please select a valid Petz or Babyz .exe file");
                        break;
                }
                if (!config.disableBaseGameFallback)
                {
                    Program.regenerateBaseGameBackup(config.gameVersion);
                    // set checkbox in case load failed
                    cbDisableFallback.Checked = config.disableBaseGameFallback;
                }
            }
        }



        //GENERAL SETTINGS
        private void cbAlwaySettings_CheckedChanged(object sender, EventArgs e)
        {
            config.alwaysShowSettings = cbAlwaySettings.Checked;
            skipSave = false;
        }
        private void cbOpenContProf_CheckedChanged(object sender, EventArgs e)
        {
            config.openContProfForum = cbOpenContProf.Checked;
            skipSave = false;
        }

        private void cbLoadOrderAutoSwapFirst_CheckedChanged(object sender, EventArgs e)
        {
            config.loadProfilesFirst = !cbLoadOrderAutoSwapFirst.Checked;
            cbLoadOrderProfilesFirst.Checked = !cbLoadOrderAutoSwapFirst.Checked;
            skipSave = false;
        }
        private void cbLoadOrderProfilesFirst_CheckedChanged(object sender, EventArgs e)
        {
            config.loadProfilesFirst = cbLoadOrderProfilesFirst.Checked;
            cbLoadOrderAutoSwapFirst.Checked = !cbLoadOrderProfilesFirst.Checked;
            skipSave = false;
        }

        private void btnRegenFolders_Click(object sender, EventArgs e)
        {
            Program.generateFilesFolder();
            MessageBox.Show("All default folders have been regenerated", "Info");
        }
        private void btnResetSettings_Click(object sender, EventArgs e)
        {
            config.SetToDefaults();
            config.refreshFolders();
            reloadEverything();
            MessageBox.Show("All settings have been reset to their defaults", "Info");
            skipSave = false;
        }

        private void btnGenerateDebug_Click(object sender, EventArgs e)
        {
            Program.createDebugTxt();
            MessageBox.Show("Debug text files have been generated for all autoswap folders. \nThe content of these files can be used to check which folder is being loaded.", "Info");
        }
        private void btnDeleteDebug_Click(object sender, EventArgs e)
        {
            Program.deleteDebugTxt();
            MessageBox.Show("Debug text files have been delete from all autoswap folders. \nAny debug.txt files left in the game files should be removed manually.", "Info");

        }

        // INFO LINKS
        private void linkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkGithub.LinkVisited = true;
            System.Diagnostics.Process.Start("explorer.exe", "https://github.com/lilliancf/PetzEZLoader");
        }
        private void linkAliveEnough_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkAliveEnough.LinkVisited = true;
            System.Diagnostics.Process.Start("explorer.exe", "https://oodlecat.meowandsparkle.party/");
        }
        private void linkOpenMeteo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkAliveEnough.LinkVisited = true;
            System.Diagnostics.Process.Start("explorer.exe", " https://open-meteo.com/");
        }

        // AUTO SWAPPING CONTROLS
        private void cbEnableAutoSwapping_CheckedChanged(object sender, EventArgs e)
        {
            config.autoSwappingEnabled = cbEnableAutoSwapping.Checked;
            skipSave = false;

            toggleAutoSwappingControls(cbEnableAutoSwapping.Checked);
        }

        private void toggleAutoSwappingControls(bool enabled)
        {
            gbSeasonalOptions.Enabled = enabled;
            gbTimeOptions.Enabled = enabled;
            gbWeatherOptions.Enabled = enabled;
        }

        // SEASONAL CONTROLS
        private void cbEnableSeasonalArea_CheckedChanged(object sender, EventArgs e)
        {
            config.seasonalAreaEnabled = cbEnableSeasonalArea.Checked;

            if (!cbEnableSeasonalArea.Checked)
            {
                cbEnableSeasonalAC.Checked = false;
                cbEnableSeasonalAC.Enabled = false;
                config.seasonalACEnabled = false;
            }
            else if (!config.gameVersion.Equals("Babyz.exe") && !config.gameVersion.Equals("Petz 5.exe"))
            {
                cbEnableSeasonalAC.Enabled = true;
            }
            skipSave = false;
        }
        private void cbEnableSeasonalCase_CheckedChanged(object sender, EventArgs e)
        {
            config.seasonalCaseEnabled = cbEnableSeasonalCase.Checked;
            skipSave = false;
        }
        private void cbEnableSeasonalMice_CheckedChanged(object sender, EventArgs e)
        {
            config.seasonalMiceEnabled = cbEnableSeasonalMice.Checked;
            skipSave = false;
        }

        private void cbEnableSeasonalAC_CheckedChanged(object sender, EventArgs e)
        {
            config.seasonalACEnabled = cbEnableSeasonalAC.Checked;
            skipSave = false;
        }

        private void ddDefaultSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddDefaultSeason.SelectedItem != null)
            {
                config.defaultSeason = ddDefaultSeason.SelectedItem.ToString().ToLower();
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
        private void cbEnableTimeArea_CheckedChanged(object sender, EventArgs e)
        {
            config.timeAreaEnabled = cbEnableTimeArea.Checked;
            if (!cbEnableTimeArea.Checked)
            {
                cbEnableTimeAC.Checked = false;
                cbEnableTimeAC.Enabled = false;
                config.timeACEnabled = false;
            }
            else if (!config.gameVersion.Equals("Babyz.exe") && !config.gameVersion.Equals("Petz 5.exe"))
            {
                cbEnableTimeAC.Enabled = true;
            }
            skipSave = false;
        }
        private void cbEnableTimeCase_CheckedChanged(object sender, EventArgs e)
        {
            config.timeCaseEnabled = cbEnableTimeCase.Checked;
            cb24HourCaseMode.Enabled = cbEnableTimeCase.Checked;

            if (!cbEnableTimeCase.Checked)
            {
                config.caseMode24Hour = false;
                cb24HourCaseMode.Checked = false;
            }

            skipSave = false;
        }
        private void cbEnableTimeMice_CheckedChanged(object sender, EventArgs e)
        {
            config.timeMiceEnabled = cbEnableTimeMice.Checked;
            skipSave = false;
        }

        private void cbEnableTimeAC_CheckedChanged(object sender, EventArgs e)
        {
            config.timeACEnabled = cbEnableTimeAC.Checked;
            skipSave = false;
        }


        private void ddDefaultTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddDefaultTime.SelectedItem != null)
            {
                config.defaultTime = ddDefaultTime.SelectedItem.ToString().ToLower();
                skipSave = false;
            }
        }

        private void cb24HourCaseMode_CheckedChanged(object sender, EventArgs e)
        {
            config.caseMode24Hour = cb24HourCaseMode.Checked;

            if (cb24HourCaseMode.Checked)
            {

                cbEnableSeasonalCase.Checked = false;
                cbEnableSeasonalCase.Enabled = false;
                config.seasonalCaseEnabled = false;

                cbEnableWeatherCase.Checked = false;
                cbEnableWeatherCase.Enabled = false;
                config.weatherCaseEnabled = false;
            }
            else
            {
                cbEnableSeasonalCase.Enabled = true;
                cbEnableWeatherCase.Enabled = true;
            }


            skipSave = false;
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
        private void cbEnableWeatherArea_CheckedChanged(object sender, EventArgs e)
        {
            config.weatherAreaEnabled = cbEnableWeatherArea.Checked;
            if (!cbEnableWeatherArea.Checked)
            {
                cbEnableWeatherAC.Checked = false;
                cbEnableWeatherAC.Enabled = false;
                config.weatherACEnabled = false;
            }
            else if (!config.gameVersion.Equals("Babyz.exe") && !config.gameVersion.Equals("Petz 5.exe"))
            {
                cbEnableWeatherAC.Enabled = true;
            }
            skipSave = false;
        }
        private void cbEnableWeatherCase_CheckedChanged(object sender, EventArgs e)
        {
            config.weatherCaseEnabled = cbEnableWeatherCase.Checked;
            skipSave = false;
        }
        private void cbEnableWeatherMice_CheckedChanged(object sender, EventArgs e)
        {
            config.weatherMiceEnabled = cbEnableWeatherMice.Checked;
            skipSave = false;
        }
        private void cbEnableWeatherAC_CheckedChanged(object sender, EventArgs e)
        {
            config.weatherACEnabled = cbEnableWeatherAC.Checked;
            skipSave = false;
        }

        private void ddDefaultWeather_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddDefaultWeather.SelectedItem != null)
            {
                config.defaultWeather = ddDefaultWeather.SelectedItem.ToString().ToLower();
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


        // CONTENT PROFILES CONTROLS 
        private void cbEnableContentProfiles_CheckedChanged(object sender, EventArgs e)
        {
            config.contentProfilesEnabled = cbEnableContProf.Checked;
            skipSave = false;

            toggleContentProfileControls(cbEnableContProf.Checked);
        }

        private void toggleContentProfileControls(bool enabled)
        {
            bnIncUp.Enabled = enabled;
            bnIncDown.Enabled = enabled;
            bnRemoveIncluded.Enabled = enabled;
            bnAddIncluded.Enabled = enabled;
            bnRefreshFolders.Enabled = enabled;
            lbIncluded.Enabled = enabled;
            lbNotIncluded.Enabled = enabled;
            bnRefreshFolders.Enabled = enabled;

            lInclude.Enabled = enabled;
            lRemove.Enabled = enabled;

            lNameFilter.Enabled = enabled;
            tbNameFilter.Enabled = enabled;

            gbCreateNewProfile.Enabled = enabled;
            gbDeleteProfile.Enabled = enabled;
            gbLoadingOverride.Enabled = enabled;
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

                string text = tbNameFilter.Text.ToLower();
                if (!string.IsNullOrEmpty(text)) filterLists(text);

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
                lbIncluded.SelectedIndex = config.include.Count - 1;

                string text = tbNameFilter.Text.ToLower();
                if (!string.IsNullOrEmpty(text)) filterLists(text);

                skipSave = false;
            }
        }

        private void bnRefreshFolders_Click(object sender, EventArgs e)
        {
            updateContentProfiles();
        }

        private void tbNameFilter_TextChanged(object sender, EventArgs e)
        {
            string text = tbNameFilter.Text.ToLower();

            if (!string.IsNullOrEmpty(text))
            {
                bnIncUp.Enabled = false;
                bnIncDown.Enabled = false;

                filterLists(text);
            }
            else
            {
                bnIncUp.Enabled = true;
                bnIncDown.Enabled = true;

                List<string> newInclude = new List<string>(config.include);
                List<string> newExclude = new List<string>(config.exclude);
                lbIncluded.DataSource = newInclude;
                lbNotIncluded.DataSource = newExclude;
            }
        }
        private void filterLists(string text)
        {
            List<string> newInclude = new List<string>();
            foreach (string s in config.include)
            {
                if (s.ToLower().Contains(text)) newInclude.Add(s);
            }

            List<string> newExclude = new List<string>();
            foreach (string s in config.exclude)
            {
                if (s.ToLower().Contains(text)) newExclude.Add(s);
            }

            lbIncluded.DataSource = newInclude;
            lbNotIncluded.DataSource = newExclude;
        }

        private void cbDisableLoadingResources_CheckedChanged(object sender, EventArgs e)
        {
            config.disableLoadingResources = cbDisableLoadingResources.Checked;

            if (cbDisableLoadingResources.Checked)
            {
                cbNpArea.Checked = false;
                cbNpCatz.Checked = false;
                cbNpClothes.Checked = false;
                cbNpDogz.Checked = false;

                cbNpSongz.Checked = false;
                cbNpToyz.Checked = false;
                cbNpWallpaper.Checked = false;

                cbNpTextures.Checked = false;
                cbNpPalettes.Checked = false;

                cbNpArea.Enabled = false;
                cbNpCatz.Enabled = false;
                cbNpClothes.Enabled = false;
                cbNpDogz.Enabled = false;

                cbNpSongz.Enabled = false;
                cbNpToyz.Enabled = false;
                cbNpWallpaper.Enabled = false;

                cbNpTextures.Enabled = false;
                cbNpPalettes.Enabled = false;
            }
            else
            {
                cbNpArea.Enabled = true;
                cbNpCatz.Enabled = true;
                cbNpClothes.Enabled = true;
                cbNpDogz.Enabled = true;

                cbNpSongz.Enabled = true;
                cbNpToyz.Enabled = true;
                cbNpWallpaper.Enabled = true;

                cbNpTextures.Enabled = true;
                cbNpPalettes.Enabled = true;
            }

            skipSave = false;
        }

        private void cbDisableLoadingPetz_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbDisableLoadingPetz.Checked)
            {
                MessageBox.Show("Note: Adopted Petz Content Profiles work best if each pet is placed in only one profile. \n\n" +
                    "If the same pet file is placed in more than one profile, there is a risk that the latest version of the pet will not always be used.", "Info");
            }
            config.disableLoadingPetz = cbDisableLoadingPetz.Checked;

            if (cbDisableLoadingPetz.Checked)
            {
                cbNpAdoptedPetz.Enabled = false;
                cbNpAdoptedPetz.Checked = false;
            }
            else
            {
                cbNpAdoptedPetz.Enabled = true;
            }

            skipSave = false;
        }



        private void cbDisableLoadingCase_CheckedChanged(object sender, EventArgs e)
        {
            config.disableLoadingCase = cbDisableLoadingCase.Checked;
            if (cbDisableLoadingCase.Checked)
            {
                cbNpCase.Checked = false;
                cbNpCase.Enabled = false;
            }
            else
            {
                cbNpCase.Enabled = true;
            }
            skipSave = false;
        }

        private void cbDisableLoadingMice_CheckedChanged(object sender, EventArgs e)
        {
            config.disableLoadingMice = cbDisableLoadingMice.Checked;
            if (cbDisableLoadingMice.Checked)
            {
                cbNpMice.Checked = false;
                cbNpMice.Enabled = false;
            }
            else
            {
                cbNpMice.Enabled = true;
            }
            skipSave = false;
        }

        private void cbDisableLoadingAC_CheckedChanged(object sender, EventArgs e)
        {
            config.disableLoadingAC = cbDisableLoadingAC.Checked;
            if (cbDisableLoadingAC.Checked)
            {
                cbNpACSprites.Checked = false;
                cbNpACSprites.Enabled = false;
            }
            else
            {
                cbNpACSprites.Enabled = true;
            }
            skipSave = false;
        }

        private void btnCreateProfile_Click(object sender, EventArgs e)
        {
            string newProfileName = tbNpName.Text;
            if (string.IsNullOrEmpty(newProfileName)) MessageBox.Show("Please enter a profile name", "Error");
            else if (newProfileName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1) MessageBox.Show("Invalid profile name", "Error");
            else
            {
                try
                {
                    DirectoryInfo newProfile = new DirectoryInfo(Path.Combine(Program.fileSource, "ContentProfiles", newProfileName));
                    newProfile.Create();

                    if (cbNpAdoptedPetz.Checked) newProfile.CreateSubdirectory(config.gameVersion.Equals("Babyz.exe") ? "Adopted Babyz" : "Adopted Petz");
                    if (cbNpACSprites.Checked) newProfile.CreateSubdirectory("ACSprites");
                    if (cbNpCase.Checked) newProfile.CreateSubdirectory("CarryingCase");
                    if (cbNpMice.Checked) newProfile.CreateSubdirectory("Mice");
                    if (cbNpArea.Checked || cbNpCatz.Checked || cbNpClothes.Checked || cbNpDogz.Checked || cbNpSongz.Checked
                        || cbNpToyz.Checked || cbNpWallpaper.Checked || cbNpTextures.Checked || cbNpPalettes.Checked)
                    {
                        DirectoryInfo resource = newProfile.CreateSubdirectory("Resource");
                        if (cbNpArea.Checked) resource.CreateSubdirectory("Area");
                        if (cbNpCatz.Checked) resource.CreateSubdirectory("Catz");
                        if (cbNpClothes.Checked) resource.CreateSubdirectory("Clothes");
                        if (cbNpDogz.Checked) resource.CreateSubdirectory("Dogz");

                        if (cbNpSongz.Checked) resource.CreateSubdirectory("Songz");
                        if (cbNpToyz.Checked) resource.CreateSubdirectory("Toyz");
                        if (cbNpWallpaper.Checked) resource.CreateSubdirectory("Wallpaper");

                        if (cbNpTextures.Checked) resource.CreateSubdirectory("Textures");
                        if (cbNpPalettes.Checked) resource.CreateSubdirectory("Palettes");
                    }

                    MessageBox.Show("Profile created sucessfully", "Sucess");

                    updateContentProfiles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A problem occured while creating the profile: " + ex.Message, "Error");
                }
            }
        }
        private void btnNpClear_Click(object sender, EventArgs e)
        {
            tbNpName.Text = "";
            cbNpAdoptedPetz.Checked = false;
            cbNpACSprites.Checked = false;
            cbNpCase.Checked = false;
            cbNpMice.Checked = false;

            cbNpArea.Checked = false;
            cbNpCatz.Checked = false;
            cbNpClothes.Checked = false;
            cbNpDogz.Checked = false;
            cbNpSongz.Checked = false;
            cbNpDogz.Checked = false;
            cbNpSongz.Checked = false;
            cbNpToyz.Checked = false;
            cbNpWallpaper.Checked = false;
            cbNpTextures.Checked = false;
            cbNpPalettes.Checked = false;
        }

        private void btnDeleteProfile_Click(object sender, EventArgs e)
        {
            string value = ddDeleteProfile.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(value))
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete " + value + "? This action will delete both the EZLoader folder and the matching in game files from your PC.", "Warning", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Program.deleteContentProfile(value);
                        string path = Path.Combine(Program.fileSource, "ContentProfiles", value);

                        Microsoft.VisualBasic.FileIO.FileSystem.DeleteDirectory(path, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);

                        updateContentProfiles();

                        Program.saveIniFile();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("A problem occurured while trying to delete the profile: " + ex.Message, "Error");
                    }

                }
            }

        }

        private void updateContentProfiles()
        {
            config.refreshFolders();

            tbNameFilter.Text = "";
            lbIncluded.DataSource = new List<string>(config.include);
            lbNotIncluded.DataSource = new List<string>(config.exclude);

            List<string> profiles = new List<string>(config.include);
            profiles.AddRange(config.exclude);
            ddDeleteProfile.DataSource = profiles;
        }

        // OTHER CONTROLS

        private void bnSave_Click(object sender, EventArgs e)
        {
            saveSettings();
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
        private void btnHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", @"readme.html");
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
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

        private void saveSettings()
        {
            if (!double.TryParse(tbLatitude.Text, out double num) || !double.TryParse(tbLongitude.Text, out double num1))
            {
                MessageBox.Show("Latitude and/or Longitude is not a valid decimal number, it will not be saved", "Error");
            }
            Program.saveIniFile();
            skipSave = true;
        }

        private void cbDisableFallback_CheckedChanged(object sender, EventArgs e)
        {
            config.disableBaseGameFallback = cbDisableFallback.Checked;
            if (!cbDisableFallback.Checked)
            {
                Program.regenerateBaseGameBackup(config.gameVersion);
            }
            skipSave = true;

        }

        private void fallbackError(string version)
        {
            MessageBox.Show("No backup folder for " + version + "found, disabling base game fallback", "Info");
            config.disableBaseGameFallback = true;
            cbDisableFallback.Checked = true;
        }

        private void btnMoveFiles_Click(object sender, EventArgs e)
        {
            saveSettings();
            Program.startLoading(false);
        }

        private void btnSortRemove_Click(object sender, EventArgs e)
        {
            config.exclude.Sort();
            lbNotIncluded.DataSource = new List<string>(config.exclude);
        }
    }
}
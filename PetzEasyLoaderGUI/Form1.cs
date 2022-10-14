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

            cbEnableSeasons.Checked = config.seasonsEnabled;
            cbEnableDayNight.Checked = config.dayNightEnabled;

            int year = DateTime.Now.Year;
            dtpWinterStart.Value = new DateTime(year, config.winterStart / 100, config.winterStart % 100);
            dtpSpringStart.Value = new DateTime(year, config.springStart / 100, config.springStart % 100);
            dtpSummerStart.Value = new DateTime(year, config.summerStart / 100, config.summerStart % 100);
            dtpFallStart.Value = new DateTime(year, config.fallStart / 100, config.fallStart % 100);


            dtpSunrise.Value = new DateTime(year, DateTime.Now.Month, DateTime.Now.Day,
                                                config.sunriseTime/100, config.sunriseTime%100, 0);
            dtpSunset.Value = new DateTime(year, DateTime.Now.Month, DateTime.Now.Day,
                                               config.sunsetTime/100, config.sunsetTime%100, 0);
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

        // SEASONAL AREA CONTROLS
        private void cbEnableSeasons_CheckedChanged(object sender, EventArgs e)
        {
            config.seasonsEnabled = cbEnableSeasons.Checked;
            skipSave = false;
        }

        private void cbEnableDayNight_CheckedChanged(object sender, EventArgs e)
        {
            config.dayNightEnabled = cbEnableDayNight.Checked;
            skipSave = false;
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

        // BULK LOADING CONTROLS 
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

        private void cbEnableBulk_CheckedChanged(object sender, EventArgs e)
        {
            config.bulkLoadingEnabled = cbEnableBulk.Checked;
            skipSave = false;
        }




        private void bnSave_Click(object sender, EventArgs e)
        {
            Program.saveIniFile();
            skipSave = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("explorer.exe", "https://oodlecat.neocities.org/");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!skipSave)
            {
                DialogResult result = MessageBox.Show("Would you like to save your settings?", "Save Message", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    Program.saveIniFile();
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
                Program.saveIniFile();
                skipSave = true;
                this.Close();
            }

        }
    }
}
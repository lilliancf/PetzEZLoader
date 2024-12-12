using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PetzEasyLoaderGUI
{
    public partial class FormContentProfiles : Form
    {
        public static string profileSource = Path.Combine(System.AppContext.BaseDirectory, "Filez", "ContentProfiles");
        configProperties config;
        bool skipSave = false;

        Dictionary<string, List<string>> profiles = new Dictionary<string, List<string>>();

        List<string> checkedFilters = new List<string>();

        public FormContentProfiles(configProperties p)
        {
            config = p;
            InitializeComponent();

            lbIncluded.DataSource = new List<string>(config.include);
            lbNotIncluded.DataSource = new List<string>(config.exclude);

            buildSubfolderList();

            skipSave = true;
        }

        private void buildSubfolderList()
        {
            List<string> allFolders = new List<string>(config.include);
            allFolders.AddRange(config.exclude);

            foreach (string i in allFolders)
            {
                profiles.Add(i, new List<string>());
                string folderPath = Path.Combine(profileSource, i);
                if (Directory.Exists(folderPath))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
                    foreach (DirectoryInfo subDir in directoryInfo.GetDirectories())
                    {
                        if (subDir.Name.Equals("Resource"))
                        {
                            foreach (DirectoryInfo s in subDir.GetDirectories())
                            {
                                profiles[i].Add(s.Name);
                            }
                        }
                        else
                        {
                            profiles[i].Add(subDir.Name);
                        }
                    }
                }
            }

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

                filterBoxes();
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

                filterBoxes();
                skipSave = false;
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", @"readme.html");
        }

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

        private void saveSettings()
        {
            Program.saveIniFile();
            skipSave = true;
        }

        private void bnFilterClear_Click(object sender, EventArgs e)
        {
            cbArea.Checked = false;
            cbCatz.Checked = false;
            cbClothes.Checked = false;
            cbDogz.Checked = false;
            cbSongz.Checked = false;
            cbToyz.Checked = false;
            cbWallpaper.Checked = false;

            cbPalettes.Checked = false;
            cbTextures.Checked = false;

            cbAdoptedPetz.Checked = false;
            cbACSprites.Checked = false;
            cbCase.Checked = false;
            cbMice.Checked = false;

            checkedFilters.Clear();
            tbNameFilter.Text = "";
            filterBoxes();
        }

        private void filterBoxes()
        {
            string text = tbNameFilter.Text.ToLower();
            if (String.IsNullOrEmpty(text) && checkedFilters.Count == 0)
            {
                bnIncUp.Enabled = true;
                bnIncDown.Enabled = true;

                lbIncluded.DataSource = new List<string>(config.include);
                lbNotIncluded.DataSource = new List<string>(config.exclude);
            }
            else
            {
                bnIncUp.Enabled = false;
                bnIncDown.Enabled = false;

                List<string> newInclude = new List<string>();
                List<string> newExclude = new List<string>();


                foreach (string iFolder in config.include)
                {
                    if (String.IsNullOrEmpty(text) || iFolder.ToLower().Contains(text))
                    {
                        if (checkedFilters.Count > 0)
                        {
                            List<string> subfolders = profiles[iFolder];
                            foreach (string cf in checkedFilters) if (subfolders.Contains(cf)) newInclude.Add(iFolder);
                        }
                        else
                        {
                            newInclude.Add(iFolder);
                        }
                    }
                }
                foreach (string eFolder in config.exclude)
                {
                    if (String.IsNullOrEmpty(text) || eFolder.ToLower().Contains(text))
                    {
                        if (checkedFilters.Count > 0)
                        {
                            List<string> subfolders = profiles[eFolder];
                            foreach (string cf in checkedFilters) if (subfolders.Contains(cf)) newExclude.Add(eFolder);
                        }
                        else
                        {
                            newExclude.Add(eFolder);
                        }
                    }
                }

                lbIncluded.DataSource = newInclude;
                lbNotIncluded.DataSource = newExclude;
            }
        }

        private void tbNameFilter_TextChanged(object sender, EventArgs e)
        {
            filterBoxes();
        }

        private void cbArea_CheckedChanged(object sender, EventArgs e)
        {
            if (cbArea.Checked) checkedFilters.Add("Area");
            else checkedFilters.Remove("Area");
            filterBoxes();
        }

        private void cbCatz_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCatz.Checked) checkedFilters.Add("Catz");
            else checkedFilters.Remove("Catz");
            filterBoxes();
        }

        private void cbClothes_CheckedChanged(object sender, EventArgs e)
        {
            if (cbClothes.Checked) checkedFilters.Add("Clothes");
            else checkedFilters.Remove("Clothes");
            filterBoxes();
        }

        private void cbDogz_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDogz.Checked) checkedFilters.Add("Dogz");
            else checkedFilters.Remove("Dogz");
            filterBoxes();
        }

        private void cbSongz_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSongz.Checked) checkedFilters.Add("Songz");
            else checkedFilters.Remove("Songz");
            filterBoxes();
        }

        private void cbToyz_CheckedChanged(object sender, EventArgs e)
        {
            if (cbToyz.Checked) checkedFilters.Add("Toyz");
            else checkedFilters.Remove("Toyz");
            filterBoxes();
        }

        private void cbWallpaper_CheckedChanged(object sender, EventArgs e)
        {
            if (cbWallpaper.Checked) checkedFilters.Add("Wallpaper");
            else checkedFilters.Remove("Wallpaper");
            filterBoxes();
        }

        private void cbAdoptedPetz_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAdoptedPetz.Checked) checkedFilters.Add("Adopted Petz");
            else checkedFilters.Remove("Adopted Petz");
            filterBoxes();
        }

        private void cbCase_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCase.Checked) checkedFilters.Add("CarryingCase");
            else checkedFilters.Remove("CarryingCase");
            filterBoxes();
        }

        private void cbACSprites_CheckedChanged(object sender, EventArgs e)
        {
            if (cbACSprites.Checked) checkedFilters.Add("ACSprites");
            else checkedFilters.Remove("ACSprites");
            filterBoxes();
        }

        private void cbMice_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMice.Checked) checkedFilters.Add("Mice");
            else checkedFilters.Remove("Mice");
            filterBoxes();
        }

        private void cbTextures_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTextures.Checked) checkedFilters.Add("Textures");
            else checkedFilters.Remove("Area");
            filterBoxes();
        }

        private void cbPalettes_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPalettes.Checked) checkedFilters.Add("Palettes");
            else checkedFilters.Remove("Palettes");
            filterBoxes();
        }

        private void FormContentProfiles_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}

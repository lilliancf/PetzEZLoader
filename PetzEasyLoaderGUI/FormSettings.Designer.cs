namespace PetzEasyLoaderGUI
{
    partial class FormSettings
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            label1 = new Label();
            labelPetzExe = new Label();
            bnEditPetzSource = new Button();
            btnSave = new Button();
            btnStartPetz = new Button();
            toolTip1 = new ToolTip(components);
            Credits = new GroupBox();
            linkGithub = new LinkLabel();
            label23 = new Label();
            linkOpenMeteo = new LinkLabel();
            label16 = new Label();
            label12 = new Label();
            linkAliveEnough = new LinkLabel();
            label9 = new Label();
            label8 = new Label();
            lbNotIncluded = new ListBox();
            lbIncluded = new ListBox();
            bnRemoveIncluded = new Button();
            bnAddIncluded = new Button();
            bnIncDown = new Button();
            bnIncUp = new Button();
            bnRefreshFolders = new Button();
            cbEnableContProf = new CheckBox();
            lInclude = new Label();
            lRemove = new Label();
            cbAlwaySettings = new CheckBox();
            btnHelp = new Button();
            dtpWinterStart = new DateTimePicker();
            label4 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            dtpSpringStart = new DateTimePicker();
            cbEnableAutoSwapping = new CheckBox();
            dtpSummerStart = new DateTimePicker();
            dtpFallStart = new DateTimePicker();
            dtpSunrise = new DateTimePicker();
            label2 = new Label();
            dtpSunset = new DateTimePicker();
            label7 = new Label();
            ddDefaultSeason = new ComboBox();
            cbEnableSunriseset = new CheckBox();
            ddDefaultWeather = new ComboBox();
            lbWeatherRotation = new Label();
            ddWeatherRotation = new ComboBox();
            ddDefaultTime = new ComboBox();
            tbLongitude = new TextBox();
            label14 = new Label();
            label15 = new Label();
            tbLatitude = new TextBox();
            cb24HourCaseMode = new CheckBox();
            gbTimeOptions = new GroupBox();
            label22 = new Label();
            cbEnableTimeMice = new CheckBox();
            label17 = new Label();
            cbEnableTimeCase = new CheckBox();
            cbEnableTimeArea = new CheckBox();
            tabControl1 = new TabControl();
            tpGerneral = new TabPage();
            gbWarning = new GroupBox();
            label10 = new Label();
            cbOpenContProf = new CheckBox();
            groupBox1 = new GroupBox();
            btnResetSettings = new Button();
            cbDisableFallback = new CheckBox();
            btnRegenFolders = new Button();
            btnDeleteDebug = new Button();
            cbLoadOrderProfilesFirst = new CheckBox();
            cbLoadOrderAutoSwapFirst = new CheckBox();
            label13 = new Label();
            btnGenerateDebug = new Button();
            tbContentProfiles = new TabPage();
            gbLoadingOverride = new GroupBox();
            cbDisableLoadingPetz = new CheckBox();
            cbDisableLoadingPetzRez = new CheckBox();
            cbDisableLoadingResources = new CheckBox();
            lNameFilter = new Label();
            tbNameFilter = new TextBox();
            gbDeleteProfile = new GroupBox();
            label28 = new Label();
            ddDeleteProfile = new ComboBox();
            btnDeleteProfile = new Button();
            gbCreateNewProfile = new GroupBox();
            btnNpClear = new Button();
            cbNpACSprites = new CheckBox();
            label27 = new Label();
            tbNpName = new TextBox();
            btnCreateProfile = new Button();
            cbNpMice = new CheckBox();
            cbNpCase = new CheckBox();
            cbNpPalettes = new CheckBox();
            cbNpTextures = new CheckBox();
            cbNpToyz = new CheckBox();
            cbNpSongz = new CheckBox();
            cbNpWallpaper = new CheckBox();
            cbNpAdoptedPetz = new CheckBox();
            cbNpClothes = new CheckBox();
            cbNpDogz = new CheckBox();
            label26 = new Label();
            cbNpArea = new CheckBox();
            cbNpCatz = new CheckBox();
            tpAutoSwap = new TabPage();
            gbSeasonalOptions = new GroupBox();
            cbEnableSeasonalArea = new CheckBox();
            cbEnableSeasonalCase = new CheckBox();
            cbEnableSeasonalMice = new CheckBox();
            label18 = new Label();
            label21 = new Label();
            gbWeatherOptions = new GroupBox();
            cbEnableWeatherMice = new CheckBox();
            cbEnableWeatherCase = new CheckBox();
            cbEnableWeatherArea = new CheckBox();
            label19 = new Label();
            Credits.SuspendLayout();
            gbTimeOptions.SuspendLayout();
            tabControl1.SuspendLayout();
            tpGerneral.SuspendLayout();
            gbWarning.SuspendLayout();
            groupBox1.SuspendLayout();
            tbContentProfiles.SuspendLayout();
            gbLoadingOverride.SuspendLayout();
            gbDeleteProfile.SuspendLayout();
            gbCreateNewProfile.SuspendLayout();
            tpAutoSwap.SuspendLayout();
            gbSeasonalOptions.SuspendLayout();
            gbWeatherOptions.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 10);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 2;
            label1.Text = "Petz Source:";
            // 
            // labelPetzExe
            // 
            labelPetzExe.AutoEllipsis = true;
            labelPetzExe.AutoSize = true;
            labelPetzExe.Location = new Point(84, 10);
            labelPetzExe.MaximumSize = new Size(525, 15);
            labelPetzExe.Name = "labelPetzExe";
            labelPetzExe.Size = new Size(517, 15);
            labelPetzExe.TabIndex = 3;
            labelPetzExe.Text = "Please select main petz folder Please select main petz folder Please select main petz folder Please select main petz folder";
            toolTip1.SetToolTip(labelPetzExe, "test");
            // 
            // bnEditPetzSource
            // 
            bnEditPetzSource.Location = new Point(7, 28);
            bnEditPetzSource.Name = "bnEditPetzSource";
            bnEditPetzSource.Size = new Size(94, 23);
            bnEditPetzSource.TabIndex = 0;
            bnEditPetzSource.Text = "Edit Source";
            bnEditPetzSource.UseVisualStyleBackColor = true;
            bnEditPetzSource.Click += bnEditPetzSource_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(373, 480);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(71, 23);
            btnSave.TabIndex = 16;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += bnSave_Click;
            // 
            // btnStartPetz
            // 
            btnStartPetz.Location = new Point(450, 480);
            btnStartPetz.Name = "btnStartPetz";
            btnStartPetz.Size = new Size(127, 23);
            btnStartPetz.TabIndex = 17;
            btnStartPetz.Text = "Save and Start Petz";
            btnStartPetz.UseVisualStyleBackColor = true;
            btnStartPetz.Click += bnStartPetz_Click;
            // 
            // Credits
            // 
            Credits.Controls.Add(linkGithub);
            Credits.Controls.Add(label23);
            Credits.Controls.Add(linkOpenMeteo);
            Credits.Controls.Add(label16);
            Credits.Controls.Add(label12);
            Credits.Controls.Add(linkAliveEnough);
            Credits.Controls.Add(label9);
            Credits.Controls.Add(label8);
            Credits.Location = new Point(5, 326);
            Credits.Name = "Credits";
            Credits.Size = new Size(552, 104);
            Credits.TabIndex = 18;
            Credits.TabStop = false;
            Credits.Text = "Info";
            // 
            // linkGithub
            // 
            linkGithub.AutoSize = true;
            linkGithub.Location = new Point(313, 34);
            linkGithub.Margin = new Padding(2, 0, 2, 0);
            linkGithub.Name = "linkGithub";
            linkGithub.Size = new Size(228, 15);
            linkGithub.TabIndex = 24;
            linkGithub.TabStop = true;
            linkGithub.Text = "https://github.com/lilliancf/PetzEZLoader";
            linkGithub.LinkClicked += linkGithub_LinkClicked;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(6, 34);
            label23.Margin = new Padding(2, 0, 2, 0);
            label23.Name = "label23";
            label23.Size = new Size(266, 15);
            label23.TabIndex = 23;
            label23.Text = "don't forget to check github for the latest version";
            // 
            // linkOpenMeteo
            // 
            linkOpenMeteo.AutoSize = true;
            linkOpenMeteo.Location = new Point(394, 64);
            linkOpenMeteo.Name = "linkOpenMeteo";
            linkOpenMeteo.Size = new Size(145, 15);
            linkOpenMeteo.TabIndex = 22;
            linkOpenMeteo.TabStop = true;
            linkOpenMeteo.Text = "https://open-meteo.com/";
            linkOpenMeteo.LinkClicked += linkOpenMeteo_LinkClicked;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 64);
            label16.Name = "label16";
            label16.Size = new Size(214, 15);
            label16.TabIndex = 21;
            label16.Text = "Weather data provided by Open-Meteo";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 79);
            label12.Name = "label12";
            label12.Size = new Size(305, 15);
            label12.TabIndex = 19;
            label12.Text = "special thanks to ButterflyChaser, Queenie and Kyle T. <3";
            // 
            // linkAliveEnough
            // 
            linkAliveEnough.AutoSize = true;
            linkAliveEnough.Location = new Point(320, 49);
            linkAliveEnough.Name = "linkAliveEnough";
            linkAliveEnough.Size = new Size(221, 15);
            linkAliveEnough.TabIndex = 18;
            linkAliveEnough.TabStop = true;
            linkAliveEnough.Text = "https://oodlecat.meowandsparkle.party/";
            linkAliveEnough.LinkClicked += linkAliveEnough_LinkClicked;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 19);
            label9.Name = "label9";
            label9.Size = new Size(70, 15);
            label9.TabIndex = 1;
            label9.Text = "version 3.0b";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 49);
            label8.Name = "label8";
            label8.Size = new Size(186, 15);
            label8.TabIndex = 0;
            label8.Text = "created by skissors@Alive Enough";
            // 
            // lbNotIncluded
            // 
            lbNotIncluded.FormattingEnabled = true;
            lbNotIncluded.ItemHeight = 15;
            lbNotIncluded.Location = new Point(312, 46);
            lbNotIncluded.Margin = new Padding(2);
            lbNotIncluded.Name = "lbNotIncluded";
            lbNotIncluded.Size = new Size(234, 124);
            lbNotIncluded.TabIndex = 11;
            // 
            // lbIncluded
            // 
            lbIncluded.FormattingEnabled = true;
            lbIncluded.ItemHeight = 15;
            lbIncluded.Location = new Point(41, 46);
            lbIncluded.Margin = new Padding(2);
            lbIncluded.Name = "lbIncluded";
            lbIncluded.Size = new Size(234, 124);
            lbIncluded.TabIndex = 12;
            // 
            // bnRemoveIncluded
            // 
            bnRemoveIncluded.Location = new Point(278, 58);
            bnRemoveIncluded.Margin = new Padding(2);
            bnRemoveIncluded.Name = "bnRemoveIncluded";
            bnRemoveIncluded.Size = new Size(30, 20);
            bnRemoveIncluded.TabIndex = 14;
            bnRemoveIncluded.Text = ">";
            bnRemoveIncluded.UseVisualStyleBackColor = true;
            bnRemoveIncluded.Click += bnRemoveIncluded_Click;
            // 
            // bnAddIncluded
            // 
            bnAddIncluded.Location = new Point(278, 81);
            bnAddIncluded.Margin = new Padding(2);
            bnAddIncluded.Name = "bnAddIncluded";
            bnAddIncluded.Size = new Size(30, 20);
            bnAddIncluded.TabIndex = 13;
            bnAddIncluded.Text = "<";
            bnAddIncluded.UseVisualStyleBackColor = true;
            bnAddIncluded.Click += bnAddIncluded_Click;
            // 
            // bnIncDown
            // 
            bnIncDown.Location = new Point(13, 81);
            bnIncDown.Margin = new Padding(2);
            bnIncDown.Name = "bnIncDown";
            bnIncDown.Size = new Size(24, 31);
            bnIncDown.TabIndex = 18;
            bnIncDown.Text = "▼";
            bnIncDown.UseVisualStyleBackColor = true;
            bnIncDown.Click += bnIncDown_Click;
            // 
            // bnIncUp
            // 
            bnIncUp.Location = new Point(13, 47);
            bnIncUp.Margin = new Padding(2);
            bnIncUp.Name = "bnIncUp";
            bnIncUp.Size = new Size(24, 31);
            bnIncUp.TabIndex = 17;
            bnIncUp.Text = "▲";
            bnIncUp.UseVisualStyleBackColor = true;
            bnIncUp.Click += bnIncUp_Click;
            // 
            // bnRefreshFolders
            // 
            bnRefreshFolders.Location = new Point(441, 178);
            bnRefreshFolders.Name = "bnRefreshFolders";
            bnRefreshFolders.Size = new Size(105, 23);
            bnRefreshFolders.TabIndex = 15;
            bnRefreshFolders.Text = "Refresh Folders";
            bnRefreshFolders.UseVisualStyleBackColor = true;
            bnRefreshFolders.Click += bnRefreshFolders_Click;
            // 
            // cbEnableContProf
            // 
            cbEnableContProf.AutoSize = true;
            cbEnableContProf.Location = new Point(7, 7);
            cbEnableContProf.Name = "cbEnableContProf";
            cbEnableContProf.Size = new Size(149, 19);
            cbEnableContProf.TabIndex = 10;
            cbEnableContProf.Text = "Enable Content Profiles\r\n";
            cbEnableContProf.UseVisualStyleBackColor = true;
            cbEnableContProf.CheckedChanged += cbEnableContentProfiles_CheckedChanged;
            // 
            // lInclude
            // 
            lInclude.AutoSize = true;
            lInclude.Location = new Point(41, 29);
            lInclude.Margin = new Padding(2, 0, 2, 0);
            lInclude.Name = "lInclude";
            lInclude.Size = new Size(46, 15);
            lInclude.TabIndex = 13;
            lInclude.Text = "Include";
            // 
            // lRemove
            // 
            lRemove.AutoSize = true;
            lRemove.Location = new Point(312, 29);
            lRemove.Margin = new Padding(2, 0, 2, 0);
            lRemove.Name = "lRemove";
            lRemove.Size = new Size(50, 15);
            lRemove.TabIndex = 12;
            lRemove.Text = "Remove";
            // 
            // cbAlwaySettings
            // 
            cbAlwaySettings.AutoSize = true;
            cbAlwaySettings.Location = new Point(7, 56);
            cbAlwaySettings.Name = "cbAlwaySettings";
            cbAlwaySettings.Size = new Size(140, 19);
            cbAlwaySettings.TabIndex = 1;
            cbAlwaySettings.Text = "Always Open Settings";
            cbAlwaySettings.UseVisualStyleBackColor = true;
            cbAlwaySettings.CheckedChanged += cbAlwaySettings_CheckedChanged;
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(15, 480);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(75, 23);
            btnHelp.TabIndex = 19;
            btnHelp.Text = "Help";
            btnHelp.UseVisualStyleBackColor = true;
            btnHelp.Click += btnHelp_Click;
            // 
            // dtpWinterStart
            // 
            dtpWinterStart.CustomFormat = "MMM dd";
            dtpWinterStart.Format = DateTimePickerFormat.Custom;
            dtpWinterStart.Location = new Point(126, 128);
            dtpWinterStart.Name = "dtpWinterStart";
            dtpWinterStart.Size = new Size(75, 23);
            dtpWinterStart.TabIndex = 4;
            dtpWinterStart.ValueChanged += dtpWinterStart_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 156);
            label4.Name = "label4";
            label4.Size = new Size(98, 15);
            label4.TabIndex = 5;
            label4.Text = "Spring Start Date:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 130);
            label3.Name = "label3";
            label3.Size = new Size(99, 15);
            label3.TabIndex = 1;
            label3.Text = "Winter Start Date:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 181);
            label5.Name = "label5";
            label5.Size = new Size(109, 15);
            label5.TabIndex = 6;
            label5.Text = "Summer Start Date:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(34, 205);
            label6.Name = "label6";
            label6.Size = new Size(82, 15);
            label6.TabIndex = 5;
            label6.Text = "Fall Start Date:";
            // 
            // dtpSpringStart
            // 
            dtpSpringStart.CustomFormat = "MMM dd";
            dtpSpringStart.Format = DateTimePickerFormat.Custom;
            dtpSpringStart.Location = new Point(126, 153);
            dtpSpringStart.Name = "dtpSpringStart";
            dtpSpringStart.Size = new Size(75, 23);
            dtpSpringStart.TabIndex = 5;
            dtpSpringStart.ValueChanged += dtpSpringStart_ValueChanged;
            // 
            // cbEnableAutoSwapping
            // 
            cbEnableAutoSwapping.AutoSize = true;
            cbEnableAutoSwapping.Location = new Point(9, 8);
            cbEnableAutoSwapping.Name = "cbEnableAutoSwapping";
            cbEnableAutoSwapping.Size = new Size(145, 19);
            cbEnableAutoSwapping.TabIndex = 2;
            cbEnableAutoSwapping.Text = "Enable Auto Swapping";
            cbEnableAutoSwapping.UseVisualStyleBackColor = true;
            cbEnableAutoSwapping.CheckedChanged += cbEnableAutoSwapping_CheckedChanged;
            // 
            // dtpSummerStart
            // 
            dtpSummerStart.CustomFormat = "MMM dd";
            dtpSummerStart.Format = DateTimePickerFormat.Custom;
            dtpSummerStart.Location = new Point(126, 178);
            dtpSummerStart.Name = "dtpSummerStart";
            dtpSummerStart.Size = new Size(75, 23);
            dtpSummerStart.TabIndex = 6;
            dtpSummerStart.ValueChanged += dtpSummerStart_ValueChanged;
            // 
            // dtpFallStart
            // 
            dtpFallStart.CustomFormat = "MMM dd";
            dtpFallStart.Format = DateTimePickerFormat.Custom;
            dtpFallStart.Location = new Point(126, 202);
            dtpFallStart.Name = "dtpFallStart";
            dtpFallStart.Size = new Size(75, 23);
            dtpFallStart.TabIndex = 7;
            dtpFallStart.ValueChanged += dtpFallStart_ValueChanged;
            // 
            // dtpSunrise
            // 
            dtpSunrise.CustomFormat = "hh:mm tt";
            dtpSunrise.Format = DateTimePickerFormat.Custom;
            dtpSunrise.Location = new Point(91, 120);
            dtpSunrise.Name = "dtpSunrise";
            dtpSunrise.ShowUpDown = true;
            dtpSunrise.Size = new Size(101, 23);
            dtpSunrise.TabIndex = 8;
            dtpSunrise.ValueChanged += dtpSunrise_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 123);
            label2.Name = "label2";
            label2.Size = new Size(77, 15);
            label2.TabIndex = 5;
            label2.Text = "Sunrise Time:";
            // 
            // dtpSunset
            // 
            dtpSunset.CustomFormat = "hh:mm tt";
            dtpSunset.Format = DateTimePickerFormat.Custom;
            dtpSunset.Location = new Point(91, 149);
            dtpSunset.Name = "dtpSunset";
            dtpSunset.ShowUpDown = true;
            dtpSunset.Size = new Size(101, 23);
            dtpSunset.TabIndex = 9;
            dtpSunset.ValueChanged += dtpSunset_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(10, 152);
            label7.Name = "label7";
            label7.Size = new Size(74, 15);
            label7.TabIndex = 5;
            label7.Text = "Sunset Time:";
            // 
            // ddDefaultSeason
            // 
            ddDefaultSeason.DropDownStyle = ComboBoxStyle.DropDownList;
            ddDefaultSeason.FormattingEnabled = true;
            ddDefaultSeason.Items.AddRange(new object[] { "Winter", "Spring", "Summer", "Fall" });
            ddDefaultSeason.Location = new Point(108, 21);
            ddDefaultSeason.Name = "ddDefaultSeason";
            ddDefaultSeason.Size = new Size(103, 23);
            ddDefaultSeason.TabIndex = 19;
            ddDefaultSeason.SelectedIndexChanged += ddDefaultSeason_SelectedIndexChanged;
            // 
            // cbEnableSunriseset
            // 
            cbEnableSunriseset.AutoSize = true;
            cbEnableSunriseset.Location = new Point(14, 178);
            cbEnableSunriseset.Name = "cbEnableSunriseset";
            cbEnableSunriseset.Size = new Size(218, 19);
            cbEnableSunriseset.TabIndex = 20;
            cbEnableSunriseset.Text = "Enable unique sunrise/sunset scenes";
            cbEnableSunriseset.UseVisualStyleBackColor = true;
            cbEnableSunriseset.CheckedChanged += cbEnableSunRiseSet_CheckedChanged;
            // 
            // ddDefaultWeather
            // 
            ddDefaultWeather.DropDownStyle = ComboBoxStyle.DropDownList;
            ddDefaultWeather.FormattingEnabled = true;
            ddDefaultWeather.Items.AddRange(new object[] { "Clear", "Cloudy", "Overcast", "Rain", "Thunder", "Snow" });
            ddDefaultWeather.Location = new Point(110, 19);
            ddDefaultWeather.Name = "ddDefaultWeather";
            ddDefaultWeather.Size = new Size(96, 23);
            ddDefaultWeather.TabIndex = 23;
            ddDefaultWeather.SelectedIndexChanged += ddDefaultWeather_SelectedIndexChanged;
            // 
            // lbWeatherRotation
            // 
            lbWeatherRotation.AutoSize = true;
            lbWeatherRotation.Location = new Point(260, 22);
            lbWeatherRotation.Name = "lbWeatherRotation";
            lbWeatherRotation.Size = new Size(126, 15);
            lbWeatherRotation.TabIndex = 25;
            lbWeatherRotation.Text = "Weather rotation style:";
            // 
            // ddWeatherRotation
            // 
            ddWeatherRotation.DropDownStyle = ComboBoxStyle.DropDownList;
            ddWeatherRotation.FormattingEnabled = true;
            ddWeatherRotation.Items.AddRange(new object[] { "Random on load", "Random per day", "Location based" });
            ddWeatherRotation.Location = new Point(392, 19);
            ddWeatherRotation.Name = "ddWeatherRotation";
            ddWeatherRotation.Size = new Size(121, 23);
            ddWeatherRotation.TabIndex = 26;
            ddWeatherRotation.SelectedIndexChanged += ddWeatherRotation_SelectedIndexChanged;
            // 
            // ddDefaultTime
            // 
            ddDefaultTime.DropDownStyle = ComboBoxStyle.DropDownList;
            ddDefaultTime.FormattingEnabled = true;
            ddDefaultTime.Items.AddRange(new object[] { "Day", "Night", "Sunrise", "Sunset" });
            ddDefaultTime.Location = new Point(135, 19);
            ddDefaultTime.Name = "ddDefaultTime";
            ddDefaultTime.Size = new Size(96, 23);
            ddDefaultTime.TabIndex = 27;
            ddDefaultTime.SelectedIndexChanged += ddDefaultTime_SelectedIndexChanged;
            // 
            // tbLongitude
            // 
            tbLongitude.Location = new Point(413, 77);
            tbLongitude.Name = "tbLongitude";
            tbLongitude.Size = new Size(100, 23);
            tbLongitude.TabIndex = 28;
            tbLongitude.TextChanged += tbLongitude_TextChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(343, 79);
            label14.Name = "label14";
            label14.Size = new Size(64, 15);
            label14.TabIndex = 29;
            label14.Text = "Longitude:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(355, 50);
            label15.Name = "label15";
            label15.Size = new Size(53, 15);
            label15.TabIndex = 30;
            label15.Text = "Latitude:";
            // 
            // tbLatitude
            // 
            tbLatitude.Location = new Point(413, 48);
            tbLatitude.Name = "tbLatitude";
            tbLatitude.Size = new Size(100, 23);
            tbLatitude.TabIndex = 31;
            tbLatitude.TextChanged += tbLatitude_TextChanged;
            // 
            // cb24HourCaseMode
            // 
            cb24HourCaseMode.AutoSize = true;
            cb24HourCaseMode.Location = new Point(14, 202);
            cb24HourCaseMode.Name = "cb24HourCaseMode";
            cb24HourCaseMode.Size = new Size(189, 19);
            cb24HourCaseMode.TabIndex = 4;
            cb24HourCaseMode.Text = "Enable 24 Hour Case Swapping\r\n";
            cb24HourCaseMode.UseVisualStyleBackColor = true;
            cb24HourCaseMode.CheckedChanged += cb24HourCaseMode_CheckedChanged;
            // 
            // gbTimeOptions
            // 
            gbTimeOptions.Controls.Add(label22);
            gbTimeOptions.Controls.Add(cb24HourCaseMode);
            gbTimeOptions.Controls.Add(cbEnableTimeMice);
            gbTimeOptions.Controls.Add(label17);
            gbTimeOptions.Controls.Add(cbEnableTimeCase);
            gbTimeOptions.Controls.Add(ddDefaultTime);
            gbTimeOptions.Controls.Add(cbEnableTimeArea);
            gbTimeOptions.Controls.Add(cbEnableSunriseset);
            gbTimeOptions.Controls.Add(dtpSunset);
            gbTimeOptions.Controls.Add(label7);
            gbTimeOptions.Controls.Add(dtpSunrise);
            gbTimeOptions.Controls.Add(label2);
            gbTimeOptions.Location = new Point(250, 30);
            gbTimeOptions.Margin = new Padding(2);
            gbTimeOptions.Name = "gbTimeOptions";
            gbTimeOptions.Padding = new Padding(2);
            gbTimeOptions.Size = new Size(302, 248);
            gbTimeOptions.TabIndex = 20;
            gbTimeOptions.TabStop = false;
            gbTimeOptions.Text = "Day/Night Options";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(3, 223);
            label22.Name = "label22";
            label22.Size = new Size(283, 15);
            label22.TabIndex = 29;
            label22.Text = "(will disable seasons and weather swapping for case)";
            // 
            // cbEnableTimeMice
            // 
            cbEnableTimeMice.AutoSize = true;
            cbEnableTimeMice.Location = new Point(15, 95);
            cbEnableTimeMice.Name = "cbEnableTimeMice";
            cbEnableTimeMice.Size = new Size(145, 19);
            cbEnableTimeMice.TabIndex = 27;
            cbEnableTimeMice.Text = "Enable Mice Swapping";
            cbEnableTimeMice.UseVisualStyleBackColor = true;
            cbEnableTimeMice.CheckedChanged += cbEnableTimeMice_CheckedChanged;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(8, 23);
            label17.Name = "label17";
            label17.Size = new Size(114, 15);
            label17.TabIndex = 28;
            label17.Text = "Default Time of Day:";
            // 
            // cbEnableTimeCase
            // 
            cbEnableTimeCase.AutoSize = true;
            cbEnableTimeCase.Location = new Point(15, 70);
            cbEnableTimeCase.Name = "cbEnableTimeCase";
            cbEnableTimeCase.Size = new Size(144, 19);
            cbEnableTimeCase.TabIndex = 26;
            cbEnableTimeCase.Text = "Enable Case Swapping";
            cbEnableTimeCase.UseVisualStyleBackColor = true;
            cbEnableTimeCase.CheckedChanged += cbEnableTimeCase_CheckedChanged;
            // 
            // cbEnableTimeArea
            // 
            cbEnableTimeArea.AutoSize = true;
            cbEnableTimeArea.Location = new Point(15, 45);
            cbEnableTimeArea.Name = "cbEnableTimeArea";
            cbEnableTimeArea.Size = new Size(171, 19);
            cbEnableTimeArea.TabIndex = 25;
            cbEnableTimeArea.Text = "Enable Playscene Swapping";
            cbEnableTimeArea.UseVisualStyleBackColor = true;
            cbEnableTimeArea.CheckedChanged += cbEnableTimeArea_CheckedChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tpGerneral);
            tabControl1.Controls.Add(tbContentProfiles);
            tabControl1.Controls.Add(tpAutoSwap);
            tabControl1.Location = new Point(11, 11);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(570, 463);
            tabControl1.TabIndex = 21;
            // 
            // tpGerneral
            // 
            tpGerneral.Controls.Add(gbWarning);
            tpGerneral.Controls.Add(cbOpenContProf);
            tpGerneral.Controls.Add(groupBox1);
            tpGerneral.Controls.Add(label1);
            tpGerneral.Controls.Add(labelPetzExe);
            tpGerneral.Controls.Add(Credits);
            tpGerneral.Controls.Add(bnEditPetzSource);
            tpGerneral.Controls.Add(cbAlwaySettings);
            tpGerneral.Location = new Point(4, 24);
            tpGerneral.Margin = new Padding(2);
            tpGerneral.Name = "tpGerneral";
            tpGerneral.Padding = new Padding(2);
            tpGerneral.Size = new Size(562, 435);
            tpGerneral.TabIndex = 0;
            tpGerneral.Text = "General Settings";
            tpGerneral.UseVisualStyleBackColor = true;
            // 
            // gbWarning
            // 
            gbWarning.Controls.Add(label10);
            gbWarning.Location = new Point(5, 133);
            gbWarning.Name = "gbWarning";
            gbWarning.Size = new Size(552, 74);
            gbWarning.TabIndex = 25;
            gbWarning.TabStop = false;
            gbWarning.Text = "WARNING";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 19);
            label10.Name = "label10";
            label10.Size = new Size(510, 45);
            label10.TabIndex = 0;
            label10.Text = resources.GetString("label10.Text");
            // 
            // cbOpenContProf
            // 
            cbOpenContProf.AutoSize = true;
            cbOpenContProf.Enabled = false;
            cbOpenContProf.Location = new Point(7, 81);
            cbOpenContProf.Name = "cbOpenContProf";
            cbOpenContProf.Size = new Size(228, 19);
            cbOpenContProf.TabIndex = 24;
            cbOpenContProf.Text = "Always Open Content Profile Manager\r\n";
            cbOpenContProf.UseVisualStyleBackColor = true;
            cbOpenContProf.CheckedChanged += cbOpenContProf_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnResetSettings);
            groupBox1.Controls.Add(cbDisableFallback);
            groupBox1.Controls.Add(btnRegenFolders);
            groupBox1.Controls.Add(btnDeleteDebug);
            groupBox1.Controls.Add(cbLoadOrderProfilesFirst);
            groupBox1.Controls.Add(cbLoadOrderAutoSwapFirst);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(btnGenerateDebug);
            groupBox1.Location = new Point(5, 212);
            groupBox1.Margin = new Padding(2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(2);
            groupBox1.Size = new Size(552, 109);
            groupBox1.TabIndex = 23;
            groupBox1.TabStop = false;
            groupBox1.Text = "Advanced Settings";
            // 
            // btnResetSettings
            // 
            btnResetSettings.Location = new Point(144, 78);
            btnResetSettings.Name = "btnResetSettings";
            btnResetSettings.Size = new Size(98, 23);
            btnResetSettings.TabIndex = 30;
            btnResetSettings.Text = "Reset Settings";
            btnResetSettings.UseVisualStyleBackColor = true;
            btnResetSettings.Click += btnResetSettings_Click;
            // 
            // cbDisableFallback
            // 
            cbDisableFallback.AutoSize = true;
            cbDisableFallback.Enabled = false;
            cbDisableFallback.Location = new Point(348, 33);
            cbDisableFallback.Margin = new Padding(2);
            cbDisableFallback.Name = "cbDisableFallback";
            cbDisableFallback.Size = new Size(192, 19);
            cbDisableFallback.TabIndex = 20;
            cbDisableFallback.Text = "Disable Base Game File Fallback";
            cbDisableFallback.UseVisualStyleBackColor = true;
            // 
            // btnRegenFolders
            // 
            btnRegenFolders.Location = new Point(5, 78);
            btnRegenFolders.Name = "btnRegenFolders";
            btnRegenFolders.Size = new Size(133, 23);
            btnRegenFolders.TabIndex = 29;
            btnRegenFolders.Text = "Regenerate Folders";
            btnRegenFolders.UseVisualStyleBackColor = true;
            btnRegenFolders.Click += btnRegenFolders_Click;
            // 
            // btnDeleteDebug
            // 
            btnDeleteDebug.Location = new Point(438, 78);
            btnDeleteDebug.Margin = new Padding(2);
            btnDeleteDebug.Name = "btnDeleteDebug";
            btnDeleteDebug.Size = new Size(111, 23);
            btnDeleteDebug.TabIndex = 24;
            btnDeleteDebug.Text = "Delete debug.txt";
            btnDeleteDebug.UseVisualStyleBackColor = true;
            btnDeleteDebug.Click += btnDeleteDebug_Click;
            // 
            // cbLoadOrderProfilesFirst
            // 
            cbLoadOrderProfilesFirst.AutoSize = true;
            cbLoadOrderProfilesFirst.Location = new Point(15, 54);
            cbLoadOrderProfilesFirst.Margin = new Padding(2);
            cbLoadOrderProfilesFirst.Name = "cbLoadOrderProfilesFirst";
            cbLoadOrderProfilesFirst.Size = new Size(165, 19);
            cbLoadOrderProfilesFirst.TabIndex = 27;
            cbLoadOrderProfilesFirst.Text = "Load Content Profiles First";
            cbLoadOrderProfilesFirst.UseVisualStyleBackColor = true;
            cbLoadOrderProfilesFirst.CheckedChanged += cbLoadOrderProfilesFirst_CheckedChanged;
            // 
            // cbLoadOrderAutoSwapFirst
            // 
            cbLoadOrderAutoSwapFirst.AutoSize = true;
            cbLoadOrderAutoSwapFirst.Location = new Point(15, 33);
            cbLoadOrderAutoSwapFirst.Margin = new Padding(2);
            cbLoadOrderAutoSwapFirst.Name = "cbLoadOrderAutoSwapFirst";
            cbLoadOrderAutoSwapFirst.Size = new Size(209, 19);
            cbLoadOrderAutoSwapFirst.TabIndex = 26;
            cbLoadOrderAutoSwapFirst.Text = "Load AutoSwap Files First (Default)";
            cbLoadOrderAutoSwapFirst.UseVisualStyleBackColor = true;
            cbLoadOrderAutoSwapFirst.CheckedChanged += cbLoadOrderAutoSwapFirst_CheckedChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(5, 16);
            label13.Name = "label13";
            label13.Size = new Size(111, 15);
            label13.TabIndex = 22;
            label13.Text = "Custom Load Order";
            // 
            // btnGenerateDebug
            // 
            btnGenerateDebug.Location = new Point(312, 78);
            btnGenerateDebug.Margin = new Padding(2);
            btnGenerateDebug.Name = "btnGenerateDebug";
            btnGenerateDebug.Size = new Size(122, 23);
            btnGenerateDebug.TabIndex = 24;
            btnGenerateDebug.Text = "Generate debug.txt\r\n";
            btnGenerateDebug.UseVisualStyleBackColor = true;
            btnGenerateDebug.Click += btnGenerateDebug_Click;
            // 
            // tbContentProfiles
            // 
            tbContentProfiles.Controls.Add(gbLoadingOverride);
            tbContentProfiles.Controls.Add(lNameFilter);
            tbContentProfiles.Controls.Add(bnRefreshFolders);
            tbContentProfiles.Controls.Add(tbNameFilter);
            tbContentProfiles.Controls.Add(gbDeleteProfile);
            tbContentProfiles.Controls.Add(lbNotIncluded);
            tbContentProfiles.Controls.Add(lRemove);
            tbContentProfiles.Controls.Add(gbCreateNewProfile);
            tbContentProfiles.Controls.Add(lInclude);
            tbContentProfiles.Controls.Add(bnIncDown);
            tbContentProfiles.Controls.Add(lbIncluded);
            tbContentProfiles.Controls.Add(cbEnableContProf);
            tbContentProfiles.Controls.Add(bnIncUp);
            tbContentProfiles.Controls.Add(bnAddIncluded);
            tbContentProfiles.Controls.Add(bnRemoveIncluded);
            tbContentProfiles.Location = new Point(4, 24);
            tbContentProfiles.Margin = new Padding(2);
            tbContentProfiles.Name = "tbContentProfiles";
            tbContentProfiles.Size = new Size(562, 435);
            tbContentProfiles.TabIndex = 2;
            tbContentProfiles.Text = "Content Profile Settings";
            tbContentProfiles.UseVisualStyleBackColor = true;
            // 
            // gbLoadingOverride
            // 
            gbLoadingOverride.Controls.Add(cbDisableLoadingPetz);
            gbLoadingOverride.Controls.Add(cbDisableLoadingPetzRez);
            gbLoadingOverride.Controls.Add(cbDisableLoadingResources);
            gbLoadingOverride.Location = new Point(296, 207);
            gbLoadingOverride.Name = "gbLoadingOverride";
            gbLoadingOverride.Size = new Size(256, 94);
            gbLoadingOverride.TabIndex = 25;
            gbLoadingOverride.TabStop = false;
            gbLoadingOverride.Text = "Loading Override Settings";
            // 
            // cbDisableLoadingPetz
            // 
            cbDisableLoadingPetz.AutoSize = true;
            cbDisableLoadingPetz.Location = new Point(6, 48);
            cbDisableLoadingPetz.Name = "cbDisableLoadingPetz";
            cbDisableLoadingPetz.Size = new Size(184, 19);
            cbDisableLoadingPetz.TabIndex = 22;
            cbDisableLoadingPetz.Text = "Disable Loading Adopted Petz";
            cbDisableLoadingPetz.UseVisualStyleBackColor = true;
            cbDisableLoadingPetz.CheckedChanged += cbDisableLoadingPetz_CheckedChanged;
            // 
            // cbDisableLoadingPetzRez
            // 
            cbDisableLoadingPetzRez.AutoSize = true;
            cbDisableLoadingPetzRez.Location = new Point(6, 73);
            cbDisableLoadingPetzRez.Name = "cbDisableLoadingPetzRez";
            cbDisableLoadingPetzRez.Size = new Size(209, 19);
            cbDisableLoadingPetzRez.TabIndex = 24;
            cbDisableLoadingPetzRez.Text = "Disable Loading PetzRez Resources";
            cbDisableLoadingPetzRez.UseVisualStyleBackColor = true;
            cbDisableLoadingPetzRez.CheckedChanged += cbDisableLoadingPetzRez_CheckedChanged;
            // 
            // cbDisableLoadingResources
            // 
            cbDisableLoadingResources.AutoSize = true;
            cbDisableLoadingResources.Location = new Point(6, 23);
            cbDisableLoadingResources.Name = "cbDisableLoadingResources";
            cbDisableLoadingResources.Size = new Size(166, 19);
            cbDisableLoadingResources.TabIndex = 23;
            cbDisableLoadingResources.Text = "Disable Loading Resources";
            cbDisableLoadingResources.UseVisualStyleBackColor = true;
            cbDisableLoadingResources.CheckedChanged += cbDisableLoadingResources_CheckedChanged;
            // 
            // lNameFilter
            // 
            lNameFilter.AutoSize = true;
            lNameFilter.Location = new Point(41, 181);
            lNameFilter.Name = "lNameFilter";
            lNameFilter.Size = new Size(71, 15);
            lNameFilter.TabIndex = 23;
            lNameFilter.Text = "Name Filter:";
            // 
            // tbNameFilter
            // 
            tbNameFilter.Location = new Point(118, 178);
            tbNameFilter.Name = "tbNameFilter";
            tbNameFilter.Size = new Size(157, 23);
            tbNameFilter.TabIndex = 22;
            tbNameFilter.TextChanged += tbNameFilter_TextChanged;
            // 
            // gbDeleteProfile
            // 
            gbDeleteProfile.Controls.Add(label28);
            gbDeleteProfile.Controls.Add(ddDeleteProfile);
            gbDeleteProfile.Controls.Add(btnDeleteProfile);
            gbDeleteProfile.Location = new Point(296, 304);
            gbDeleteProfile.Margin = new Padding(2);
            gbDeleteProfile.Name = "gbDeleteProfile";
            gbDeleteProfile.Padding = new Padding(2);
            gbDeleteProfile.Size = new Size(256, 126);
            gbDeleteProfile.TabIndex = 22;
            gbDeleteProfile.TabStop = false;
            gbDeleteProfile.Text = "Delete Profile";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(4, 43);
            label28.Margin = new Padding(2, 0, 2, 0);
            label28.Name = "label28";
            label28.Size = new Size(239, 75);
            label28.TabIndex = 23;
            label28.Text = resources.GetString("label28.Text");
            // 
            // ddDeleteProfile
            // 
            ddDeleteProfile.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ddDeleteProfile.AutoCompleteSource = AutoCompleteSource.ListItems;
            ddDeleteProfile.FormattingEnabled = true;
            ddDeleteProfile.Location = new Point(4, 18);
            ddDeleteProfile.Margin = new Padding(2);
            ddDeleteProfile.Name = "ddDeleteProfile";
            ddDeleteProfile.Size = new Size(129, 23);
            ddDeleteProfile.TabIndex = 22;
            // 
            // btnDeleteProfile
            // 
            btnDeleteProfile.Location = new Point(137, 18);
            btnDeleteProfile.Margin = new Padding(2);
            btnDeleteProfile.Name = "btnDeleteProfile";
            btnDeleteProfile.Size = new Size(89, 23);
            btnDeleteProfile.TabIndex = 20;
            btnDeleteProfile.Text = "Delete Profile";
            btnDeleteProfile.UseVisualStyleBackColor = true;
            btnDeleteProfile.Click += btnDeleteProfile_Click;
            // 
            // gbCreateNewProfile
            // 
            gbCreateNewProfile.Controls.Add(btnNpClear);
            gbCreateNewProfile.Controls.Add(cbNpACSprites);
            gbCreateNewProfile.Controls.Add(label27);
            gbCreateNewProfile.Controls.Add(tbNpName);
            gbCreateNewProfile.Controls.Add(btnCreateProfile);
            gbCreateNewProfile.Controls.Add(cbNpMice);
            gbCreateNewProfile.Controls.Add(cbNpCase);
            gbCreateNewProfile.Controls.Add(cbNpPalettes);
            gbCreateNewProfile.Controls.Add(cbNpTextures);
            gbCreateNewProfile.Controls.Add(cbNpToyz);
            gbCreateNewProfile.Controls.Add(cbNpSongz);
            gbCreateNewProfile.Controls.Add(cbNpWallpaper);
            gbCreateNewProfile.Controls.Add(cbNpAdoptedPetz);
            gbCreateNewProfile.Controls.Add(cbNpClothes);
            gbCreateNewProfile.Controls.Add(cbNpDogz);
            gbCreateNewProfile.Controls.Add(label26);
            gbCreateNewProfile.Controls.Add(cbNpArea);
            gbCreateNewProfile.Controls.Add(cbNpCatz);
            gbCreateNewProfile.Location = new Point(6, 207);
            gbCreateNewProfile.Margin = new Padding(2);
            gbCreateNewProfile.Name = "gbCreateNewProfile";
            gbCreateNewProfile.Padding = new Padding(2);
            gbCreateNewProfile.Size = new Size(285, 223);
            gbCreateNewProfile.TabIndex = 19;
            gbCreateNewProfile.TabStop = false;
            gbCreateNewProfile.Text = "Create New Profile";
            // 
            // btnNpClear
            // 
            btnNpClear.Location = new Point(4, 196);
            btnNpClear.Margin = new Padding(2);
            btnNpClear.Name = "btnNpClear";
            btnNpClear.Size = new Size(105, 23);
            btnNpClear.TabIndex = 17;
            btnNpClear.Text = "Clear Selection";
            btnNpClear.UseVisualStyleBackColor = true;
            btnNpClear.Click += btnNpClear_Click;
            // 
            // cbNpACSprites
            // 
            cbNpACSprites.AutoSize = true;
            cbNpACSprites.Location = new Point(146, 173);
            cbNpACSprites.Margin = new Padding(2);
            cbNpACSprites.Name = "cbNpACSprites";
            cbNpACSprites.Size = new Size(122, 19);
            cbNpACSprites.TabIndex = 16;
            cbNpACSprites.Text = "Include AC Sprites";
            cbNpACSprites.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(7, 22);
            label27.Margin = new Padding(2, 0, 2, 0);
            label27.Name = "label27";
            label27.Size = new Size(42, 15);
            label27.TabIndex = 15;
            label27.Text = "Name:";
            // 
            // tbNpName
            // 
            tbNpName.Location = new Point(52, 19);
            tbNpName.Margin = new Padding(2);
            tbNpName.Name = "tbNpName";
            tbNpName.Size = new Size(217, 23);
            tbNpName.TabIndex = 14;
            // 
            // btnCreateProfile
            // 
            btnCreateProfile.Location = new Point(192, 196);
            btnCreateProfile.Margin = new Padding(2);
            btnCreateProfile.Name = "btnCreateProfile";
            btnCreateProfile.Size = new Size(89, 23);
            btnCreateProfile.TabIndex = 13;
            btnCreateProfile.Text = "Create Profile";
            btnCreateProfile.UseVisualStyleBackColor = true;
            btnCreateProfile.Click += btnCreateProfile_Click;
            // 
            // cbNpMice
            // 
            cbNpMice.AutoSize = true;
            cbNpMice.Location = new Point(146, 150);
            cbNpMice.Margin = new Padding(2);
            cbNpMice.Name = "cbNpMice";
            cbNpMice.Size = new Size(97, 19);
            cbNpMice.TabIndex = 12;
            cbNpMice.Text = "Include Mice ";
            cbNpMice.UseVisualStyleBackColor = true;
            // 
            // cbNpCase
            // 
            cbNpCase.AutoSize = true;
            cbNpCase.Location = new Point(4, 173);
            cbNpCase.Margin = new Padding(2);
            cbNpCase.Name = "cbNpCase";
            cbNpCase.Size = new Size(141, 19);
            cbNpCase.TabIndex = 11;
            cbNpCase.Text = "Include Carrying Case";
            cbNpCase.UseVisualStyleBackColor = true;
            // 
            // cbNpPalettes
            // 
            cbNpPalettes.AutoSize = true;
            cbNpPalettes.Location = new Point(83, 117);
            cbNpPalettes.Margin = new Padding(2);
            cbNpPalettes.Name = "cbNpPalettes";
            cbNpPalettes.Size = new Size(67, 19);
            cbNpPalettes.TabIndex = 10;
            cbNpPalettes.Text = "Palettes";
            cbNpPalettes.UseVisualStyleBackColor = true;
            // 
            // cbNpTextures
            // 
            cbNpTextures.AutoSize = true;
            cbNpTextures.Location = new Point(11, 117);
            cbNpTextures.Margin = new Padding(2);
            cbNpTextures.Name = "cbNpTextures";
            cbNpTextures.Size = new Size(69, 19);
            cbNpTextures.TabIndex = 9;
            cbNpTextures.Text = "Textures";
            cbNpTextures.UseVisualStyleBackColor = true;
            // 
            // cbNpToyz
            // 
            cbNpToyz.AutoSize = true;
            cbNpToyz.Location = new Point(73, 94);
            cbNpToyz.Margin = new Padding(2);
            cbNpToyz.Name = "cbNpToyz";
            cbNpToyz.Size = new Size(49, 19);
            cbNpToyz.TabIndex = 8;
            cbNpToyz.Text = "Toyz";
            cbNpToyz.UseVisualStyleBackColor = true;
            // 
            // cbNpSongz
            // 
            cbNpSongz.AutoSize = true;
            cbNpSongz.Location = new Point(11, 94);
            cbNpSongz.Margin = new Padding(2);
            cbNpSongz.Name = "cbNpSongz";
            cbNpSongz.Size = new Size(58, 19);
            cbNpSongz.TabIndex = 7;
            cbNpSongz.Text = "Songz";
            cbNpSongz.UseVisualStyleBackColor = true;
            // 
            // cbNpWallpaper
            // 
            cbNpWallpaper.AutoSize = true;
            cbNpWallpaper.Location = new Point(126, 94);
            cbNpWallpaper.Margin = new Padding(2);
            cbNpWallpaper.Name = "cbNpWallpaper";
            cbNpWallpaper.Size = new Size(79, 19);
            cbNpWallpaper.TabIndex = 6;
            cbNpWallpaper.Text = "Wallpaper";
            cbNpWallpaper.UseVisualStyleBackColor = true;
            // 
            // cbNpAdoptedPetz
            // 
            cbNpAdoptedPetz.AutoSize = true;
            cbNpAdoptedPetz.Location = new Point(4, 150);
            cbNpAdoptedPetz.Margin = new Padding(2);
            cbNpAdoptedPetz.Name = "cbNpAdoptedPetz";
            cbNpAdoptedPetz.Size = new Size(139, 19);
            cbNpAdoptedPetz.TabIndex = 0;
            cbNpAdoptedPetz.Text = "Include Adopted Petz";
            cbNpAdoptedPetz.UseVisualStyleBackColor = true;
            // 
            // cbNpClothes
            // 
            cbNpClothes.AutoSize = true;
            cbNpClothes.Location = new Point(118, 71);
            cbNpClothes.Margin = new Padding(2);
            cbNpClothes.Name = "cbNpClothes";
            cbNpClothes.Size = new Size(66, 19);
            cbNpClothes.TabIndex = 5;
            cbNpClothes.Text = "Clothes";
            cbNpClothes.UseVisualStyleBackColor = true;
            // 
            // cbNpDogz
            // 
            cbNpDogz.AutoSize = true;
            cbNpDogz.Location = new Point(190, 71);
            cbNpDogz.Margin = new Padding(2);
            cbNpDogz.Name = "cbNpDogz";
            cbNpDogz.Size = new Size(53, 19);
            cbNpDogz.TabIndex = 4;
            cbNpDogz.Text = "Dogz";
            cbNpDogz.UseVisualStyleBackColor = true;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(6, 50);
            label26.Margin = new Padding(2, 0, 2, 0);
            label26.Name = "label26";
            label26.Size = new Size(116, 15);
            label26.TabIndex = 3;
            label26.Text = "Resources to Include";
            // 
            // cbNpArea
            // 
            cbNpArea.AutoSize = true;
            cbNpArea.Location = new Point(11, 71);
            cbNpArea.Margin = new Padding(2);
            cbNpArea.Name = "cbNpArea";
            cbNpArea.Size = new Size(50, 19);
            cbNpArea.TabIndex = 2;
            cbNpArea.Text = "Area";
            cbNpArea.UseVisualStyleBackColor = true;
            // 
            // cbNpCatz
            // 
            cbNpCatz.AutoSize = true;
            cbNpCatz.Location = new Point(65, 71);
            cbNpCatz.Margin = new Padding(2);
            cbNpCatz.Name = "cbNpCatz";
            cbNpCatz.Size = new Size(49, 19);
            cbNpCatz.TabIndex = 1;
            cbNpCatz.Text = "Catz";
            cbNpCatz.UseVisualStyleBackColor = true;
            // 
            // tpAutoSwap
            // 
            tpAutoSwap.Controls.Add(cbEnableAutoSwapping);
            tpAutoSwap.Controls.Add(gbTimeOptions);
            tpAutoSwap.Controls.Add(gbSeasonalOptions);
            tpAutoSwap.Controls.Add(label21);
            tpAutoSwap.Controls.Add(gbWeatherOptions);
            tpAutoSwap.Location = new Point(4, 24);
            tpAutoSwap.Margin = new Padding(2);
            tpAutoSwap.Name = "tpAutoSwap";
            tpAutoSwap.Padding = new Padding(2);
            tpAutoSwap.Size = new Size(562, 435);
            tpAutoSwap.TabIndex = 1;
            tpAutoSwap.Text = "Auto Swap Settings";
            tpAutoSwap.UseVisualStyleBackColor = true;
            // 
            // gbSeasonalOptions
            // 
            gbSeasonalOptions.Controls.Add(cbEnableSeasonalArea);
            gbSeasonalOptions.Controls.Add(cbEnableSeasonalCase);
            gbSeasonalOptions.Controls.Add(cbEnableSeasonalMice);
            gbSeasonalOptions.Controls.Add(label18);
            gbSeasonalOptions.Controls.Add(dtpFallStart);
            gbSeasonalOptions.Controls.Add(label6);
            gbSeasonalOptions.Controls.Add(ddDefaultSeason);
            gbSeasonalOptions.Controls.Add(label5);
            gbSeasonalOptions.Controls.Add(dtpSummerStart);
            gbSeasonalOptions.Controls.Add(label3);
            gbSeasonalOptions.Controls.Add(dtpSpringStart);
            gbSeasonalOptions.Controls.Add(dtpWinterStart);
            gbSeasonalOptions.Controls.Add(label4);
            gbSeasonalOptions.Location = new Point(5, 30);
            gbSeasonalOptions.Name = "gbSeasonalOptions";
            gbSeasonalOptions.Size = new Size(240, 248);
            gbSeasonalOptions.TabIndex = 22;
            gbSeasonalOptions.TabStop = false;
            gbSeasonalOptions.Text = "Seasonal Options";
            // 
            // cbEnableSeasonalArea
            // 
            cbEnableSeasonalArea.AutoSize = true;
            cbEnableSeasonalArea.Location = new Point(14, 49);
            cbEnableSeasonalArea.Name = "cbEnableSeasonalArea";
            cbEnableSeasonalArea.Size = new Size(171, 19);
            cbEnableSeasonalArea.TabIndex = 27;
            cbEnableSeasonalArea.Text = "Enable Playscene Swapping";
            cbEnableSeasonalArea.UseVisualStyleBackColor = true;
            cbEnableSeasonalArea.CheckedChanged += cbEnableSeasonalArea_CheckedChanged;
            // 
            // cbEnableSeasonalCase
            // 
            cbEnableSeasonalCase.AutoSize = true;
            cbEnableSeasonalCase.Location = new Point(14, 74);
            cbEnableSeasonalCase.Name = "cbEnableSeasonalCase";
            cbEnableSeasonalCase.Size = new Size(144, 19);
            cbEnableSeasonalCase.TabIndex = 26;
            cbEnableSeasonalCase.Text = "Enable Case Swapping";
            cbEnableSeasonalCase.UseVisualStyleBackColor = true;
            cbEnableSeasonalCase.CheckedChanged += cbEnableSeasonalCase_CheckedChanged;
            // 
            // cbEnableSeasonalMice
            // 
            cbEnableSeasonalMice.AutoSize = true;
            cbEnableSeasonalMice.Location = new Point(13, 99);
            cbEnableSeasonalMice.Name = "cbEnableSeasonalMice";
            cbEnableSeasonalMice.Size = new Size(145, 19);
            cbEnableSeasonalMice.TabIndex = 25;
            cbEnableSeasonalMice.Text = "Enable Mice Swapping";
            cbEnableSeasonalMice.UseVisualStyleBackColor = true;
            cbEnableSeasonalMice.CheckedChanged += cbEnableSeasonalMice_CheckedChanged;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(6, 23);
            label18.Name = "label18";
            label18.Size = new Size(91, 15);
            label18.TabIndex = 20;
            label18.Text = "Default Season: ";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(5, 411);
            label21.Name = "label21";
            label21.Size = new Size(468, 15);
            label21.TabIndex = 23;
            label21.Text = "Tip: Default selects the folder that will be loaded if that style of swapping is not enabled.\r\n";
            // 
            // gbWeatherOptions
            // 
            gbWeatherOptions.Controls.Add(cbEnableWeatherMice);
            gbWeatherOptions.Controls.Add(cbEnableWeatherCase);
            gbWeatherOptions.Controls.Add(cbEnableWeatherArea);
            gbWeatherOptions.Controls.Add(label19);
            gbWeatherOptions.Controls.Add(tbLongitude);
            gbWeatherOptions.Controls.Add(label14);
            gbWeatherOptions.Controls.Add(ddDefaultWeather);
            gbWeatherOptions.Controls.Add(tbLatitude);
            gbWeatherOptions.Controls.Add(label15);
            gbWeatherOptions.Controls.Add(lbWeatherRotation);
            gbWeatherOptions.Controls.Add(ddWeatherRotation);
            gbWeatherOptions.Location = new Point(5, 284);
            gbWeatherOptions.Name = "gbWeatherOptions";
            gbWeatherOptions.Size = new Size(547, 124);
            gbWeatherOptions.TabIndex = 21;
            gbWeatherOptions.TabStop = false;
            gbWeatherOptions.Text = "Weather Options";
            // 
            // cbEnableWeatherMice
            // 
            cbEnableWeatherMice.AutoSize = true;
            cbEnableWeatherMice.Location = new Point(30, 98);
            cbEnableWeatherMice.Name = "cbEnableWeatherMice";
            cbEnableWeatherMice.Size = new Size(145, 19);
            cbEnableWeatherMice.TabIndex = 35;
            cbEnableWeatherMice.Text = "Enable Mice Swapping";
            cbEnableWeatherMice.UseVisualStyleBackColor = true;
            cbEnableWeatherMice.CheckedChanged += cbEnableWeatherMice_CheckedChanged;
            // 
            // cbEnableWeatherCase
            // 
            cbEnableWeatherCase.AutoSize = true;
            cbEnableWeatherCase.Location = new Point(30, 73);
            cbEnableWeatherCase.Name = "cbEnableWeatherCase";
            cbEnableWeatherCase.Size = new Size(144, 19);
            cbEnableWeatherCase.TabIndex = 34;
            cbEnableWeatherCase.Text = "Enable Case Swapping";
            cbEnableWeatherCase.UseVisualStyleBackColor = true;
            cbEnableWeatherCase.CheckedChanged += cbEnableWeatherCase_CheckedChanged;
            // 
            // cbEnableWeatherArea
            // 
            cbEnableWeatherArea.AutoSize = true;
            cbEnableWeatherArea.Location = new Point(30, 48);
            cbEnableWeatherArea.Name = "cbEnableWeatherArea";
            cbEnableWeatherArea.Size = new Size(171, 19);
            cbEnableWeatherArea.TabIndex = 33;
            cbEnableWeatherArea.Text = "Enable Playscene Swapping";
            cbEnableWeatherArea.UseVisualStyleBackColor = true;
            cbEnableWeatherArea.CheckedChanged += cbEnableWeatherArea_CheckedChanged;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(6, 22);
            label19.Name = "label19";
            label19.Size = new Size(98, 15);
            label19.TabIndex = 32;
            label19.Text = "Default Weather: ";
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(591, 515);
            Controls.Add(tabControl1);
            Controls.Add(btnSave);
            Controls.Add(btnStartPetz);
            Controls.Add(btnHelp);
            Name = "FormSettings";
            Text = "Petz EZLoader Settings";
            FormClosing += FormSettings_FormClosing;
            Credits.ResumeLayout(false);
            Credits.PerformLayout();
            gbTimeOptions.ResumeLayout(false);
            gbTimeOptions.PerformLayout();
            tabControl1.ResumeLayout(false);
            tpGerneral.ResumeLayout(false);
            tpGerneral.PerformLayout();
            gbWarning.ResumeLayout(false);
            gbWarning.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tbContentProfiles.ResumeLayout(false);
            tbContentProfiles.PerformLayout();
            gbLoadingOverride.ResumeLayout(false);
            gbLoadingOverride.PerformLayout();
            gbDeleteProfile.ResumeLayout(false);
            gbDeleteProfile.PerformLayout();
            gbCreateNewProfile.ResumeLayout(false);
            gbCreateNewProfile.PerformLayout();
            tpAutoSwap.ResumeLayout(false);
            tpAutoSwap.PerformLayout();
            gbSeasonalOptions.ResumeLayout(false);
            gbSeasonalOptions.PerformLayout();
            gbWeatherOptions.ResumeLayout(false);
            gbWeatherOptions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Label labelPetzExe;
        private Button bnEditPetzSource;
        private Button btnSave;
        private Button btnStartPetz;
        private ToolTip toolTip1;
        private GroupBox Credits;
        private LinkLabel linkAliveEnough;
        private Label label9;
        private Label label8;
        private ListBox lbNotIncluded;
        private ListBox lbIncluded;
        private Button bnRemoveIncluded;
        private Button bnAddIncluded;
        private Label lInclude;
        private Label lRemove;
        private CheckBox cbEnableContProf;
        private Button bnRefreshFolders;
        private CheckBox cbAlwaySettings;
        private Button bnIncDown;
        private Button bnIncUp;
        private LinkLabel linkOpenMeteo;
        private Label label16;
        private Label label12;
        private Button btnHelp;
        private DateTimePicker dtpWinterStart;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label6;
        private DateTimePicker dtpSpringStart;
        private CheckBox cbEnableAutoSwapping;
        private DateTimePicker dtpSummerStart;
        private DateTimePicker dtpFallStart;
        private DateTimePicker dtpSunrise;
        private Label label2;
        private DateTimePicker dtpSunset;
        private Label label7;
        private ComboBox ddDefaultSeason;
        private CheckBox cbEnableSunriseset;
        private ComboBox ddDefaultWeather;
        private Label lbWeatherRotation;
        private ComboBox ddWeatherRotation;
        private ComboBox ddDefaultTime;
        private TextBox tbLongitude;
        private Label label14;
        private Label label15;
        private TextBox tbLatitude;
        private GroupBox gbTimeOptions;
        private TabControl tabControl1;
        private TabPage tpGerneral;
        private TabPage tpAutoSwap;
        private TabPage tbContentProfiles;
        private GroupBox gbWeatherOptions;
        private GroupBox gbSeasonalOptions;
        private CheckBox cb24HourCaseMode;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label13;
        private CheckBox cbEnableSeasonalCase;
        private CheckBox cbEnableSeasonalMice;
        private CheckBox cbEnableSeasonalArea;
        private Label label21;
        private CheckBox cbEnableTimeCase;
        private CheckBox cbEnableTimeArea;
        private CheckBox cbEnableTimeMice;
        private Label label22;
        private CheckBox cbEnableWeatherMice;
        private CheckBox cbEnableWeatherCase;
        private CheckBox cbEnableWeatherArea;
        private Button btnGenerateDebug;
        private GroupBox groupBox1;
        private Label label23;
        private CheckBox cbLoadOrderProfilesFirst;
        private CheckBox cbLoadOrderAutoSwapFirst;
        private Button btnDeleteDebug;
        private GroupBox gbCreateNewProfile;
        private CheckBox cbNpSongz;
        private CheckBox cbNpWallpaper;
        private CheckBox cbNpClothes;
        private CheckBox cbNpDogz;
        private Label label26;
        private CheckBox cbNpArea;
        private CheckBox cbNpCatz;
        private CheckBox cbNpAdoptedPetz;
        private Label label27;
        private TextBox tbNpName;
        private Button btnCreateProfile;
        private CheckBox cbNpMice;
        private CheckBox cbNpCase;
        private CheckBox cbNpPalettes;
        private CheckBox cbNpTextures;
        private CheckBox cbNpToyz;
        private LinkLabel linkGithub;
        private CheckBox cbDisableFallback;
        private CheckBox cbNpACSprites;
        private Button btnDeleteProfile;
        private ComboBox ddDeleteProfile;
        private Label label28;
        private GroupBox gbDeleteProfile;
        private Button btnNpClear;
        private Label lNameFilter;
        private TextBox tbNameFilter;
        private CheckBox cbOpenContProf;
        private Button btnResetSettings;
        private Button btnRegenFolders;
        private CheckBox cbDisableLoadingPetz;
        private CheckBox cbDisableLoadingResources;
        private CheckBox cbDisableLoadingPetzRez;
        private GroupBox gbLoadingOverride;
        private GroupBox gbWarning;
        private Label label10;
    }
}
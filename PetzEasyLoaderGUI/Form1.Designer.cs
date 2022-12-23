namespace PetzEasyLoaderGUI
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPetzExe = new System.Windows.Forms.Label();
            this.bnEditPetzSource = new System.Windows.Forms.Button();
            this.bnSave = new System.Windows.Forms.Button();
            this.bnStartPetz = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Credits = new System.Windows.Forms.GroupBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbNotIncluded = new System.Windows.Forms.ListBox();
            this.lbIncluded = new System.Windows.Forms.ListBox();
            this.bnRemoveIncluded = new System.Windows.Forms.Button();
            this.bnAddIncluded = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bnIncDown = new System.Windows.Forms.Button();
            this.bnIncUp = new System.Windows.Forms.Button();
            this.bnRefreshFolders = new System.Windows.Forms.Button();
            this.cbEnableBulk = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbAlwaySettings = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dtpWinterStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpSpringStart = new System.Windows.Forms.DateTimePicker();
            this.cbEnableSceneSwapping = new System.Windows.Forms.CheckBox();
            this.dtpSummerStart = new System.Windows.Forms.DateTimePicker();
            this.cbForceTime = new System.Windows.Forms.CheckBox();
            this.dtpFallStart = new System.Windows.Forms.DateTimePicker();
            this.dtpSunrise = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpSunset = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.ddForceSeason = new System.Windows.Forms.ComboBox();
            this.cbEnableSunriseset = new System.Windows.Forms.CheckBox();
            this.cbForceWeather = new System.Windows.Forms.CheckBox();
            this.ddForceWeather = new System.Windows.Forms.ComboBox();
            this.cbForceSeason = new System.Windows.Forms.CheckBox();
            this.lbWeatherRotation = new System.Windows.Forms.Label();
            this.ddWeatherRotation = new System.Windows.Forms.ComboBox();
            this.ddForceTime = new System.Windows.Forms.ComboBox();
            this.tbLongitude = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbLatitude = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Credits.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Petz Source:";
            // 
            // labelPetzExe
            // 
            this.labelPetzExe.AutoEllipsis = true;
            this.labelPetzExe.AutoSize = true;
            this.labelPetzExe.Location = new System.Drawing.Point(82, 9);
            this.labelPetzExe.MaximumSize = new System.Drawing.Size(525, 15);
            this.labelPetzExe.Name = "labelPetzExe";
            this.labelPetzExe.Size = new System.Drawing.Size(517, 15);
            this.labelPetzExe.TabIndex = 3;
            this.labelPetzExe.Text = "Please select main petz folder Please select main petz folder Please select main " +
    "petz folder Please select main petz folder";
            this.toolTip1.SetToolTip(this.labelPetzExe, "test");
            // 
            // bnEditPetzSource
            // 
            this.bnEditPetzSource.Location = new System.Drawing.Point(12, 27);
            this.bnEditPetzSource.Name = "bnEditPetzSource";
            this.bnEditPetzSource.Size = new System.Drawing.Size(94, 23);
            this.bnEditPetzSource.TabIndex = 0;
            this.bnEditPetzSource.Text = "Edit Source";
            this.bnEditPetzSource.UseVisualStyleBackColor = true;
            this.bnEditPetzSource.Click += new System.EventHandler(this.bnEditPetzSource_Click);
            // 
            // bnSave
            // 
            this.bnSave.Location = new System.Drawing.Point(368, 320);
            this.bnSave.Name = "bnSave";
            this.bnSave.Size = new System.Drawing.Size(71, 23);
            this.bnSave.TabIndex = 16;
            this.bnSave.Text = "Save";
            this.bnSave.UseVisualStyleBackColor = true;
            this.bnSave.Click += new System.EventHandler(this.bnSave_Click);
            // 
            // bnStartPetz
            // 
            this.bnStartPetz.Location = new System.Drawing.Point(472, 320);
            this.bnStartPetz.Name = "bnStartPetz";
            this.bnStartPetz.Size = new System.Drawing.Size(127, 23);
            this.bnStartPetz.TabIndex = 17;
            this.bnStartPetz.Text = "Save and Start Petz";
            this.bnStartPetz.UseVisualStyleBackColor = true;
            this.bnStartPetz.Click += new System.EventHandler(this.bnStartPetz_Click);
            // 
            // Credits
            // 
            this.Credits.Controls.Add(this.linkLabel2);
            this.Credits.Controls.Add(this.label16);
            this.Credits.Controls.Add(this.label13);
            this.Credits.Controls.Add(this.label12);
            this.Credits.Controls.Add(this.linkLabel1);
            this.Credits.Controls.Add(this.label9);
            this.Credits.Controls.Add(this.label8);
            this.Credits.Location = new System.Drawing.Point(362, 368);
            this.Credits.Name = "Credits";
            this.Credits.Size = new System.Drawing.Size(237, 149);
            this.Credits.TabIndex = 18;
            this.Credits.TabStop = false;
            this.Credits.Text = "Info";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(8, 84);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(145, 15);
            this.linkLabel2.TabIndex = 22;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "https://open-meteo.com/";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 69);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(214, 15);
            this.label16.TabIndex = 21;
            this.label16.Text = "Weather data provided by Open-Meteo";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 15);
            this.label13.TabIndex = 20;
            this.label13.Text = "and Kyle T. <3";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(179, 15);
            this.label12.TabIndex = 19;
            this.label12.Text = "special thanks to ButterflyChaser\r\n";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(6, 47);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(221, 15);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://oodlecat.meowandsparkle.party/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "version 2.0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(186, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "created by skissors@Alive Enough";
            // 
            // lbNotIncluded
            // 
            this.lbNotIncluded.FormattingEnabled = true;
            this.lbNotIncluded.ItemHeight = 15;
            this.lbNotIncluded.Location = new System.Drawing.Point(200, 66);
            this.lbNotIncluded.Margin = new System.Windows.Forms.Padding(2);
            this.lbNotIncluded.Name = "lbNotIncluded";
            this.lbNotIncluded.Size = new System.Drawing.Size(127, 94);
            this.lbNotIncluded.TabIndex = 11;
            // 
            // lbIncluded
            // 
            this.lbIncluded.FormattingEnabled = true;
            this.lbIncluded.ItemHeight = 15;
            this.lbIncluded.Location = new System.Drawing.Point(36, 66);
            this.lbIncluded.Margin = new System.Windows.Forms.Padding(2);
            this.lbIncluded.Name = "lbIncluded";
            this.lbIncluded.Size = new System.Drawing.Size(127, 94);
            this.lbIncluded.TabIndex = 12;
            // 
            // bnRemoveIncluded
            // 
            this.bnRemoveIncluded.Location = new System.Drawing.Point(166, 94);
            this.bnRemoveIncluded.Margin = new System.Windows.Forms.Padding(2);
            this.bnRemoveIncluded.Name = "bnRemoveIncluded";
            this.bnRemoveIncluded.Size = new System.Drawing.Size(30, 20);
            this.bnRemoveIncluded.TabIndex = 14;
            this.bnRemoveIncluded.Text = ">";
            this.bnRemoveIncluded.UseVisualStyleBackColor = true;
            this.bnRemoveIncluded.Click += new System.EventHandler(this.bnRemoveIncluded_Click);
            // 
            // bnAddIncluded
            // 
            this.bnAddIncluded.Location = new System.Drawing.Point(166, 118);
            this.bnAddIncluded.Margin = new System.Windows.Forms.Padding(2);
            this.bnAddIncluded.Name = "bnAddIncluded";
            this.bnAddIncluded.Size = new System.Drawing.Size(30, 20);
            this.bnAddIncluded.TabIndex = 13;
            this.bnAddIncluded.Text = "<";
            this.bnAddIncluded.UseVisualStyleBackColor = true;
            this.bnAddIncluded.Click += new System.EventHandler(this.bnAddIncluded_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bnIncDown);
            this.groupBox2.Controls.Add(this.bnIncUp);
            this.groupBox2.Controls.Add(this.bnRefreshFolders);
            this.groupBox2.Controls.Add(this.cbEnableBulk);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lbNotIncluded);
            this.groupBox2.Controls.Add(this.bnAddIncluded);
            this.groupBox2.Controls.Add(this.lbIncluded);
            this.groupBox2.Controls.Add(this.bnRemoveIncluded);
            this.groupBox2.Location = new System.Drawing.Point(12, 319);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(339, 198);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bulk Content Settings";
            // 
            // bnIncDown
            // 
            this.bnIncDown.Location = new System.Drawing.Point(8, 118);
            this.bnIncDown.Margin = new System.Windows.Forms.Padding(2);
            this.bnIncDown.Name = "bnIncDown";
            this.bnIncDown.Size = new System.Drawing.Size(24, 20);
            this.bnIncDown.TabIndex = 18;
            this.bnIncDown.Text = "▼";
            this.bnIncDown.UseVisualStyleBackColor = true;
            this.bnIncDown.Click += new System.EventHandler(this.bnIncDown_Click);
            // 
            // bnIncUp
            // 
            this.bnIncUp.Location = new System.Drawing.Point(8, 94);
            this.bnIncUp.Margin = new System.Windows.Forms.Padding(2);
            this.bnIncUp.Name = "bnIncUp";
            this.bnIncUp.Size = new System.Drawing.Size(24, 20);
            this.bnIncUp.TabIndex = 17;
            this.bnIncUp.Text = "▲";
            this.bnIncUp.UseVisualStyleBackColor = true;
            this.bnIncUp.Click += new System.EventHandler(this.bnIncUp_Click);
            // 
            // bnRefreshFolders
            // 
            this.bnRefreshFolders.Location = new System.Drawing.Point(127, 170);
            this.bnRefreshFolders.Name = "bnRefreshFolders";
            this.bnRefreshFolders.Size = new System.Drawing.Size(105, 23);
            this.bnRefreshFolders.TabIndex = 15;
            this.bnRefreshFolders.Text = "Refresh Folders";
            this.bnRefreshFolders.UseVisualStyleBackColor = true;
            this.bnRefreshFolders.Click += new System.EventHandler(this.bnRefreshFolders_Click);
            // 
            // cbEnableBulk
            // 
            this.cbEnableBulk.AutoSize = true;
            this.cbEnableBulk.Location = new System.Drawing.Point(5, 19);
            this.cbEnableBulk.Name = "cbEnableBulk";
            this.cbEnableBulk.Size = new System.Drawing.Size(174, 19);
            this.cbEnableBulk.TabIndex = 10;
            this.cbEnableBulk.Text = "Enable bulk content loading";
            this.cbEnableBulk.UseVisualStyleBackColor = true;
            this.cbEnableBulk.CheckedChanged += new System.EventHandler(this.cbEnableBulk_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(36, 49);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 15);
            this.label11.TabIndex = 13;
            this.label11.Text = "Include";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(200, 49);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 15);
            this.label10.TabIndex = 12;
            this.label10.Text = "Remove";
            // 
            // cbAlwaySettings
            // 
            this.cbAlwaySettings.AutoSize = true;
            this.cbAlwaySettings.Location = new System.Drawing.Point(112, 30);
            this.cbAlwaySettings.Name = "cbAlwaySettings";
            this.cbAlwaySettings.Size = new System.Drawing.Size(140, 19);
            this.cbAlwaySettings.TabIndex = 1;
            this.cbAlwaySettings.Text = "Always Open Settings";
            this.cbAlwaySettings.UseVisualStyleBackColor = true;
            this.cbAlwaySettings.CheckedChanged += new System.EventHandler(this.cbAlwaySettings_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(524, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Help";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtpWinterStart
            // 
            this.dtpWinterStart.CustomFormat = "MMM dd";
            this.dtpWinterStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWinterStart.Location = new System.Drawing.Point(138, 78);
            this.dtpWinterStart.Name = "dtpWinterStart";
            this.dtpWinterStart.Size = new System.Drawing.Size(97, 23);
            this.dtpWinterStart.TabIndex = 4;
            this.dtpWinterStart.ValueChanged += new System.EventHandler(this.dtpWinterStart_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Spring Start Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Winter Start Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Summer Start Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fall Start Date:";
            // 
            // dtpSpringStart
            // 
            this.dtpSpringStart.CustomFormat = "MMM dd";
            this.dtpSpringStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSpringStart.Location = new System.Drawing.Point(138, 107);
            this.dtpSpringStart.Name = "dtpSpringStart";
            this.dtpSpringStart.Size = new System.Drawing.Size(97, 23);
            this.dtpSpringStart.TabIndex = 5;
            this.dtpSpringStart.ValueChanged += new System.EventHandler(this.dtpSpringStart_ValueChanged);
            // 
            // cbEnableSceneSwapping
            // 
            this.cbEnableSceneSwapping.AutoSize = true;
            this.cbEnableSceneSwapping.Location = new System.Drawing.Point(6, 24);
            this.cbEnableSceneSwapping.Name = "cbEnableSceneSwapping";
            this.cbEnableSceneSwapping.Size = new System.Drawing.Size(179, 19);
            this.cbEnableSceneSwapping.TabIndex = 2;
            this.cbEnableSceneSwapping.Text = "Enable Auto Scene Swapping";
            this.cbEnableSceneSwapping.UseVisualStyleBackColor = true;
            this.cbEnableSceneSwapping.CheckedChanged += new System.EventHandler(this.cbEnableSceneSwapping_CheckedChanged);
            // 
            // dtpSummerStart
            // 
            this.dtpSummerStart.CustomFormat = "MMM dd";
            this.dtpSummerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSummerStart.Location = new System.Drawing.Point(138, 134);
            this.dtpSummerStart.Name = "dtpSummerStart";
            this.dtpSummerStart.Size = new System.Drawing.Size(97, 23);
            this.dtpSummerStart.TabIndex = 6;
            this.dtpSummerStart.ValueChanged += new System.EventHandler(this.dtpSummerStart_ValueChanged);
            // 
            // cbForceTime
            // 
            this.cbForceTime.AutoSize = true;
            this.cbForceTime.Location = new System.Drawing.Point(283, 53);
            this.cbForceTime.Name = "cbForceTime";
            this.cbForceTime.Size = new System.Drawing.Size(121, 19);
            this.cbForceTime.TabIndex = 3;
            this.cbForceTime.Text = "Force time of day:";
            this.cbForceTime.UseVisualStyleBackColor = true;
            this.cbForceTime.CheckedChanged += new System.EventHandler(this.cbForceTime_CheckedChanged);
            // 
            // dtpFallStart
            // 
            this.dtpFallStart.CustomFormat = "MMM dd";
            this.dtpFallStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFallStart.Location = new System.Drawing.Point(138, 161);
            this.dtpFallStart.Name = "dtpFallStart";
            this.dtpFallStart.Size = new System.Drawing.Size(97, 23);
            this.dtpFallStart.TabIndex = 7;
            this.dtpFallStart.ValueChanged += new System.EventHandler(this.dtpFallStart_ValueChanged);
            // 
            // dtpSunrise
            // 
            this.dtpSunrise.CustomFormat = "hh:mm tt";
            this.dtpSunrise.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSunrise.Location = new System.Drawing.Point(402, 101);
            this.dtpSunrise.Name = "dtpSunrise";
            this.dtpSunrise.ShowUpDown = true;
            this.dtpSunrise.Size = new System.Drawing.Size(101, 23);
            this.dtpSunrise.TabIndex = 8;
            this.dtpSunrise.ValueChanged += new System.EventHandler(this.dtpSunrise_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sunrise Time:";
            // 
            // dtpSunset
            // 
            this.dtpSunset.CustomFormat = "hh:mm tt";
            this.dtpSunset.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSunset.Location = new System.Drawing.Point(402, 126);
            this.dtpSunset.Name = "dtpSunset";
            this.dtpSunset.ShowUpDown = true;
            this.dtpSunset.Size = new System.Drawing.Size(101, 23);
            this.dtpSunset.TabIndex = 9;
            this.dtpSunset.ValueChanged += new System.EventHandler(this.dtpSunset_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(307, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Sunset Time:";
            // 
            // ddForceSeason
            // 
            this.ddForceSeason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddForceSeason.Enabled = false;
            this.ddForceSeason.FormattingEnabled = true;
            this.ddForceSeason.Items.AddRange(new object[] {
            "Winter",
            "Spring",
            "Summer",
            "Fall"});
            this.ddForceSeason.Location = new System.Drawing.Point(138, 49);
            this.ddForceSeason.Name = "ddForceSeason";
            this.ddForceSeason.Size = new System.Drawing.Size(121, 23);
            this.ddForceSeason.TabIndex = 19;
            this.ddForceSeason.SelectedIndexChanged += new System.EventHandler(this.ddForceSeason_SelectedIndexChanged);
            // 
            // cbEnableSunriseset
            // 
            this.cbEnableSunriseset.AutoSize = true;
            this.cbEnableSunriseset.Location = new System.Drawing.Point(283, 78);
            this.cbEnableSunriseset.Name = "cbEnableSunriseset";
            this.cbEnableSunriseset.Size = new System.Drawing.Size(218, 19);
            this.cbEnableSunriseset.TabIndex = 20;
            this.cbEnableSunriseset.Text = "Enable unique sunrise/sunset scenes";
            this.cbEnableSunriseset.UseVisualStyleBackColor = true;
            this.cbEnableSunriseset.CheckedChanged += new System.EventHandler(this.cbEnableSunRiseSet_CheckedChanged);
            // 
            // cbForceWeather
            // 
            this.cbForceWeather.AutoSize = true;
            this.cbForceWeather.Location = new System.Drawing.Point(6, 199);
            this.cbForceWeather.Name = "cbForceWeather";
            this.cbForceWeather.Size = new System.Drawing.Size(129, 19);
            this.cbForceWeather.TabIndex = 22;
            this.cbForceWeather.Text = "Force weather type:";
            this.cbForceWeather.UseVisualStyleBackColor = true;
            this.cbForceWeather.CheckedChanged += new System.EventHandler(this.cbForceWeather_CheckedChanged);
            // 
            // ddForceWeather
            // 
            this.ddForceWeather.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddForceWeather.FormattingEnabled = true;
            this.ddForceWeather.Items.AddRange(new object[] {
            "Clear",
            "Cloudy",
            "Overcast",
            "Rain",
            "Thunder",
            "Snow"});
            this.ddForceWeather.Location = new System.Drawing.Point(138, 195);
            this.ddForceWeather.Name = "ddForceWeather";
            this.ddForceWeather.Size = new System.Drawing.Size(121, 23);
            this.ddForceWeather.TabIndex = 23;
            this.ddForceWeather.SelectedIndexChanged += new System.EventHandler(this.ddForceWeather_SelectedIndexChanged);
            // 
            // cbForceSeason
            // 
            this.cbForceSeason.AutoSize = true;
            this.cbForceSeason.Location = new System.Drawing.Point(6, 53);
            this.cbForceSeason.Name = "cbForceSeason";
            this.cbForceSeason.Size = new System.Drawing.Size(97, 19);
            this.cbForceSeason.TabIndex = 24;
            this.cbForceSeason.Text = "Force season:";
            this.cbForceSeason.UseVisualStyleBackColor = true;
            this.cbForceSeason.CheckedChanged += new System.EventHandler(this.cbForceSeason_CheckedChanged);
            // 
            // lbWeatherRotation
            // 
            this.lbWeatherRotation.AutoSize = true;
            this.lbWeatherRotation.Location = new System.Drawing.Point(6, 227);
            this.lbWeatherRotation.Name = "lbWeatherRotation";
            this.lbWeatherRotation.Size = new System.Drawing.Size(126, 15);
            this.lbWeatherRotation.TabIndex = 25;
            this.lbWeatherRotation.Text = "Weather rotation style:";
            // 
            // ddWeatherRotation
            // 
            this.ddWeatherRotation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddWeatherRotation.FormattingEnabled = true;
            this.ddWeatherRotation.Items.AddRange(new object[] {
            "Random on load",
            "Random per day",
            "Location based"});
            this.ddWeatherRotation.Location = new System.Drawing.Point(138, 224);
            this.ddWeatherRotation.Name = "ddWeatherRotation";
            this.ddWeatherRotation.Size = new System.Drawing.Size(121, 23);
            this.ddWeatherRotation.TabIndex = 26;
            this.ddWeatherRotation.SelectedIndexChanged += new System.EventHandler(this.ddWeatherRotation_SelectedIndexChanged);
            // 
            // ddForceTime
            // 
            this.ddForceTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddForceTime.FormattingEnabled = true;
            this.ddForceTime.Items.AddRange(new object[] {
            "Day",
            "Night",
            "Sunrise",
            "Sunset"});
            this.ddForceTime.Location = new System.Drawing.Point(410, 49);
            this.ddForceTime.Name = "ddForceTime";
            this.ddForceTime.Size = new System.Drawing.Size(121, 23);
            this.ddForceTime.TabIndex = 27;
            this.ddForceTime.SelectedIndexChanged += new System.EventHandler(this.ddForceTime_SelectedIndexChanged);
            // 
            // tbLongitude
            // 
            this.tbLongitude.Location = new System.Drawing.Point(350, 224);
            this.tbLongitude.Name = "tbLongitude";
            this.tbLongitude.Size = new System.Drawing.Size(100, 23);
            this.tbLongitude.TabIndex = 28;
            this.tbLongitude.TextChanged += new System.EventHandler(this.tbLongitude_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(283, 227);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 15);
            this.label14.TabIndex = 29;
            this.label14.Text = "Longitude:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(294, 198);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 15);
            this.label15.TabIndex = 30;
            this.label15.Text = "Latitude:";
            // 
            // tbLatitude
            // 
            this.tbLatitude.Location = new System.Drawing.Point(350, 195);
            this.tbLatitude.Name = "tbLatitude";
            this.tbLatitude.Size = new System.Drawing.Size(100, 23);
            this.tbLatitude.TabIndex = 31;
            this.tbLatitude.TextChanged += new System.EventHandler(this.tbLatitude_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbLatitude);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tbLongitude);
            this.groupBox1.Controls.Add(this.ddForceTime);
            this.groupBox1.Controls.Add(this.ddWeatherRotation);
            this.groupBox1.Controls.Add(this.lbWeatherRotation);
            this.groupBox1.Controls.Add(this.cbForceSeason);
            this.groupBox1.Controls.Add(this.ddForceWeather);
            this.groupBox1.Controls.Add(this.cbForceWeather);
            this.groupBox1.Controls.Add(this.cbEnableSunriseset);
            this.groupBox1.Controls.Add(this.ddForceSeason);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpSunset);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpSunrise);
            this.groupBox1.Controls.Add(this.dtpFallStart);
            this.groupBox1.Controls.Add(this.cbForceTime);
            this.groupBox1.Controls.Add(this.dtpSummerStart);
            this.groupBox1.Controls.Add(this.cbEnableSceneSwapping);
            this.groupBox1.Controls.Add(this.dtpSpringStart);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpWinterStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 258);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Auto Scene Swapping Settings";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 525);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbAlwaySettings);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Credits);
            this.Controls.Add(this.bnStartPetz);
            this.Controls.Add(this.bnSave);
            this.Controls.Add(this.bnEditPetzSource);
            this.Controls.Add(this.labelPetzExe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Petz EZLoader Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Credits.ResumeLayout(false);
            this.Credits.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private Label labelPetzExe;
        private Button bnEditPetzSource;
        private Button bnSave;
        private Button bnStartPetz;
        private ToolTip toolTip1;
        private GroupBox Credits;
        private LinkLabel linkLabel1;
        private Label label9;
        private Label label8;
        private ListBox lbNotIncluded;
        private ListBox lbIncluded;
        private Button bnRemoveIncluded;
        private Button bnAddIncluded;
        private GroupBox groupBox2;
        private Label label11;
        private Label label10;
        private CheckBox cbEnableBulk;
        private Button bnRefreshFolders;
        private CheckBox cbAlwaySettings;
        private Button bnIncDown;
        private Button bnIncUp;
        private LinkLabel linkLabel2;
        private Label label16;
        private Label label13;
        private Label label12;
        private Button button1;
        private DateTimePicker dtpWinterStart;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label6;
        private DateTimePicker dtpSpringStart;
        private CheckBox cbEnableSceneSwapping;
        private DateTimePicker dtpSummerStart;
        private CheckBox cbForceTime;
        private DateTimePicker dtpFallStart;
        private DateTimePicker dtpSunrise;
        private Label label2;
        private DateTimePicker dtpSunset;
        private Label label7;
        private ComboBox ddForceSeason;
        private CheckBox cbEnableSunriseset;
        private CheckBox cbForceWeather;
        private ComboBox ddForceWeather;
        private CheckBox cbForceSeason;
        private Label lbWeatherRotation;
        private ComboBox ddWeatherRotation;
        private ComboBox ddForceTime;
        private TextBox tbLongitude;
        private Label label14;
        private Label label15;
        private TextBox tbLatitude;
        private GroupBox groupBox1;
    }
}
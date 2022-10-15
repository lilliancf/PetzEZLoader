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
            this.dtpWinterStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpSunset = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpSunrise = new System.Windows.Forms.DateTimePicker();
            this.dtpFallStart = new System.Windows.Forms.DateTimePicker();
            this.cbEnableDayNight = new System.Windows.Forms.CheckBox();
            this.dtpSummerStart = new System.Windows.Forms.DateTimePicker();
            this.cbEnableSeasons = new System.Windows.Forms.CheckBox();
            this.dtpSpringStart = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPetzExe = new System.Windows.Forms.Label();
            this.bnEditPetzSource = new System.Windows.Forms.Button();
            this.bnSave = new System.Windows.Forms.Button();
            this.bnStartPetz = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Credits = new System.Windows.Forms.GroupBox();
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
            this.groupBox1.SuspendLayout();
            this.Credits.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpWinterStart
            // 
            this.dtpWinterStart.CustomFormat = "MMM dd";
            this.dtpWinterStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWinterStart.Location = new System.Drawing.Point(184, 150);
            this.dtpWinterStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpWinterStart.Name = "dtpWinterStart";
            this.dtpWinterStart.Size = new System.Drawing.Size(137, 31);
            this.dtpWinterStart.TabIndex = 4;
            this.dtpWinterStart.ValueChanged += new System.EventHandler(this.dtpWinterStart_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpSunset);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpSunrise);
            this.groupBox1.Controls.Add(this.dtpFallStart);
            this.groupBox1.Controls.Add(this.cbEnableDayNight);
            this.groupBox1.Controls.Add(this.dtpSummerStart);
            this.groupBox1.Controls.Add(this.cbEnableSeasons);
            this.groupBox1.Controls.Add(this.dtpSpringStart);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpWinterStart);
            this.groupBox1.Location = new System.Drawing.Point(17, 93);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(336, 457);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seasonal Settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 412);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Sunset Time:";
            // 
            // dtpSunset
            // 
            this.dtpSunset.CustomFormat = "hh:mm tt";
            this.dtpSunset.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSunset.Location = new System.Drawing.Point(179, 407);
            this.dtpSunset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpSunset.Name = "dtpSunset";
            this.dtpSunset.ShowUpDown = true;
            this.dtpSunset.Size = new System.Drawing.Size(143, 31);
            this.dtpSunset.TabIndex = 9;
            this.dtpSunset.ValueChanged += new System.EventHandler(this.dtpSunset_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 372);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sunrise Time:";
            // 
            // dtpSunrise
            // 
            this.dtpSunrise.CustomFormat = "hh:mm tt";
            this.dtpSunrise.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSunrise.Location = new System.Drawing.Point(179, 365);
            this.dtpSunrise.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpSunrise.Name = "dtpSunrise";
            this.dtpSunrise.ShowUpDown = true;
            this.dtpSunrise.Size = new System.Drawing.Size(143, 31);
            this.dtpSunrise.TabIndex = 8;
            this.dtpSunrise.ValueChanged += new System.EventHandler(this.dtpSunrise_ValueChanged);
            // 
            // dtpFallStart
            // 
            this.dtpFallStart.CustomFormat = "MMM dd";
            this.dtpFallStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFallStart.Location = new System.Drawing.Point(184, 273);
            this.dtpFallStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpFallStart.Name = "dtpFallStart";
            this.dtpFallStart.Size = new System.Drawing.Size(137, 31);
            this.dtpFallStart.TabIndex = 7;
            this.dtpFallStart.ValueChanged += new System.EventHandler(this.dtpFallStart_ValueChanged);
            // 
            // cbEnableDayNight
            // 
            this.cbEnableDayNight.AutoSize = true;
            this.cbEnableDayNight.Location = new System.Drawing.Point(9, 78);
            this.cbEnableDayNight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbEnableDayNight.Name = "cbEnableDayNight";
            this.cbEnableDayNight.Size = new System.Drawing.Size(223, 29);
            this.cbEnableDayNight.TabIndex = 3;
            this.cbEnableDayNight.Text = "Enable Day/Night Cycle";
            this.cbEnableDayNight.UseVisualStyleBackColor = true;
            this.cbEnableDayNight.CheckedChanged += new System.EventHandler(this.cbEnableDayNight_CheckedChanged);
            // 
            // dtpSummerStart
            // 
            this.dtpSummerStart.CustomFormat = "MMM dd";
            this.dtpSummerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSummerStart.Location = new System.Drawing.Point(184, 232);
            this.dtpSummerStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpSummerStart.Name = "dtpSummerStart";
            this.dtpSummerStart.Size = new System.Drawing.Size(137, 31);
            this.dtpSummerStart.TabIndex = 6;
            this.dtpSummerStart.ValueChanged += new System.EventHandler(this.dtpSummerStart_ValueChanged);
            // 
            // cbEnableSeasons
            // 
            this.cbEnableSeasons.AutoSize = true;
            this.cbEnableSeasons.Location = new System.Drawing.Point(9, 37);
            this.cbEnableSeasons.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbEnableSeasons.Name = "cbEnableSeasons";
            this.cbEnableSeasons.Size = new System.Drawing.Size(160, 29);
            this.cbEnableSeasons.TabIndex = 2;
            this.cbEnableSeasons.Text = "Enable Seasons";
            this.cbEnableSeasons.UseVisualStyleBackColor = true;
            this.cbEnableSeasons.CheckedChanged += new System.EventHandler(this.cbEnableSeasons_CheckedChanged);
            // 
            // dtpSpringStart
            // 
            this.dtpSpringStart.CustomFormat = "MMM dd";
            this.dtpSpringStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSpringStart.Location = new System.Drawing.Point(184, 192);
            this.dtpSpringStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpSpringStart.Name = "dtpSpringStart";
            this.dtpSpringStart.Size = new System.Drawing.Size(137, 31);
            this.dtpSpringStart.TabIndex = 5;
            this.dtpSpringStart.ValueChanged += new System.EventHandler(this.dtpSpringStart_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 278);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fall Start Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 237);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Summer Start Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Winter Start Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 197);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Spring Start Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Petz Source:";
            // 
            // labelPetzExe
            // 
            this.labelPetzExe.AutoEllipsis = true;
            this.labelPetzExe.AutoSize = true;
            this.labelPetzExe.Location = new System.Drawing.Point(117, 15);
            this.labelPetzExe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPetzExe.MaximumSize = new System.Drawing.Size(750, 25);
            this.labelPetzExe.Name = "labelPetzExe";
            this.labelPetzExe.Size = new System.Drawing.Size(726, 25);
            this.labelPetzExe.TabIndex = 3;
            this.labelPetzExe.Text = "Please select main petz folder Please select main petz folder Please select main " +
    "petz folder Please select main petz folder";
            this.toolTip1.SetToolTip(this.labelPetzExe, "test");
            // 
            // bnEditPetzSource
            // 
            this.bnEditPetzSource.Location = new System.Drawing.Point(17, 45);
            this.bnEditPetzSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnEditPetzSource.Name = "bnEditPetzSource";
            this.bnEditPetzSource.Size = new System.Drawing.Size(134, 38);
            this.bnEditPetzSource.TabIndex = 0;
            this.bnEditPetzSource.Text = "Edit Source";
            this.bnEditPetzSource.UseVisualStyleBackColor = true;
            this.bnEditPetzSource.Click += new System.EventHandler(this.bnEditPetzSource_Click);
            // 
            // bnSave
            // 
            this.bnSave.Location = new System.Drawing.Point(251, 562);
            this.bnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnSave.Name = "bnSave";
            this.bnSave.Size = new System.Drawing.Size(101, 38);
            this.bnSave.TabIndex = 16;
            this.bnSave.Text = "Save";
            this.bnSave.UseVisualStyleBackColor = true;
            this.bnSave.Click += new System.EventHandler(this.bnSave_Click);
            // 
            // bnStartPetz
            // 
            this.bnStartPetz.Location = new System.Drawing.Point(361, 562);
            this.bnStartPetz.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnStartPetz.Name = "bnStartPetz";
            this.bnStartPetz.Size = new System.Drawing.Size(181, 38);
            this.bnStartPetz.TabIndex = 17;
            this.bnStartPetz.Text = "Save and Start Petz";
            this.bnStartPetz.UseVisualStyleBackColor = true;
            this.bnStartPetz.Click += new System.EventHandler(this.bnStartPetz_Click);
            // 
            // Credits
            // 
            this.Credits.Controls.Add(this.linkLabel1);
            this.Credits.Controls.Add(this.label9);
            this.Credits.Controls.Add(this.label8);
            this.Credits.Location = new System.Drawing.Point(361, 432);
            this.Credits.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Credits.Name = "Credits";
            this.Credits.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Credits.Size = new System.Drawing.Size(311, 118);
            this.Credits.TabIndex = 18;
            this.Credits.TabStop = false;
            this.Credits.Text = "Info";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(9, 78);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(252, 25);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://oodlecat.neocities.org/";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 28);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 25);
            this.label9.TabIndex = 1;
            this.label9.Text = "version 1.0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 53);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(283, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "created by skissors@Alive Enough";
            // 
            // lbNotIncluded
            // 
            this.lbNotIncluded.FormattingEnabled = true;
            this.lbNotIncluded.ItemHeight = 25;
            this.lbNotIncluded.Location = new System.Drawing.Point(286, 110);
            this.lbNotIncluded.Name = "lbNotIncluded";
            this.lbNotIncluded.Size = new System.Drawing.Size(180, 154);
            this.lbNotIncluded.TabIndex = 11;
            // 
            // lbIncluded
            // 
            this.lbIncluded.FormattingEnabled = true;
            this.lbIncluded.ItemHeight = 25;
            this.lbIncluded.Location = new System.Drawing.Point(51, 110);
            this.lbIncluded.Name = "lbIncluded";
            this.lbIncluded.Size = new System.Drawing.Size(180, 154);
            this.lbIncluded.TabIndex = 12;
            // 
            // bnRemoveIncluded
            // 
            this.bnRemoveIncluded.Location = new System.Drawing.Point(237, 157);
            this.bnRemoveIncluded.Name = "bnRemoveIncluded";
            this.bnRemoveIncluded.Size = new System.Drawing.Size(43, 33);
            this.bnRemoveIncluded.TabIndex = 14;
            this.bnRemoveIncluded.Text = ">";
            this.bnRemoveIncluded.UseVisualStyleBackColor = true;
            this.bnRemoveIncluded.Click += new System.EventHandler(this.bnRemoveIncluded_Click);
            // 
            // bnAddIncluded
            // 
            this.bnAddIncluded.Location = new System.Drawing.Point(237, 197);
            this.bnAddIncluded.Name = "bnAddIncluded";
            this.bnAddIncluded.Size = new System.Drawing.Size(43, 33);
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
            this.groupBox2.Location = new System.Drawing.Point(361, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(484, 330);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bulk Content Settings";
            // 
            // bnIncDown
            // 
            this.bnIncDown.Location = new System.Drawing.Point(11, 197);
            this.bnIncDown.Name = "bnIncDown";
            this.bnIncDown.Size = new System.Drawing.Size(34, 33);
            this.bnIncDown.TabIndex = 18;
            this.bnIncDown.Text = "▼";
            this.bnIncDown.UseVisualStyleBackColor = true;
            this.bnIncDown.Click += new System.EventHandler(this.bnIncDown_Click);
            // 
            // bnIncUp
            // 
            this.bnIncUp.Location = new System.Drawing.Point(11, 157);
            this.bnIncUp.Name = "bnIncUp";
            this.bnIncUp.Size = new System.Drawing.Size(34, 33);
            this.bnIncUp.TabIndex = 17;
            this.bnIncUp.Text = "▲";
            this.bnIncUp.UseVisualStyleBackColor = true;
            this.bnIncUp.Click += new System.EventHandler(this.bnIncUp_Click);
            // 
            // bnRefreshFolders
            // 
            this.bnRefreshFolders.Location = new System.Drawing.Point(181, 283);
            this.bnRefreshFolders.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bnRefreshFolders.Name = "bnRefreshFolders";
            this.bnRefreshFolders.Size = new System.Drawing.Size(150, 38);
            this.bnRefreshFolders.TabIndex = 15;
            this.bnRefreshFolders.Text = "Refresh Folders";
            this.bnRefreshFolders.UseVisualStyleBackColor = true;
            this.bnRefreshFolders.Click += new System.EventHandler(this.bnRefreshFolders_Click);
            // 
            // cbEnableBulk
            // 
            this.cbEnableBulk.AutoSize = true;
            this.cbEnableBulk.Location = new System.Drawing.Point(7, 32);
            this.cbEnableBulk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbEnableBulk.Name = "cbEnableBulk";
            this.cbEnableBulk.Size = new System.Drawing.Size(259, 29);
            this.cbEnableBulk.TabIndex = 10;
            this.cbEnableBulk.Text = "Enable bulk content loading";
            this.cbEnableBulk.UseVisualStyleBackColor = true;
            this.cbEnableBulk.CheckedChanged += new System.EventHandler(this.cbEnableBulk_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(51, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 25);
            this.label11.TabIndex = 13;
            this.label11.Text = "Include";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(286, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 25);
            this.label10.TabIndex = 12;
            this.label10.Text = "Remove";
            // 
            // cbAlwaySettings
            // 
            this.cbAlwaySettings.AutoSize = true;
            this.cbAlwaySettings.Location = new System.Drawing.Point(160, 50);
            this.cbAlwaySettings.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAlwaySettings.Name = "cbAlwaySettings";
            this.cbAlwaySettings.Size = new System.Drawing.Size(211, 29);
            this.cbAlwaySettings.TabIndex = 1;
            this.cbAlwaySettings.Text = "Always Open Settings";
            this.cbAlwaySettings.UseVisualStyleBackColor = true;
            this.cbAlwaySettings.CheckedChanged += new System.EventHandler(this.cbAlwaySettings_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 613);
            this.Controls.Add(this.cbAlwaySettings);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Credits);
            this.Controls.Add(this.bnStartPetz);
            this.Controls.Add(this.bnSave);
            this.Controls.Add(this.bnEditPetzSource);
            this.Controls.Add(this.labelPetzExe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Petz EZLoader Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Credits.ResumeLayout(false);
            this.Credits.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DateTimePicker dtpWinterStart;
        private GroupBox groupBox1;
        private Label label1;
        private Label labelPetzExe;
        private Button bnEditPetzSource;
        private Label label3;
        private DateTimePicker dtpFallStart;
        private CheckBox cbEnableDayNight;
        private DateTimePicker dtpSummerStart;
        private CheckBox cbEnableSeasons;
        private DateTimePicker dtpSpringStart;
        private Label label6;
        private Label label5;
        private Label label4;
        private DateTimePicker dtpSunrise;
        private Label label7;
        private DateTimePicker dtpSunset;
        private Label label2;
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
    }
}
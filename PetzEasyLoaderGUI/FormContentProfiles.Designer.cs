namespace PetzEasyLoaderGUI
{
    partial class FormContentProfiles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lbNotIncluded = new ListBox();
            label10 = new Label();
            label11 = new Label();
            lbIncluded = new ListBox();
            bnAddIncluded = new Button();
            bnRemoveIncluded = new Button();
            cbACSprites = new CheckBox();
            cbMice = new CheckBox();
            cbCase = new CheckBox();
            cbPalettes = new CheckBox();
            cbTextures = new CheckBox();
            cbToyz = new CheckBox();
            cbSongz = new CheckBox();
            cbWallpaper = new CheckBox();
            cbClothes = new CheckBox();
            cbDogz = new CheckBox();
            cbArea = new CheckBox();
            cbCatz = new CheckBox();
            cbAdoptedPetz = new CheckBox();
            gbFilters = new GroupBox();
            bnFilterClear = new Button();
            tbNameFilter = new TextBox();
            label1 = new Label();
            bnSave = new Button();
            bnStartPetz = new Button();
            bnHelp = new Button();
            bindingSource1 = new BindingSource(components);
            bnIncDown = new Button();
            bnIncUp = new Button();
            gbFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // lbNotIncluded
            // 
            lbNotIncluded.FormattingEnabled = true;
            lbNotIncluded.ItemHeight = 15;
            lbNotIncluded.Location = new Point(266, 25);
            lbNotIncluded.Margin = new Padding(2);
            lbNotIncluded.Name = "lbNotIncluded";
            lbNotIncluded.Size = new Size(188, 214);
            lbNotIncluded.TabIndex = 19;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(266, 8);
            label10.Margin = new Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.Size = new Size(50, 15);
            label10.TabIndex = 20;
            label10.Text = "Remove";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(39, 8);
            label11.Margin = new Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.Size = new Size(46, 15);
            label11.TabIndex = 22;
            label11.Text = "Include";
            // 
            // lbIncluded
            // 
            lbIncluded.FormattingEnabled = true;
            lbIncluded.ItemHeight = 15;
            lbIncluded.Location = new Point(39, 25);
            lbIncluded.Margin = new Padding(2);
            lbIncluded.Name = "lbIncluded";
            lbIncluded.Size = new Size(188, 214);
            lbIncluded.TabIndex = 21;
            // 
            // bnAddIncluded
            // 
            bnAddIncluded.Location = new Point(231, 61);
            bnAddIncluded.Margin = new Padding(2);
            bnAddIncluded.Name = "bnAddIncluded";
            bnAddIncluded.Size = new Size(30, 20);
            bnAddIncluded.TabIndex = 23;
            bnAddIncluded.Text = "<";
            bnAddIncluded.UseVisualStyleBackColor = true;
            bnAddIncluded.Click += bnAddIncluded_Click;
            // 
            // bnRemoveIncluded
            // 
            bnRemoveIncluded.Location = new Point(231, 37);
            bnRemoveIncluded.Margin = new Padding(2);
            bnRemoveIncluded.Name = "bnRemoveIncluded";
            bnRemoveIncluded.Size = new Size(30, 20);
            bnRemoveIncluded.TabIndex = 24;
            bnRemoveIncluded.Text = ">";
            bnRemoveIncluded.UseVisualStyleBackColor = true;
            bnRemoveIncluded.Click += bnRemoveIncluded_Click;
            // 
            // cbACSprites
            // 
            cbACSprites.AutoSize = true;
            cbACSprites.Location = new Point(84, 67);
            cbACSprites.Margin = new Padding(2);
            cbACSprites.Name = "cbACSprites";
            cbACSprites.Size = new Size(80, 19);
            cbACSprites.TabIndex = 40;
            cbACSprites.Text = "AC Sprites";
            cbACSprites.UseVisualStyleBackColor = true;
            cbACSprites.CheckedChanged += cbACSprites_CheckedChanged;
            // 
            // cbMice
            // 
            cbMice.AutoSize = true;
            cbMice.Location = new Point(84, 90);
            cbMice.Margin = new Padding(2);
            cbMice.Name = "cbMice";
            cbMice.Size = new Size(52, 19);
            cbMice.TabIndex = 39;
            cbMice.Text = "Mice";
            cbMice.UseVisualStyleBackColor = true;
            cbMice.CheckedChanged += cbMice_CheckedChanged;
            // 
            // cbCase
            // 
            cbCase.AutoSize = true;
            cbCase.Location = new Point(84, 44);
            cbCase.Margin = new Padding(2);
            cbCase.Name = "cbCase";
            cbCase.Size = new Size(99, 19);
            cbCase.TabIndex = 38;
            cbCase.Text = "Carrying Case";
            cbCase.UseVisualStyleBackColor = true;
            cbCase.CheckedChanged += cbCase_CheckedChanged;
            // 
            // cbPalettes
            // 
            cbPalettes.AutoSize = true;
            cbPalettes.Location = new Point(84, 136);
            cbPalettes.Margin = new Padding(2);
            cbPalettes.Name = "cbPalettes";
            cbPalettes.Size = new Size(67, 19);
            cbPalettes.TabIndex = 37;
            cbPalettes.Text = "Palettes";
            cbPalettes.UseVisualStyleBackColor = true;
            cbPalettes.CheckedChanged += cbPalettes_CheckedChanged;
            // 
            // cbTextures
            // 
            cbTextures.AutoSize = true;
            cbTextures.Location = new Point(84, 113);
            cbTextures.Margin = new Padding(2);
            cbTextures.Name = "cbTextures";
            cbTextures.Size = new Size(69, 19);
            cbTextures.TabIndex = 36;
            cbTextures.Text = "Textures";
            cbTextures.UseVisualStyleBackColor = true;
            cbTextures.CheckedChanged += cbTextures_CheckedChanged;
            // 
            // cbToyz
            // 
            cbToyz.AutoSize = true;
            cbToyz.Location = new Point(5, 136);
            cbToyz.Margin = new Padding(2);
            cbToyz.Name = "cbToyz";
            cbToyz.Size = new Size(49, 19);
            cbToyz.TabIndex = 35;
            cbToyz.Text = "Toyz";
            cbToyz.UseVisualStyleBackColor = true;
            cbToyz.CheckedChanged += cbToyz_CheckedChanged;
            // 
            // cbSongz
            // 
            cbSongz.AutoSize = true;
            cbSongz.Location = new Point(5, 113);
            cbSongz.Margin = new Padding(2);
            cbSongz.Name = "cbSongz";
            cbSongz.Size = new Size(58, 19);
            cbSongz.TabIndex = 34;
            cbSongz.Text = "Songz";
            cbSongz.UseVisualStyleBackColor = true;
            cbSongz.CheckedChanged += cbSongz_CheckedChanged;
            // 
            // cbWallpaper
            // 
            cbWallpaper.AutoSize = true;
            cbWallpaper.Location = new Point(5, 159);
            cbWallpaper.Margin = new Padding(2);
            cbWallpaper.Name = "cbWallpaper";
            cbWallpaper.Size = new Size(79, 19);
            cbWallpaper.TabIndex = 33;
            cbWallpaper.Text = "Wallpaper";
            cbWallpaper.UseVisualStyleBackColor = true;
            cbWallpaper.CheckedChanged += cbWallpaper_CheckedChanged;
            // 
            // cbClothes
            // 
            cbClothes.AutoSize = true;
            cbClothes.Location = new Point(5, 67);
            cbClothes.Margin = new Padding(2);
            cbClothes.Name = "cbClothes";
            cbClothes.Size = new Size(66, 19);
            cbClothes.TabIndex = 32;
            cbClothes.Text = "Clothes";
            cbClothes.UseVisualStyleBackColor = true;
            cbClothes.CheckedChanged += cbClothes_CheckedChanged;
            // 
            // cbDogz
            // 
            cbDogz.AutoSize = true;
            cbDogz.Location = new Point(5, 90);
            cbDogz.Margin = new Padding(2);
            cbDogz.Name = "cbDogz";
            cbDogz.Size = new Size(53, 19);
            cbDogz.TabIndex = 31;
            cbDogz.Text = "Dogz";
            cbDogz.UseVisualStyleBackColor = true;
            cbDogz.CheckedChanged += cbDogz_CheckedChanged;
            // 
            // cbArea
            // 
            cbArea.AutoSize = true;
            cbArea.Location = new Point(5, 21);
            cbArea.Margin = new Padding(2);
            cbArea.Name = "cbArea";
            cbArea.Size = new Size(50, 19);
            cbArea.TabIndex = 29;
            cbArea.Text = "Area";
            cbArea.UseVisualStyleBackColor = true;
            cbArea.CheckedChanged += cbArea_CheckedChanged;
            // 
            // cbCatz
            // 
            cbCatz.AutoSize = true;
            cbCatz.Location = new Point(5, 44);
            cbCatz.Margin = new Padding(2);
            cbCatz.Name = "cbCatz";
            cbCatz.Size = new Size(49, 19);
            cbCatz.TabIndex = 28;
            cbCatz.Text = "Catz";
            cbCatz.UseVisualStyleBackColor = true;
            cbCatz.CheckedChanged += cbCatz_CheckedChanged;
            // 
            // cbAdoptedPetz
            // 
            cbAdoptedPetz.AutoSize = true;
            cbAdoptedPetz.Location = new Point(84, 21);
            cbAdoptedPetz.Margin = new Padding(2);
            cbAdoptedPetz.Name = "cbAdoptedPetz";
            cbAdoptedPetz.Size = new Size(97, 19);
            cbAdoptedPetz.TabIndex = 27;
            cbAdoptedPetz.Text = "Adopted Petz";
            cbAdoptedPetz.UseVisualStyleBackColor = true;
            cbAdoptedPetz.CheckedChanged += cbAdoptedPetz_CheckedChanged;
            // 
            // gbFilters
            // 
            gbFilters.Controls.Add(bnFilterClear);
            gbFilters.Controls.Add(cbMice);
            gbFilters.Controls.Add(cbArea);
            gbFilters.Controls.Add(cbPalettes);
            gbFilters.Controls.Add(cbACSprites);
            gbFilters.Controls.Add(cbTextures);
            gbFilters.Controls.Add(cbCase);
            gbFilters.Controls.Add(cbCatz);
            gbFilters.Controls.Add(cbClothes);
            gbFilters.Controls.Add(cbAdoptedPetz);
            gbFilters.Controls.Add(cbDogz);
            gbFilters.Controls.Add(cbSongz);
            gbFilters.Controls.Add(cbToyz);
            gbFilters.Controls.Add(cbWallpaper);
            gbFilters.Location = new Point(464, 51);
            gbFilters.Name = "gbFilters";
            gbFilters.Size = new Size(188, 188);
            gbFilters.TabIndex = 42;
            gbFilters.TabStop = false;
            gbFilters.Text = "Categrory Filters";
            // 
            // bnFilterClear
            // 
            bnFilterClear.Location = new Point(135, 160);
            bnFilterClear.Name = "bnFilterClear";
            bnFilterClear.Size = new Size(46, 23);
            bnFilterClear.TabIndex = 41;
            bnFilterClear.Text = "Clear";
            bnFilterClear.UseVisualStyleBackColor = true;
            bnFilterClear.Click += bnFilterClear_Click;
            // 
            // tbNameFilter
            // 
            tbNameFilter.Location = new Point(506, 22);
            tbNameFilter.Name = "tbNameFilter";
            tbNameFilter.Size = new Size(146, 23);
            tbNameFilter.TabIndex = 43;
            tbNameFilter.TextChanged += tbNameFilter_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(464, 25);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 44;
            label1.Text = "Filter:";
            // 
            // bnSave
            // 
            bnSave.Location = new Point(448, 246);
            bnSave.Name = "bnSave";
            bnSave.Size = new Size(71, 23);
            bnSave.TabIndex = 45;
            bnSave.Text = "Save";
            bnSave.UseVisualStyleBackColor = true;
            bnSave.Click += bnSave_Click;
            // 
            // bnStartPetz
            // 
            bnStartPetz.Location = new Point(525, 246);
            bnStartPetz.Name = "bnStartPetz";
            bnStartPetz.Size = new Size(127, 23);
            bnStartPetz.TabIndex = 46;
            bnStartPetz.Text = "Save and Start Petz";
            bnStartPetz.UseVisualStyleBackColor = true;
            bnStartPetz.Click += bnStartPetz_Click;
            // 
            // bnHelp
            // 
            bnHelp.Location = new Point(39, 246);
            bnHelp.Name = "bnHelp";
            bnHelp.Size = new Size(75, 23);
            bnHelp.TabIndex = 47;
            bnHelp.Text = "Help";
            bnHelp.UseVisualStyleBackColor = true;
            bnHelp.Click += this.bnHelp_Click;
            // 
            // bnIncDown
            // 
            bnIncDown.Location = new Point(11, 71);
            bnIncDown.Margin = new Padding(2);
            bnIncDown.Name = "bnIncDown";
            bnIncDown.Size = new Size(24, 31);
            bnIncDown.TabIndex = 49;
            bnIncDown.Text = "▼";
            bnIncDown.UseVisualStyleBackColor = true;
            bnIncDown.Click += bnIncDown_Click;
            // 
            // bnIncUp
            // 
            bnIncUp.Location = new Point(11, 37);
            bnIncUp.Margin = new Padding(2);
            bnIncUp.Name = "bnIncUp";
            bnIncUp.Size = new Size(24, 31);
            bnIncUp.TabIndex = 48;
            bnIncUp.Text = "▲";
            bnIncUp.UseVisualStyleBackColor = true;
            bnIncUp.Click += bnIncUp_Click;
            // 
            // FormContentProfiles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 281);
            Controls.Add(bnIncDown);
            Controls.Add(bnIncUp);
            Controls.Add(bnSave);
            Controls.Add(bnStartPetz);
            Controls.Add(bnHelp);
            Controls.Add(label1);
            Controls.Add(tbNameFilter);
            Controls.Add(gbFilters);
            Controls.Add(lbNotIncluded);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(lbIncluded);
            Controls.Add(bnAddIncluded);
            Controls.Add(bnRemoveIncluded);
            Name = "FormContentProfiles";
            Text = "Content Profile Manager";
            FormClosing += FormContentProfiles_FormClosing;
            gbFilters.ResumeLayout(false);
            gbFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbNotIncluded;
        private Label label10;
        private Label label11;
        private ListBox lbIncluded;
        private Button bnAddIncluded;
        private Button bnRemoveIncluded;
        private CheckBox cbACSprites;
        private CheckBox cbMice;
        private CheckBox cbCase;
        private CheckBox cbPalettes;
        private CheckBox cbTextures;
        private CheckBox cbToyz;
        private CheckBox cbSongz;
        private CheckBox cbWallpaper;
        private CheckBox cbClothes;
        private CheckBox cbDogz;
        private CheckBox cbArea;
        private CheckBox cbCatz;
        private CheckBox cbAdoptedPetz;
        private GroupBox gbFilters;
        private TextBox tbNameFilter;
        private Label label1;
        private Button bnSave;
        private Button bnStartPetz;
        private Button bnHelp;
        private BindingSource bindingSource1;
        private Button bnFilterClear;
        private Button bnIncDown;
        private Button bnIncUp;
    }
}
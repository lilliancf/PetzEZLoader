namespace PetzEasyLoaderGUI
{
    partial class Form2
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
            bnIncDown = new Button();
            lbIncluded = new ListBox();
            bnIncUp = new Button();
            bnAddIncluded = new Button();
            bnRemoveIncluded = new Button();
            cbNpACSprites = new CheckBox();
            cbNpMice = new CheckBox();
            cbNpCase = new CheckBox();
            cbNpPalettes = new CheckBox();
            cbNpTextures = new CheckBox();
            cbNpToyz = new CheckBox();
            cbNpSongz = new CheckBox();
            cbNpWallpaper = new CheckBox();
            cbNpClothes = new CheckBox();
            cbNpDogz = new CheckBox();
            cbNpArea = new CheckBox();
            cbNpCatz = new CheckBox();
            cbNpAdoptedPetz = new CheckBox();
            gbFilters = new GroupBox();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            btnSave = new Button();
            btnStartPetz = new Button();
            btnHelp = new Button();
            bindingSource1 = new BindingSource(components);
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
            // bnIncDown
            // 
            bnIncDown.Location = new Point(11, 61);
            bnIncDown.Margin = new Padding(2);
            bnIncDown.Name = "bnIncDown";
            bnIncDown.Size = new Size(24, 20);
            bnIncDown.TabIndex = 26;
            bnIncDown.Text = "▼";
            bnIncDown.UseVisualStyleBackColor = true;
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
            // bnIncUp
            // 
            bnIncUp.Location = new Point(11, 37);
            bnIncUp.Margin = new Padding(2);
            bnIncUp.Name = "bnIncUp";
            bnIncUp.Size = new Size(24, 20);
            bnIncUp.TabIndex = 25;
            bnIncUp.Text = "▲";
            bnIncUp.UseVisualStyleBackColor = true;
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
            // 
            // cbNpACSprites
            // 
            cbNpACSprites.AutoSize = true;
            cbNpACSprites.Location = new Point(84, 67);
            cbNpACSprites.Margin = new Padding(2);
            cbNpACSprites.Name = "cbNpACSprites";
            cbNpACSprites.Size = new Size(80, 19);
            cbNpACSprites.TabIndex = 40;
            cbNpACSprites.Text = "AC Sprites";
            cbNpACSprites.UseVisualStyleBackColor = true;
            // 
            // cbNpMice
            // 
            cbNpMice.AutoSize = true;
            cbNpMice.Location = new Point(84, 90);
            cbNpMice.Margin = new Padding(2);
            cbNpMice.Name = "cbNpMice";
            cbNpMice.Size = new Size(52, 19);
            cbNpMice.TabIndex = 39;
            cbNpMice.Text = "Mice";
            cbNpMice.UseVisualStyleBackColor = true;
            // 
            // cbNpCase
            // 
            cbNpCase.AutoSize = true;
            cbNpCase.Location = new Point(84, 44);
            cbNpCase.Margin = new Padding(2);
            cbNpCase.Name = "cbNpCase";
            cbNpCase.Size = new Size(99, 19);
            cbNpCase.TabIndex = 38;
            cbNpCase.Text = "Carrying Case";
            cbNpCase.UseVisualStyleBackColor = true;
            // 
            // cbNpPalettes
            // 
            cbNpPalettes.AutoSize = true;
            cbNpPalettes.Location = new Point(84, 136);
            cbNpPalettes.Margin = new Padding(2);
            cbNpPalettes.Name = "cbNpPalettes";
            cbNpPalettes.Size = new Size(67, 19);
            cbNpPalettes.TabIndex = 37;
            cbNpPalettes.Text = "Palettes";
            cbNpPalettes.UseVisualStyleBackColor = true;
            // 
            // cbNpTextures
            // 
            cbNpTextures.AutoSize = true;
            cbNpTextures.Location = new Point(84, 113);
            cbNpTextures.Margin = new Padding(2);
            cbNpTextures.Name = "cbNpTextures";
            cbNpTextures.Size = new Size(69, 19);
            cbNpTextures.TabIndex = 36;
            cbNpTextures.Text = "Textures";
            cbNpTextures.UseVisualStyleBackColor = true;
            // 
            // cbNpToyz
            // 
            cbNpToyz.AutoSize = true;
            cbNpToyz.Location = new Point(5, 136);
            cbNpToyz.Margin = new Padding(2);
            cbNpToyz.Name = "cbNpToyz";
            cbNpToyz.Size = new Size(49, 19);
            cbNpToyz.TabIndex = 35;
            cbNpToyz.Text = "Toyz";
            cbNpToyz.UseVisualStyleBackColor = true;
            // 
            // cbNpSongz
            // 
            cbNpSongz.AutoSize = true;
            cbNpSongz.Location = new Point(5, 113);
            cbNpSongz.Margin = new Padding(2);
            cbNpSongz.Name = "cbNpSongz";
            cbNpSongz.Size = new Size(58, 19);
            cbNpSongz.TabIndex = 34;
            cbNpSongz.Text = "Songz";
            cbNpSongz.UseVisualStyleBackColor = true;
            // 
            // cbNpWallpaper
            // 
            cbNpWallpaper.AutoSize = true;
            cbNpWallpaper.Location = new Point(5, 159);
            cbNpWallpaper.Margin = new Padding(2);
            cbNpWallpaper.Name = "cbNpWallpaper";
            cbNpWallpaper.Size = new Size(79, 19);
            cbNpWallpaper.TabIndex = 33;
            cbNpWallpaper.Text = "Wallpaper";
            cbNpWallpaper.UseVisualStyleBackColor = true;
            // 
            // cbNpClothes
            // 
            cbNpClothes.AutoSize = true;
            cbNpClothes.Location = new Point(5, 67);
            cbNpClothes.Margin = new Padding(2);
            cbNpClothes.Name = "cbNpClothes";
            cbNpClothes.Size = new Size(66, 19);
            cbNpClothes.TabIndex = 32;
            cbNpClothes.Text = "Clothes";
            cbNpClothes.UseVisualStyleBackColor = true;
            // 
            // cbNpDogz
            // 
            cbNpDogz.AutoSize = true;
            cbNpDogz.Location = new Point(5, 90);
            cbNpDogz.Margin = new Padding(2);
            cbNpDogz.Name = "cbNpDogz";
            cbNpDogz.Size = new Size(53, 19);
            cbNpDogz.TabIndex = 31;
            cbNpDogz.Text = "Dogz";
            cbNpDogz.UseVisualStyleBackColor = true;
            // 
            // cbNpArea
            // 
            cbNpArea.AutoSize = true;
            cbNpArea.Location = new Point(5, 21);
            cbNpArea.Margin = new Padding(2);
            cbNpArea.Name = "cbNpArea";
            cbNpArea.Size = new Size(50, 19);
            cbNpArea.TabIndex = 29;
            cbNpArea.Text = "Area";
            cbNpArea.UseVisualStyleBackColor = true;
            // 
            // cbNpCatz
            // 
            cbNpCatz.AutoSize = true;
            cbNpCatz.Location = new Point(5, 44);
            cbNpCatz.Margin = new Padding(2);
            cbNpCatz.Name = "cbNpCatz";
            cbNpCatz.Size = new Size(49, 19);
            cbNpCatz.TabIndex = 28;
            cbNpCatz.Text = "Catz";
            cbNpCatz.UseVisualStyleBackColor = true;
            // 
            // cbNpAdoptedPetz
            // 
            cbNpAdoptedPetz.AutoSize = true;
            cbNpAdoptedPetz.Location = new Point(84, 21);
            cbNpAdoptedPetz.Margin = new Padding(2);
            cbNpAdoptedPetz.Name = "cbNpAdoptedPetz";
            cbNpAdoptedPetz.Size = new Size(97, 19);
            cbNpAdoptedPetz.TabIndex = 27;
            cbNpAdoptedPetz.Text = "Adopted Petz";
            cbNpAdoptedPetz.UseVisualStyleBackColor = true;
            // 
            // gbFilters
            // 
            gbFilters.Controls.Add(button1);
            gbFilters.Controls.Add(cbNpMice);
            gbFilters.Controls.Add(cbNpArea);
            gbFilters.Controls.Add(cbNpPalettes);
            gbFilters.Controls.Add(cbNpACSprites);
            gbFilters.Controls.Add(cbNpTextures);
            gbFilters.Controls.Add(cbNpCase);
            gbFilters.Controls.Add(cbNpCatz);
            gbFilters.Controls.Add(cbNpClothes);
            gbFilters.Controls.Add(cbNpAdoptedPetz);
            gbFilters.Controls.Add(cbNpDogz);
            gbFilters.Controls.Add(cbNpSongz);
            gbFilters.Controls.Add(cbNpToyz);
            gbFilters.Controls.Add(cbNpWallpaper);
            gbFilters.Location = new Point(464, 51);
            gbFilters.Name = "gbFilters";
            gbFilters.Size = new Size(188, 188);
            gbFilters.TabIndex = 42;
            gbFilters.TabStop = false;
            gbFilters.Text = "Categrory Filters";
            // 
            // button1
            // 
            button1.Location = new Point(135, 160);
            button1.Name = "button1";
            button1.Size = new Size(46, 23);
            button1.TabIndex = 41;
            button1.Text = "Clear";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(541, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(111, 23);
            textBox1.TabIndex = 43;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(464, 25);
            label1.Name = "label1";
            label1.Size = new Size(71, 15);
            label1.TabIndex = 44;
            label1.Text = "Name Filter:";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(448, 246);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(71, 23);
            btnSave.TabIndex = 45;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnStartPetz
            // 
            btnStartPetz.Location = new Point(525, 246);
            btnStartPetz.Name = "btnStartPetz";
            btnStartPetz.Size = new Size(127, 23);
            btnStartPetz.TabIndex = 46;
            btnStartPetz.Text = "Save and Start Petz";
            btnStartPetz.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            btnHelp.Location = new Point(39, 246);
            btnHelp.Name = "btnHelp";
            btnHelp.Size = new Size(75, 23);
            btnHelp.TabIndex = 47;
            btnHelp.Text = "Help";
            btnHelp.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(665, 281);
            Controls.Add(btnSave);
            Controls.Add(btnStartPetz);
            Controls.Add(btnHelp);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(gbFilters);
            Controls.Add(lbNotIncluded);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(bnIncDown);
            Controls.Add(lbIncluded);
            Controls.Add(bnIncUp);
            Controls.Add(bnAddIncluded);
            Controls.Add(bnRemoveIncluded);
            Name = "Form2";
            Text = "Content Profile Manager";
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
        private Button bnIncDown;
        private ListBox lbIncluded;
        private Button bnIncUp;
        private Button bnAddIncluded;
        private Button bnRemoveIncluded;
        private CheckBox cbNpACSprites;
        private CheckBox cbNpMice;
        private CheckBox cbNpCase;
        private CheckBox cbNpPalettes;
        private CheckBox cbNpTextures;
        private CheckBox cbNpToyz;
        private CheckBox cbNpSongz;
        private CheckBox cbNpWallpaper;
        private CheckBox cbNpClothes;
        private CheckBox cbNpDogz;
        private CheckBox cbNpArea;
        private CheckBox cbNpCatz;
        private CheckBox cbNpAdoptedPetz;
        private GroupBox gbFilters;
        private TextBox textBox1;
        private Label label1;
        private Button btnSave;
        private Button btnStartPetz;
        private Button btnHelp;
        private BindingSource bindingSource1;
        private Button button1;
    }
}
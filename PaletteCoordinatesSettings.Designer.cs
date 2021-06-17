
namespace GarticBot
{
    partial class PaletteCoordinatesSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaletteCoordinatesSettings));
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.pasteImageButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.blueY = new System.Windows.Forms.NumericUpDown();
            this.blueX = new System.Windows.Forms.NumericUpDown();
            this.setBlue = new System.Windows.Forms.Button();
            this.greenY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.greenX = new System.Windows.Forms.NumericUpDown();
            this.redY = new System.Windows.Forms.NumericUpDown();
            this.redX = new System.Windows.Forms.NumericUpDown();
            this.setGreen = new System.Windows.Forms.Button();
            this.setRed = new System.Windows.Forms.Button();
            this.emptySpaceY = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.emptySpaceX = new System.Windows.Forms.NumericUpDown();
            this.openPaletteY = new System.Windows.Forms.NumericUpDown();
            this.openPaletteX = new System.Windows.Forms.NumericUpDown();
            this.setEmpty = new System.Windows.Forms.Button();
            this.setOpenPalette = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.coordsPreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openPaletteY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openPaletteX)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.coordsPreviewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.saveSettingsButton);
            this.panel1.Controls.Add(this.pasteImageButton);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.blueY);
            this.panel1.Controls.Add(this.blueX);
            this.panel1.Controls.Add(this.setBlue);
            this.panel1.Controls.Add(this.greenY);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.greenX);
            this.panel1.Controls.Add(this.redY);
            this.panel1.Controls.Add(this.redX);
            this.panel1.Controls.Add(this.setGreen);
            this.panel1.Controls.Add(this.setRed);
            this.panel1.Controls.Add(this.emptySpaceY);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.emptySpaceX);
            this.panel1.Controls.Add(this.openPaletteY);
            this.panel1.Controls.Add(this.openPaletteX);
            this.panel1.Controls.Add(this.setEmpty);
            this.panel1.Controls.Add(this.setOpenPalette);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(597, 85);
            this.panel1.TabIndex = 1;
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(500, 49);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(71, 30);
            this.saveSettingsButton.TabIndex = 26;
            this.saveSettingsButton.Text = "Сохранить";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // pasteImageButton
            // 
            this.pasteImageButton.Location = new System.Drawing.Point(404, 49);
            this.pasteImageButton.Name = "pasteImageButton";
            this.pasteImageButton.Size = new System.Drawing.Size(94, 30);
            this.pasteImageButton.TabIndex = 25;
            this.pasteImageButton.Text = "Вставить фото";
            this.pasteImageButton.UseVisualStyleBackColor = true;
            this.pasteImageButton.Click += new System.EventHandler(this.pasteImageButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(404, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Синий";
            // 
            // blueY
            // 
            this.blueY.Location = new System.Drawing.Point(504, 22);
            this.blueY.Name = "blueY";
            this.blueY.Size = new System.Drawing.Size(67, 20);
            this.blueY.TabIndex = 22;
            this.blueY.ValueChanged += new System.EventHandler(this.coordsChanged);
            // 
            // blueX
            // 
            this.blueX.Location = new System.Drawing.Point(431, 22);
            this.blueX.Name = "blueX";
            this.blueX.Size = new System.Drawing.Size(67, 20);
            this.blueX.TabIndex = 21;
            this.blueX.ValueChanged += new System.EventHandler(this.coordsChanged);
            // 
            // setBlue
            // 
            this.setBlue.Location = new System.Drawing.Point(404, 22);
            this.setBlue.Name = "setBlue";
            this.setBlue.Size = new System.Drawing.Size(21, 21);
            this.setBlue.TabIndex = 19;
            this.setBlue.Text = "Х";
            this.setBlue.UseVisualStyleBackColor = true;
            this.setBlue.Click += new System.EventHandler(this.setCoord_Click);
            // 
            // greenY
            // 
            this.greenY.Location = new System.Drawing.Point(314, 59);
            this.greenY.Name = "greenY";
            this.greenY.Size = new System.Drawing.Size(67, 20);
            this.greenY.TabIndex = 18;
            this.greenY.ValueChanged += new System.EventHandler(this.coordsChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Зелёный";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Красный";
            // 
            // greenX
            // 
            this.greenX.Location = new System.Drawing.Point(241, 59);
            this.greenX.Name = "greenX";
            this.greenX.Size = new System.Drawing.Size(67, 20);
            this.greenX.TabIndex = 15;
            this.greenX.ValueChanged += new System.EventHandler(this.coordsChanged);
            // 
            // redY
            // 
            this.redY.Location = new System.Drawing.Point(314, 22);
            this.redY.Name = "redY";
            this.redY.Size = new System.Drawing.Size(67, 20);
            this.redY.TabIndex = 14;
            this.redY.ValueChanged += new System.EventHandler(this.coordsChanged);
            // 
            // redX
            // 
            this.redX.Location = new System.Drawing.Point(241, 22);
            this.redX.Name = "redX";
            this.redX.Size = new System.Drawing.Size(67, 20);
            this.redX.TabIndex = 13;
            this.redX.ValueChanged += new System.EventHandler(this.coordsChanged);
            // 
            // setGreen
            // 
            this.setGreen.Location = new System.Drawing.Point(214, 59);
            this.setGreen.Name = "setGreen";
            this.setGreen.Size = new System.Drawing.Size(21, 20);
            this.setGreen.TabIndex = 12;
            this.setGreen.Text = "Х";
            this.setGreen.UseVisualStyleBackColor = true;
            this.setGreen.Click += new System.EventHandler(this.setCoord_Click);
            // 
            // setRed
            // 
            this.setRed.Location = new System.Drawing.Point(214, 22);
            this.setRed.Name = "setRed";
            this.setRed.Size = new System.Drawing.Size(21, 21);
            this.setRed.TabIndex = 11;
            this.setRed.Text = "Х";
            this.setRed.UseVisualStyleBackColor = true;
            this.setRed.Click += new System.EventHandler(this.setCoord_Click);
            // 
            // emptySpaceY
            // 
            this.emptySpaceY.Location = new System.Drawing.Point(112, 59);
            this.emptySpaceY.Name = "emptySpaceY";
            this.emptySpaceY.Size = new System.Drawing.Size(67, 20);
            this.emptySpaceY.TabIndex = 10;
            this.emptySpaceY.ValueChanged += new System.EventHandler(this.coordsChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Пустое место";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Открыть палитру";
            // 
            // emptySpaceX
            // 
            this.emptySpaceX.Location = new System.Drawing.Point(39, 59);
            this.emptySpaceX.Name = "emptySpaceX";
            this.emptySpaceX.Size = new System.Drawing.Size(67, 20);
            this.emptySpaceX.TabIndex = 7;
            this.emptySpaceX.ValueChanged += new System.EventHandler(this.coordsChanged);
            // 
            // openPaletteY
            // 
            this.openPaletteY.Location = new System.Drawing.Point(112, 22);
            this.openPaletteY.Name = "openPaletteY";
            this.openPaletteY.Size = new System.Drawing.Size(67, 20);
            this.openPaletteY.TabIndex = 6;
            this.openPaletteY.ValueChanged += new System.EventHandler(this.coordsChanged);
            // 
            // openPaletteX
            // 
            this.openPaletteX.Location = new System.Drawing.Point(39, 22);
            this.openPaletteX.Name = "openPaletteX";
            this.openPaletteX.Size = new System.Drawing.Size(67, 20);
            this.openPaletteX.TabIndex = 5;
            this.openPaletteX.ValueChanged += new System.EventHandler(this.coordsChanged);
            // 
            // setEmpty
            // 
            this.setEmpty.Location = new System.Drawing.Point(12, 59);
            this.setEmpty.Name = "setEmpty";
            this.setEmpty.Size = new System.Drawing.Size(21, 20);
            this.setEmpty.TabIndex = 1;
            this.setEmpty.Text = "Х";
            this.setEmpty.UseVisualStyleBackColor = true;
            this.setEmpty.Click += new System.EventHandler(this.setCoord_Click);
            // 
            // setOpenPalette
            // 
            this.setOpenPalette.Location = new System.Drawing.Point(12, 22);
            this.setOpenPalette.Name = "setOpenPalette";
            this.setOpenPalette.Size = new System.Drawing.Size(21, 21);
            this.setOpenPalette.TabIndex = 0;
            this.setOpenPalette.Text = "Х";
            this.setOpenPalette.UseVisualStyleBackColor = true;
            this.setOpenPalette.Click += new System.EventHandler(this.setCoord_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.coordsPreviewPictureBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(597, 353);
            this.panel2.TabIndex = 2;
            // 
            // coordsPreviewPictureBox
            // 
            this.coordsPreviewPictureBox.BackColor = System.Drawing.Color.DimGray;
            this.coordsPreviewPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.coordsPreviewPictureBox.Location = new System.Drawing.Point(0, 0);
            this.coordsPreviewPictureBox.Name = "coordsPreviewPictureBox";
            this.coordsPreviewPictureBox.Size = new System.Drawing.Size(597, 353);
            this.coordsPreviewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.coordsPreviewPictureBox.TabIndex = 0;
            this.coordsPreviewPictureBox.TabStop = false;
            this.coordsPreviewPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.coordsPreviewPictureBox_Click);
            // 
            // PaletteCoordinatesSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 438);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PaletteCoordinatesSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки координат палитры";
            this.Load += new System.EventHandler(this.PaletteCoordinatesSettings_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openPaletteY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openPaletteX)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.coordsPreviewPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox coordsPreviewPictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button pasteImageButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown blueY;
        private System.Windows.Forms.NumericUpDown blueX;
        private System.Windows.Forms.Button setBlue;
        private System.Windows.Forms.NumericUpDown greenY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown greenX;
        private System.Windows.Forms.NumericUpDown redY;
        private System.Windows.Forms.NumericUpDown redX;
        private System.Windows.Forms.Button setGreen;
        private System.Windows.Forms.Button setRed;
        private System.Windows.Forms.NumericUpDown emptySpaceY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown emptySpaceX;
        private System.Windows.Forms.NumericUpDown openPaletteY;
        private System.Windows.Forms.NumericUpDown openPaletteX;
        private System.Windows.Forms.Button setEmpty;
        private System.Windows.Forms.Button setOpenPalette;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button saveSettingsButton;
    }
}
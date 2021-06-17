
namespace GarticBot
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.previewImagebox = new System.Windows.Forms.PictureBox();
            this.gapSizeTrackbar = new System.Windows.Forms.TrackBar();
            this.speedTrackbar = new System.Windows.Forms.TrackBar();
            this.addFrameCheckbox = new System.Windows.Forms.CheckBox();
            this.colorCountInput = new System.Windows.Forms.NumericUpDown();
            this.imageSizeCombobox = new System.Windows.Forms.ComboBox();
            this.downloadImageButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.workProgressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.coordinatesSetup = new System.Windows.Forms.Button();
            this.speedLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gapLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.frameSelectButton = new System.Windows.Forms.Button();
            this.topWindowCheckbox = new System.Windows.Forms.CheckBox();
            this.imageUrlTextBox = new GarticBot.TextBoxWithPlaceholder();
            ((System.ComponentModel.ISupportInitialize)(this.previewImagebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gapSizeTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorCountInput)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // previewImagebox
            // 
            this.previewImagebox.BackColor = System.Drawing.Color.Transparent;
            this.previewImagebox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewImagebox.Location = new System.Drawing.Point(3, 18);
            this.previewImagebox.Name = "previewImagebox";
            this.previewImagebox.Size = new System.Drawing.Size(291, 177);
            this.previewImagebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewImagebox.TabIndex = 0;
            this.previewImagebox.TabStop = false;
            // 
            // gapSizeTrackbar
            // 
            this.gapSizeTrackbar.AutoSize = false;
            this.gapSizeTrackbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.gapSizeTrackbar.Location = new System.Drawing.Point(168, 172);
            this.gapSizeTrackbar.Maximum = 12;
            this.gapSizeTrackbar.Minimum = 1;
            this.gapSizeTrackbar.Name = "gapSizeTrackbar";
            this.gapSizeTrackbar.Size = new System.Drawing.Size(144, 24);
            this.gapSizeTrackbar.TabIndex = 1;
            this.gapSizeTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.gapSizeTrackbar.Value = 4;
            this.gapSizeTrackbar.Scroll += new System.EventHandler(this.gapSizeTrackbar_Scroll);
            // 
            // speedTrackbar
            // 
            this.speedTrackbar.AutoSize = false;
            this.speedTrackbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.speedTrackbar.LargeChange = 1;
            this.speedTrackbar.Location = new System.Drawing.Point(16, 172);
            this.speedTrackbar.Maximum = 4;
            this.speedTrackbar.Minimum = 1;
            this.speedTrackbar.Name = "speedTrackbar";
            this.speedTrackbar.Size = new System.Drawing.Size(149, 24);
            this.speedTrackbar.TabIndex = 2;
            this.speedTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.speedTrackbar.Value = 3;
            this.speedTrackbar.Scroll += new System.EventHandler(this.speedTrackbar_Scroll);
            // 
            // addFrameCheckbox
            // 
            this.addFrameCheckbox.AutoSize = true;
            this.addFrameCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.addFrameCheckbox.Enabled = false;
            this.addFrameCheckbox.ForeColor = System.Drawing.Color.White;
            this.addFrameCheckbox.Location = new System.Drawing.Point(19, 70);
            this.addFrameCheckbox.Name = "addFrameCheckbox";
            this.addFrameCheckbox.Size = new System.Drawing.Size(110, 19);
            this.addFrameCheckbox.TabIndex = 3;
            this.addFrameCheckbox.Text = "Добавить рамку";
            this.addFrameCheckbox.UseVisualStyleBackColor = false;
            // 
            // colorCountInput
            // 
            this.colorCountInput.Location = new System.Drawing.Point(14, 118);
            this.colorCountInput.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.colorCountInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.colorCountInput.Name = "colorCountInput";
            this.colorCountInput.Size = new System.Drawing.Size(112, 22);
            this.colorCountInput.TabIndex = 4;
            this.colorCountInput.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.colorCountInput.ValueChanged += new System.EventHandler(this.colorCountInput_ValueChanged);
            // 
            // imageSizeCombobox
            // 
            this.imageSizeCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.imageSizeCombobox.FormattingEnabled = true;
            this.imageSizeCombobox.Items.AddRange(new object[] {
            "Обычный",
            "Вписать",
            "Растянуть",
            "По центру"});
            this.imageSizeCombobox.Location = new System.Drawing.Point(187, 118);
            this.imageSizeCombobox.Name = "imageSizeCombobox";
            this.imageSizeCombobox.Size = new System.Drawing.Size(125, 23);
            this.imageSizeCombobox.TabIndex = 5;
            this.imageSizeCombobox.SelectedIndexChanged += new System.EventHandler(this.imageSizeCombobox_SelectedIndexChanged);
            // 
            // downloadImageButton
            // 
            this.downloadImageButton.BackColor = System.Drawing.Color.Transparent;
            this.downloadImageButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.downloadImageButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.downloadImageButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.downloadImageButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadImageButton.Location = new System.Drawing.Point(14, 35);
            this.downloadImageButton.Margin = new System.Windows.Forms.Padding(1);
            this.downloadImageButton.Name = "downloadImageButton";
            this.downloadImageButton.Size = new System.Drawing.Size(298, 27);
            this.downloadImageButton.TabIndex = 6;
            this.downloadImageButton.Text = "Загрузить изображение";
            this.downloadImageButton.UseVisualStyleBackColor = false;
            this.downloadImageButton.Click += new System.EventHandler(this.downloadImageButton_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Transparent;
            this.startButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.startButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.startButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Microsoft JhengHei", 20F, System.Drawing.FontStyle.Bold);
            this.startButton.ForeColor = System.Drawing.Color.White;
            this.startButton.Location = new System.Drawing.Point(14, 410);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(299, 41);
            this.startButton.TabIndex = 9;
            this.startButton.Text = "Старт";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // workProgressBar
            // 
            this.workProgressBar.Location = new System.Drawing.Point(15, 399);
            this.workProgressBar.Name = "workProgressBar";
            this.workProgressBar.Size = new System.Drawing.Size(297, 10);
            this.workProgressBar.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(19, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Количество цветов:";
            // 
            // coordinatesSetup
            // 
            this.coordinatesSetup.BackColor = System.Drawing.Color.Transparent;
            this.coordinatesSetup.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.coordinatesSetup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.coordinatesSetup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.coordinatesSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.coordinatesSetup.Location = new System.Drawing.Point(129, 65);
            this.coordinatesSetup.Name = "coordinatesSetup";
            this.coordinatesSetup.Size = new System.Drawing.Size(183, 23);
            this.coordinatesSetup.TabIndex = 13;
            this.coordinatesSetup.Text = "Координаты палитры";
            this.coordinatesSetup.UseVisualStyleBackColor = false;
            this.coordinatesSetup.Click += new System.EventHandler(this.coordinatesSetup_Click);
            // 
            // speedLabel
            // 
            this.speedLabel.BackColor = System.Drawing.Color.Transparent;
            this.speedLabel.Location = new System.Drawing.Point(15, 154);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(149, 15);
            this.speedLabel.TabIndex = 15;
            this.speedLabel.Text = "Скорость: (3)";
            this.speedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.previewImagebox);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(15, 202);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 198);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Предпросмотр";
            // 
            // gapLabel
            // 
            this.gapLabel.BackColor = System.Drawing.Color.Transparent;
            this.gapLabel.Location = new System.Drawing.Point(168, 154);
            this.gapLabel.Name = "gapLabel";
            this.gapLabel.Size = new System.Drawing.Size(145, 15);
            this.gapLabel.TabIndex = 17;
            this.gapLabel.Text = "Ширина пропуска: (4)";
            this.gapLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorLabel
            // 
            this.errorLabel.BackColor = System.Drawing.Color.Transparent;
            this.errorLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLabel.Location = new System.Drawing.Point(0, 454);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(324, 19);
            this.errorLabel.TabIndex = 18;
            this.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frameSelectButton
            // 
            this.frameSelectButton.BackColor = System.Drawing.Color.Transparent;
            this.frameSelectButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.frameSelectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.frameSelectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.frameSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.frameSelectButton.Location = new System.Drawing.Point(129, 91);
            this.frameSelectButton.Name = "frameSelectButton";
            this.frameSelectButton.Size = new System.Drawing.Size(183, 23);
            this.frameSelectButton.TabIndex = 19;
            this.frameSelectButton.Text = "Выбрать поле для рисования";
            this.frameSelectButton.UseVisualStyleBackColor = false;
            this.frameSelectButton.Click += new System.EventHandler(this.frameSelectButton_Click);
            // 
            // topWindowCheckbox
            // 
            this.topWindowCheckbox.Appearance = System.Windows.Forms.Appearance.Button;
            this.topWindowCheckbox.BackColor = System.Drawing.Color.Transparent;
            this.topWindowCheckbox.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkGreen;
            this.topWindowCheckbox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.topWindowCheckbox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.topWindowCheckbox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.topWindowCheckbox.Font = new System.Drawing.Font("Microsoft JhengHei", 7F);
            this.topWindowCheckbox.Location = new System.Drawing.Point(129, 118);
            this.topWindowCheckbox.Name = "topWindowCheckbox";
            this.topWindowCheckbox.Size = new System.Drawing.Size(53, 23);
            this.topWindowCheckbox.TabIndex = 1;
            this.topWindowCheckbox.Text = "Поверх";
            this.topWindowCheckbox.UseVisualStyleBackColor = false;
            this.topWindowCheckbox.CheckedChanged += new System.EventHandler(this.topWindowCheckbox_CheckedChanged);
            // 
            // imageUrlTextBox
            // 
            this.imageUrlTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F);
            this.imageUrlTextBox.Location = new System.Drawing.Point(14, 10);
            this.imageUrlTextBox.Margin = new System.Windows.Forms.Padding(1);
            this.imageUrlTextBox.Name = "imageUrlTextBox";
            this.imageUrlTextBox.Size = new System.Drawing.Size(298, 22);
            this.imageUrlTextBox.TabIndex = 8;
            this.imageUrlTextBox.WaterMark = "URL для загрузки изображения";
            this.imageUrlTextBox.WaterMarkActiveForeColor = System.Drawing.Color.DimGray;
            this.imageUrlTextBox.WaterMarkFont = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageUrlTextBox.WaterMarkForeColor = System.Drawing.Color.DarkGray;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::GarticBot.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(324, 473);
            this.Controls.Add(this.topWindowCheckbox);
            this.Controls.Add(this.frameSelectButton);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.gapLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.coordinatesSetup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.workProgressBar);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.imageUrlTextBox);
            this.Controls.Add(this.downloadImageButton);
            this.Controls.Add(this.imageSizeCombobox);
            this.Controls.Add(this.colorCountInput);
            this.Controls.Add(this.addFrameCheckbox);
            this.Controls.Add(this.speedTrackbar);
            this.Controls.Add(this.gapSizeTrackbar);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gartic Bot by Prevter";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.previewImagebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gapSizeTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorCountInput)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox previewImagebox;
        private System.Windows.Forms.TrackBar gapSizeTrackbar;
        private System.Windows.Forms.TrackBar speedTrackbar;
        private System.Windows.Forms.CheckBox addFrameCheckbox;
        private System.Windows.Forms.NumericUpDown colorCountInput;
        private System.Windows.Forms.ComboBox imageSizeCombobox;
        private System.Windows.Forms.Button downloadImageButton;
        private TextBoxWithPlaceholder imageUrlTextBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ProgressBar workProgressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button coordinatesSetup;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label gapLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button frameSelectButton;
        private System.Windows.Forms.CheckBox topWindowCheckbox;
    }
}


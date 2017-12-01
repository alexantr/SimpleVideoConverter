namespace Alexantr.SimpleVideoConverter
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBoxIn = new System.Windows.Forms.TextBox();
            this.buttonBrowseIn = new System.Windows.Forms.Button();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.buttonBrowseOut = new System.Windows.Forms.Button();
            this.labelIn = new System.Windows.Forms.Label();
            this.labelOut = new System.Windows.Forms.Label();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.labelX = new System.Windows.Forms.Label();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.labelBitrate = new System.Windows.Forms.Label();
            this.numericUpDownBitrate = new System.Windows.Forms.NumericUpDown();
            this.groupBoxInOut = new System.Windows.Forms.GroupBox();
            this.checkBoxKeepOutPath = new System.Windows.Forms.CheckBox();
            this.groupBoxVideoParams = new System.Windows.Forms.GroupBox();
            this.labelFileType = new System.Windows.Forms.Label();
            this.comboBoxFileType = new System.Windows.Forms.ComboBox();
            this.checkBoxDeinterlace = new System.Windows.Forms.CheckBox();
            this.checkBoxResizePicture = new System.Windows.Forms.CheckBox();
            this.groupBoxAudioParams = new System.Windows.Forms.GroupBox();
            this.checkBoxEnableAudio = new System.Windows.Forms.CheckBox();
            this.labelAudioBitrate = new System.Windows.Forms.Label();
            this.numericUpDownAudioBitrate = new System.Windows.Forms.NumericUpDown();
            this.labelChannels = new System.Windows.Forms.Label();
            this.comboBoxChannels = new System.Windows.Forms.ComboBox();
            this.labelFrequency = new System.Windows.Forms.Label();
            this.comboBoxFrequency = new System.Windows.Forms.ComboBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBitrate)).BeginInit();
            this.groupBoxInOut.SuspendLayout();
            this.groupBoxVideoParams.SuspendLayout();
            this.groupBoxAudioParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAudioBitrate)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxIn
            // 
            this.textBoxIn.Location = new System.Drawing.Point(9, 32);
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.ReadOnly = true;
            this.textBoxIn.Size = new System.Drawing.Size(381, 22);
            this.textBoxIn.TabIndex = 1;
            // 
            // buttonBrowseIn
            // 
            this.buttonBrowseIn.Location = new System.Drawing.Point(396, 31);
            this.buttonBrowseIn.Name = "buttonBrowseIn";
            this.buttonBrowseIn.Size = new System.Drawing.Size(32, 23);
            this.buttonBrowseIn.TabIndex = 2;
            this.buttonBrowseIn.Text = "...";
            this.buttonBrowseIn.UseVisualStyleBackColor = true;
            this.buttonBrowseIn.Click += new System.EventHandler(this.buttonBrowseIn_Click);
            // 
            // textBoxOut
            // 
            this.textBoxOut.Location = new System.Drawing.Point(9, 75);
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.Size = new System.Drawing.Size(381, 22);
            this.textBoxOut.TabIndex = 4;
            // 
            // buttonBrowseOut
            // 
            this.buttonBrowseOut.Location = new System.Drawing.Point(396, 74);
            this.buttonBrowseOut.Name = "buttonBrowseOut";
            this.buttonBrowseOut.Size = new System.Drawing.Size(32, 23);
            this.buttonBrowseOut.TabIndex = 5;
            this.buttonBrowseOut.Text = "...";
            this.buttonBrowseOut.UseVisualStyleBackColor = true;
            this.buttonBrowseOut.Click += new System.EventHandler(this.buttonBrowseOut_Click);
            // 
            // labelIn
            // 
            this.labelIn.AutoSize = true;
            this.labelIn.Location = new System.Drawing.Point(6, 16);
            this.labelIn.Name = "labelIn";
            this.labelIn.Size = new System.Drawing.Size(91, 13);
            this.labelIn.TabIndex = 0;
            this.labelIn.Text = "Исходный файл";
            // 
            // labelOut
            // 
            this.labelOut.AutoSize = true;
            this.labelOut.Location = new System.Drawing.Point(6, 59);
            this.labelOut.Name = "labelOut";
            this.labelOut.Size = new System.Drawing.Size(85, 13);
            this.labelOut.TabIndex = 3;
            this.labelOut.Text = "Сохранить как";
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownWidth.Location = new System.Drawing.Point(9, 126);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.numericUpDownWidth.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownWidth.TabIndex = 6;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            640,
            0,
            0,
            0});
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(74, 128);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(12, 13);
            this.labelX.TabIndex = 7;
            this.labelX.Text = "x";
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownHeight.Location = new System.Drawing.Point(90, 126);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.numericUpDownHeight.Minimum = new decimal(new int[] {
            96,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(60, 22);
            this.numericUpDownHeight.TabIndex = 8;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            // 
            // labelBitrate
            // 
            this.labelBitrate.AutoSize = true;
            this.labelBitrate.Location = new System.Drawing.Point(6, 52);
            this.labelBitrate.Name = "labelBitrate";
            this.labelBitrate.Size = new System.Drawing.Size(93, 13);
            this.labelBitrate.TabIndex = 2;
            this.labelBitrate.Text = "Битрейт (кбит/с)";
            // 
            // numericUpDownBitrate
            // 
            this.numericUpDownBitrate.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownBitrate.Location = new System.Drawing.Point(127, 48);
            this.numericUpDownBitrate.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.numericUpDownBitrate.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownBitrate.Name = "numericUpDownBitrate";
            this.numericUpDownBitrate.Size = new System.Drawing.Size(80, 22);
            this.numericUpDownBitrate.TabIndex = 3;
            this.numericUpDownBitrate.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // groupBoxInOut
            // 
            this.groupBoxInOut.Controls.Add(this.labelIn);
            this.groupBoxInOut.Controls.Add(this.textBoxIn);
            this.groupBoxInOut.Controls.Add(this.buttonBrowseIn);
            this.groupBoxInOut.Controls.Add(this.labelOut);
            this.groupBoxInOut.Controls.Add(this.textBoxOut);
            this.groupBoxInOut.Controls.Add(this.buttonBrowseOut);
            this.groupBoxInOut.Controls.Add(this.checkBoxKeepOutPath);
            this.groupBoxInOut.Location = new System.Drawing.Point(6, 6);
            this.groupBoxInOut.Name = "groupBoxInOut";
            this.groupBoxInOut.Size = new System.Drawing.Size(436, 126);
            this.groupBoxInOut.TabIndex = 0;
            this.groupBoxInOut.TabStop = false;
            this.groupBoxInOut.Text = "Файл";
            // 
            // checkBoxKeepOutPath
            // 
            this.checkBoxKeepOutPath.AutoSize = true;
            this.checkBoxKeepOutPath.Location = new System.Drawing.Point(9, 103);
            this.checkBoxKeepOutPath.Name = "checkBoxKeepOutPath";
            this.checkBoxKeepOutPath.Size = new System.Drawing.Size(206, 17);
            this.checkBoxKeepOutPath.TabIndex = 6;
            this.checkBoxKeepOutPath.Text = "Запомнить папку для сохранения";
            this.checkBoxKeepOutPath.UseVisualStyleBackColor = true;
            this.checkBoxKeepOutPath.CheckedChanged += new System.EventHandler(this.checkBoxKeepOutPath_CheckedChanged);
            // 
            // groupBoxVideoParams
            // 
            this.groupBoxVideoParams.Controls.Add(this.labelFileType);
            this.groupBoxVideoParams.Controls.Add(this.comboBoxFileType);
            this.groupBoxVideoParams.Controls.Add(this.labelBitrate);
            this.groupBoxVideoParams.Controls.Add(this.numericUpDownBitrate);
            this.groupBoxVideoParams.Controls.Add(this.checkBoxDeinterlace);
            this.groupBoxVideoParams.Controls.Add(this.checkBoxResizePicture);
            this.groupBoxVideoParams.Controls.Add(this.numericUpDownWidth);
            this.groupBoxVideoParams.Controls.Add(this.labelX);
            this.groupBoxVideoParams.Controls.Add(this.numericUpDownHeight);
            this.groupBoxVideoParams.Location = new System.Drawing.Point(6, 138);
            this.groupBoxVideoParams.Name = "groupBoxVideoParams";
            this.groupBoxVideoParams.Size = new System.Drawing.Size(215, 158);
            this.groupBoxVideoParams.TabIndex = 1;
            this.groupBoxVideoParams.TabStop = false;
            this.groupBoxVideoParams.Text = "Видео";
            // 
            // labelFileType
            // 
            this.labelFileType.AutoSize = true;
            this.labelFileType.Location = new System.Drawing.Point(6, 24);
            this.labelFileType.Name = "labelFileType";
            this.labelFileType.Size = new System.Drawing.Size(84, 13);
            this.labelFileType.TabIndex = 0;
            this.labelFileType.Text = "Формат файла";
            // 
            // comboBoxFileType
            // 
            this.comboBoxFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFileType.FormattingEnabled = true;
            this.comboBoxFileType.Items.AddRange(new object[] {
            "MP4",
            "WebM"});
            this.comboBoxFileType.Location = new System.Drawing.Point(127, 21);
            this.comboBoxFileType.Name = "comboBoxFileType";
            this.comboBoxFileType.Size = new System.Drawing.Size(80, 21);
            this.comboBoxFileType.TabIndex = 1;
            this.comboBoxFileType.SelectedIndexChanged += new System.EventHandler(this.comboBoxFileType_SelectedIndexChanged);
            // 
            // checkBoxDeinterlace
            // 
            this.checkBoxDeinterlace.AutoSize = true;
            this.checkBoxDeinterlace.Location = new System.Drawing.Point(9, 78);
            this.checkBoxDeinterlace.Name = "checkBoxDeinterlace";
            this.checkBoxDeinterlace.Size = new System.Drawing.Size(175, 17);
            this.checkBoxDeinterlace.TabIndex = 4;
            this.checkBoxDeinterlace.Text = "Устранить чересстрочность";
            this.checkBoxDeinterlace.UseVisualStyleBackColor = true;
            // 
            // checkBoxResizePicture
            // 
            this.checkBoxResizePicture.AutoSize = true;
            this.checkBoxResizePicture.Location = new System.Drawing.Point(9, 106);
            this.checkBoxResizePicture.Name = "checkBoxResizePicture";
            this.checkBoxResizePicture.Size = new System.Drawing.Size(147, 17);
            this.checkBoxResizePicture.TabIndex = 5;
            this.checkBoxResizePicture.Text = "Изменить разрешение";
            this.checkBoxResizePicture.UseVisualStyleBackColor = true;
            this.checkBoxResizePicture.CheckedChanged += new System.EventHandler(this.checkBoxResizePicture_CheckedChanged);
            // 
            // groupBoxAudioParams
            // 
            this.groupBoxAudioParams.Controls.Add(this.checkBoxEnableAudio);
            this.groupBoxAudioParams.Controls.Add(this.labelAudioBitrate);
            this.groupBoxAudioParams.Controls.Add(this.numericUpDownAudioBitrate);
            this.groupBoxAudioParams.Controls.Add(this.labelChannels);
            this.groupBoxAudioParams.Controls.Add(this.comboBoxChannels);
            this.groupBoxAudioParams.Controls.Add(this.labelFrequency);
            this.groupBoxAudioParams.Controls.Add(this.comboBoxFrequency);
            this.groupBoxAudioParams.Location = new System.Drawing.Point(227, 138);
            this.groupBoxAudioParams.Name = "groupBoxAudioParams";
            this.groupBoxAudioParams.Size = new System.Drawing.Size(215, 107);
            this.groupBoxAudioParams.TabIndex = 2;
            this.groupBoxAudioParams.TabStop = false;
            // 
            // checkBoxEnableAudio
            // 
            this.checkBoxEnableAudio.AutoSize = true;
            this.checkBoxEnableAudio.Location = new System.Drawing.Point(9, 0);
            this.checkBoxEnableAudio.Name = "checkBoxEnableAudio";
            this.checkBoxEnableAudio.Size = new System.Drawing.Size(58, 17);
            this.checkBoxEnableAudio.TabIndex = 0;
            this.checkBoxEnableAudio.Text = "Аудио";
            this.checkBoxEnableAudio.UseVisualStyleBackColor = true;
            this.checkBoxEnableAudio.CheckedChanged += new System.EventHandler(this.checkBoxEnableAudio_CheckedChanged);
            // 
            // labelAudioBitrate
            // 
            this.labelAudioBitrate.AutoSize = true;
            this.labelAudioBitrate.Location = new System.Drawing.Point(6, 24);
            this.labelAudioBitrate.Name = "labelAudioBitrate";
            this.labelAudioBitrate.Size = new System.Drawing.Size(93, 13);
            this.labelAudioBitrate.TabIndex = 1;
            this.labelAudioBitrate.Text = "Битрейт (кбит/с)";
            // 
            // numericUpDownAudioBitrate
            // 
            this.numericUpDownAudioBitrate.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownAudioBitrate.Location = new System.Drawing.Point(127, 21);
            this.numericUpDownAudioBitrate.Maximum = new decimal(new int[] {
            320,
            0,
            0,
            0});
            this.numericUpDownAudioBitrate.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownAudioBitrate.Name = "numericUpDownAudioBitrate";
            this.numericUpDownAudioBitrate.Size = new System.Drawing.Size(80, 22);
            this.numericUpDownAudioBitrate.TabIndex = 2;
            this.numericUpDownAudioBitrate.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // labelChannels
            // 
            this.labelChannels.AutoSize = true;
            this.labelChannels.Location = new System.Drawing.Point(6, 79);
            this.labelChannels.Name = "labelChannels";
            this.labelChannels.Size = new System.Drawing.Size(46, 13);
            this.labelChannels.TabIndex = 3;
            this.labelChannels.Text = "Каналы";
            // 
            // comboBoxChannels
            // 
            this.comboBoxChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChannels.FormattingEnabled = true;
            this.comboBoxChannels.Location = new System.Drawing.Point(127, 76);
            this.comboBoxChannels.Name = "comboBoxChannels";
            this.comboBoxChannels.Size = new System.Drawing.Size(80, 21);
            this.comboBoxChannels.TabIndex = 4;
            // 
            // labelFrequency
            // 
            this.labelFrequency.AutoSize = true;
            this.labelFrequency.Location = new System.Drawing.Point(6, 52);
            this.labelFrequency.Name = "labelFrequency";
            this.labelFrequency.Size = new System.Drawing.Size(69, 13);
            this.labelFrequency.TabIndex = 5;
            this.labelFrequency.Text = "Частота (Гц)";
            // 
            // comboBoxFrequency
            // 
            this.comboBoxFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrequency.FormattingEnabled = true;
            this.comboBoxFrequency.Location = new System.Drawing.Point(127, 49);
            this.comboBoxFrequency.Name = "comboBoxFrequency";
            this.comboBoxFrequency.Size = new System.Drawing.Size(80, 21);
            this.comboBoxFrequency.TabIndex = 6;
            // 
            // buttonGo
            // 
            this.buttonGo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGo.Location = new System.Drawing.Point(262, 258);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(145, 35);
            this.buttonGo.TabIndex = 3;
            this.buttonGo.Text = "Конвертировать";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(3, 309);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(443, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 4;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(275, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(120, 16);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 331);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBoxInOut);
            this.Controls.Add(this.groupBoxVideoParams);
            this.Controls.Add(this.groupBoxAudioParams);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.Text = "Simple Video Converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBitrate)).EndInit();
            this.groupBoxInOut.ResumeLayout(false);
            this.groupBoxInOut.PerformLayout();
            this.groupBoxVideoParams.ResumeLayout(false);
            this.groupBoxVideoParams.PerformLayout();
            this.groupBoxAudioParams.ResumeLayout(false);
            this.groupBoxAudioParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAudioBitrate)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonBrowseIn;
        private System.Windows.Forms.Button buttonBrowseOut;
        private System.Windows.Forms.Label labelIn;
        private System.Windows.Forms.Label labelOut;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label labelBitrate;
        private System.Windows.Forms.NumericUpDown numericUpDownBitrate;
        private System.Windows.Forms.GroupBox groupBoxInOut;
        private System.Windows.Forms.GroupBox groupBoxVideoParams;
        private System.Windows.Forms.GroupBox groupBoxAudioParams;
        private System.Windows.Forms.Label labelAudioBitrate;
        private System.Windows.Forms.Label labelChannels;
        private System.Windows.Forms.NumericUpDown numericUpDownAudioBitrate;
        private System.Windows.Forms.ComboBox comboBoxChannels;
        private System.Windows.Forms.ComboBox comboBoxFileType;
        private System.Windows.Forms.Label labelFileType;
        private System.Windows.Forms.CheckBox checkBoxResizePicture;
        private System.Windows.Forms.Button buttonGo;
        public System.Windows.Forms.TextBox textBoxIn;
        public System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.CheckBox checkBoxDeinterlace;
        private System.Windows.Forms.CheckBox checkBoxKeepOutPath;
        private System.Windows.Forms.CheckBox checkBoxEnableAudio;
        private System.Windows.Forms.ComboBox comboBoxFrequency;
        private System.Windows.Forms.Label labelFrequency;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
    }
}


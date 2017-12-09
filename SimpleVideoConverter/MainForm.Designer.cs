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
            this.labelFrameRate = new System.Windows.Forms.Label();
            this.comboBoxFrameRate = new System.Windows.Forms.ComboBox();
            this.labelFileType = new System.Windows.Forms.Label();
            this.comboBoxFileType = new System.Windows.Forms.ComboBox();
            this.checkBoxDeinterlace = new System.Windows.Forms.CheckBox();
            this.checkBoxResizePicture = new System.Windows.Forms.CheckBox();
            this.groupBoxAudioParams = new System.Windows.Forms.GroupBox();
            this.comboBoxAudioBitrate = new System.Windows.Forms.ComboBox();
            this.labelAudioBitrate = new System.Windows.Forms.Label();
            this.labelChannels = new System.Windows.Forms.Label();
            this.comboBoxChannels = new System.Windows.Forms.ComboBox();
            this.labelFrequency = new System.Windows.Forms.Label();
            this.comboBoxFrequency = new System.Windows.Forms.ComboBox();
            this.checkedListBoxAudioStreams = new System.Windows.Forms.CheckedListBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.groupBoxDeinterlace = new System.Windows.Forms.GroupBox();
            this.labelFieldOrder = new System.Windows.Forms.Label();
            this.comboBoxFieldOrder = new System.Windows.Forms.ComboBox();
            this.groupBoxResolution = new System.Windows.Forms.GroupBox();
            this.pictureBoxRatioError = new System.Windows.Forms.PictureBox();
            this.comboBoxAspectRatio = new System.Windows.Forms.ComboBox();
            this.checkBoxKeepAspectRatio = new System.Windows.Forms.CheckBox();
            this.groupBoxAudioStreams = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBitrate)).BeginInit();
            this.groupBoxInOut.SuspendLayout();
            this.groupBoxVideoParams.SuspendLayout();
            this.groupBoxAudioParams.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.groupBoxDeinterlace.SuspendLayout();
            this.groupBoxResolution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRatioError)).BeginInit();
            this.groupBoxAudioStreams.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxIn
            // 
            this.textBoxIn.Location = new System.Drawing.Point(9, 32);
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.ReadOnly = true;
            this.textBoxIn.Size = new System.Drawing.Size(381, 21);
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
            this.textBoxOut.Size = new System.Drawing.Size(381, 21);
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
            this.labelIn.Size = new System.Drawing.Size(87, 13);
            this.labelIn.TabIndex = 0;
            this.labelIn.Text = "Исходный файл";
            // 
            // labelOut
            // 
            this.labelOut.AutoSize = true;
            this.labelOut.Location = new System.Drawing.Point(6, 59);
            this.labelOut.Name = "labelOut";
            this.labelOut.Size = new System.Drawing.Size(83, 13);
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
            this.numericUpDownWidth.Location = new System.Drawing.Point(8, 26);
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
            this.numericUpDownWidth.Size = new System.Drawing.Size(60, 21);
            this.numericUpDownWidth.TabIndex = 1;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            640,
            0,
            0,
            0});
            this.numericUpDownWidth.ValueChanged += new System.EventHandler(this.numericUpDownWidth_ValueChanged);
            this.numericUpDownWidth.Leave += new System.EventHandler(this.numericUpDownWidth_Leave);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(73, 28);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(13, 13);
            this.labelX.TabIndex = 2;
            this.labelX.Text = "x";
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownHeight.Location = new System.Drawing.Point(89, 26);
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
            this.numericUpDownHeight.Size = new System.Drawing.Size(60, 21);
            this.numericUpDownHeight.TabIndex = 3;
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
            this.numericUpDownBitrate.Size = new System.Drawing.Size(80, 21);
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
            this.checkBoxKeepOutPath.Size = new System.Drawing.Size(149, 17);
            this.checkBoxKeepOutPath.TabIndex = 6;
            this.checkBoxKeepOutPath.Text = "Запомнить путь к папке";
            this.checkBoxKeepOutPath.UseVisualStyleBackColor = true;
            this.checkBoxKeepOutPath.CheckedChanged += new System.EventHandler(this.checkBoxKeepOutPath_CheckedChanged);
            // 
            // groupBoxVideoParams
            // 
            this.groupBoxVideoParams.Controls.Add(this.labelFrameRate);
            this.groupBoxVideoParams.Controls.Add(this.comboBoxFrameRate);
            this.groupBoxVideoParams.Controls.Add(this.labelFileType);
            this.groupBoxVideoParams.Controls.Add(this.comboBoxFileType);
            this.groupBoxVideoParams.Controls.Add(this.labelBitrate);
            this.groupBoxVideoParams.Controls.Add(this.numericUpDownBitrate);
            this.groupBoxVideoParams.Location = new System.Drawing.Point(6, 138);
            this.groupBoxVideoParams.Name = "groupBoxVideoParams";
            this.groupBoxVideoParams.Size = new System.Drawing.Size(215, 112);
            this.groupBoxVideoParams.TabIndex = 1;
            this.groupBoxVideoParams.TabStop = false;
            this.groupBoxVideoParams.Text = "Видео";
            // 
            // labelFrameRate
            // 
            this.labelFrameRate.AutoSize = true;
            this.labelFrameRate.Location = new System.Drawing.Point(6, 81);
            this.labelFrameRate.Name = "labelFrameRate";
            this.labelFrameRate.Size = new System.Drawing.Size(89, 13);
            this.labelFrameRate.TabIndex = 4;
            this.labelFrameRate.Text = "Частота кадров";
            // 
            // comboBoxFrameRate
            // 
            this.comboBoxFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrameRate.FormattingEnabled = true;
            this.comboBoxFrameRate.Location = new System.Drawing.Point(127, 78);
            this.comboBoxFrameRate.Name = "comboBoxFrameRate";
            this.comboBoxFrameRate.Size = new System.Drawing.Size(80, 21);
            this.comboBoxFrameRate.TabIndex = 5;
            // 
            // labelFileType
            // 
            this.labelFileType.AutoSize = true;
            this.labelFileType.Location = new System.Drawing.Point(6, 24);
            this.labelFileType.Name = "labelFileType";
            this.labelFileType.Size = new System.Drawing.Size(80, 13);
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
            this.checkBoxDeinterlace.Location = new System.Drawing.Point(7, 0);
            this.checkBoxDeinterlace.Name = "checkBoxDeinterlace";
            this.checkBoxDeinterlace.Size = new System.Drawing.Size(110, 17);
            this.checkBoxDeinterlace.TabIndex = 0;
            this.checkBoxDeinterlace.Text = "Деинтерлейсинг";
            this.checkBoxDeinterlace.UseVisualStyleBackColor = true;
            this.checkBoxDeinterlace.CheckedChanged += new System.EventHandler(this.checkBoxDeinterlace_CheckedChanged);
            // 
            // checkBoxResizePicture
            // 
            this.checkBoxResizePicture.AutoSize = true;
            this.checkBoxResizePicture.Location = new System.Drawing.Point(7, 0);
            this.checkBoxResizePicture.Name = "checkBoxResizePicture";
            this.checkBoxResizePicture.Size = new System.Drawing.Size(138, 17);
            this.checkBoxResizePicture.TabIndex = 0;
            this.checkBoxResizePicture.Text = "Изменить разрешение";
            this.checkBoxResizePicture.UseVisualStyleBackColor = true;
            this.checkBoxResizePicture.CheckedChanged += new System.EventHandler(this.checkBoxResizePicture_CheckedChanged);
            // 
            // groupBoxAudioParams
            // 
            this.groupBoxAudioParams.Controls.Add(this.comboBoxAudioBitrate);
            this.groupBoxAudioParams.Controls.Add(this.labelAudioBitrate);
            this.groupBoxAudioParams.Controls.Add(this.labelChannels);
            this.groupBoxAudioParams.Controls.Add(this.comboBoxChannels);
            this.groupBoxAudioParams.Controls.Add(this.labelFrequency);
            this.groupBoxAudioParams.Controls.Add(this.comboBoxFrequency);
            this.groupBoxAudioParams.Location = new System.Drawing.Point(6, 256);
            this.groupBoxAudioParams.Name = "groupBoxAudioParams";
            this.groupBoxAudioParams.Size = new System.Drawing.Size(215, 107);
            this.groupBoxAudioParams.TabIndex = 2;
            this.groupBoxAudioParams.TabStop = false;
            this.groupBoxAudioParams.Text = "Аудио";
            // 
            // comboBoxAudioBitrate
            // 
            this.comboBoxAudioBitrate.FormattingEnabled = true;
            this.comboBoxAudioBitrate.Location = new System.Drawing.Point(127, 22);
            this.comboBoxAudioBitrate.Name = "comboBoxAudioBitrate";
            this.comboBoxAudioBitrate.Size = new System.Drawing.Size(80, 21);
            this.comboBoxAudioBitrate.TabIndex = 1;
            this.comboBoxAudioBitrate.Leave += new System.EventHandler(this.comboBoxAudioBitrate_Leave);
            // 
            // labelAudioBitrate
            // 
            this.labelAudioBitrate.AutoSize = true;
            this.labelAudioBitrate.Location = new System.Drawing.Point(6, 24);
            this.labelAudioBitrate.Name = "labelAudioBitrate";
            this.labelAudioBitrate.Size = new System.Drawing.Size(93, 13);
            this.labelAudioBitrate.TabIndex = 0;
            this.labelAudioBitrate.Text = "Битрейт (кбит/с)";
            // 
            // labelChannels
            // 
            this.labelChannels.AutoSize = true;
            this.labelChannels.Location = new System.Drawing.Point(6, 79);
            this.labelChannels.Name = "labelChannels";
            this.labelChannels.Size = new System.Drawing.Size(46, 13);
            this.labelChannels.TabIndex = 4;
            this.labelChannels.Text = "Каналы";
            // 
            // comboBoxChannels
            // 
            this.comboBoxChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChannels.FormattingEnabled = true;
            this.comboBoxChannels.Location = new System.Drawing.Point(127, 76);
            this.comboBoxChannels.Name = "comboBoxChannels";
            this.comboBoxChannels.Size = new System.Drawing.Size(80, 21);
            this.comboBoxChannels.TabIndex = 5;
            // 
            // labelFrequency
            // 
            this.labelFrequency.AutoSize = true;
            this.labelFrequency.Location = new System.Drawing.Point(6, 52);
            this.labelFrequency.Name = "labelFrequency";
            this.labelFrequency.Size = new System.Drawing.Size(49, 13);
            this.labelFrequency.TabIndex = 2;
            this.labelFrequency.Text = "Частота";
            // 
            // comboBoxFrequency
            // 
            this.comboBoxFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrequency.FormattingEnabled = true;
            this.comboBoxFrequency.Location = new System.Drawing.Point(127, 49);
            this.comboBoxFrequency.Name = "comboBoxFrequency";
            this.comboBoxFrequency.Size = new System.Drawing.Size(80, 21);
            this.comboBoxFrequency.TabIndex = 3;
            // 
            // checkedListBoxAudioStreams
            // 
            this.checkedListBoxAudioStreams.BackColor = System.Drawing.SystemColors.Control;
            this.checkedListBoxAudioStreams.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxAudioStreams.CheckOnClick = true;
            this.checkedListBoxAudioStreams.FormattingEnabled = true;
            this.checkedListBoxAudioStreams.HorizontalScrollbar = true;
            this.checkedListBoxAudioStreams.Location = new System.Drawing.Point(6, 16);
            this.checkedListBoxAudioStreams.Name = "checkedListBoxAudioStreams";
            this.checkedListBoxAudioStreams.Size = new System.Drawing.Size(203, 80);
            this.checkedListBoxAudioStreams.TabIndex = 0;
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(484, 296);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(145, 35);
            this.buttonGo.TabIndex = 6;
            this.buttonGo.Text = "Конвертировать";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(3, 374);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(664, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 7;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(527, 17);
            this.toolStripStatusLabel.Spring = true;
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(120, 16);
            // 
            // groupBoxInfo
            // 
            this.groupBoxInfo.Controls.Add(this.richTextBoxInfo);
            this.groupBoxInfo.Location = new System.Drawing.Point(448, 6);
            this.groupBoxInfo.Name = "groupBoxInfo";
            this.groupBoxInfo.Size = new System.Drawing.Size(215, 126);
            this.groupBoxInfo.TabIndex = 8;
            this.groupBoxInfo.TabStop = false;
            this.groupBoxInfo.Text = "Информация о файле";
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxInfo.Location = new System.Drawing.Point(7, 16);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxInfo.Size = new System.Drawing.Size(202, 104);
            this.richTextBoxInfo.TabIndex = 0;
            this.richTextBoxInfo.Text = "";
            // 
            // groupBoxDeinterlace
            // 
            this.groupBoxDeinterlace.Controls.Add(this.labelFieldOrder);
            this.groupBoxDeinterlace.Controls.Add(this.comboBoxFieldOrder);
            this.groupBoxDeinterlace.Controls.Add(this.checkBoxDeinterlace);
            this.groupBoxDeinterlace.Location = new System.Drawing.Point(227, 138);
            this.groupBoxDeinterlace.Name = "groupBoxDeinterlace";
            this.groupBoxDeinterlace.Size = new System.Drawing.Size(215, 112);
            this.groupBoxDeinterlace.TabIndex = 3;
            this.groupBoxDeinterlace.TabStop = false;
            // 
            // labelFieldOrder
            // 
            this.labelFieldOrder.AutoSize = true;
            this.labelFieldOrder.Location = new System.Drawing.Point(6, 22);
            this.labelFieldOrder.Name = "labelFieldOrder";
            this.labelFieldOrder.Size = new System.Drawing.Size(84, 13);
            this.labelFieldOrder.TabIndex = 1;
            this.labelFieldOrder.Text = "Порядок полей";
            // 
            // comboBoxFieldOrder
            // 
            this.comboBoxFieldOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFieldOrder.FormattingEnabled = true;
            this.comboBoxFieldOrder.Location = new System.Drawing.Point(9, 38);
            this.comboBoxFieldOrder.Name = "comboBoxFieldOrder";
            this.comboBoxFieldOrder.Size = new System.Drawing.Size(110, 21);
            this.comboBoxFieldOrder.TabIndex = 2;
            // 
            // groupBoxResolution
            // 
            this.groupBoxResolution.Controls.Add(this.pictureBoxRatioError);
            this.groupBoxResolution.Controls.Add(this.comboBoxAspectRatio);
            this.groupBoxResolution.Controls.Add(this.checkBoxResizePicture);
            this.groupBoxResolution.Controls.Add(this.checkBoxKeepAspectRatio);
            this.groupBoxResolution.Controls.Add(this.numericUpDownWidth);
            this.groupBoxResolution.Controls.Add(this.numericUpDownHeight);
            this.groupBoxResolution.Controls.Add(this.labelX);
            this.groupBoxResolution.Location = new System.Drawing.Point(448, 138);
            this.groupBoxResolution.Name = "groupBoxResolution";
            this.groupBoxResolution.Size = new System.Drawing.Size(215, 112);
            this.groupBoxResolution.TabIndex = 4;
            this.groupBoxResolution.TabStop = false;
            // 
            // pictureBoxRatioError
            // 
            this.pictureBoxRatioError.Location = new System.Drawing.Point(108, 80);
            this.pictureBoxRatioError.Name = "pictureBoxRatioError";
            this.pictureBoxRatioError.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxRatioError.TabIndex = 11;
            this.pictureBoxRatioError.TabStop = false;
            // 
            // comboBoxAspectRatio
            // 
            this.comboBoxAspectRatio.FormattingEnabled = true;
            this.comboBoxAspectRatio.Location = new System.Drawing.Point(8, 78);
            this.comboBoxAspectRatio.Name = "comboBoxAspectRatio";
            this.comboBoxAspectRatio.Size = new System.Drawing.Size(95, 21);
            this.comboBoxAspectRatio.TabIndex = 5;
            this.comboBoxAspectRatio.SelectedIndexChanged += new System.EventHandler(this.comboBoxAspectRatio_SelectedIndexChanged);
            this.comboBoxAspectRatio.TextUpdate += new System.EventHandler(this.comboBoxAspectRatio_TextUpdate);
            // 
            // checkBoxKeepAspectRatio
            // 
            this.checkBoxKeepAspectRatio.AutoSize = true;
            this.checkBoxKeepAspectRatio.Location = new System.Drawing.Point(8, 55);
            this.checkBoxKeepAspectRatio.Name = "checkBoxKeepAspectRatio";
            this.checkBoxKeepAspectRatio.Size = new System.Drawing.Size(138, 17);
            this.checkBoxKeepAspectRatio.TabIndex = 4;
            this.checkBoxKeepAspectRatio.Text = "Сохранять пропорции";
            this.checkBoxKeepAspectRatio.UseVisualStyleBackColor = true;
            this.checkBoxKeepAspectRatio.CheckedChanged += new System.EventHandler(this.checkBoxKeepAspectRatio_CheckedChanged);
            // 
            // groupBoxAudioStreams
            // 
            this.groupBoxAudioStreams.Controls.Add(this.checkedListBoxAudioStreams);
            this.groupBoxAudioStreams.Location = new System.Drawing.Point(227, 256);
            this.groupBoxAudioStreams.Name = "groupBoxAudioStreams";
            this.groupBoxAudioStreams.Size = new System.Drawing.Size(215, 107);
            this.groupBoxAudioStreams.TabIndex = 5;
            this.groupBoxAudioStreams.TabStop = false;
            this.groupBoxAudioStreams.Text = "Дорожки";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 396);
            this.Controls.Add(this.groupBoxAudioStreams);
            this.Controls.Add(this.groupBoxResolution);
            this.Controls.Add(this.groupBoxDeinterlace);
            this.Controls.Add(this.groupBoxInfo);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupBoxInOut);
            this.Controls.Add(this.groupBoxVideoParams);
            this.Controls.Add(this.groupBoxAudioParams);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxDeinterlace.ResumeLayout(false);
            this.groupBoxDeinterlace.PerformLayout();
            this.groupBoxResolution.ResumeLayout(false);
            this.groupBoxResolution.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRatioError)).EndInit();
            this.groupBoxAudioStreams.ResumeLayout(false);
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
        private System.Windows.Forms.ComboBox comboBoxChannels;
        private System.Windows.Forms.ComboBox comboBoxFileType;
        private System.Windows.Forms.Label labelFileType;
        private System.Windows.Forms.CheckBox checkBoxResizePicture;
        private System.Windows.Forms.Button buttonGo;
        public System.Windows.Forms.TextBox textBoxIn;
        public System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.CheckBox checkBoxDeinterlace;
        private System.Windows.Forms.CheckBox checkBoxKeepOutPath;
        private System.Windows.Forms.ComboBox comboBoxFrequency;
        private System.Windows.Forms.Label labelFrequency;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
        private System.Windows.Forms.CheckedListBox checkedListBoxAudioStreams;
        private System.Windows.Forms.GroupBox groupBoxDeinterlace;
        private System.Windows.Forms.GroupBox groupBoxResolution;
        private System.Windows.Forms.CheckBox checkBoxKeepAspectRatio;
        private System.Windows.Forms.ComboBox comboBoxAspectRatio;
        private System.Windows.Forms.ComboBox comboBoxFrameRate;
        private System.Windows.Forms.Label labelFieldOrder;
        private System.Windows.Forms.ComboBox comboBoxFieldOrder;
        private System.Windows.Forms.PictureBox pictureBoxRatioError;
        private System.Windows.Forms.Label labelFrameRate;
        private System.Windows.Forms.GroupBox groupBoxAudioStreams;
        private System.Windows.Forms.ComboBox comboBoxAudioBitrate;
    }
}


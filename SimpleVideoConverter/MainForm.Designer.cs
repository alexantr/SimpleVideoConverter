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
            this.buttonBrowseIn = new System.Windows.Forms.Button();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.buttonBrowseOut = new System.Windows.Forms.Button();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.labelX = new System.Windows.Forms.Label();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.labelBitrate = new System.Windows.Forms.Label();
            this.numericUpDownBitrate = new System.Windows.Forms.NumericUpDown();
            this.comboBoxEncodeMode = new System.Windows.Forms.ComboBox();
            this.labelEncodeMode = new System.Windows.Forms.Label();
            this.comboBoxFileType = new System.Windows.Forms.ComboBox();
            this.labelFrameRate = new System.Windows.Forms.Label();
            this.comboBoxFrameRate = new System.Windows.Forms.ComboBox();
            this.checkBoxResizePicture = new System.Windows.Forms.CheckBox();
            this.comboBoxAudioBitrate = new System.Windows.Forms.ComboBox();
            this.labelAudioBitrate = new System.Windows.Forms.Label();
            this.labelChannels = new System.Windows.Forms.Label();
            this.comboBoxChannels = new System.Windows.Forms.ComboBox();
            this.labelFrequency = new System.Windows.Forms.Label();
            this.comboBoxFrequency = new System.Windows.Forms.ComboBox();
            this.checkedListBoxAudioStreams = new System.Windows.Forms.CheckedListBox();
            this.buttonGo = new System.Windows.Forms.Button();
            this.pictureBoxRatioError = new System.Windows.Forms.PictureBox();
            this.comboBoxAspectRatio = new System.Windows.Forms.ComboBox();
            this.checkBoxKeepAspectRatio = new System.Windows.Forms.CheckBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPagePicture = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelCropBottom = new System.Windows.Forms.Label();
            this.labelCropRight = new System.Windows.Forms.Label();
            this.labelCropLeft = new System.Windows.Forms.Label();
            this.labelCropTop = new System.Windows.Forms.Label();
            this.numericCropBottom = new System.Windows.Forms.NumericUpDown();
            this.numericCropRight = new System.Windows.Forms.NumericUpDown();
            this.numericCropLeft = new System.Windows.Forms.NumericUpDown();
            this.numericCropTop = new System.Windows.Forms.NumericUpDown();
            this.labelCrop = new System.Windows.Forms.Label();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.labelColorFilter = new System.Windows.Forms.Label();
            this.comboBoxColorFilter = new System.Windows.Forms.ComboBox();
            this.panelDeinterlace = new System.Windows.Forms.Panel();
            this.labelFieldOrder = new System.Windows.Forms.Label();
            this.checkBoxDeinterlace = new System.Windows.Forms.CheckBox();
            this.comboBoxFieldOrder = new System.Windows.Forms.ComboBox();
            this.panelResolution = new System.Windows.Forms.Panel();
            this.comboBoxScalingMethod = new System.Windows.Forms.ComboBox();
            this.labelScalingMethod = new System.Windows.Forms.Label();
            this.tabPageVideo = new System.Windows.Forms.TabPage();
            this.panelVideoParams = new System.Windows.Forms.Panel();
            this.buttonVideoAdvanced = new System.Windows.Forms.Button();
            this.tabPageAudio = new System.Windows.Forms.TabPage();
            this.panelAudioParams = new System.Windows.Forms.Panel();
            this.labelInputFile = new System.Windows.Forms.Label();
            this.checkBoxKeepOutPath = new System.Windows.Forms.CheckBox();
            this.buttonShowInfo = new System.Windows.Forms.Button();
            this.labelFileType = new System.Windows.Forms.Label();
            this.labelOut = new System.Windows.Forms.Label();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.textBoxIn = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBitrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRatioError)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPagePicture.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropTop)).BeginInit();
            this.panelFilters.SuspendLayout();
            this.panelDeinterlace.SuspendLayout();
            this.panelResolution.SuspendLayout();
            this.tabPageVideo.SuspendLayout();
            this.panelVideoParams.SuspendLayout();
            this.tabPageAudio.SuspendLayout();
            this.panelAudioParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBrowseIn
            // 
            this.buttonBrowseIn.Location = new System.Drawing.Point(441, 25);
            this.buttonBrowseIn.Name = "buttonBrowseIn";
            this.buttonBrowseIn.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseIn.TabIndex = 2;
            this.buttonBrowseIn.Text = "Обзор";
            this.buttonBrowseIn.UseVisualStyleBackColor = true;
            this.buttonBrowseIn.Click += new System.EventHandler(this.buttonBrowseIn_Click);
            // 
            // textBoxOut
            // 
            this.textBoxOut.Location = new System.Drawing.Point(10, 71);
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.Size = new System.Drawing.Size(425, 21);
            this.textBoxOut.TabIndex = 4;
            // 
            // buttonBrowseOut
            // 
            this.buttonBrowseOut.Location = new System.Drawing.Point(441, 70);
            this.buttonBrowseOut.Name = "buttonBrowseOut";
            this.buttonBrowseOut.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseOut.TabIndex = 5;
            this.buttonBrowseOut.Text = "Обзор";
            this.buttonBrowseOut.UseVisualStyleBackColor = true;
            this.buttonBrowseOut.Click += new System.EventHandler(this.buttonBrowseOut_Click);
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownWidth.Location = new System.Drawing.Point(3, 26);
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
            this.labelX.Location = new System.Drawing.Point(67, 29);
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
            this.numericUpDownHeight.Location = new System.Drawing.Point(83, 26);
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
            this.numericUpDownHeight.Leave += new System.EventHandler(this.numericUpDownHeight_Leave);
            // 
            // labelBitrate
            // 
            this.labelBitrate.AutoSize = true;
            this.labelBitrate.Location = new System.Drawing.Point(3, 32);
            this.labelBitrate.Name = "labelBitrate";
            this.labelBitrate.Size = new System.Drawing.Size(27, 13);
            this.labelBitrate.TabIndex = 4;
            this.labelBitrate.Text = "CRF";
            // 
            // numericUpDownBitrate
            // 
            this.numericUpDownBitrate.Location = new System.Drawing.Point(118, 30);
            this.numericUpDownBitrate.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownBitrate.Name = "numericUpDownBitrate";
            this.numericUpDownBitrate.Size = new System.Drawing.Size(80, 21);
            this.numericUpDownBitrate.TabIndex = 5;
            this.numericUpDownBitrate.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // comboBoxEncodeMode
            // 
            this.comboBoxEncodeMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEncodeMode.FormattingEnabled = true;
            this.comboBoxEncodeMode.Location = new System.Drawing.Point(118, 3);
            this.comboBoxEncodeMode.Name = "comboBoxEncodeMode";
            this.comboBoxEncodeMode.Size = new System.Drawing.Size(80, 21);
            this.comboBoxEncodeMode.TabIndex = 3;
            this.comboBoxEncodeMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxEncodeMode_SelectedIndexChanged);
            // 
            // labelEncodeMode
            // 
            this.labelEncodeMode.AutoSize = true;
            this.labelEncodeMode.Location = new System.Drawing.Point(3, 6);
            this.labelEncodeMode.Name = "labelEncodeMode";
            this.labelEncodeMode.Size = new System.Drawing.Size(109, 13);
            this.labelEncodeMode.TabIndex = 2;
            this.labelEncodeMode.Text = "Режим кодирования";
            // 
            // comboBoxFileType
            // 
            this.comboBoxFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFileType.FormattingEnabled = true;
            this.comboBoxFileType.Location = new System.Drawing.Point(530, 71);
            this.comboBoxFileType.Name = "comboBoxFileType";
            this.comboBoxFileType.Size = new System.Drawing.Size(73, 21);
            this.comboBoxFileType.TabIndex = 1;
            this.comboBoxFileType.SelectedIndexChanged += new System.EventHandler(this.comboBoxFileType_SelectedIndexChanged);
            // 
            // labelFrameRate
            // 
            this.labelFrameRate.AutoSize = true;
            this.labelFrameRate.Location = new System.Drawing.Point(3, 76);
            this.labelFrameRate.Name = "labelFrameRate";
            this.labelFrameRate.Size = new System.Drawing.Size(89, 13);
            this.labelFrameRate.TabIndex = 0;
            this.labelFrameRate.Text = "Частота кадров";
            // 
            // comboBoxFrameRate
            // 
            this.comboBoxFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrameRate.FormattingEnabled = true;
            this.comboBoxFrameRate.Location = new System.Drawing.Point(118, 73);
            this.comboBoxFrameRate.Name = "comboBoxFrameRate";
            this.comboBoxFrameRate.Size = new System.Drawing.Size(80, 21);
            this.comboBoxFrameRate.TabIndex = 1;
            // 
            // checkBoxResizePicture
            // 
            this.checkBoxResizePicture.AutoSize = true;
            this.checkBoxResizePicture.Location = new System.Drawing.Point(3, 3);
            this.checkBoxResizePicture.Name = "checkBoxResizePicture";
            this.checkBoxResizePicture.Size = new System.Drawing.Size(120, 17);
            this.checkBoxResizePicture.TabIndex = 0;
            this.checkBoxResizePicture.Text = "Изменить размеры";
            this.checkBoxResizePicture.UseVisualStyleBackColor = true;
            this.checkBoxResizePicture.CheckedChanged += new System.EventHandler(this.checkBoxResizePicture_CheckedChanged);
            // 
            // comboBoxAudioBitrate
            // 
            this.comboBoxAudioBitrate.FormattingEnabled = true;
            this.comboBoxAudioBitrate.Location = new System.Drawing.Point(174, 3);
            this.comboBoxAudioBitrate.Name = "comboBoxAudioBitrate";
            this.comboBoxAudioBitrate.Size = new System.Drawing.Size(80, 21);
            this.comboBoxAudioBitrate.TabIndex = 1;
            this.comboBoxAudioBitrate.Leave += new System.EventHandler(this.comboBoxAudioBitrate_Leave);
            // 
            // labelAudioBitrate
            // 
            this.labelAudioBitrate.AutoSize = true;
            this.labelAudioBitrate.Location = new System.Drawing.Point(5, 6);
            this.labelAudioBitrate.Name = "labelAudioBitrate";
            this.labelAudioBitrate.Size = new System.Drawing.Size(93, 13);
            this.labelAudioBitrate.TabIndex = 0;
            this.labelAudioBitrate.Text = "Битрейт (кбит/с)";
            // 
            // labelChannels
            // 
            this.labelChannels.AutoSize = true;
            this.labelChannels.Location = new System.Drawing.Point(5, 60);
            this.labelChannels.Name = "labelChannels";
            this.labelChannels.Size = new System.Drawing.Size(112, 13);
            this.labelChannels.TabIndex = 4;
            this.labelChannels.Text = "Количество каналов";
            // 
            // comboBoxChannels
            // 
            this.comboBoxChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChannels.FormattingEnabled = true;
            this.comboBoxChannels.Location = new System.Drawing.Point(174, 57);
            this.comboBoxChannels.Name = "comboBoxChannels";
            this.comboBoxChannels.Size = new System.Drawing.Size(80, 21);
            this.comboBoxChannels.TabIndex = 5;
            // 
            // labelFrequency
            // 
            this.labelFrequency.AutoSize = true;
            this.labelFrequency.Location = new System.Drawing.Point(5, 33);
            this.labelFrequency.Name = "labelFrequency";
            this.labelFrequency.Size = new System.Drawing.Size(152, 13);
            this.labelFrequency.TabIndex = 2;
            this.labelFrequency.Text = "Частота дискретизации (Гц)";
            // 
            // comboBoxFrequency
            // 
            this.comboBoxFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrequency.FormattingEnabled = true;
            this.comboBoxFrequency.Location = new System.Drawing.Point(174, 30);
            this.comboBoxFrequency.Name = "comboBoxFrequency";
            this.comboBoxFrequency.Size = new System.Drawing.Size(80, 21);
            this.comboBoxFrequency.TabIndex = 3;
            // 
            // checkedListBoxAudioStreams
            // 
            this.checkedListBoxAudioStreams.CheckOnClick = true;
            this.checkedListBoxAudioStreams.FormattingEnabled = true;
            this.checkedListBoxAudioStreams.HorizontalScrollbar = true;
            this.checkedListBoxAudioStreams.Location = new System.Drawing.Point(278, 6);
            this.checkedListBoxAudioStreams.Name = "checkedListBoxAudioStreams";
            this.checkedListBoxAudioStreams.Size = new System.Drawing.Size(280, 116);
            this.checkedListBoxAudioStreams.TabIndex = 0;
            this.checkedListBoxAudioStreams.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxAudioStreams_SelectedIndexChanged);
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(478, 324);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(130, 32);
            this.buttonGo.TabIndex = 8;
            this.buttonGo.Text = "Конвертировать";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // pictureBoxRatioError
            // 
            this.pictureBoxRatioError.Location = new System.Drawing.Point(104, 77);
            this.pictureBoxRatioError.Name = "pictureBoxRatioError";
            this.pictureBoxRatioError.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxRatioError.TabIndex = 11;
            this.pictureBoxRatioError.TabStop = false;
            // 
            // comboBoxAspectRatio
            // 
            this.comboBoxAspectRatio.FormattingEnabled = true;
            this.comboBoxAspectRatio.Location = new System.Drawing.Point(3, 76);
            this.comboBoxAspectRatio.Name = "comboBoxAspectRatio";
            this.comboBoxAspectRatio.Size = new System.Drawing.Size(95, 21);
            this.comboBoxAspectRatio.TabIndex = 5;
            this.comboBoxAspectRatio.SelectedIndexChanged += new System.EventHandler(this.comboBoxAspectRatio_SelectedIndexChanged);
            this.comboBoxAspectRatio.TextUpdate += new System.EventHandler(this.comboBoxAspectRatio_TextUpdate);
            // 
            // checkBoxKeepAspectRatio
            // 
            this.checkBoxKeepAspectRatio.AutoSize = true;
            this.checkBoxKeepAspectRatio.Location = new System.Drawing.Point(3, 53);
            this.checkBoxKeepAspectRatio.Name = "checkBoxKeepAspectRatio";
            this.checkBoxKeepAspectRatio.Size = new System.Drawing.Size(138, 17);
            this.checkBoxKeepAspectRatio.TabIndex = 4;
            this.checkBoxKeepAspectRatio.Text = "Сохранять пропорции";
            this.checkBoxKeepAspectRatio.UseVisualStyleBackColor = true;
            this.checkBoxKeepAspectRatio.CheckedChanged += new System.EventHandler(this.checkBoxKeepAspectRatio_CheckedChanged);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPagePicture);
            this.tabControlMain.Controls.Add(this.tabPageVideo);
            this.tabControlMain.Controls.Add(this.tabPageAudio);
            this.tabControlMain.Location = new System.Drawing.Point(6, 124);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(602, 194);
            this.tabControlMain.TabIndex = 9;
            // 
            // tabPagePicture
            // 
            this.tabPagePicture.Controls.Add(this.panel1);
            this.tabPagePicture.Controls.Add(this.panelFilters);
            this.tabPagePicture.Controls.Add(this.panelDeinterlace);
            this.tabPagePicture.Controls.Add(this.panelResolution);
            this.tabPagePicture.Location = new System.Drawing.Point(4, 22);
            this.tabPagePicture.Name = "tabPagePicture";
            this.tabPagePicture.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePicture.Size = new System.Drawing.Size(594, 168);
            this.tabPagePicture.TabIndex = 1;
            this.tabPagePicture.Text = "Картинка";
            this.tabPagePicture.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelCropBottom);
            this.panel1.Controls.Add(this.labelCropRight);
            this.panel1.Controls.Add(this.labelCropLeft);
            this.panel1.Controls.Add(this.labelCropTop);
            this.panel1.Controls.Add(this.numericCropBottom);
            this.panel1.Controls.Add(this.numericCropRight);
            this.panel1.Controls.Add(this.numericCropLeft);
            this.panel1.Controls.Add(this.numericCropTop);
            this.panel1.Controls.Add(this.labelCrop);
            this.panel1.Location = new System.Drawing.Point(402, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 155);
            this.panel1.TabIndex = 11;
            // 
            // labelCropBottom
            // 
            this.labelCropBottom.AutoSize = true;
            this.labelCropBottom.Location = new System.Drawing.Point(76, 122);
            this.labelCropBottom.Name = "labelCropBottom";
            this.labelCropBottom.Size = new System.Drawing.Size(37, 13);
            this.labelCropBottom.TabIndex = 8;
            this.labelCropBottom.Text = "Снизу";
            // 
            // labelCropRight
            // 
            this.labelCropRight.AutoSize = true;
            this.labelCropRight.Location = new System.Drawing.Point(127, 55);
            this.labelCropRight.Name = "labelCropRight";
            this.labelCropRight.Size = new System.Drawing.Size(44, 13);
            this.labelCropRight.TabIndex = 7;
            this.labelCropRight.Text = "Справа";
            // 
            // labelCropLeft
            // 
            this.labelCropLeft.AutoSize = true;
            this.labelCropLeft.Location = new System.Drawing.Point(22, 55);
            this.labelCropLeft.Name = "labelCropLeft";
            this.labelCropLeft.Size = new System.Drawing.Size(38, 13);
            this.labelCropLeft.TabIndex = 6;
            this.labelCropLeft.Text = "Слева";
            // 
            // labelCropTop
            // 
            this.labelCropTop.AutoSize = true;
            this.labelCropTop.Location = new System.Drawing.Point(69, 28);
            this.labelCropTop.Name = "labelCropTop";
            this.labelCropTop.Size = new System.Drawing.Size(44, 13);
            this.labelCropTop.TabIndex = 5;
            this.labelCropTop.Text = "Сверху";
            // 
            // numericCropBottom
            // 
            this.numericCropBottom.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericCropBottom.Location = new System.Drawing.Point(66, 98);
            this.numericCropBottom.Name = "numericCropBottom";
            this.numericCropBottom.Size = new System.Drawing.Size(55, 21);
            this.numericCropBottom.TabIndex = 4;
            this.numericCropBottom.ValueChanged += new System.EventHandler(this.numericCropBottom_ValueChanged);
            // 
            // numericCropRight
            // 
            this.numericCropRight.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericCropRight.Location = new System.Drawing.Point(121, 71);
            this.numericCropRight.Name = "numericCropRight";
            this.numericCropRight.Size = new System.Drawing.Size(55, 21);
            this.numericCropRight.TabIndex = 3;
            this.numericCropRight.ValueChanged += new System.EventHandler(this.numericCropRight_ValueChanged);
            // 
            // numericCropLeft
            // 
            this.numericCropLeft.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericCropLeft.Location = new System.Drawing.Point(12, 71);
            this.numericCropLeft.Name = "numericCropLeft";
            this.numericCropLeft.Size = new System.Drawing.Size(55, 21);
            this.numericCropLeft.TabIndex = 2;
            this.numericCropLeft.ValueChanged += new System.EventHandler(this.numericCropLeft_ValueChanged);
            // 
            // numericCropTop
            // 
            this.numericCropTop.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericCropTop.Location = new System.Drawing.Point(66, 44);
            this.numericCropTop.Name = "numericCropTop";
            this.numericCropTop.Size = new System.Drawing.Size(55, 21);
            this.numericCropTop.TabIndex = 1;
            this.numericCropTop.ValueChanged += new System.EventHandler(this.numericCropTop_ValueChanged);
            // 
            // labelCrop
            // 
            this.labelCrop.AutoSize = true;
            this.labelCrop.Location = new System.Drawing.Point(4, 4);
            this.labelCrop.Name = "labelCrop";
            this.labelCrop.Size = new System.Drawing.Size(152, 13);
            this.labelCrop.TabIndex = 0;
            this.labelCrop.Text = "Обрезка исходной картинки";
            // 
            // panelFilters
            // 
            this.panelFilters.Controls.Add(this.labelColorFilter);
            this.panelFilters.Controls.Add(this.comboBoxColorFilter);
            this.panelFilters.Location = new System.Drawing.Point(194, 73);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(191, 89);
            this.panelFilters.TabIndex = 10;
            // 
            // labelColorFilter
            // 
            this.labelColorFilter.AutoSize = true;
            this.labelColorFilter.Location = new System.Drawing.Point(3, 13);
            this.labelColorFilter.Name = "labelColorFilter";
            this.labelColorFilter.Size = new System.Drawing.Size(45, 13);
            this.labelColorFilter.TabIndex = 2;
            this.labelColorFilter.Text = "Фильтр";
            // 
            // comboBoxColorFilter
            // 
            this.comboBoxColorFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColorFilter.FormattingEnabled = true;
            this.comboBoxColorFilter.Location = new System.Drawing.Point(93, 9);
            this.comboBoxColorFilter.Name = "comboBoxColorFilter";
            this.comboBoxColorFilter.Size = new System.Drawing.Size(95, 21);
            this.comboBoxColorFilter.TabIndex = 1;
            // 
            // panelDeinterlace
            // 
            this.panelDeinterlace.Controls.Add(this.labelFieldOrder);
            this.panelDeinterlace.Controls.Add(this.checkBoxDeinterlace);
            this.panelDeinterlace.Controls.Add(this.comboBoxFieldOrder);
            this.panelDeinterlace.Location = new System.Drawing.Point(193, 6);
            this.panelDeinterlace.Name = "panelDeinterlace";
            this.panelDeinterlace.Size = new System.Drawing.Size(192, 60);
            this.panelDeinterlace.TabIndex = 9;
            // 
            // labelFieldOrder
            // 
            this.labelFieldOrder.AutoSize = true;
            this.labelFieldOrder.Location = new System.Drawing.Point(4, 29);
            this.labelFieldOrder.Name = "labelFieldOrder";
            this.labelFieldOrder.Size = new System.Drawing.Size(84, 13);
            this.labelFieldOrder.TabIndex = 1;
            this.labelFieldOrder.Text = "Порядок полей";
            // 
            // checkBoxDeinterlace
            // 
            this.checkBoxDeinterlace.AutoSize = true;
            this.checkBoxDeinterlace.Location = new System.Drawing.Point(3, 3);
            this.checkBoxDeinterlace.Name = "checkBoxDeinterlace";
            this.checkBoxDeinterlace.Size = new System.Drawing.Size(153, 17);
            this.checkBoxDeinterlace.TabIndex = 0;
            this.checkBoxDeinterlace.Text = "Убрать чересстрочность";
            this.checkBoxDeinterlace.UseVisualStyleBackColor = true;
            // 
            // comboBoxFieldOrder
            // 
            this.comboBoxFieldOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFieldOrder.FormattingEnabled = true;
            this.comboBoxFieldOrder.Location = new System.Drawing.Point(94, 25);
            this.comboBoxFieldOrder.Name = "comboBoxFieldOrder";
            this.comboBoxFieldOrder.Size = new System.Drawing.Size(95, 21);
            this.comboBoxFieldOrder.TabIndex = 2;
            // 
            // panelResolution
            // 
            this.panelResolution.Controls.Add(this.comboBoxScalingMethod);
            this.panelResolution.Controls.Add(this.labelScalingMethod);
            this.panelResolution.Controls.Add(this.pictureBoxRatioError);
            this.panelResolution.Controls.Add(this.checkBoxResizePicture);
            this.panelResolution.Controls.Add(this.comboBoxAspectRatio);
            this.panelResolution.Controls.Add(this.numericUpDownWidth);
            this.panelResolution.Controls.Add(this.checkBoxKeepAspectRatio);
            this.panelResolution.Controls.Add(this.labelX);
            this.panelResolution.Controls.Add(this.numericUpDownHeight);
            this.panelResolution.Location = new System.Drawing.Point(6, 6);
            this.panelResolution.Name = "panelResolution";
            this.panelResolution.Size = new System.Drawing.Size(169, 156);
            this.panelResolution.TabIndex = 8;
            // 
            // comboBoxScalingMethod
            // 
            this.comboBoxScalingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScalingMethod.FormattingEnabled = true;
            this.comboBoxScalingMethod.Location = new System.Drawing.Point(3, 121);
            this.comboBoxScalingMethod.Name = "comboBoxScalingMethod";
            this.comboBoxScalingMethod.Size = new System.Drawing.Size(117, 21);
            this.comboBoxScalingMethod.TabIndex = 13;
            // 
            // labelScalingMethod
            // 
            this.labelScalingMethod.AutoSize = true;
            this.labelScalingMethod.Location = new System.Drawing.Point(3, 105);
            this.labelScalingMethod.Name = "labelScalingMethod";
            this.labelScalingMethod.Size = new System.Drawing.Size(134, 13);
            this.labelScalingMethod.TabIndex = 12;
            this.labelScalingMethod.Text = "Метод масштабирования";
            // 
            // tabPageVideo
            // 
            this.tabPageVideo.Controls.Add(this.panelVideoParams);
            this.tabPageVideo.Location = new System.Drawing.Point(4, 22);
            this.tabPageVideo.Name = "tabPageVideo";
            this.tabPageVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVideo.Size = new System.Drawing.Size(594, 168);
            this.tabPageVideo.TabIndex = 0;
            this.tabPageVideo.Text = "Видео";
            this.tabPageVideo.UseVisualStyleBackColor = true;
            // 
            // panelVideoParams
            // 
            this.panelVideoParams.Controls.Add(this.labelEncodeMode);
            this.panelVideoParams.Controls.Add(this.buttonVideoAdvanced);
            this.panelVideoParams.Controls.Add(this.labelBitrate);
            this.panelVideoParams.Controls.Add(this.labelFrameRate);
            this.panelVideoParams.Controls.Add(this.numericUpDownBitrate);
            this.panelVideoParams.Controls.Add(this.comboBoxFrameRate);
            this.panelVideoParams.Controls.Add(this.comboBoxEncodeMode);
            this.panelVideoParams.Location = new System.Drawing.Point(6, 6);
            this.panelVideoParams.Name = "panelVideoParams";
            this.panelVideoParams.Size = new System.Drawing.Size(261, 141);
            this.panelVideoParams.TabIndex = 7;
            // 
            // buttonVideoAdvanced
            // 
            this.buttonVideoAdvanced.Enabled = false;
            this.buttonVideoAdvanced.Location = new System.Drawing.Point(3, 115);
            this.buttonVideoAdvanced.Name = "buttonVideoAdvanced";
            this.buttonVideoAdvanced.Size = new System.Drawing.Size(105, 23);
            this.buttonVideoAdvanced.TabIndex = 6;
            this.buttonVideoAdvanced.Text = "Доп. настройки";
            this.buttonVideoAdvanced.UseVisualStyleBackColor = true;
            // 
            // tabPageAudio
            // 
            this.tabPageAudio.Controls.Add(this.checkedListBoxAudioStreams);
            this.tabPageAudio.Controls.Add(this.panelAudioParams);
            this.tabPageAudio.Location = new System.Drawing.Point(4, 22);
            this.tabPageAudio.Name = "tabPageAudio";
            this.tabPageAudio.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAudio.Size = new System.Drawing.Size(594, 168);
            this.tabPageAudio.TabIndex = 2;
            this.tabPageAudio.Text = "Аудио";
            this.tabPageAudio.UseVisualStyleBackColor = true;
            // 
            // panelAudioParams
            // 
            this.panelAudioParams.Controls.Add(this.comboBoxAudioBitrate);
            this.panelAudioParams.Controls.Add(this.labelAudioBitrate);
            this.panelAudioParams.Controls.Add(this.comboBoxFrequency);
            this.panelAudioParams.Controls.Add(this.labelChannels);
            this.panelAudioParams.Controls.Add(this.labelFrequency);
            this.panelAudioParams.Controls.Add(this.comboBoxChannels);
            this.panelAudioParams.Location = new System.Drawing.Point(6, 6);
            this.panelAudioParams.Name = "panelAudioParams";
            this.panelAudioParams.Size = new System.Drawing.Size(266, 100);
            this.panelAudioParams.TabIndex = 17;
            // 
            // labelInputFile
            // 
            this.labelInputFile.AutoSize = true;
            this.labelInputFile.Location = new System.Drawing.Point(7, 10);
            this.labelInputFile.Name = "labelInputFile";
            this.labelInputFile.Size = new System.Drawing.Size(80, 13);
            this.labelInputFile.TabIndex = 15;
            this.labelInputFile.Text = "Выбрать файл";
            // 
            // checkBoxKeepOutPath
            // 
            this.checkBoxKeepOutPath.AutoSize = true;
            this.checkBoxKeepOutPath.Location = new System.Drawing.Point(10, 98);
            this.checkBoxKeepOutPath.Name = "checkBoxKeepOutPath";
            this.checkBoxKeepOutPath.Size = new System.Drawing.Size(175, 17);
            this.checkBoxKeepOutPath.TabIndex = 12;
            this.checkBoxKeepOutPath.Text = "Запомнить выбранную папку";
            this.checkBoxKeepOutPath.UseVisualStyleBackColor = true;
            // 
            // buttonShowInfo
            // 
            this.buttonShowInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonShowInfo.Location = new System.Drawing.Point(529, 25);
            this.buttonShowInfo.Name = "buttonShowInfo";
            this.buttonShowInfo.Size = new System.Drawing.Size(75, 23);
            this.buttonShowInfo.TabIndex = 7;
            this.buttonShowInfo.Text = "Инфо";
            this.buttonShowInfo.UseVisualStyleBackColor = true;
            this.buttonShowInfo.Click += new System.EventHandler(this.buttonShowInfo_Click);
            // 
            // labelFileType
            // 
            this.labelFileType.AutoSize = true;
            this.labelFileType.Location = new System.Drawing.Point(527, 55);
            this.labelFileType.Name = "labelFileType";
            this.labelFileType.Size = new System.Drawing.Size(60, 13);
            this.labelFileType.TabIndex = 0;
            this.labelFileType.Text = "Тип файла";
            // 
            // labelOut
            // 
            this.labelOut.AutoSize = true;
            this.labelOut.Location = new System.Drawing.Point(7, 55);
            this.labelOut.Name = "labelOut";
            this.labelOut.Size = new System.Drawing.Size(83, 13);
            this.labelOut.TabIndex = 3;
            this.labelOut.Text = "Сохранить как";
            // 
            // buttonAbout
            // 
            this.buttonAbout.BackgroundImage = global::Alexantr.SimpleVideoConverter.Properties.Resources.information;
            this.buttonAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAbout.Location = new System.Drawing.Point(6, 324);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(32, 32);
            this.buttonAbout.TabIndex = 10;
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // textBoxIn
            // 
            this.textBoxIn.Location = new System.Drawing.Point(10, 26);
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.ReadOnly = true;
            this.textBoxIn.Size = new System.Drawing.Size(425, 21);
            this.textBoxIn.TabIndex = 16;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 362);
            this.Controls.Add(this.comboBoxFileType);
            this.Controls.Add(this.buttonShowInfo);
            this.Controls.Add(this.labelFileType);
            this.Controls.Add(this.checkBoxKeepOutPath);
            this.Controls.Add(this.buttonBrowseOut);
            this.Controls.Add(this.textBoxIn);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.labelInputFile);
            this.Controls.Add(this.buttonBrowseIn);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.textBoxOut);
            this.Controls.Add(this.labelOut);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Simple Video Converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBitrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRatioError)).EndInit();
            this.tabControlMain.ResumeLayout(false);
            this.tabPagePicture.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropTop)).EndInit();
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.panelDeinterlace.ResumeLayout(false);
            this.panelDeinterlace.PerformLayout();
            this.panelResolution.ResumeLayout(false);
            this.panelResolution.PerformLayout();
            this.tabPageVideo.ResumeLayout(false);
            this.panelVideoParams.ResumeLayout(false);
            this.panelVideoParams.PerformLayout();
            this.tabPageAudio.ResumeLayout(false);
            this.panelAudioParams.ResumeLayout(false);
            this.panelAudioParams.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonBrowseIn;
        private System.Windows.Forms.Button buttonBrowseOut;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label labelBitrate;
        private System.Windows.Forms.NumericUpDown numericUpDownBitrate;
        private System.Windows.Forms.Label labelAudioBitrate;
        private System.Windows.Forms.Label labelChannels;
        private System.Windows.Forms.ComboBox comboBoxChannels;
        private System.Windows.Forms.ComboBox comboBoxFileType;
        private System.Windows.Forms.CheckBox checkBoxResizePicture;
        private System.Windows.Forms.Button buttonGo;
        public System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.ComboBox comboBoxFrequency;
        private System.Windows.Forms.Label labelFrequency;
        private System.Windows.Forms.CheckedListBox checkedListBoxAudioStreams;
        private System.Windows.Forms.CheckBox checkBoxKeepAspectRatio;
        private System.Windows.Forms.ComboBox comboBoxAspectRatio;
        private System.Windows.Forms.ComboBox comboBoxFrameRate;
        private System.Windows.Forms.PictureBox pictureBoxRatioError;
        private System.Windows.Forms.Label labelFrameRate;
        private System.Windows.Forms.ComboBox comboBoxAudioBitrate;
        private System.Windows.Forms.ComboBox comboBoxEncodeMode;
        private System.Windows.Forms.Label labelEncodeMode;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPagePicture;
        private System.Windows.Forms.TabPage tabPageVideo;
        private System.Windows.Forms.TabPage tabPageAudio;
        private System.Windows.Forms.Button buttonShowInfo;
        private System.Windows.Forms.Button buttonVideoAdvanced;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.CheckBox checkBoxKeepOutPath;
        private System.Windows.Forms.Label labelFileType;
        private System.Windows.Forms.Label labelInputFile;
        private System.Windows.Forms.Label labelOut;
        private System.Windows.Forms.TextBox textBoxIn;
        private System.Windows.Forms.Panel panelResolution;
        private System.Windows.Forms.Panel panelVideoParams;
        private System.Windows.Forms.Panel panelAudioParams;
        private System.Windows.Forms.Panel panelDeinterlace;
        private System.Windows.Forms.Label labelFieldOrder;
        private System.Windows.Forms.CheckBox checkBoxDeinterlace;
        private System.Windows.Forms.ComboBox comboBoxFieldOrder;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.ComboBox comboBoxScalingMethod;
        private System.Windows.Forms.Label labelScalingMethod;
        private System.Windows.Forms.Label labelColorFilter;
        private System.Windows.Forms.ComboBox comboBoxColorFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelCropBottom;
        private System.Windows.Forms.Label labelCropRight;
        private System.Windows.Forms.Label labelCropLeft;
        private System.Windows.Forms.Label labelCropTop;
        private System.Windows.Forms.NumericUpDown numericCropBottom;
        private System.Windows.Forms.NumericUpDown numericCropRight;
        private System.Windows.Forms.NumericUpDown numericCropLeft;
        private System.Windows.Forms.NumericUpDown numericCropTop;
        private System.Windows.Forms.Label labelCrop;
    }
}


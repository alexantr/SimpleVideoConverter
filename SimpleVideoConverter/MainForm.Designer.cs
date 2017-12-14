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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.buttonBrowseOut = new System.Windows.Forms.Button();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.labelX = new System.Windows.Forms.Label();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownBitrate = new System.Windows.Forms.NumericUpDown();
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
            this.tabPageFile = new System.Windows.Forms.TabPage();
            this.panelFile = new System.Windows.Forms.Panel();
            this.labelFileType = new System.Windows.Forms.Label();
            this.buttonOpenInputFile = new System.Windows.Forms.Button();
            this.labelOut = new System.Windows.Forms.Label();
            this.labelInputFile = new System.Windows.Forms.Label();
            this.buttonShowInfo = new System.Windows.Forms.Button();
            this.checkBoxKeepOutPath = new System.Windows.Forms.CheckBox();
            this.buttonBrowseIn = new System.Windows.Forms.Button();
            this.textBoxIn = new System.Windows.Forms.TextBox();
            this.tabPagePicture = new System.Windows.Forms.TabPage();
            this.panelCrop = new System.Windows.Forms.Panel();
            this.labelCropSize = new System.Windows.Forms.Label();
            this.labelCropBottom = new System.Windows.Forms.Label();
            this.labelCropRight = new System.Windows.Forms.Label();
            this.labelCropLeft = new System.Windows.Forms.Label();
            this.labelCropTop = new System.Windows.Forms.Label();
            this.numericCropBottom = new System.Windows.Forms.NumericUpDown();
            this.numericCropRight = new System.Windows.Forms.NumericUpDown();
            this.numericCropLeft = new System.Windows.Forms.NumericUpDown();
            this.numericCropTop = new System.Windows.Forms.NumericUpDown();
            this.labelCrop = new System.Windows.Forms.Label();
            this.panelResolution = new System.Windows.Forms.Panel();
            this.labelResizeMethod = new System.Windows.Forms.Label();
            this.comboBoxResizeMethod = new System.Windows.Forms.ComboBox();
            this.comboBoxResizePreset = new System.Windows.Forms.ComboBox();
            this.tabPageFilters = new System.Windows.Forms.TabPage();
            this.panelFilters = new System.Windows.Forms.Panel();
            this.labelColorFilter = new System.Windows.Forms.Label();
            this.comboBoxColorFilter = new System.Windows.Forms.ComboBox();
            this.panelDeinterlace = new System.Windows.Forms.Panel();
            this.labelFieldOrder = new System.Windows.Forms.Label();
            this.checkBoxDeinterlace = new System.Windows.Forms.CheckBox();
            this.comboBoxFieldOrder = new System.Windows.Forms.ComboBox();
            this.tabPageVideo = new System.Windows.Forms.TabPage();
            this.panelVideo = new System.Windows.Forms.Panel();
            this.labelCalcSize = new System.Windows.Forms.Label();
            this.labelCalcSizeText = new System.Windows.Forms.Label();
            this.labelVideoKbps = new System.Windows.Forms.Label();
            this.labelMinQ = new System.Windows.Forms.Label();
            this.labelMaxQ = new System.Windows.Forms.Label();
            this.labelCRF = new System.Windows.Forms.Label();
            this.radioButtonBitrate = new System.Windows.Forms.RadioButton();
            this.radioButtonCRF = new System.Windows.Forms.RadioButton();
            this.trackBarCRF = new System.Windows.Forms.TrackBar();
            this.panelVideoParams = new System.Windows.Forms.Panel();
            this.buttonVideoAdvanced = new System.Windows.Forms.Button();
            this.tabPageAudio = new System.Windows.Forms.TabPage();
            this.panelAudioStreams = new System.Windows.Forms.Panel();
            this.labelSelectStreams = new System.Windows.Forms.Label();
            this.panelAudioParams = new System.Windows.Forms.Panel();
            this.labelAudioHz = new System.Windows.Forms.Label();
            this.labelAudioKbps = new System.Windows.Forms.Label();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.toolTipHint = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBitrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRatioError)).BeginInit();
            this.tabControlMain.SuspendLayout();
            this.tabPageFile.SuspendLayout();
            this.panelFile.SuspendLayout();
            this.tabPagePicture.SuspendLayout();
            this.panelCrop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropTop)).BeginInit();
            this.panelResolution.SuspendLayout();
            this.tabPageFilters.SuspendLayout();
            this.panelFilters.SuspendLayout();
            this.panelDeinterlace.SuspendLayout();
            this.tabPageVideo.SuspendLayout();
            this.panelVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCRF)).BeginInit();
            this.panelVideoParams.SuspendLayout();
            this.tabPageAudio.SuspendLayout();
            this.panelAudioStreams.SuspendLayout();
            this.panelAudioParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxOut
            // 
            this.textBoxOut.Location = new System.Drawing.Point(92, 71);
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.Size = new System.Drawing.Size(346, 21);
            this.textBoxOut.TabIndex = 4;
            // 
            // buttonBrowseOut
            // 
            this.buttonBrowseOut.Location = new System.Drawing.Point(444, 70);
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
            // numericUpDownBitrate
            // 
            this.numericUpDownBitrate.Location = new System.Drawing.Point(77, 95);
            this.numericUpDownBitrate.Name = "numericUpDownBitrate";
            this.numericUpDownBitrate.Size = new System.Drawing.Size(80, 21);
            this.numericUpDownBitrate.TabIndex = 5;
            this.numericUpDownBitrate.ValueChanged += new System.EventHandler(this.numericUpDownBitrate_ValueChanged);
            // 
            // comboBoxFileType
            // 
            this.comboBoxFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFileType.FormattingEnabled = true;
            this.comboBoxFileType.Location = new System.Drawing.Point(92, 133);
            this.comboBoxFileType.Name = "comboBoxFileType";
            this.comboBoxFileType.Size = new System.Drawing.Size(75, 21);
            this.comboBoxFileType.TabIndex = 1;
            this.comboBoxFileType.SelectedIndexChanged += new System.EventHandler(this.comboBoxFileType_SelectedIndexChanged);
            // 
            // labelFrameRate
            // 
            this.labelFrameRate.AutoSize = true;
            this.labelFrameRate.Location = new System.Drawing.Point(3, 6);
            this.labelFrameRate.Name = "labelFrameRate";
            this.labelFrameRate.Size = new System.Drawing.Size(89, 13);
            this.labelFrameRate.TabIndex = 0;
            this.labelFrameRate.Text = "Частота кадров";
            // 
            // comboBoxFrameRate
            // 
            this.comboBoxFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrameRate.FormattingEnabled = true;
            this.comboBoxFrameRate.Location = new System.Drawing.Point(98, 3);
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
            this.comboBoxAudioBitrate.Location = new System.Drawing.Point(138, 22);
            this.comboBoxAudioBitrate.Name = "comboBoxAudioBitrate";
            this.comboBoxAudioBitrate.Size = new System.Drawing.Size(80, 21);
            this.comboBoxAudioBitrate.TabIndex = 1;
            this.comboBoxAudioBitrate.Leave += new System.EventHandler(this.comboBoxAudioBitrate_Leave);
            // 
            // labelAudioBitrate
            // 
            this.labelAudioBitrate.AutoSize = true;
            this.labelAudioBitrate.Location = new System.Drawing.Point(3, 25);
            this.labelAudioBitrate.Name = "labelAudioBitrate";
            this.labelAudioBitrate.Size = new System.Drawing.Size(49, 13);
            this.labelAudioBitrate.TabIndex = 0;
            this.labelAudioBitrate.Text = "Битрейт";
            // 
            // labelChannels
            // 
            this.labelChannels.AutoSize = true;
            this.labelChannels.Location = new System.Drawing.Point(3, 89);
            this.labelChannels.Name = "labelChannels";
            this.labelChannels.Size = new System.Drawing.Size(112, 13);
            this.labelChannels.TabIndex = 4;
            this.labelChannels.Text = "Количество каналов";
            // 
            // comboBoxChannels
            // 
            this.comboBoxChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChannels.FormattingEnabled = true;
            this.comboBoxChannels.Location = new System.Drawing.Point(138, 86);
            this.comboBoxChannels.Name = "comboBoxChannels";
            this.comboBoxChannels.Size = new System.Drawing.Size(80, 21);
            this.comboBoxChannels.TabIndex = 5;
            // 
            // labelFrequency
            // 
            this.labelFrequency.AutoSize = true;
            this.labelFrequency.Location = new System.Drawing.Point(3, 57);
            this.labelFrequency.Name = "labelFrequency";
            this.labelFrequency.Size = new System.Drawing.Size(129, 13);
            this.labelFrequency.TabIndex = 2;
            this.labelFrequency.Text = "Частота дискретизации";
            // 
            // comboBoxFrequency
            // 
            this.comboBoxFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrequency.FormattingEnabled = true;
            this.comboBoxFrequency.Location = new System.Drawing.Point(138, 54);
            this.comboBoxFrequency.Name = "comboBoxFrequency";
            this.comboBoxFrequency.Size = new System.Drawing.Size(80, 21);
            this.comboBoxFrequency.TabIndex = 3;
            // 
            // checkedListBoxAudioStreams
            // 
            this.checkedListBoxAudioStreams.CheckOnClick = true;
            this.checkedListBoxAudioStreams.FormattingEnabled = true;
            this.checkedListBoxAudioStreams.HorizontalScrollbar = true;
            this.checkedListBoxAudioStreams.Location = new System.Drawing.Point(3, 22);
            this.checkedListBoxAudioStreams.Name = "checkedListBoxAudioStreams";
            this.checkedListBoxAudioStreams.Size = new System.Drawing.Size(235, 132);
            this.checkedListBoxAudioStreams.TabIndex = 0;
            this.checkedListBoxAudioStreams.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxAudioStreams_SelectedIndexChanged);
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(418, 207);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(130, 32);
            this.buttonGo.TabIndex = 8;
            this.buttonGo.Text = "Конвертировать";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // pictureBoxRatioError
            // 
            this.pictureBoxRatioError.Location = new System.Drawing.Point(99, 89);
            this.pictureBoxRatioError.Name = "pictureBoxRatioError";
            this.pictureBoxRatioError.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxRatioError.TabIndex = 11;
            this.pictureBoxRatioError.TabStop = false;
            // 
            // comboBoxAspectRatio
            // 
            this.comboBoxAspectRatio.FormattingEnabled = true;
            this.comboBoxAspectRatio.Location = new System.Drawing.Point(3, 87);
            this.comboBoxAspectRatio.Name = "comboBoxAspectRatio";
            this.comboBoxAspectRatio.Size = new System.Drawing.Size(90, 21);
            this.comboBoxAspectRatio.TabIndex = 5;
            this.comboBoxAspectRatio.SelectedIndexChanged += new System.EventHandler(this.comboBoxAspectRatio_SelectedIndexChanged);
            this.comboBoxAspectRatio.TextUpdate += new System.EventHandler(this.comboBoxAspectRatio_TextUpdate);
            // 
            // checkBoxKeepAspectRatio
            // 
            this.checkBoxKeepAspectRatio.AutoSize = true;
            this.checkBoxKeepAspectRatio.Location = new System.Drawing.Point(3, 67);
            this.checkBoxKeepAspectRatio.Name = "checkBoxKeepAspectRatio";
            this.checkBoxKeepAspectRatio.Size = new System.Drawing.Size(138, 17);
            this.checkBoxKeepAspectRatio.TabIndex = 4;
            this.checkBoxKeepAspectRatio.Text = "Сохранять пропорции";
            this.checkBoxKeepAspectRatio.UseVisualStyleBackColor = true;
            this.checkBoxKeepAspectRatio.CheckedChanged += new System.EventHandler(this.checkBoxKeepAspectRatio_CheckedChanged);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageFile);
            this.tabControlMain.Controls.Add(this.tabPagePicture);
            this.tabControlMain.Controls.Add(this.tabPageFilters);
            this.tabControlMain.Controls.Add(this.tabPageVideo);
            this.tabControlMain.Controls.Add(this.tabPageAudio);
            this.tabControlMain.Location = new System.Drawing.Point(6, 6);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(542, 195);
            this.tabControlMain.TabIndex = 9;
            // 
            // tabPageFile
            // 
            this.tabPageFile.Controls.Add(this.panelFile);
            this.tabPageFile.Location = new System.Drawing.Point(4, 22);
            this.tabPageFile.Name = "tabPageFile";
            this.tabPageFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFile.Size = new System.Drawing.Size(534, 169);
            this.tabPageFile.TabIndex = 3;
            this.tabPageFile.Text = "Файл";
            this.tabPageFile.UseVisualStyleBackColor = true;
            // 
            // panelFile
            // 
            this.panelFile.Controls.Add(this.comboBoxFileType);
            this.panelFile.Controls.Add(this.labelFileType);
            this.panelFile.Controls.Add(this.buttonOpenInputFile);
            this.panelFile.Controls.Add(this.labelOut);
            this.panelFile.Controls.Add(this.labelInputFile);
            this.panelFile.Controls.Add(this.textBoxOut);
            this.panelFile.Controls.Add(this.buttonShowInfo);
            this.panelFile.Controls.Add(this.checkBoxKeepOutPath);
            this.panelFile.Controls.Add(this.buttonBrowseIn);
            this.panelFile.Controls.Add(this.buttonBrowseOut);
            this.panelFile.Controls.Add(this.textBoxIn);
            this.panelFile.Location = new System.Drawing.Point(6, 6);
            this.panelFile.Name = "panelFile";
            this.panelFile.Size = new System.Drawing.Size(522, 157);
            this.panelFile.TabIndex = 0;
            // 
            // labelFileType
            // 
            this.labelFileType.AutoSize = true;
            this.labelFileType.Location = new System.Drawing.Point(3, 136);
            this.labelFileType.Name = "labelFileType";
            this.labelFileType.Size = new System.Drawing.Size(60, 13);
            this.labelFileType.TabIndex = 0;
            this.labelFileType.Text = "Тип файла";
            // 
            // buttonOpenInputFile
            // 
            this.buttonOpenInputFile.Location = new System.Drawing.Point(173, 31);
            this.buttonOpenInputFile.Name = "buttonOpenInputFile";
            this.buttonOpenInputFile.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenInputFile.TabIndex = 17;
            this.buttonOpenInputFile.Text = "Открыть";
            this.toolTipHint.SetToolTip(this.buttonOpenInputFile, "Открыть исходный файл в проигрывателе по умолчанию");
            this.buttonOpenInputFile.UseVisualStyleBackColor = true;
            this.buttonOpenInputFile.Click += new System.EventHandler(this.buttonOpenInputFile_Click);
            // 
            // labelOut
            // 
            this.labelOut.AutoSize = true;
            this.labelOut.Location = new System.Drawing.Point(3, 75);
            this.labelOut.Name = "labelOut";
            this.labelOut.Size = new System.Drawing.Size(83, 13);
            this.labelOut.TabIndex = 3;
            this.labelOut.Text = "Сохранить как";
            // 
            // labelInputFile
            // 
            this.labelInputFile.AutoSize = true;
            this.labelInputFile.Location = new System.Drawing.Point(3, 8);
            this.labelInputFile.Name = "labelInputFile";
            this.labelInputFile.Size = new System.Drawing.Size(80, 13);
            this.labelInputFile.TabIndex = 15;
            this.labelInputFile.Text = "Выбрать файл";
            // 
            // buttonShowInfo
            // 
            this.buttonShowInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonShowInfo.Location = new System.Drawing.Point(92, 31);
            this.buttonShowInfo.Name = "buttonShowInfo";
            this.buttonShowInfo.Size = new System.Drawing.Size(75, 23);
            this.buttonShowInfo.TabIndex = 7;
            this.buttonShowInfo.Text = "Инфо";
            this.toolTipHint.SetToolTip(this.buttonShowInfo, "Показать информацию об исходном файле");
            this.buttonShowInfo.UseVisualStyleBackColor = true;
            this.buttonShowInfo.Click += new System.EventHandler(this.buttonShowInfo_Click);
            // 
            // checkBoxKeepOutPath
            // 
            this.checkBoxKeepOutPath.AutoSize = true;
            this.checkBoxKeepOutPath.Location = new System.Drawing.Point(92, 98);
            this.checkBoxKeepOutPath.Name = "checkBoxKeepOutPath";
            this.checkBoxKeepOutPath.Size = new System.Drawing.Size(175, 17);
            this.checkBoxKeepOutPath.TabIndex = 12;
            this.checkBoxKeepOutPath.Text = "Запомнить выбранную папку";
            this.checkBoxKeepOutPath.UseVisualStyleBackColor = true;
            // 
            // buttonBrowseIn
            // 
            this.buttonBrowseIn.Location = new System.Drawing.Point(444, 3);
            this.buttonBrowseIn.Name = "buttonBrowseIn";
            this.buttonBrowseIn.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseIn.TabIndex = 2;
            this.buttonBrowseIn.Text = "Обзор";
            this.buttonBrowseIn.UseVisualStyleBackColor = true;
            this.buttonBrowseIn.Click += new System.EventHandler(this.buttonBrowseIn_Click);
            // 
            // textBoxIn
            // 
            this.textBoxIn.Location = new System.Drawing.Point(92, 4);
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.ReadOnly = true;
            this.textBoxIn.Size = new System.Drawing.Size(346, 21);
            this.textBoxIn.TabIndex = 16;
            // 
            // tabPagePicture
            // 
            this.tabPagePicture.Controls.Add(this.panelCrop);
            this.tabPagePicture.Controls.Add(this.panelResolution);
            this.tabPagePicture.Location = new System.Drawing.Point(4, 22);
            this.tabPagePicture.Name = "tabPagePicture";
            this.tabPagePicture.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePicture.Size = new System.Drawing.Size(534, 169);
            this.tabPagePicture.TabIndex = 1;
            this.tabPagePicture.Text = "Картинка";
            this.tabPagePicture.UseVisualStyleBackColor = true;
            // 
            // panelCrop
            // 
            this.panelCrop.Controls.Add(this.labelCropSize);
            this.panelCrop.Controls.Add(this.labelCropBottom);
            this.panelCrop.Controls.Add(this.labelCropRight);
            this.panelCrop.Controls.Add(this.labelCropLeft);
            this.panelCrop.Controls.Add(this.labelCropTop);
            this.panelCrop.Controls.Add(this.numericCropBottom);
            this.panelCrop.Controls.Add(this.numericCropRight);
            this.panelCrop.Controls.Add(this.numericCropLeft);
            this.panelCrop.Controls.Add(this.numericCropTop);
            this.panelCrop.Controls.Add(this.labelCrop);
            this.panelCrop.Location = new System.Drawing.Point(283, 6);
            this.panelCrop.Name = "panelCrop";
            this.panelCrop.Size = new System.Drawing.Size(245, 157);
            this.panelCrop.TabIndex = 11;
            // 
            // labelCropSize
            // 
            this.labelCropSize.Location = new System.Drawing.Point(3, 138);
            this.labelCropSize.Name = "labelCropSize";
            this.labelCropSize.Size = new System.Drawing.Size(239, 16);
            this.labelCropSize.TabIndex = 15;
            this.labelCropSize.Text = "WxH → WxH";
            this.labelCropSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelCropBottom
            // 
            this.labelCropBottom.AutoSize = true;
            this.labelCropBottom.Location = new System.Drawing.Point(102, 118);
            this.labelCropBottom.Name = "labelCropBottom";
            this.labelCropBottom.Size = new System.Drawing.Size(37, 13);
            this.labelCropBottom.TabIndex = 8;
            this.labelCropBottom.Text = "Снизу";
            // 
            // labelCropRight
            // 
            this.labelCropRight.AutoSize = true;
            this.labelCropRight.Location = new System.Drawing.Point(196, 71);
            this.labelCropRight.Name = "labelCropRight";
            this.labelCropRight.Size = new System.Drawing.Size(44, 13);
            this.labelCropRight.TabIndex = 7;
            this.labelCropRight.Text = "Справа";
            // 
            // labelCropLeft
            // 
            this.labelCropLeft.AutoSize = true;
            this.labelCropLeft.Location = new System.Drawing.Point(8, 71);
            this.labelCropLeft.Name = "labelCropLeft";
            this.labelCropLeft.Size = new System.Drawing.Size(38, 13);
            this.labelCropLeft.TabIndex = 6;
            this.labelCropLeft.Text = "Слева";
            // 
            // labelCropTop
            // 
            this.labelCropTop.AutoSize = true;
            this.labelCropTop.Location = new System.Drawing.Point(95, 24);
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
            this.numericCropBottom.Location = new System.Drawing.Point(94, 94);
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
            this.numericCropRight.Location = new System.Drawing.Point(135, 67);
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
            this.numericCropLeft.Location = new System.Drawing.Point(52, 67);
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
            this.numericCropTop.Location = new System.Drawing.Point(94, 40);
            this.numericCropTop.Name = "numericCropTop";
            this.numericCropTop.Size = new System.Drawing.Size(55, 21);
            this.numericCropTop.TabIndex = 1;
            this.numericCropTop.ValueChanged += new System.EventHandler(this.numericCropTop_ValueChanged);
            // 
            // labelCrop
            // 
            this.labelCrop.AutoSize = true;
            this.labelCrop.Location = new System.Drawing.Point(3, 3);
            this.labelCrop.Name = "labelCrop";
            this.labelCrop.Size = new System.Drawing.Size(83, 13);
            this.labelCrop.TabIndex = 0;
            this.labelCrop.Text = "Обрезать поля";
            // 
            // panelResolution
            // 
            this.panelResolution.Controls.Add(this.labelResizeMethod);
            this.panelResolution.Controls.Add(this.comboBoxResizeMethod);
            this.panelResolution.Controls.Add(this.comboBoxResizePreset);
            this.panelResolution.Controls.Add(this.pictureBoxRatioError);
            this.panelResolution.Controls.Add(this.checkBoxResizePicture);
            this.panelResolution.Controls.Add(this.comboBoxAspectRatio);
            this.panelResolution.Controls.Add(this.numericUpDownWidth);
            this.panelResolution.Controls.Add(this.checkBoxKeepAspectRatio);
            this.panelResolution.Controls.Add(this.labelX);
            this.panelResolution.Controls.Add(this.numericUpDownHeight);
            this.panelResolution.Location = new System.Drawing.Point(6, 6);
            this.panelResolution.Name = "panelResolution";
            this.panelResolution.Size = new System.Drawing.Size(271, 157);
            this.panelResolution.TabIndex = 8;
            // 
            // labelResizeMethod
            // 
            this.labelResizeMethod.AutoSize = true;
            this.labelResizeMethod.Location = new System.Drawing.Point(3, 136);
            this.labelResizeMethod.Name = "labelResizeMethod";
            this.labelResizeMethod.Size = new System.Drawing.Size(83, 13);
            this.labelResizeMethod.TabIndex = 21;
            this.labelResizeMethod.Text = "Метод ресайза";
            // 
            // comboBoxResizeMethod
            // 
            this.comboBoxResizeMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResizeMethod.FormattingEnabled = true;
            this.comboBoxResizeMethod.Location = new System.Drawing.Point(92, 133);
            this.comboBoxResizeMethod.Name = "comboBoxResizeMethod";
            this.comboBoxResizeMethod.Size = new System.Drawing.Size(110, 21);
            this.comboBoxResizeMethod.TabIndex = 20;
            // 
            // comboBoxResizePreset
            // 
            this.comboBoxResizePreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResizePreset.FormattingEnabled = true;
            this.comboBoxResizePreset.Location = new System.Drawing.Point(162, 26);
            this.comboBoxResizePreset.Name = "comboBoxResizePreset";
            this.comboBoxResizePreset.Size = new System.Drawing.Size(65, 21);
            this.comboBoxResizePreset.TabIndex = 19;
            this.toolTipHint.SetToolTip(this.comboBoxResizePreset, resources.GetString("comboBoxResizePreset.ToolTip"));
            this.comboBoxResizePreset.SelectedIndexChanged += new System.EventHandler(this.comboBoxResizePreset_SelectedIndexChanged);
            // 
            // tabPageFilters
            // 
            this.tabPageFilters.Controls.Add(this.panelFilters);
            this.tabPageFilters.Controls.Add(this.panelDeinterlace);
            this.tabPageFilters.Location = new System.Drawing.Point(4, 22);
            this.tabPageFilters.Name = "tabPageFilters";
            this.tabPageFilters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFilters.Size = new System.Drawing.Size(534, 169);
            this.tabPageFilters.TabIndex = 4;
            this.tabPageFilters.Text = "Фильтры";
            this.tabPageFilters.UseVisualStyleBackColor = true;
            // 
            // panelFilters
            // 
            this.panelFilters.Controls.Add(this.labelColorFilter);
            this.panelFilters.Controls.Add(this.comboBoxColorFilter);
            this.panelFilters.Location = new System.Drawing.Point(6, 81);
            this.panelFilters.Name = "panelFilters";
            this.panelFilters.Size = new System.Drawing.Size(264, 82);
            this.panelFilters.TabIndex = 12;
            // 
            // labelColorFilter
            // 
            this.labelColorFilter.AutoSize = true;
            this.labelColorFilter.Location = new System.Drawing.Point(3, 14);
            this.labelColorFilter.Name = "labelColorFilter";
            this.labelColorFilter.Size = new System.Drawing.Size(98, 13);
            this.labelColorFilter.TabIndex = 2;
            this.labelColorFilter.Text = "Цветовой фильтр";
            // 
            // comboBoxColorFilter
            // 
            this.comboBoxColorFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColorFilter.FormattingEnabled = true;
            this.comboBoxColorFilter.Location = new System.Drawing.Point(107, 11);
            this.comboBoxColorFilter.Name = "comboBoxColorFilter";
            this.comboBoxColorFilter.Size = new System.Drawing.Size(110, 21);
            this.comboBoxColorFilter.TabIndex = 1;
            // 
            // panelDeinterlace
            // 
            this.panelDeinterlace.Controls.Add(this.labelFieldOrder);
            this.panelDeinterlace.Controls.Add(this.checkBoxDeinterlace);
            this.panelDeinterlace.Controls.Add(this.comboBoxFieldOrder);
            this.panelDeinterlace.Location = new System.Drawing.Point(6, 6);
            this.panelDeinterlace.Name = "panelDeinterlace";
            this.panelDeinterlace.Size = new System.Drawing.Size(264, 69);
            this.panelDeinterlace.TabIndex = 11;
            // 
            // labelFieldOrder
            // 
            this.labelFieldOrder.AutoSize = true;
            this.labelFieldOrder.Location = new System.Drawing.Point(3, 29);
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
            this.checkBoxDeinterlace.CheckedChanged += new System.EventHandler(this.checkBoxDeinterlace_CheckedChanged);
            // 
            // comboBoxFieldOrder
            // 
            this.comboBoxFieldOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFieldOrder.FormattingEnabled = true;
            this.comboBoxFieldOrder.Location = new System.Drawing.Point(107, 26);
            this.comboBoxFieldOrder.Name = "comboBoxFieldOrder";
            this.comboBoxFieldOrder.Size = new System.Drawing.Size(110, 21);
            this.comboBoxFieldOrder.TabIndex = 2;
            // 
            // tabPageVideo
            // 
            this.tabPageVideo.Controls.Add(this.panelVideo);
            this.tabPageVideo.Controls.Add(this.panelVideoParams);
            this.tabPageVideo.Location = new System.Drawing.Point(4, 22);
            this.tabPageVideo.Name = "tabPageVideo";
            this.tabPageVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVideo.Size = new System.Drawing.Size(534, 169);
            this.tabPageVideo.TabIndex = 0;
            this.tabPageVideo.Text = "Видео";
            this.tabPageVideo.UseVisualStyleBackColor = true;
            // 
            // panelVideo
            // 
            this.panelVideo.Controls.Add(this.labelCalcSize);
            this.panelVideo.Controls.Add(this.labelCalcSizeText);
            this.panelVideo.Controls.Add(this.labelVideoKbps);
            this.panelVideo.Controls.Add(this.labelMinQ);
            this.panelVideo.Controls.Add(this.labelMaxQ);
            this.panelVideo.Controls.Add(this.labelCRF);
            this.panelVideo.Controls.Add(this.radioButtonBitrate);
            this.panelVideo.Controls.Add(this.radioButtonCRF);
            this.panelVideo.Controls.Add(this.trackBarCRF);
            this.panelVideo.Controls.Add(this.numericUpDownBitrate);
            this.panelVideo.Location = new System.Drawing.Point(6, 6);
            this.panelVideo.Name = "panelVideo";
            this.panelVideo.Size = new System.Drawing.Size(288, 157);
            this.panelVideo.TabIndex = 8;
            // 
            // labelCalcSize
            // 
            this.labelCalcSize.AutoSize = true;
            this.labelCalcSize.Location = new System.Drawing.Point(84, 141);
            this.labelCalcSize.Name = "labelCalcSize";
            this.labelCalcSize.Size = new System.Drawing.Size(11, 13);
            this.labelCalcSize.TabIndex = 11;
            this.labelCalcSize.Text = "-";
            // 
            // labelCalcSizeText
            // 
            this.labelCalcSizeText.AutoSize = true;
            this.labelCalcSizeText.Location = new System.Drawing.Point(3, 141);
            this.labelCalcSizeText.Name = "labelCalcSizeText";
            this.labelCalcSizeText.Size = new System.Drawing.Size(81, 13);
            this.labelCalcSizeText.TabIndex = 10;
            this.labelCalcSizeText.Text = "Размер файла:";
            // 
            // labelVideoKbps
            // 
            this.labelVideoKbps.AutoSize = true;
            this.labelVideoKbps.Location = new System.Drawing.Point(163, 98);
            this.labelVideoKbps.Name = "labelVideoKbps";
            this.labelVideoKbps.Size = new System.Drawing.Size(40, 13);
            this.labelVideoKbps.TabIndex = 9;
            this.labelVideoKbps.Text = "кбит/с";
            // 
            // labelMinQ
            // 
            this.labelMinQ.AutoSize = true;
            this.labelMinQ.Location = new System.Drawing.Point(204, 62);
            this.labelMinQ.Name = "labelMinQ";
            this.labelMinQ.Size = new System.Drawing.Size(81, 13);
            this.labelMinQ.TabIndex = 8;
            this.labelMinQ.Text = "Мин. качество";
            // 
            // labelMaxQ
            // 
            this.labelMaxQ.AutoSize = true;
            this.labelMaxQ.Location = new System.Drawing.Point(3, 62);
            this.labelMaxQ.Name = "labelMaxQ";
            this.labelMaxQ.Size = new System.Drawing.Size(86, 13);
            this.labelMaxQ.TabIndex = 7;
            this.labelMaxQ.Text = "Макс. качество";
            // 
            // labelCRF
            // 
            this.labelCRF.AutoSize = true;
            this.labelCRF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCRF.Location = new System.Drawing.Point(139, 6);
            this.labelCRF.Name = "labelCRF";
            this.labelCRF.Size = new System.Drawing.Size(21, 13);
            this.labelCRF.TabIndex = 6;
            this.labelCRF.Text = "20";
            // 
            // radioButtonBitrate
            // 
            this.radioButtonBitrate.AutoSize = true;
            this.radioButtonBitrate.Location = new System.Drawing.Point(4, 96);
            this.radioButtonBitrate.Name = "radioButtonBitrate";
            this.radioButtonBitrate.Size = new System.Drawing.Size(67, 17);
            this.radioButtonBitrate.TabIndex = 2;
            this.radioButtonBitrate.TabStop = true;
            this.radioButtonBitrate.Text = "Битрейт";
            this.radioButtonBitrate.UseVisualStyleBackColor = true;
            this.radioButtonBitrate.CheckedChanged += new System.EventHandler(this.radioButtonBitrate_CheckedChanged);
            // 
            // radioButtonCRF
            // 
            this.radioButtonCRF.AutoSize = true;
            this.radioButtonCRF.Location = new System.Drawing.Point(4, 4);
            this.radioButtonCRF.Name = "radioButtonCRF";
            this.radioButtonCRF.Size = new System.Drawing.Size(129, 17);
            this.radioButtonCRF.TabIndex = 1;
            this.radioButtonCRF.TabStop = true;
            this.radioButtonCRF.Text = "Constant Rate Factor";
            this.radioButtonCRF.UseVisualStyleBackColor = true;
            this.radioButtonCRF.CheckedChanged += new System.EventHandler(this.radioButtonCRF_CheckedChanged);
            // 
            // trackBarCRF
            // 
            this.trackBarCRF.BackColor = System.Drawing.SystemColors.Window;
            this.trackBarCRF.Location = new System.Drawing.Point(3, 30);
            this.trackBarCRF.Maximum = 51;
            this.trackBarCRF.Name = "trackBarCRF";
            this.trackBarCRF.Size = new System.Drawing.Size(282, 45);
            this.trackBarCRF.TabIndex = 0;
            this.trackBarCRF.Value = 20;
            this.trackBarCRF.ValueChanged += new System.EventHandler(this.trackBarCRF_ValueChanged);
            // 
            // panelVideoParams
            // 
            this.panelVideoParams.Controls.Add(this.buttonVideoAdvanced);
            this.panelVideoParams.Controls.Add(this.labelFrameRate);
            this.panelVideoParams.Controls.Add(this.comboBoxFrameRate);
            this.panelVideoParams.Location = new System.Drawing.Point(300, 6);
            this.panelVideoParams.Name = "panelVideoParams";
            this.panelVideoParams.Size = new System.Drawing.Size(228, 157);
            this.panelVideoParams.TabIndex = 7;
            // 
            // buttonVideoAdvanced
            // 
            this.buttonVideoAdvanced.Enabled = false;
            this.buttonVideoAdvanced.Location = new System.Drawing.Point(6, 131);
            this.buttonVideoAdvanced.Name = "buttonVideoAdvanced";
            this.buttonVideoAdvanced.Size = new System.Drawing.Size(105, 23);
            this.buttonVideoAdvanced.TabIndex = 6;
            this.buttonVideoAdvanced.Text = "Доп. настройки";
            this.buttonVideoAdvanced.UseVisualStyleBackColor = true;
            // 
            // tabPageAudio
            // 
            this.tabPageAudio.Controls.Add(this.panelAudioStreams);
            this.tabPageAudio.Controls.Add(this.panelAudioParams);
            this.tabPageAudio.Location = new System.Drawing.Point(4, 22);
            this.tabPageAudio.Name = "tabPageAudio";
            this.tabPageAudio.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAudio.Size = new System.Drawing.Size(534, 169);
            this.tabPageAudio.TabIndex = 2;
            this.tabPageAudio.Text = "Аудио";
            this.tabPageAudio.UseVisualStyleBackColor = true;
            // 
            // panelAudioStreams
            // 
            this.panelAudioStreams.Controls.Add(this.labelSelectStreams);
            this.panelAudioStreams.Controls.Add(this.checkedListBoxAudioStreams);
            this.panelAudioStreams.Location = new System.Drawing.Point(6, 6);
            this.panelAudioStreams.Name = "panelAudioStreams";
            this.panelAudioStreams.Size = new System.Drawing.Size(241, 157);
            this.panelAudioStreams.TabIndex = 18;
            // 
            // labelSelectStreams
            // 
            this.labelSelectStreams.AutoSize = true;
            this.labelSelectStreams.Location = new System.Drawing.Point(3, 3);
            this.labelSelectStreams.Name = "labelSelectStreams";
            this.labelSelectStreams.Size = new System.Drawing.Size(99, 13);
            this.labelSelectStreams.TabIndex = 1;
            this.labelSelectStreams.Text = "Выбрать дорожки";
            // 
            // panelAudioParams
            // 
            this.panelAudioParams.Controls.Add(this.labelAudioHz);
            this.panelAudioParams.Controls.Add(this.labelAudioKbps);
            this.panelAudioParams.Controls.Add(this.comboBoxAudioBitrate);
            this.panelAudioParams.Controls.Add(this.labelAudioBitrate);
            this.panelAudioParams.Controls.Add(this.comboBoxFrequency);
            this.panelAudioParams.Controls.Add(this.labelChannels);
            this.panelAudioParams.Controls.Add(this.labelFrequency);
            this.panelAudioParams.Controls.Add(this.comboBoxChannels);
            this.panelAudioParams.Location = new System.Drawing.Point(250, 6);
            this.panelAudioParams.Name = "panelAudioParams";
            this.panelAudioParams.Size = new System.Drawing.Size(278, 157);
            this.panelAudioParams.TabIndex = 17;
            // 
            // labelAudioHz
            // 
            this.labelAudioHz.AutoSize = true;
            this.labelAudioHz.Location = new System.Drawing.Point(224, 57);
            this.labelAudioHz.Name = "labelAudioHz";
            this.labelAudioHz.Size = new System.Drawing.Size(19, 13);
            this.labelAudioHz.TabIndex = 7;
            this.labelAudioHz.Text = "Гц";
            // 
            // labelAudioKbps
            // 
            this.labelAudioKbps.AutoSize = true;
            this.labelAudioKbps.Location = new System.Drawing.Point(224, 25);
            this.labelAudioKbps.Name = "labelAudioKbps";
            this.labelAudioKbps.Size = new System.Drawing.Size(40, 13);
            this.labelAudioKbps.TabIndex = 6;
            this.labelAudioKbps.Text = "кбит/с";
            // 
            // buttonAbout
            // 
            this.buttonAbout.BackgroundImage = global::Alexantr.SimpleVideoConverter.Properties.Resources.information;
            this.buttonAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAbout.Location = new System.Drawing.Point(6, 207);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(32, 32);
            this.buttonAbout.TabIndex = 10;
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 245);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.buttonGo);
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
            this.tabPageFile.ResumeLayout(false);
            this.panelFile.ResumeLayout(false);
            this.panelFile.PerformLayout();
            this.tabPagePicture.ResumeLayout(false);
            this.panelCrop.ResumeLayout(false);
            this.panelCrop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropTop)).EndInit();
            this.panelResolution.ResumeLayout(false);
            this.panelResolution.PerformLayout();
            this.tabPageFilters.ResumeLayout(false);
            this.panelFilters.ResumeLayout(false);
            this.panelFilters.PerformLayout();
            this.panelDeinterlace.ResumeLayout(false);
            this.panelDeinterlace.PerformLayout();
            this.tabPageVideo.ResumeLayout(false);
            this.panelVideo.ResumeLayout(false);
            this.panelVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCRF)).EndInit();
            this.panelVideoParams.ResumeLayout(false);
            this.panelVideoParams.PerformLayout();
            this.tabPageAudio.ResumeLayout(false);
            this.panelAudioStreams.ResumeLayout(false);
            this.panelAudioStreams.PerformLayout();
            this.panelAudioParams.ResumeLayout(false);
            this.panelAudioParams.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonBrowseOut;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
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
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPagePicture;
        private System.Windows.Forms.TabPage tabPageVideo;
        private System.Windows.Forms.TabPage tabPageAudio;
        private System.Windows.Forms.Button buttonVideoAdvanced;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.CheckBox checkBoxKeepOutPath;
        private System.Windows.Forms.Label labelFileType;
        private System.Windows.Forms.Label labelOut;
        private System.Windows.Forms.Panel panelResolution;
        private System.Windows.Forms.Panel panelVideoParams;
        private System.Windows.Forms.Panel panelAudioParams;
        private System.Windows.Forms.Panel panelCrop;
        private System.Windows.Forms.Label labelCropBottom;
        private System.Windows.Forms.Label labelCropRight;
        private System.Windows.Forms.Label labelCropLeft;
        private System.Windows.Forms.Label labelCropTop;
        private System.Windows.Forms.NumericUpDown numericCropBottom;
        private System.Windows.Forms.NumericUpDown numericCropRight;
        private System.Windows.Forms.NumericUpDown numericCropLeft;
        private System.Windows.Forms.NumericUpDown numericCropTop;
        private System.Windows.Forms.Label labelCrop;
        private System.Windows.Forms.Label labelCropSize;
        private System.Windows.Forms.TabPage tabPageFile;
        private System.Windows.Forms.TabPage tabPageFilters;
        private System.Windows.Forms.Panel panelFilters;
        private System.Windows.Forms.Label labelColorFilter;
        private System.Windows.Forms.ComboBox comboBoxColorFilter;
        private System.Windows.Forms.Panel panelDeinterlace;
        private System.Windows.Forms.Label labelFieldOrder;
        private System.Windows.Forms.CheckBox checkBoxDeinterlace;
        private System.Windows.Forms.ComboBox comboBoxFieldOrder;
        private System.Windows.Forms.Panel panelAudioStreams;
        private System.Windows.Forms.Panel panelFile;
        private System.Windows.Forms.Button buttonOpenInputFile;
        private System.Windows.Forms.Label labelInputFile;
        private System.Windows.Forms.Button buttonShowInfo;
        private System.Windows.Forms.Button buttonBrowseIn;
        private System.Windows.Forms.TextBox textBoxIn;
        private System.Windows.Forms.Panel panelVideo;
        private System.Windows.Forms.ToolTip toolTipHint;
        private System.Windows.Forms.TrackBar trackBarCRF;
        private System.Windows.Forms.RadioButton radioButtonBitrate;
        private System.Windows.Forms.RadioButton radioButtonCRF;
        private System.Windows.Forms.Label labelCRF;
        private System.Windows.Forms.Label labelMinQ;
        private System.Windows.Forms.Label labelMaxQ;
        private System.Windows.Forms.Label labelVideoKbps;
        private System.Windows.Forms.Label labelCalcSize;
        private System.Windows.Forms.Label labelCalcSizeText;
        private System.Windows.Forms.Label labelSelectStreams;
        private System.Windows.Forms.Label labelAudioHz;
        private System.Windows.Forms.Label labelAudioKbps;
        private System.Windows.Forms.ComboBox comboBoxResizePreset;
        private System.Windows.Forms.Label labelResizeMethod;
        private System.Windows.Forms.ComboBox comboBoxResizeMethod;
    }
}


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
            this.groupBoxDeinterlace = new System.Windows.Forms.GroupBox();
            this.labelFieldOrder = new System.Windows.Forms.Label();
            this.comboBoxFieldOrder = new System.Windows.Forms.ComboBox();
            this.groupBoxResolution = new System.Windows.Forms.GroupBox();
            this.pictureBoxRatioError = new System.Windows.Forms.PictureBox();
            this.comboBoxAspectRatio = new System.Windows.Forms.ComboBox();
            this.checkBoxKeepAspectRatio = new System.Windows.Forms.CheckBox();
            this.groupBoxAudioStreams = new System.Windows.Forms.GroupBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageFile = new System.Windows.Forms.TabPage();
            this.checkBoxKeepOutPath = new System.Windows.Forms.CheckBox();
            this.buttonShowInfo = new System.Windows.Forms.Button();
            this.tabPagePicture = new System.Windows.Forms.TabPage();
            this.tabPageFilters = new System.Windows.Forms.TabPage();
            this.tabPageVideo = new System.Windows.Forms.TabPage();
            this.buttonVideoAdvanced = new System.Windows.Forms.Button();
            this.tabPageAudio = new System.Windows.Forms.TabPage();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.labelInFileName = new System.Windows.Forms.Label();
            this.buttonOpenInputFile = new System.Windows.Forms.Button();
            this.labelFileType = new System.Windows.Forms.Label();
            this.labelOut = new System.Windows.Forms.Label();
            this.labelInputFile = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBitrate)).BeginInit();
            this.groupBoxAudioParams.SuspendLayout();
            this.groupBoxDeinterlace.SuspendLayout();
            this.groupBoxResolution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRatioError)).BeginInit();
            this.groupBoxAudioStreams.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageFile.SuspendLayout();
            this.tabPagePicture.SuspendLayout();
            this.tabPageFilters.SuspendLayout();
            this.tabPageVideo.SuspendLayout();
            this.tabPageAudio.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBrowseIn
            // 
            this.buttonBrowseIn.Location = new System.Drawing.Point(6, 25);
            this.buttonBrowseIn.Name = "buttonBrowseIn";
            this.buttonBrowseIn.Size = new System.Drawing.Size(110, 25);
            this.buttonBrowseIn.TabIndex = 2;
            this.buttonBrowseIn.Text = "Выбрать файл";
            this.buttonBrowseIn.UseVisualStyleBackColor = true;
            this.buttonBrowseIn.Click += new System.EventHandler(this.buttonBrowseIn_Click);
            // 
            // textBoxOut
            // 
            this.textBoxOut.Location = new System.Drawing.Point(6, 105);
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.Size = new System.Drawing.Size(390, 21);
            this.textBoxOut.TabIndex = 4;
            // 
            // buttonBrowseOut
            // 
            this.buttonBrowseOut.Location = new System.Drawing.Point(402, 104);
            this.buttonBrowseOut.Name = "buttonBrowseOut";
            this.buttonBrowseOut.Size = new System.Drawing.Size(70, 23);
            this.buttonBrowseOut.TabIndex = 5;
            this.buttonBrowseOut.Text = "Обзор...";
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
            this.numericUpDownWidth.Location = new System.Drawing.Point(6, 23);
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
            this.labelX.Location = new System.Drawing.Point(70, 26);
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
            this.numericUpDownHeight.Location = new System.Drawing.Point(86, 23);
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
            this.labelBitrate.Location = new System.Drawing.Point(6, 35);
            this.labelBitrate.Name = "labelBitrate";
            this.labelBitrate.Size = new System.Drawing.Size(27, 13);
            this.labelBitrate.TabIndex = 4;
            this.labelBitrate.Text = "CRF";
            // 
            // numericUpDownBitrate
            // 
            this.numericUpDownBitrate.Location = new System.Drawing.Point(131, 33);
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
            this.comboBoxEncodeMode.Location = new System.Drawing.Point(131, 6);
            this.comboBoxEncodeMode.Name = "comboBoxEncodeMode";
            this.comboBoxEncodeMode.Size = new System.Drawing.Size(80, 21);
            this.comboBoxEncodeMode.TabIndex = 3;
            this.comboBoxEncodeMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxEncodeMode_SelectedIndexChanged);
            // 
            // labelEncodeMode
            // 
            this.labelEncodeMode.AutoSize = true;
            this.labelEncodeMode.Location = new System.Drawing.Point(6, 9);
            this.labelEncodeMode.Name = "labelEncodeMode";
            this.labelEncodeMode.Size = new System.Drawing.Size(109, 13);
            this.labelEncodeMode.TabIndex = 2;
            this.labelEncodeMode.Text = "Режим кодирования";
            // 
            // comboBoxFileType
            // 
            this.comboBoxFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFileType.FormattingEnabled = true;
            this.comboBoxFileType.Location = new System.Drawing.Point(497, 105);
            this.comboBoxFileType.Name = "comboBoxFileType";
            this.comboBoxFileType.Size = new System.Drawing.Size(80, 21);
            this.comboBoxFileType.TabIndex = 1;
            this.comboBoxFileType.SelectedIndexChanged += new System.EventHandler(this.comboBoxFileType_SelectedIndexChanged);
            // 
            // labelFrameRate
            // 
            this.labelFrameRate.AutoSize = true;
            this.labelFrameRate.Location = new System.Drawing.Point(6, 79);
            this.labelFrameRate.Name = "labelFrameRate";
            this.labelFrameRate.Size = new System.Drawing.Size(89, 13);
            this.labelFrameRate.TabIndex = 0;
            this.labelFrameRate.Text = "Частота кадров";
            // 
            // comboBoxFrameRate
            // 
            this.comboBoxFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrameRate.FormattingEnabled = true;
            this.comboBoxFrameRate.Location = new System.Drawing.Point(131, 76);
            this.comboBoxFrameRate.Name = "comboBoxFrameRate";
            this.comboBoxFrameRate.Size = new System.Drawing.Size(80, 21);
            this.comboBoxFrameRate.TabIndex = 1;
            // 
            // checkBoxDeinterlace
            // 
            this.checkBoxDeinterlace.AutoSize = true;
            this.checkBoxDeinterlace.Location = new System.Drawing.Point(7, 0);
            this.checkBoxDeinterlace.Name = "checkBoxDeinterlace";
            this.checkBoxDeinterlace.Size = new System.Drawing.Size(153, 17);
            this.checkBoxDeinterlace.TabIndex = 0;
            this.checkBoxDeinterlace.Text = "Убрать чересстрочность";
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
            this.groupBoxAudioParams.Location = new System.Drawing.Point(6, 6);
            this.groupBoxAudioParams.Name = "groupBoxAudioParams";
            this.groupBoxAudioParams.Size = new System.Drawing.Size(336, 143);
            this.groupBoxAudioParams.TabIndex = 3;
            this.groupBoxAudioParams.TabStop = false;
            this.groupBoxAudioParams.Text = "Аудио";
            // 
            // comboBoxAudioBitrate
            // 
            this.comboBoxAudioBitrate.FormattingEnabled = true;
            this.comboBoxAudioBitrate.Location = new System.Drawing.Point(175, 20);
            this.comboBoxAudioBitrate.Name = "comboBoxAudioBitrate";
            this.comboBoxAudioBitrate.Size = new System.Drawing.Size(80, 21);
            this.comboBoxAudioBitrate.TabIndex = 1;
            this.comboBoxAudioBitrate.Leave += new System.EventHandler(this.comboBoxAudioBitrate_Leave);
            // 
            // labelAudioBitrate
            // 
            this.labelAudioBitrate.AutoSize = true;
            this.labelAudioBitrate.Location = new System.Drawing.Point(6, 23);
            this.labelAudioBitrate.Name = "labelAudioBitrate";
            this.labelAudioBitrate.Size = new System.Drawing.Size(93, 13);
            this.labelAudioBitrate.TabIndex = 0;
            this.labelAudioBitrate.Text = "Битрейт (кбит/с)";
            // 
            // labelChannels
            // 
            this.labelChannels.AutoSize = true;
            this.labelChannels.Location = new System.Drawing.Point(6, 77);
            this.labelChannels.Name = "labelChannels";
            this.labelChannels.Size = new System.Drawing.Size(112, 13);
            this.labelChannels.TabIndex = 4;
            this.labelChannels.Text = "Количество каналов";
            // 
            // comboBoxChannels
            // 
            this.comboBoxChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChannels.FormattingEnabled = true;
            this.comboBoxChannels.Location = new System.Drawing.Point(175, 74);
            this.comboBoxChannels.Name = "comboBoxChannels";
            this.comboBoxChannels.Size = new System.Drawing.Size(80, 21);
            this.comboBoxChannels.TabIndex = 5;
            // 
            // labelFrequency
            // 
            this.labelFrequency.AutoSize = true;
            this.labelFrequency.Location = new System.Drawing.Point(6, 50);
            this.labelFrequency.Name = "labelFrequency";
            this.labelFrequency.Size = new System.Drawing.Size(152, 13);
            this.labelFrequency.TabIndex = 2;
            this.labelFrequency.Text = "Частота дискретизации (Гц)";
            // 
            // comboBoxFrequency
            // 
            this.comboBoxFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrequency.FormattingEnabled = true;
            this.comboBoxFrequency.Location = new System.Drawing.Point(175, 47);
            this.comboBoxFrequency.Name = "comboBoxFrequency";
            this.comboBoxFrequency.Size = new System.Drawing.Size(80, 21);
            this.comboBoxFrequency.TabIndex = 3;
            // 
            // checkedListBoxAudioStreams
            // 
            this.checkedListBoxAudioStreams.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.checkedListBoxAudioStreams.CheckOnClick = true;
            this.checkedListBoxAudioStreams.FormattingEnabled = true;
            this.checkedListBoxAudioStreams.HorizontalScrollbar = true;
            this.checkedListBoxAudioStreams.Location = new System.Drawing.Point(6, 19);
            this.checkedListBoxAudioStreams.Name = "checkedListBoxAudioStreams";
            this.checkedListBoxAudioStreams.Size = new System.Drawing.Size(228, 112);
            this.checkedListBoxAudioStreams.TabIndex = 0;
            this.checkedListBoxAudioStreams.SelectedIndexChanged += new System.EventHandler(this.checkedListBoxAudioStreams_SelectedIndexChanged);
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(478, 193);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(130, 32);
            this.buttonGo.TabIndex = 8;
            this.buttonGo.Text = "Конвертировать";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // groupBoxDeinterlace
            // 
            this.groupBoxDeinterlace.Controls.Add(this.labelFieldOrder);
            this.groupBoxDeinterlace.Controls.Add(this.comboBoxFieldOrder);
            this.groupBoxDeinterlace.Controls.Add(this.checkBoxDeinterlace);
            this.groupBoxDeinterlace.Location = new System.Drawing.Point(6, 6);
            this.groupBoxDeinterlace.Name = "groupBoxDeinterlace";
            this.groupBoxDeinterlace.Size = new System.Drawing.Size(215, 51);
            this.groupBoxDeinterlace.TabIndex = 4;
            this.groupBoxDeinterlace.TabStop = false;
            // 
            // labelFieldOrder
            // 
            this.labelFieldOrder.AutoSize = true;
            this.labelFieldOrder.Location = new System.Drawing.Point(6, 23);
            this.labelFieldOrder.Name = "labelFieldOrder";
            this.labelFieldOrder.Size = new System.Drawing.Size(84, 13);
            this.labelFieldOrder.TabIndex = 1;
            this.labelFieldOrder.Text = "Порядок полей";
            // 
            // comboBoxFieldOrder
            // 
            this.comboBoxFieldOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFieldOrder.FormattingEnabled = true;
            this.comboBoxFieldOrder.Location = new System.Drawing.Point(114, 20);
            this.comboBoxFieldOrder.Name = "comboBoxFieldOrder";
            this.comboBoxFieldOrder.Size = new System.Drawing.Size(95, 21);
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
            this.groupBoxResolution.Location = new System.Drawing.Point(6, 6);
            this.groupBoxResolution.Name = "groupBoxResolution";
            this.groupBoxResolution.Size = new System.Drawing.Size(215, 105);
            this.groupBoxResolution.TabIndex = 7;
            this.groupBoxResolution.TabStop = false;
            // 
            // pictureBoxRatioError
            // 
            this.pictureBoxRatioError.Location = new System.Drawing.Point(107, 75);
            this.pictureBoxRatioError.Name = "pictureBoxRatioError";
            this.pictureBoxRatioError.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxRatioError.TabIndex = 11;
            this.pictureBoxRatioError.TabStop = false;
            // 
            // comboBoxAspectRatio
            // 
            this.comboBoxAspectRatio.FormattingEnabled = true;
            this.comboBoxAspectRatio.Location = new System.Drawing.Point(6, 74);
            this.comboBoxAspectRatio.Name = "comboBoxAspectRatio";
            this.comboBoxAspectRatio.Size = new System.Drawing.Size(95, 21);
            this.comboBoxAspectRatio.TabIndex = 5;
            this.comboBoxAspectRatio.SelectedIndexChanged += new System.EventHandler(this.comboBoxAspectRatio_SelectedIndexChanged);
            this.comboBoxAspectRatio.TextUpdate += new System.EventHandler(this.comboBoxAspectRatio_TextUpdate);
            // 
            // checkBoxKeepAspectRatio
            // 
            this.checkBoxKeepAspectRatio.AutoSize = true;
            this.checkBoxKeepAspectRatio.Location = new System.Drawing.Point(6, 51);
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
            this.groupBoxAudioStreams.Location = new System.Drawing.Point(348, 6);
            this.groupBoxAudioStreams.Name = "groupBoxAudioStreams";
            this.groupBoxAudioStreams.Size = new System.Drawing.Size(240, 143);
            this.groupBoxAudioStreams.TabIndex = 6;
            this.groupBoxAudioStreams.TabStop = false;
            this.groupBoxAudioStreams.Text = "Звуковые дорожки";
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
            this.tabControlMain.Size = new System.Drawing.Size(602, 181);
            this.tabControlMain.TabIndex = 9;
            // 
            // tabPageFile
            // 
            this.tabPageFile.Controls.Add(this.labelInputFile);
            this.tabPageFile.Controls.Add(this.buttonOpenInputFile);
            this.tabPageFile.Controls.Add(this.labelInFileName);
            this.tabPageFile.Controls.Add(this.checkBoxKeepOutPath);
            this.tabPageFile.Controls.Add(this.buttonShowInfo);
            this.tabPageFile.Controls.Add(this.comboBoxFileType);
            this.tabPageFile.Controls.Add(this.labelFileType);
            this.tabPageFile.Controls.Add(this.buttonBrowseOut);
            this.tabPageFile.Controls.Add(this.buttonBrowseIn);
            this.tabPageFile.Controls.Add(this.textBoxOut);
            this.tabPageFile.Controls.Add(this.labelOut);
            this.tabPageFile.Location = new System.Drawing.Point(4, 22);
            this.tabPageFile.Name = "tabPageFile";
            this.tabPageFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFile.Size = new System.Drawing.Size(594, 155);
            this.tabPageFile.TabIndex = 4;
            this.tabPageFile.Text = "Файл";
            this.tabPageFile.UseVisualStyleBackColor = true;
            // 
            // checkBoxKeepOutPath
            // 
            this.checkBoxKeepOutPath.AutoSize = true;
            this.checkBoxKeepOutPath.Location = new System.Drawing.Point(6, 132);
            this.checkBoxKeepOutPath.Name = "checkBoxKeepOutPath";
            this.checkBoxKeepOutPath.Size = new System.Drawing.Size(175, 17);
            this.checkBoxKeepOutPath.TabIndex = 12;
            this.checkBoxKeepOutPath.Text = "Запомнить выбранную папку";
            this.checkBoxKeepOutPath.UseVisualStyleBackColor = true;
            // 
            // buttonShowInfo
            // 
            this.buttonShowInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonShowInfo.Location = new System.Drawing.Point(122, 25);
            this.buttonShowInfo.Name = "buttonShowInfo";
            this.buttonShowInfo.Size = new System.Drawing.Size(50, 25);
            this.buttonShowInfo.TabIndex = 7;
            this.buttonShowInfo.Text = "Инфо";
            this.buttonShowInfo.UseVisualStyleBackColor = true;
            this.buttonShowInfo.Click += new System.EventHandler(this.buttonShowInfo_Click);
            // 
            // tabPagePicture
            // 
            this.tabPagePicture.Controls.Add(this.groupBoxResolution);
            this.tabPagePicture.Location = new System.Drawing.Point(4, 22);
            this.tabPagePicture.Name = "tabPagePicture";
            this.tabPagePicture.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePicture.Size = new System.Drawing.Size(594, 155);
            this.tabPagePicture.TabIndex = 1;
            this.tabPagePicture.Text = "Картинка";
            this.tabPagePicture.UseVisualStyleBackColor = true;
            // 
            // tabPageFilters
            // 
            this.tabPageFilters.Controls.Add(this.groupBoxDeinterlace);
            this.tabPageFilters.Location = new System.Drawing.Point(4, 22);
            this.tabPageFilters.Name = "tabPageFilters";
            this.tabPageFilters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFilters.Size = new System.Drawing.Size(594, 155);
            this.tabPageFilters.TabIndex = 3;
            this.tabPageFilters.Text = "Фильтры";
            this.tabPageFilters.UseVisualStyleBackColor = true;
            // 
            // tabPageVideo
            // 
            this.tabPageVideo.Controls.Add(this.buttonVideoAdvanced);
            this.tabPageVideo.Controls.Add(this.labelFrameRate);
            this.tabPageVideo.Controls.Add(this.comboBoxFrameRate);
            this.tabPageVideo.Controls.Add(this.comboBoxEncodeMode);
            this.tabPageVideo.Controls.Add(this.labelEncodeMode);
            this.tabPageVideo.Controls.Add(this.numericUpDownBitrate);
            this.tabPageVideo.Controls.Add(this.labelBitrate);
            this.tabPageVideo.Location = new System.Drawing.Point(4, 22);
            this.tabPageVideo.Name = "tabPageVideo";
            this.tabPageVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVideo.Size = new System.Drawing.Size(594, 155);
            this.tabPageVideo.TabIndex = 0;
            this.tabPageVideo.Text = "Видео";
            this.tabPageVideo.UseVisualStyleBackColor = true;
            // 
            // buttonVideoAdvanced
            // 
            this.buttonVideoAdvanced.Enabled = false;
            this.buttonVideoAdvanced.Location = new System.Drawing.Point(6, 126);
            this.buttonVideoAdvanced.Name = "buttonVideoAdvanced";
            this.buttonVideoAdvanced.Size = new System.Drawing.Size(105, 23);
            this.buttonVideoAdvanced.TabIndex = 6;
            this.buttonVideoAdvanced.Text = "Доп. настройки";
            this.buttonVideoAdvanced.UseVisualStyleBackColor = true;
            // 
            // tabPageAudio
            // 
            this.tabPageAudio.Controls.Add(this.groupBoxAudioStreams);
            this.tabPageAudio.Controls.Add(this.groupBoxAudioParams);
            this.tabPageAudio.Location = new System.Drawing.Point(4, 22);
            this.tabPageAudio.Name = "tabPageAudio";
            this.tabPageAudio.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAudio.Size = new System.Drawing.Size(594, 155);
            this.tabPageAudio.TabIndex = 2;
            this.tabPageAudio.Text = "Аудио";
            this.tabPageAudio.UseVisualStyleBackColor = true;
            // 
            // buttonAbout
            // 
            this.buttonAbout.BackgroundImage = global::Alexantr.SimpleVideoConverter.Properties.Resources.information;
            this.buttonAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonAbout.Location = new System.Drawing.Point(6, 193);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(32, 32);
            this.buttonAbout.TabIndex = 10;
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // labelInFileName
            // 
            this.labelInFileName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelInFileName.Location = new System.Drawing.Point(4, 53);
            this.labelInFileName.Name = "labelInFileName";
            this.labelInFileName.Size = new System.Drawing.Size(573, 36);
            this.labelInFileName.TabIndex = 13;
            this.labelInFileName.Text = "Файл не выбран";
            // 
            // buttonOpenInputFile
            // 
            this.buttonOpenInputFile.Location = new System.Drawing.Point(178, 25);
            this.buttonOpenInputFile.Name = "buttonOpenInputFile";
            this.buttonOpenInputFile.Size = new System.Drawing.Size(70, 25);
            this.buttonOpenInputFile.TabIndex = 14;
            this.buttonOpenInputFile.Text = "Открыть";
            this.buttonOpenInputFile.UseVisualStyleBackColor = true;
            this.buttonOpenInputFile.Click += new System.EventHandler(this.buttonOpenInputFile_Click);
            // 
            // labelFileType
            // 
            this.labelFileType.AutoSize = true;
            this.labelFileType.Location = new System.Drawing.Point(496, 89);
            this.labelFileType.Name = "labelFileType";
            this.labelFileType.Size = new System.Drawing.Size(60, 13);
            this.labelFileType.TabIndex = 0;
            this.labelFileType.Text = "Тип файла";
            // 
            // labelOut
            // 
            this.labelOut.AutoSize = true;
            this.labelOut.Location = new System.Drawing.Point(5, 89);
            this.labelOut.Name = "labelOut";
            this.labelOut.Size = new System.Drawing.Size(83, 13);
            this.labelOut.TabIndex = 3;
            this.labelOut.Text = "Сохранить как";
            // 
            // labelInputFile
            // 
            this.labelInputFile.AutoSize = true;
            this.labelInputFile.Location = new System.Drawing.Point(5, 9);
            this.labelInputFile.Name = "labelInputFile";
            this.labelInputFile.Size = new System.Drawing.Size(87, 13);
            this.labelInputFile.TabIndex = 15;
            this.labelInputFile.Text = "Исходный файл";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 231);
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
            this.groupBoxAudioParams.ResumeLayout(false);
            this.groupBoxAudioParams.PerformLayout();
            this.groupBoxDeinterlace.ResumeLayout(false);
            this.groupBoxDeinterlace.PerformLayout();
            this.groupBoxResolution.ResumeLayout(false);
            this.groupBoxResolution.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRatioError)).EndInit();
            this.groupBoxAudioStreams.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageFile.ResumeLayout(false);
            this.tabPageFile.PerformLayout();
            this.tabPagePicture.ResumeLayout(false);
            this.tabPageFilters.ResumeLayout(false);
            this.tabPageVideo.ResumeLayout(false);
            this.tabPageVideo.PerformLayout();
            this.tabPageAudio.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonBrowseIn;
        private System.Windows.Forms.Button buttonBrowseOut;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label labelBitrate;
        private System.Windows.Forms.NumericUpDown numericUpDownBitrate;
        private System.Windows.Forms.GroupBox groupBoxAudioParams;
        private System.Windows.Forms.Label labelAudioBitrate;
        private System.Windows.Forms.Label labelChannels;
        private System.Windows.Forms.ComboBox comboBoxChannels;
        private System.Windows.Forms.ComboBox comboBoxFileType;
        private System.Windows.Forms.CheckBox checkBoxResizePicture;
        private System.Windows.Forms.Button buttonGo;
        public System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.CheckBox checkBoxDeinterlace;
        private System.Windows.Forms.ComboBox comboBoxFrequency;
        private System.Windows.Forms.Label labelFrequency;
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
        private System.Windows.Forms.ComboBox comboBoxEncodeMode;
        private System.Windows.Forms.Label labelEncodeMode;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPagePicture;
        private System.Windows.Forms.TabPage tabPageFilters;
        private System.Windows.Forms.TabPage tabPageVideo;
        private System.Windows.Forms.TabPage tabPageAudio;
        private System.Windows.Forms.TabPage tabPageFile;
        private System.Windows.Forms.Button buttonShowInfo;
        private System.Windows.Forms.Button buttonVideoAdvanced;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.CheckBox checkBoxKeepOutPath;
        private System.Windows.Forms.Label labelInFileName;
        private System.Windows.Forms.Button buttonOpenInputFile;
        private System.Windows.Forms.Label labelFileType;
        private System.Windows.Forms.Label labelInputFile;
        private System.Windows.Forms.Label labelOut;
    }
}


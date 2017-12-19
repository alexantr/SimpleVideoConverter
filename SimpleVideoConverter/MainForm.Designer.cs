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
            this.buttonGo = new System.Windows.Forms.Button();
            this.toolTipHint = new System.Windows.Forms.ToolTip(this.components);
            this.comboBoxResizeMethod = new System.Windows.Forms.ComboBox();
            this.buttonShowInfo = new System.Windows.Forms.Button();
            this.buttonOpenInputFile = new System.Windows.Forms.Button();
            this.checkBoxWebOptimized = new System.Windows.Forms.CheckBox();
            this.tabPageAudio = new System.Windows.Forms.TabPage();
            this.panelAudioParams = new System.Windows.Forms.Panel();
            this.checkBoxConvertAudio = new System.Windows.Forms.CheckBox();
            this.pictureBoxAudioBitrateError = new System.Windows.Forms.PictureBox();
            this.comboBoxAudioBitrate = new System.Windows.Forms.ComboBox();
            this.labelAudioHz = new System.Windows.Forms.Label();
            this.labelChannels = new System.Windows.Forms.Label();
            this.labelFrequency = new System.Windows.Forms.Label();
            this.labelAudioKbps = new System.Windows.Forms.Label();
            this.comboBoxAudioFrequency = new System.Windows.Forms.ComboBox();
            this.comboBoxAudioChannels = new System.Windows.Forms.ComboBox();
            this.labelAudioBitrate = new System.Windows.Forms.Label();
            this.panelAudioStreams = new System.Windows.Forms.Panel();
            this.comboBoxAudioStreams = new System.Windows.Forms.ComboBox();
            this.labelSelectAudioStream = new System.Windows.Forms.Label();
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
            this.numericUpDownBitrate = new System.Windows.Forms.NumericUpDown();
            this.panelVideoParams = new System.Windows.Forms.Panel();
            this.labelFrameRate = new System.Windows.Forms.Label();
            this.comboBoxFrameRate = new System.Windows.Forms.ComboBox();
            this.tabPagePicture = new System.Windows.Forms.TabPage();
            this.panelDeinterlace = new System.Windows.Forms.Panel();
            this.labelFieldOrder = new System.Windows.Forms.Label();
            this.checkBoxDeinterlace = new System.Windows.Forms.CheckBox();
            this.comboBoxFieldOrder = new System.Windows.Forms.ComboBox();
            this.panelCrop = new System.Windows.Forms.Panel();
            this.labelColorFilter = new System.Windows.Forms.Label();
            this.comboBoxColorFilter = new System.Windows.Forms.ComboBox();
            this.panelResolution = new System.Windows.Forms.Panel();
            this.pictureBoxSizeError = new System.Windows.Forms.PictureBox();
            this.labelResizeMethod = new System.Windows.Forms.Label();
            this.labelScalingAlgorithm = new System.Windows.Forms.Label();
            this.comboBoxScalingAlgorithm = new System.Windows.Forms.ComboBox();
            this.labelPictureSize = new System.Windows.Forms.Label();
            this.comboBoxPictureSize = new System.Windows.Forms.ComboBox();
            this.buttonCrop = new System.Windows.Forms.Button();
            this.labelCropSize = new System.Windows.Forms.Label();
            this.tabPageFile = new System.Windows.Forms.TabPage();
            this.panelFile = new System.Windows.Forms.Panel();
            this.comboBoxFileType = new System.Windows.Forms.ComboBox();
            this.labelFileType = new System.Windows.Forms.Label();
            this.labelOut = new System.Windows.Forms.Label();
            this.labelInputFile = new System.Windows.Forms.Label();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.checkBoxKeepOutPath = new System.Windows.Forms.CheckBox();
            this.buttonBrowseIn = new System.Windows.Forms.Button();
            this.buttonBrowseOut = new System.Windows.Forms.Button();
            this.textBoxIn = new System.Windows.Forms.TextBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.labelOutputInfo = new System.Windows.Forms.Label();
            this.labelOutputInfoTitle = new System.Windows.Forms.Label();
            this.tabPageAudio.SuspendLayout();
            this.panelAudioParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAudioBitrateError)).BeginInit();
            this.panelAudioStreams.SuspendLayout();
            this.tabPageVideo.SuspendLayout();
            this.panelVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCRF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBitrate)).BeginInit();
            this.panelVideoParams.SuspendLayout();
            this.tabPagePicture.SuspendLayout();
            this.panelDeinterlace.SuspendLayout();
            this.panelCrop.SuspendLayout();
            this.panelResolution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSizeError)).BeginInit();
            this.tabPageFile.SuspendLayout();
            this.panelFile.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGo
            // 
            this.buttonGo.Location = new System.Drawing.Point(488, 223);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(130, 32);
            this.buttonGo.TabIndex = 3;
            this.buttonGo.Text = "Конвертировать";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // comboBoxResizeMethod
            // 
            this.comboBoxResizeMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxResizeMethod.FormattingEnabled = true;
            this.comboBoxResizeMethod.Location = new System.Drawing.Point(124, 67);
            this.comboBoxResizeMethod.Name = "comboBoxResizeMethod";
            this.comboBoxResizeMethod.Size = new System.Drawing.Size(121, 21);
            this.comboBoxResizeMethod.TabIndex = 5;
            this.toolTipHint.SetToolTip(this.comboBoxResizeMethod, resources.GetString("comboBoxResizeMethod.ToolTip"));
            this.comboBoxResizeMethod.SelectedIndexChanged += new System.EventHandler(this.comboBoxResizeMethod_SelectedIndexChanged);
            // 
            // buttonShowInfo
            // 
            this.buttonShowInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonShowInfo.Location = new System.Drawing.Point(92, 31);
            this.buttonShowInfo.Name = "buttonShowInfo";
            this.buttonShowInfo.Size = new System.Drawing.Size(75, 23);
            this.buttonShowInfo.TabIndex = 3;
            this.buttonShowInfo.Text = "Инфо";
            this.toolTipHint.SetToolTip(this.buttonShowInfo, "Показать информацию об исходном файле");
            this.buttonShowInfo.UseVisualStyleBackColor = true;
            this.buttonShowInfo.Click += new System.EventHandler(this.buttonShowInfo_Click);
            // 
            // buttonOpenInputFile
            // 
            this.buttonOpenInputFile.Location = new System.Drawing.Point(173, 31);
            this.buttonOpenInputFile.Name = "buttonOpenInputFile";
            this.buttonOpenInputFile.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenInputFile.TabIndex = 4;
            this.buttonOpenInputFile.Text = "Открыть";
            this.toolTipHint.SetToolTip(this.buttonOpenInputFile, "Открыть исходный файл в проигрывателе по умолчанию");
            this.buttonOpenInputFile.UseVisualStyleBackColor = true;
            this.buttonOpenInputFile.Click += new System.EventHandler(this.buttonOpenInputFile_Click);
            // 
            // checkBoxWebOptimized
            // 
            this.checkBoxWebOptimized.AutoSize = true;
            this.checkBoxWebOptimized.Location = new System.Drawing.Point(173, 145);
            this.checkBoxWebOptimized.Name = "checkBoxWebOptimized";
            this.checkBoxWebOptimized.Size = new System.Drawing.Size(129, 17);
            this.checkBoxWebOptimized.TabIndex = 11;
            this.checkBoxWebOptimized.Text = "Web-оптимизирован";
            this.toolTipHint.SetToolTip(this.checkBoxWebOptimized, "Служебная информация будет перенесена в начало файла для быстрого старта воспроиз" +
        "ведения в браузерах");
            this.checkBoxWebOptimized.UseVisualStyleBackColor = true;
            // 
            // tabPageAudio
            // 
            this.tabPageAudio.Controls.Add(this.panelAudioParams);
            this.tabPageAudio.Controls.Add(this.panelAudioStreams);
            this.tabPageAudio.Location = new System.Drawing.Point(4, 22);
            this.tabPageAudio.Name = "tabPageAudio";
            this.tabPageAudio.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAudio.Size = new System.Drawing.Size(604, 185);
            this.tabPageAudio.TabIndex = 2;
            this.tabPageAudio.Text = "Аудио";
            this.tabPageAudio.UseVisualStyleBackColor = true;
            // 
            // panelAudioParams
            // 
            this.panelAudioParams.Controls.Add(this.checkBoxConvertAudio);
            this.panelAudioParams.Controls.Add(this.pictureBoxAudioBitrateError);
            this.panelAudioParams.Controls.Add(this.comboBoxAudioBitrate);
            this.panelAudioParams.Controls.Add(this.labelAudioHz);
            this.panelAudioParams.Controls.Add(this.labelChannels);
            this.panelAudioParams.Controls.Add(this.labelFrequency);
            this.panelAudioParams.Controls.Add(this.labelAudioKbps);
            this.panelAudioParams.Controls.Add(this.comboBoxAudioFrequency);
            this.panelAudioParams.Controls.Add(this.comboBoxAudioChannels);
            this.panelAudioParams.Controls.Add(this.labelAudioBitrate);
            this.panelAudioParams.Location = new System.Drawing.Point(6, 50);
            this.panelAudioParams.Name = "panelAudioParams";
            this.panelAudioParams.Size = new System.Drawing.Size(364, 129);
            this.panelAudioParams.TabIndex = 1;
            // 
            // checkBoxConvertAudio
            // 
            this.checkBoxConvertAudio.AutoSize = true;
            this.checkBoxConvertAudio.Location = new System.Drawing.Point(3, 3);
            this.checkBoxConvertAudio.Name = "checkBoxConvertAudio";
            this.checkBoxConvertAudio.Size = new System.Drawing.Size(135, 17);
            this.checkBoxConvertAudio.TabIndex = 0;
            this.checkBoxConvertAudio.Text = "Переконвертировать";
            this.checkBoxConvertAudio.UseVisualStyleBackColor = true;
            this.checkBoxConvertAudio.CheckedChanged += new System.EventHandler(this.checkBoxConvertAudio_CheckedChanged);
            // 
            // pictureBoxAudioBitrateError
            // 
            this.pictureBoxAudioBitrateError.Location = new System.Drawing.Point(209, 35);
            this.pictureBoxAudioBitrateError.Name = "pictureBoxAudioBitrateError";
            this.pictureBoxAudioBitrateError.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxAudioBitrateError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxAudioBitrateError.TabIndex = 8;
            this.pictureBoxAudioBitrateError.TabStop = false;
            // 
            // comboBoxAudioBitrate
            // 
            this.comboBoxAudioBitrate.FormattingEnabled = true;
            this.comboBoxAudioBitrate.Location = new System.Drawing.Point(77, 33);
            this.comboBoxAudioBitrate.Name = "comboBoxAudioBitrate";
            this.comboBoxAudioBitrate.Size = new System.Drawing.Size(80, 21);
            this.comboBoxAudioBitrate.TabIndex = 2;
            this.comboBoxAudioBitrate.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioBitrate_SelectedIndexChanged);
            this.comboBoxAudioBitrate.TextUpdate += new System.EventHandler(this.comboBoxAudioBitrate_TextUpdate);
            this.comboBoxAudioBitrate.Leave += new System.EventHandler(this.comboBoxAudioBitrate_Leave);
            // 
            // labelAudioHz
            // 
            this.labelAudioHz.AutoSize = true;
            this.labelAudioHz.Location = new System.Drawing.Point(163, 68);
            this.labelAudioHz.Name = "labelAudioHz";
            this.labelAudioHz.Size = new System.Drawing.Size(19, 13);
            this.labelAudioHz.TabIndex = 6;
            this.labelAudioHz.Text = "Гц";
            // 
            // labelChannels
            // 
            this.labelChannels.AutoSize = true;
            this.labelChannels.Location = new System.Drawing.Point(3, 100);
            this.labelChannels.Name = "labelChannels";
            this.labelChannels.Size = new System.Drawing.Size(46, 13);
            this.labelChannels.TabIndex = 7;
            this.labelChannels.Text = "Каналы";
            // 
            // labelFrequency
            // 
            this.labelFrequency.AutoSize = true;
            this.labelFrequency.Location = new System.Drawing.Point(3, 68);
            this.labelFrequency.Name = "labelFrequency";
            this.labelFrequency.Size = new System.Drawing.Size(49, 13);
            this.labelFrequency.TabIndex = 4;
            this.labelFrequency.Text = "Частота";
            // 
            // labelAudioKbps
            // 
            this.labelAudioKbps.AutoSize = true;
            this.labelAudioKbps.Location = new System.Drawing.Point(163, 36);
            this.labelAudioKbps.Name = "labelAudioKbps";
            this.labelAudioKbps.Size = new System.Drawing.Size(40, 13);
            this.labelAudioKbps.TabIndex = 3;
            this.labelAudioKbps.Text = "кбит/с";
            // 
            // comboBoxAudioFrequency
            // 
            this.comboBoxAudioFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudioFrequency.FormattingEnabled = true;
            this.comboBoxAudioFrequency.Location = new System.Drawing.Point(77, 65);
            this.comboBoxAudioFrequency.Name = "comboBoxAudioFrequency";
            this.comboBoxAudioFrequency.Size = new System.Drawing.Size(80, 21);
            this.comboBoxAudioFrequency.TabIndex = 5;
            this.comboBoxAudioFrequency.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioFrequency_SelectedIndexChanged);
            // 
            // comboBoxAudioChannels
            // 
            this.comboBoxAudioChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudioChannels.FormattingEnabled = true;
            this.comboBoxAudioChannels.Location = new System.Drawing.Point(77, 97);
            this.comboBoxAudioChannels.Name = "comboBoxAudioChannels";
            this.comboBoxAudioChannels.Size = new System.Drawing.Size(80, 21);
            this.comboBoxAudioChannels.TabIndex = 8;
            this.comboBoxAudioChannels.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioChannels_SelectedIndexChanged);
            // 
            // labelAudioBitrate
            // 
            this.labelAudioBitrate.AutoSize = true;
            this.labelAudioBitrate.Location = new System.Drawing.Point(3, 36);
            this.labelAudioBitrate.Name = "labelAudioBitrate";
            this.labelAudioBitrate.Size = new System.Drawing.Size(49, 13);
            this.labelAudioBitrate.TabIndex = 1;
            this.labelAudioBitrate.Text = "Битрейт";
            // 
            // panelAudioStreams
            // 
            this.panelAudioStreams.Controls.Add(this.comboBoxAudioStreams);
            this.panelAudioStreams.Controls.Add(this.labelSelectAudioStream);
            this.panelAudioStreams.Location = new System.Drawing.Point(6, 6);
            this.panelAudioStreams.Name = "panelAudioStreams";
            this.panelAudioStreams.Size = new System.Drawing.Size(364, 38);
            this.panelAudioStreams.TabIndex = 0;
            // 
            // comboBoxAudioStreams
            // 
            this.comboBoxAudioStreams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudioStreams.FormattingEnabled = true;
            this.comboBoxAudioStreams.Location = new System.Drawing.Point(77, 3);
            this.comboBoxAudioStreams.Name = "comboBoxAudioStreams";
            this.comboBoxAudioStreams.Size = new System.Drawing.Size(220, 21);
            this.comboBoxAudioStreams.TabIndex = 1;
            this.comboBoxAudioStreams.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioStreams_SelectedIndexChanged);
            // 
            // labelSelectAudioStream
            // 
            this.labelSelectAudioStream.AutoSize = true;
            this.labelSelectAudioStream.Location = new System.Drawing.Point(3, 6);
            this.labelSelectAudioStream.Name = "labelSelectAudioStream";
            this.labelSelectAudioStream.Size = new System.Drawing.Size(53, 13);
            this.labelSelectAudioStream.TabIndex = 0;
            this.labelSelectAudioStream.Text = "Дорожка";
            // 
            // tabPageVideo
            // 
            this.tabPageVideo.Controls.Add(this.panelVideo);
            this.tabPageVideo.Controls.Add(this.panelVideoParams);
            this.tabPageVideo.Location = new System.Drawing.Point(4, 22);
            this.tabPageVideo.Name = "tabPageVideo";
            this.tabPageVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVideo.Size = new System.Drawing.Size(604, 185);
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
            this.panelVideo.Size = new System.Drawing.Size(307, 173);
            this.panelVideo.TabIndex = 0;
            // 
            // labelCalcSize
            // 
            this.labelCalcSize.AutoSize = true;
            this.labelCalcSize.Location = new System.Drawing.Point(84, 157);
            this.labelCalcSize.Name = "labelCalcSize";
            this.labelCalcSize.Size = new System.Drawing.Size(11, 13);
            this.labelCalcSize.TabIndex = 9;
            this.labelCalcSize.Text = "-";
            // 
            // labelCalcSizeText
            // 
            this.labelCalcSizeText.AutoSize = true;
            this.labelCalcSizeText.Location = new System.Drawing.Point(3, 157);
            this.labelCalcSizeText.Name = "labelCalcSizeText";
            this.labelCalcSizeText.Size = new System.Drawing.Size(81, 13);
            this.labelCalcSizeText.TabIndex = 8;
            this.labelCalcSizeText.Text = "Размер файла:";
            // 
            // labelVideoKbps
            // 
            this.labelVideoKbps.AutoSize = true;
            this.labelVideoKbps.Location = new System.Drawing.Point(162, 106);
            this.labelVideoKbps.Name = "labelVideoKbps";
            this.labelVideoKbps.Size = new System.Drawing.Size(40, 13);
            this.labelVideoKbps.TabIndex = 7;
            this.labelVideoKbps.Text = "кбит/с";
            // 
            // labelMinQ
            // 
            this.labelMinQ.AutoSize = true;
            this.labelMinQ.Location = new System.Drawing.Point(223, 62);
            this.labelMinQ.Name = "labelMinQ";
            this.labelMinQ.Size = new System.Drawing.Size(81, 13);
            this.labelMinQ.TabIndex = 4;
            this.labelMinQ.Text = "Мин. качество";
            // 
            // labelMaxQ
            // 
            this.labelMaxQ.AutoSize = true;
            this.labelMaxQ.Location = new System.Drawing.Point(3, 62);
            this.labelMaxQ.Name = "labelMaxQ";
            this.labelMaxQ.Size = new System.Drawing.Size(86, 13);
            this.labelMaxQ.TabIndex = 3;
            this.labelMaxQ.Text = "Макс. качество";
            // 
            // labelCRF
            // 
            this.labelCRF.AutoSize = true;
            this.labelCRF.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCRF.Location = new System.Drawing.Point(139, 6);
            this.labelCRF.Name = "labelCRF";
            this.labelCRF.Size = new System.Drawing.Size(21, 13);
            this.labelCRF.TabIndex = 1;
            this.labelCRF.Text = "20";
            // 
            // radioButtonBitrate
            // 
            this.radioButtonBitrate.AutoSize = true;
            this.radioButtonBitrate.Location = new System.Drawing.Point(3, 104);
            this.radioButtonBitrate.Name = "radioButtonBitrate";
            this.radioButtonBitrate.Size = new System.Drawing.Size(67, 17);
            this.radioButtonBitrate.TabIndex = 5;
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
            this.radioButtonCRF.TabIndex = 0;
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
            this.trackBarCRF.Size = new System.Drawing.Size(301, 45);
            this.trackBarCRF.TabIndex = 2;
            this.trackBarCRF.Value = 20;
            this.trackBarCRF.ValueChanged += new System.EventHandler(this.trackBarCRF_ValueChanged);
            // 
            // numericUpDownBitrate
            // 
            this.numericUpDownBitrate.Location = new System.Drawing.Point(76, 103);
            this.numericUpDownBitrate.Name = "numericUpDownBitrate";
            this.numericUpDownBitrate.Size = new System.Drawing.Size(80, 21);
            this.numericUpDownBitrate.TabIndex = 6;
            this.numericUpDownBitrate.ValueChanged += new System.EventHandler(this.numericUpDownBitrate_ValueChanged);
            // 
            // panelVideoParams
            // 
            this.panelVideoParams.Controls.Add(this.labelFrameRate);
            this.panelVideoParams.Controls.Add(this.comboBoxFrameRate);
            this.panelVideoParams.Location = new System.Drawing.Point(319, 6);
            this.panelVideoParams.Name = "panelVideoParams";
            this.panelVideoParams.Size = new System.Drawing.Size(279, 31);
            this.panelVideoParams.TabIndex = 1;
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
            this.comboBoxFrameRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxFrameRate_SelectedIndexChanged);
            // 
            // tabPagePicture
            // 
            this.tabPagePicture.Controls.Add(this.panelDeinterlace);
            this.tabPagePicture.Controls.Add(this.panelCrop);
            this.tabPagePicture.Controls.Add(this.panelResolution);
            this.tabPagePicture.Location = new System.Drawing.Point(4, 22);
            this.tabPagePicture.Name = "tabPagePicture";
            this.tabPagePicture.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePicture.Size = new System.Drawing.Size(604, 185);
            this.tabPagePicture.TabIndex = 1;
            this.tabPagePicture.Text = "Картинка";
            this.tabPagePicture.UseVisualStyleBackColor = true;
            // 
            // panelDeinterlace
            // 
            this.panelDeinterlace.Controls.Add(this.labelFieldOrder);
            this.panelDeinterlace.Controls.Add(this.checkBoxDeinterlace);
            this.panelDeinterlace.Controls.Add(this.comboBoxFieldOrder);
            this.panelDeinterlace.Location = new System.Drawing.Point(314, 6);
            this.panelDeinterlace.Name = "panelDeinterlace";
            this.panelDeinterlace.Size = new System.Drawing.Size(284, 63);
            this.panelDeinterlace.TabIndex = 1;
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
            this.checkBoxDeinterlace.Size = new System.Drawing.Size(110, 17);
            this.checkBoxDeinterlace.TabIndex = 0;
            this.checkBoxDeinterlace.Text = "Деинтерлейсинг";
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
            this.comboBoxFieldOrder.SelectedIndexChanged += new System.EventHandler(this.comboBoxFieldOrder_SelectedIndexChanged);
            // 
            // panelCrop
            // 
            this.panelCrop.Controls.Add(this.labelColorFilter);
            this.panelCrop.Controls.Add(this.comboBoxColorFilter);
            this.panelCrop.Location = new System.Drawing.Point(314, 75);
            this.panelCrop.Name = "panelCrop";
            this.panelCrop.Size = new System.Drawing.Size(284, 104);
            this.panelCrop.TabIndex = 2;
            // 
            // labelColorFilter
            // 
            this.labelColorFilter.AutoSize = true;
            this.labelColorFilter.Location = new System.Drawing.Point(3, 83);
            this.labelColorFilter.Name = "labelColorFilter";
            this.labelColorFilter.Size = new System.Drawing.Size(98, 13);
            this.labelColorFilter.TabIndex = 0;
            this.labelColorFilter.Text = "Цветовой фильтр";
            // 
            // comboBoxColorFilter
            // 
            this.comboBoxColorFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColorFilter.FormattingEnabled = true;
            this.comboBoxColorFilter.Location = new System.Drawing.Point(107, 80);
            this.comboBoxColorFilter.Name = "comboBoxColorFilter";
            this.comboBoxColorFilter.Size = new System.Drawing.Size(110, 21);
            this.comboBoxColorFilter.TabIndex = 1;
            this.comboBoxColorFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxColorFilter_SelectedIndexChanged);
            // 
            // panelResolution
            // 
            this.panelResolution.Controls.Add(this.pictureBoxSizeError);
            this.panelResolution.Controls.Add(this.labelResizeMethod);
            this.panelResolution.Controls.Add(this.comboBoxResizeMethod);
            this.panelResolution.Controls.Add(this.labelScalingAlgorithm);
            this.panelResolution.Controls.Add(this.comboBoxScalingAlgorithm);
            this.panelResolution.Controls.Add(this.labelPictureSize);
            this.panelResolution.Controls.Add(this.comboBoxPictureSize);
            this.panelResolution.Controls.Add(this.buttonCrop);
            this.panelResolution.Controls.Add(this.labelCropSize);
            this.panelResolution.Location = new System.Drawing.Point(6, 6);
            this.panelResolution.Name = "panelResolution";
            this.panelResolution.Size = new System.Drawing.Size(302, 173);
            this.panelResolution.TabIndex = 0;
            // 
            // pictureBoxSizeError
            // 
            this.pictureBoxSizeError.Location = new System.Drawing.Point(251, 39);
            this.pictureBoxSizeError.Name = "pictureBoxSizeError";
            this.pictureBoxSizeError.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxSizeError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxSizeError.TabIndex = 25;
            this.pictureBoxSizeError.TabStop = false;
            // 
            // labelResizeMethod
            // 
            this.labelResizeMethod.AutoSize = true;
            this.labelResizeMethod.Location = new System.Drawing.Point(3, 70);
            this.labelResizeMethod.Name = "labelResizeMethod";
            this.labelResizeMethod.Size = new System.Drawing.Size(83, 13);
            this.labelResizeMethod.TabIndex = 4;
            this.labelResizeMethod.Text = "Метод ресайза";
            // 
            // labelScalingAlgorithm
            // 
            this.labelScalingAlgorithm.AutoSize = true;
            this.labelScalingAlgorithm.Location = new System.Drawing.Point(3, 101);
            this.labelScalingAlgorithm.Name = "labelScalingAlgorithm";
            this.labelScalingAlgorithm.Size = new System.Drawing.Size(98, 13);
            this.labelScalingAlgorithm.TabIndex = 6;
            this.labelScalingAlgorithm.Text = "Алгоритм ресайза";
            // 
            // comboBoxScalingAlgorithm
            // 
            this.comboBoxScalingAlgorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScalingAlgorithm.FormattingEnabled = true;
            this.comboBoxScalingAlgorithm.Location = new System.Drawing.Point(124, 98);
            this.comboBoxScalingAlgorithm.Name = "comboBoxScalingAlgorithm";
            this.comboBoxScalingAlgorithm.Size = new System.Drawing.Size(121, 21);
            this.comboBoxScalingAlgorithm.TabIndex = 7;
            // 
            // labelPictureSize
            // 
            this.labelPictureSize.AutoSize = true;
            this.labelPictureSize.Location = new System.Drawing.Point(3, 40);
            this.labelPictureSize.Name = "labelPictureSize";
            this.labelPictureSize.Size = new System.Drawing.Size(84, 13);
            this.labelPictureSize.TabIndex = 2;
            this.labelPictureSize.Text = "Размеры видео";
            // 
            // comboBoxPictureSize
            // 
            this.comboBoxPictureSize.FormattingEnabled = true;
            this.comboBoxPictureSize.Location = new System.Drawing.Point(124, 37);
            this.comboBoxPictureSize.Name = "comboBoxPictureSize";
            this.comboBoxPictureSize.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPictureSize.TabIndex = 3;
            this.comboBoxPictureSize.SelectedIndexChanged += new System.EventHandler(this.comboBoxPictureSize_SelectedIndexChanged);
            this.comboBoxPictureSize.TextUpdate += new System.EventHandler(this.comboBoxPictureSize_TextUpdate);
            this.comboBoxPictureSize.Leave += new System.EventHandler(this.comboBoxPictureSize_Leave);
            // 
            // buttonCrop
            // 
            this.buttonCrop.Location = new System.Drawing.Point(3, 3);
            this.buttonCrop.Name = "buttonCrop";
            this.buttonCrop.Size = new System.Drawing.Size(100, 23);
            this.buttonCrop.TabIndex = 0;
            this.buttonCrop.Text = "Обрезать края";
            this.buttonCrop.UseVisualStyleBackColor = true;
            this.buttonCrop.Click += new System.EventHandler(this.buttonCrop_Click);
            // 
            // labelCropSize
            // 
            this.labelCropSize.AutoSize = true;
            this.labelCropSize.Location = new System.Drawing.Point(109, 8);
            this.labelCropSize.Name = "labelCropSize";
            this.labelCropSize.Size = new System.Drawing.Size(70, 13);
            this.labelCropSize.TabIndex = 1;
            this.labelCropSize.Text = "WxH → WxH";
            this.labelCropSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tabPageFile
            // 
            this.tabPageFile.Controls.Add(this.panelFile);
            this.tabPageFile.Location = new System.Drawing.Point(4, 22);
            this.tabPageFile.Name = "tabPageFile";
            this.tabPageFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFile.Size = new System.Drawing.Size(604, 185);
            this.tabPageFile.TabIndex = 3;
            this.tabPageFile.Text = "Файл";
            this.tabPageFile.UseVisualStyleBackColor = true;
            // 
            // panelFile
            // 
            this.panelFile.Controls.Add(this.checkBoxWebOptimized);
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
            this.panelFile.Size = new System.Drawing.Size(592, 173);
            this.panelFile.TabIndex = 0;
            // 
            // comboBoxFileType
            // 
            this.comboBoxFileType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFileType.FormattingEnabled = true;
            this.comboBoxFileType.Location = new System.Drawing.Point(92, 142);
            this.comboBoxFileType.Name = "comboBoxFileType";
            this.comboBoxFileType.Size = new System.Drawing.Size(75, 21);
            this.comboBoxFileType.TabIndex = 10;
            this.comboBoxFileType.SelectedIndexChanged += new System.EventHandler(this.comboBoxFileType_SelectedIndexChanged);
            // 
            // labelFileType
            // 
            this.labelFileType.AutoSize = true;
            this.labelFileType.Location = new System.Drawing.Point(3, 145);
            this.labelFileType.Name = "labelFileType";
            this.labelFileType.Size = new System.Drawing.Size(60, 13);
            this.labelFileType.TabIndex = 9;
            this.labelFileType.Text = "Тип файла";
            // 
            // labelOut
            // 
            this.labelOut.AutoSize = true;
            this.labelOut.Location = new System.Drawing.Point(3, 78);
            this.labelOut.Name = "labelOut";
            this.labelOut.Size = new System.Drawing.Size(83, 13);
            this.labelOut.TabIndex = 5;
            this.labelOut.Text = "Сохранить как";
            // 
            // labelInputFile
            // 
            this.labelInputFile.AutoSize = true;
            this.labelInputFile.Location = new System.Drawing.Point(3, 8);
            this.labelInputFile.Name = "labelInputFile";
            this.labelInputFile.Size = new System.Drawing.Size(80, 13);
            this.labelInputFile.TabIndex = 0;
            this.labelInputFile.Text = "Выбрать файл";
            // 
            // textBoxOut
            // 
            this.textBoxOut.Location = new System.Drawing.Point(92, 74);
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.Size = new System.Drawing.Size(416, 21);
            this.textBoxOut.TabIndex = 6;
            // 
            // checkBoxKeepOutPath
            // 
            this.checkBoxKeepOutPath.AutoSize = true;
            this.checkBoxKeepOutPath.Location = new System.Drawing.Point(92, 101);
            this.checkBoxKeepOutPath.Name = "checkBoxKeepOutPath";
            this.checkBoxKeepOutPath.Size = new System.Drawing.Size(175, 17);
            this.checkBoxKeepOutPath.TabIndex = 8;
            this.checkBoxKeepOutPath.Text = "Запомнить выбранную папку";
            this.checkBoxKeepOutPath.UseVisualStyleBackColor = true;
            // 
            // buttonBrowseIn
            // 
            this.buttonBrowseIn.Location = new System.Drawing.Point(514, 3);
            this.buttonBrowseIn.Name = "buttonBrowseIn";
            this.buttonBrowseIn.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseIn.TabIndex = 2;
            this.buttonBrowseIn.Text = "Обзор";
            this.buttonBrowseIn.UseVisualStyleBackColor = true;
            this.buttonBrowseIn.Click += new System.EventHandler(this.buttonBrowseIn_Click);
            // 
            // buttonBrowseOut
            // 
            this.buttonBrowseOut.Location = new System.Drawing.Point(514, 73);
            this.buttonBrowseOut.Name = "buttonBrowseOut";
            this.buttonBrowseOut.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseOut.TabIndex = 7;
            this.buttonBrowseOut.Text = "Обзор";
            this.buttonBrowseOut.UseVisualStyleBackColor = true;
            this.buttonBrowseOut.Click += new System.EventHandler(this.buttonBrowseOut_Click);
            // 
            // textBoxIn
            // 
            this.textBoxIn.Location = new System.Drawing.Point(92, 4);
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.ReadOnly = true;
            this.textBoxIn.Size = new System.Drawing.Size(416, 21);
            this.textBoxIn.TabIndex = 1;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageFile);
            this.tabControlMain.Controls.Add(this.tabPagePicture);
            this.tabControlMain.Controls.Add(this.tabPageVideo);
            this.tabControlMain.Controls.Add(this.tabPageAudio);
            this.tabControlMain.Location = new System.Drawing.Point(6, 6);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(612, 211);
            this.tabControlMain.TabIndex = 0;
            // 
            // labelOutputInfo
            // 
            this.labelOutputInfo.AutoSize = true;
            this.labelOutputInfo.Location = new System.Drawing.Point(60, 223);
            this.labelOutputInfo.Name = "labelOutputInfo";
            this.labelOutputInfo.Size = new System.Drawing.Size(19, 13);
            this.labelOutputInfo.TabIndex = 2;
            this.labelOutputInfo.Text = "...";
            // 
            // labelOutputInfoTitle
            // 
            this.labelOutputInfoTitle.AutoSize = true;
            this.labelOutputInfoTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOutputInfoTitle.Location = new System.Drawing.Point(7, 223);
            this.labelOutputInfoTitle.Name = "labelOutputInfoTitle";
            this.labelOutputInfoTitle.Size = new System.Drawing.Size(47, 26);
            this.labelOutputInfoTitle.TabIndex = 1;
            this.labelOutputInfoTitle.Text = "Видео:\r\nАудио:";
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 261);
            this.Controls.Add(this.labelOutputInfoTitle);
            this.Controls.Add(this.labelOutputInfo);
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
            this.tabPageAudio.ResumeLayout(false);
            this.panelAudioParams.ResumeLayout(false);
            this.panelAudioParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAudioBitrateError)).EndInit();
            this.panelAudioStreams.ResumeLayout(false);
            this.panelAudioStreams.PerformLayout();
            this.tabPageVideo.ResumeLayout(false);
            this.panelVideo.ResumeLayout(false);
            this.panelVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCRF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBitrate)).EndInit();
            this.panelVideoParams.ResumeLayout(false);
            this.panelVideoParams.PerformLayout();
            this.tabPagePicture.ResumeLayout(false);
            this.panelDeinterlace.ResumeLayout(false);
            this.panelDeinterlace.PerformLayout();
            this.panelCrop.ResumeLayout(false);
            this.panelCrop.PerformLayout();
            this.panelResolution.ResumeLayout(false);
            this.panelResolution.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSizeError)).EndInit();
            this.tabPageFile.ResumeLayout(false);
            this.panelFile.ResumeLayout(false);
            this.panelFile.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.ToolTip toolTipHint;
        private System.Windows.Forms.TabPage tabPageAudio;
        private System.Windows.Forms.Panel panelAudioStreams;
        private System.Windows.Forms.Label labelAudioHz;
        private System.Windows.Forms.Label labelAudioKbps;
        private System.Windows.Forms.ComboBox comboBoxAudioBitrate;
        private System.Windows.Forms.Label labelAudioBitrate;
        private System.Windows.Forms.ComboBox comboBoxAudioFrequency;
        private System.Windows.Forms.Label labelChannels;
        private System.Windows.Forms.Label labelFrequency;
        private System.Windows.Forms.ComboBox comboBoxAudioChannels;
        private System.Windows.Forms.TabPage tabPageVideo;
        private System.Windows.Forms.Panel panelVideo;
        private System.Windows.Forms.Label labelCalcSize;
        private System.Windows.Forms.Label labelCalcSizeText;
        private System.Windows.Forms.Label labelVideoKbps;
        private System.Windows.Forms.Label labelMinQ;
        private System.Windows.Forms.Label labelMaxQ;
        private System.Windows.Forms.Label labelCRF;
        private System.Windows.Forms.RadioButton radioButtonBitrate;
        private System.Windows.Forms.RadioButton radioButtonCRF;
        private System.Windows.Forms.TrackBar trackBarCRF;
        private System.Windows.Forms.NumericUpDown numericUpDownBitrate;
        private System.Windows.Forms.Panel panelVideoParams;
        private System.Windows.Forms.Label labelFrameRate;
        private System.Windows.Forms.ComboBox comboBoxFrameRate;
        private System.Windows.Forms.TabPage tabPagePicture;
        private System.Windows.Forms.Panel panelDeinterlace;
        private System.Windows.Forms.Label labelFieldOrder;
        private System.Windows.Forms.CheckBox checkBoxDeinterlace;
        private System.Windows.Forms.ComboBox comboBoxFieldOrder;
        private System.Windows.Forms.Panel panelCrop;
        private System.Windows.Forms.Label labelColorFilter;
        private System.Windows.Forms.ComboBox comboBoxColorFilter;
        private System.Windows.Forms.Panel panelResolution;
        private System.Windows.Forms.PictureBox pictureBoxSizeError;
        private System.Windows.Forms.Label labelResizeMethod;
        private System.Windows.Forms.ComboBox comboBoxResizeMethod;
        private System.Windows.Forms.Label labelScalingAlgorithm;
        private System.Windows.Forms.ComboBox comboBoxScalingAlgorithm;
        private System.Windows.Forms.Label labelPictureSize;
        private System.Windows.Forms.ComboBox comboBoxPictureSize;
        private System.Windows.Forms.Button buttonCrop;
        private System.Windows.Forms.Label labelCropSize;
        private System.Windows.Forms.TabPage tabPageFile;
        private System.Windows.Forms.Panel panelFile;
        private System.Windows.Forms.ComboBox comboBoxFileType;
        private System.Windows.Forms.Label labelFileType;
        private System.Windows.Forms.Button buttonOpenInputFile;
        private System.Windows.Forms.Label labelOut;
        private System.Windows.Forms.Label labelInputFile;
        public System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.Button buttonShowInfo;
        private System.Windows.Forms.CheckBox checkBoxKeepOutPath;
        private System.Windows.Forms.Button buttonBrowseIn;
        private System.Windows.Forms.Button buttonBrowseOut;
        private System.Windows.Forms.TextBox textBoxIn;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.Label labelOutputInfo;
        private System.Windows.Forms.PictureBox pictureBoxAudioBitrateError;
        private System.Windows.Forms.Label labelOutputInfoTitle;
        private System.Windows.Forms.ComboBox comboBoxAudioStreams;
        private System.Windows.Forms.Label labelSelectAudioStream;
        private System.Windows.Forms.Panel panelAudioParams;
        private System.Windows.Forms.CheckBox checkBoxConvertAudio;
        private System.Windows.Forms.CheckBox checkBoxWebOptimized;
    }
}


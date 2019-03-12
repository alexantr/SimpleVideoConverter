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
            this.buttonShowInfo = new System.Windows.Forms.Button();
            this.buttonOpenInputFile = new System.Windows.Forms.Button();
            this.checkBoxWebOptimized = new System.Windows.Forms.CheckBox();
            this.buttonPreset1080p = new System.Windows.Forms.Button();
            this.buttonPreset720p = new System.Windows.Forms.Button();
            this.buttonPresetOriginal = new System.Windows.Forms.Button();
            this.buttonPreset480p = new System.Windows.Forms.Button();
            this.textBoxTagCreationTime = new System.Windows.Forms.TextBox();
            this.tabPageTags = new System.Windows.Forms.TabPage();
            this.buttonDateHelp = new System.Windows.Forms.Button();
            this.labelTagCopyright = new System.Windows.Forms.Label();
            this.textBoxTagCopyright = new System.Windows.Forms.TextBox();
            this.labelTagAuthor = new System.Windows.Forms.Label();
            this.textBoxTagAuthor = new System.Windows.Forms.TextBox();
            this.labelTagComment = new System.Windows.Forms.Label();
            this.textBoxTagComment = new System.Windows.Forms.TextBox();
            this.labelTagCreationTime = new System.Windows.Forms.Label();
            this.textBoxTagTitle = new System.Windows.Forms.TextBox();
            this.labelTagTitle = new System.Windows.Forms.Label();
            this.tabPageAudio = new System.Windows.Forms.TabPage();
            this.panelAudioParams = new System.Windows.Forms.Panel();
            this.labelAudioCodec = new System.Windows.Forms.Label();
            this.comboBoxAudioCodec = new System.Windows.Forms.ComboBox();
            this.checkBoxConvertAudio = new System.Windows.Forms.CheckBox();
            this.comboBoxAudioBitrate = new System.Windows.Forms.ComboBox();
            this.labelAudioHz = new System.Windows.Forms.Label();
            this.labelChannels = new System.Windows.Forms.Label();
            this.labelFrequency = new System.Windows.Forms.Label();
            this.labelAudioKbps = new System.Windows.Forms.Label();
            this.comboBoxAudioSampleRate = new System.Windows.Forms.ComboBox();
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
            this.labelVideoCodec = new System.Windows.Forms.Label();
            this.comboBoxVideoCodec = new System.Windows.Forms.ComboBox();
            this.labelFrameRate = new System.Windows.Forms.Label();
            this.comboBoxFrameRate = new System.Windows.Forms.ComboBox();
            this.tabPagePicture = new System.Windows.Forms.TabPage();
            this.panelResize = new System.Windows.Forms.Panel();
            this.labelCrop = new System.Windows.Forms.Label();
            this.checkBoxFlip = new System.Windows.Forms.CheckBox();
            this.buttonCrop = new System.Windows.Forms.Button();
            this.labelCropSize = new System.Windows.Forms.Label();
            this.comboBoxRotate = new System.Windows.Forms.ComboBox();
            this.labelRotate = new System.Windows.Forms.Label();
            this.labelPictureSize = new System.Windows.Forms.Label();
            this.labelSizePreset = new System.Windows.Forms.Label();
            this.labelInterpolation = new System.Windows.Forms.Label();
            this.comboBoxInterpolation = new System.Windows.Forms.ComboBox();
            this.checkBoxKeepAspectRatio = new System.Windows.Forms.CheckBox();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxRatioError = new System.Windows.Forms.PictureBox();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.comboBoxAspectRatio = new System.Windows.Forms.ComboBox();
            this.labelX = new System.Windows.Forms.Label();
            this.tabPageFile = new System.Windows.Forms.TabPage();
            this.panelFile = new System.Windows.Forms.Panel();
            this.labelOut = new System.Windows.Forms.Label();
            this.labelInputFile = new System.Windows.Forms.Label();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.checkBoxKeepOutPath = new System.Windows.Forms.CheckBox();
            this.buttonBrowseIn = new System.Windows.Forms.Button();
            this.buttonBrowseOut = new System.Windows.Forms.Button();
            this.textBoxIn = new System.Windows.Forms.TextBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageFilters = new System.Windows.Forms.TabPage();
            this.panelSubtitles = new System.Windows.Forms.Panel();
            this.labelSubtitles = new System.Windows.Forms.Label();
            this.buttonBrowseSubtitles = new System.Windows.Forms.Button();
            this.textBoxSubtitlesPath = new System.Windows.Forms.TextBox();
            this.panelColorFilter = new System.Windows.Forms.Panel();
            this.labelColorFilter = new System.Windows.Forms.Label();
            this.comboBoxColorFilter = new System.Windows.Forms.ComboBox();
            this.panelDeinterlace = new System.Windows.Forms.Panel();
            this.labelFieldOrder = new System.Windows.Forms.Label();
            this.checkBoxDeinterlace = new System.Windows.Forms.CheckBox();
            this.comboBoxFieldOrder = new System.Windows.Forms.ComboBox();
            this.labelOutputInfo = new System.Windows.Forms.Label();
            this.labelOutputInfoTitle = new System.Windows.Forms.Label();
            this.labelPreset = new System.Windows.Forms.Label();
            this.comboBoxPreset = new System.Windows.Forms.ComboBox();
            this.checkBoxConvertVideo = new System.Windows.Forms.CheckBox();
            this.tabPageTags.SuspendLayout();
            this.tabPageAudio.SuspendLayout();
            this.panelAudioParams.SuspendLayout();
            this.panelAudioStreams.SuspendLayout();
            this.tabPageVideo.SuspendLayout();
            this.panelVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCRF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBitrate)).BeginInit();
            this.tabPagePicture.SuspendLayout();
            this.panelResize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRatioError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            this.tabPageFile.SuspendLayout();
            this.panelFile.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageFilters.SuspendLayout();
            this.panelSubtitles.SuspendLayout();
            this.panelColorFilter.SuspendLayout();
            this.panelDeinterlace.SuspendLayout();
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
            // buttonShowInfo
            // 
            this.buttonShowInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonShowInfo.Location = new System.Drawing.Point(95, 33);
            this.buttonShowInfo.Name = "buttonShowInfo";
            this.buttonShowInfo.Size = new System.Drawing.Size(75, 25);
            this.buttonShowInfo.TabIndex = 3;
            this.buttonShowInfo.Text = "Инфо";
            this.toolTipHint.SetToolTip(this.buttonShowInfo, "Показать информацию об исходном файле");
            this.buttonShowInfo.UseVisualStyleBackColor = true;
            this.buttonShowInfo.Click += new System.EventHandler(this.buttonShowInfo_Click);
            // 
            // buttonOpenInputFile
            // 
            this.buttonOpenInputFile.Location = new System.Drawing.Point(176, 33);
            this.buttonOpenInputFile.Name = "buttonOpenInputFile";
            this.buttonOpenInputFile.Size = new System.Drawing.Size(75, 25);
            this.buttonOpenInputFile.TabIndex = 4;
            this.buttonOpenInputFile.Text = "Открыть";
            this.toolTipHint.SetToolTip(this.buttonOpenInputFile, "Открыть исходный файл в проигрывателе по умолчанию");
            this.buttonOpenInputFile.UseVisualStyleBackColor = true;
            this.buttonOpenInputFile.Click += new System.EventHandler(this.buttonOpenInputFile_Click);
            // 
            // checkBoxWebOptimized
            // 
            this.checkBoxWebOptimized.AutoSize = true;
            this.checkBoxWebOptimized.Location = new System.Drawing.Point(95, 147);
            this.checkBoxWebOptimized.Name = "checkBoxWebOptimized";
            this.checkBoxWebOptimized.Size = new System.Drawing.Size(142, 19);
            this.checkBoxWebOptimized.TabIndex = 9;
            this.checkBoxWebOptimized.Text = "Web-оптимизирован";
            this.toolTipHint.SetToolTip(this.checkBoxWebOptimized, "Служебная информация будет перенесена в начало файла для быстрого старта воспроиз" +
        "ведения в браузерах");
            this.checkBoxWebOptimized.UseVisualStyleBackColor = true;
            // 
            // buttonPreset1080p
            // 
            this.buttonPreset1080p.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPreset1080p.Location = new System.Drawing.Point(111, 78);
            this.buttonPreset1080p.Name = "buttonPreset1080p";
            this.buttonPreset1080p.Size = new System.Drawing.Size(45, 21);
            this.buttonPreset1080p.TabIndex = 33;
            this.buttonPreset1080p.Text = "1080p";
            this.toolTipHint.SetToolTip(this.buttonPreset1080p, "Вписать в 1920x1080");
            this.buttonPreset1080p.UseVisualStyleBackColor = true;
            this.buttonPreset1080p.Click += new System.EventHandler(this.buttonPreset1080p_Click);
            // 
            // buttonPreset720p
            // 
            this.buttonPreset720p.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPreset720p.Location = new System.Drawing.Point(162, 78);
            this.buttonPreset720p.Name = "buttonPreset720p";
            this.buttonPreset720p.Size = new System.Drawing.Size(45, 21);
            this.buttonPreset720p.TabIndex = 34;
            this.buttonPreset720p.Text = "720p";
            this.toolTipHint.SetToolTip(this.buttonPreset720p, "Вписать в 1280x720");
            this.buttonPreset720p.UseVisualStyleBackColor = true;
            this.buttonPreset720p.Click += new System.EventHandler(this.buttonPreset720p_Click);
            // 
            // buttonPresetOriginal
            // 
            this.buttonPresetOriginal.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPresetOriginal.Location = new System.Drawing.Point(264, 78);
            this.buttonPresetOriginal.Name = "buttonPresetOriginal";
            this.buttonPresetOriginal.Size = new System.Drawing.Size(60, 21);
            this.buttonPresetOriginal.TabIndex = 35;
            this.buttonPresetOriginal.Text = "Сбросить";
            this.toolTipHint.SetToolTip(this.buttonPresetOriginal, "Задать исходный размер");
            this.buttonPresetOriginal.UseVisualStyleBackColor = true;
            this.buttonPresetOriginal.Click += new System.EventHandler(this.buttonPresetOriginal_Click);
            // 
            // buttonPreset480p
            // 
            this.buttonPreset480p.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPreset480p.Location = new System.Drawing.Point(213, 78);
            this.buttonPreset480p.Name = "buttonPreset480p";
            this.buttonPreset480p.Size = new System.Drawing.Size(45, 21);
            this.buttonPreset480p.TabIndex = 38;
            this.buttonPreset480p.Text = "480p";
            this.toolTipHint.SetToolTip(this.buttonPreset480p, "Вписать в 640x480");
            this.buttonPreset480p.UseVisualStyleBackColor = true;
            this.buttonPreset480p.Click += new System.EventHandler(this.buttonPreset480p_Click);
            // 
            // textBoxTagCreationTime
            // 
            this.textBoxTagCreationTime.Location = new System.Drawing.Point(137, 117);
            this.textBoxTagCreationTime.Name = "textBoxTagCreationTime";
            this.textBoxTagCreationTime.Size = new System.Drawing.Size(180, 23);
            this.textBoxTagCreationTime.TabIndex = 9;
            this.textBoxTagCreationTime.TextChanged += new System.EventHandler(this.textBoxTagCreationTime_TextChanged);
            // 
            // tabPageTags
            // 
            this.tabPageTags.Controls.Add(this.buttonDateHelp);
            this.tabPageTags.Controls.Add(this.labelTagCopyright);
            this.tabPageTags.Controls.Add(this.textBoxTagCopyright);
            this.tabPageTags.Controls.Add(this.labelTagAuthor);
            this.tabPageTags.Controls.Add(this.textBoxTagAuthor);
            this.tabPageTags.Controls.Add(this.labelTagComment);
            this.tabPageTags.Controls.Add(this.textBoxTagComment);
            this.tabPageTags.Controls.Add(this.textBoxTagCreationTime);
            this.tabPageTags.Controls.Add(this.labelTagCreationTime);
            this.tabPageTags.Controls.Add(this.textBoxTagTitle);
            this.tabPageTags.Controls.Add(this.labelTagTitle);
            this.tabPageTags.Location = new System.Drawing.Point(4, 24);
            this.tabPageTags.Name = "tabPageTags";
            this.tabPageTags.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTags.Size = new System.Drawing.Size(604, 183);
            this.tabPageTags.TabIndex = 4;
            this.tabPageTags.Text = "Теги";
            this.tabPageTags.UseVisualStyleBackColor = true;
            // 
            // buttonDateHelp
            // 
            this.buttonDateHelp.Location = new System.Drawing.Point(323, 116);
            this.buttonDateHelp.Name = "buttonDateHelp";
            this.buttonDateHelp.Size = new System.Drawing.Size(25, 25);
            this.buttonDateHelp.TabIndex = 10;
            this.buttonDateHelp.Text = "?";
            this.buttonDateHelp.UseVisualStyleBackColor = true;
            this.buttonDateHelp.Click += new System.EventHandler(this.buttonDateHelp_Click);
            // 
            // labelTagCopyright
            // 
            this.labelTagCopyright.AutoSize = true;
            this.labelTagCopyright.Location = new System.Drawing.Point(6, 66);
            this.labelTagCopyright.Name = "labelTagCopyright";
            this.labelTagCopyright.Size = new System.Drawing.Size(60, 15);
            this.labelTagCopyright.TabIndex = 4;
            this.labelTagCopyright.Text = "Копирайт";
            // 
            // textBoxTagCopyright
            // 
            this.textBoxTagCopyright.Location = new System.Drawing.Point(137, 63);
            this.textBoxTagCopyright.Name = "textBoxTagCopyright";
            this.textBoxTagCopyright.Size = new System.Drawing.Size(461, 23);
            this.textBoxTagCopyright.TabIndex = 5;
            this.textBoxTagCopyright.TextChanged += new System.EventHandler(this.textBoxTagCopyright_TextChanged);
            // 
            // labelTagAuthor
            // 
            this.labelTagAuthor.AutoSize = true;
            this.labelTagAuthor.Location = new System.Drawing.Point(6, 38);
            this.labelTagAuthor.Name = "labelTagAuthor";
            this.labelTagAuthor.Size = new System.Drawing.Size(125, 15);
            this.labelTagAuthor.TabIndex = 2;
            this.labelTagAuthor.Text = "Автор (Исполнитель)";
            // 
            // textBoxTagAuthor
            // 
            this.textBoxTagAuthor.Location = new System.Drawing.Point(137, 35);
            this.textBoxTagAuthor.Name = "textBoxTagAuthor";
            this.textBoxTagAuthor.Size = new System.Drawing.Size(461, 23);
            this.textBoxTagAuthor.TabIndex = 3;
            this.textBoxTagAuthor.TextChanged += new System.EventHandler(this.textBoxTagAuthor_TextChanged);
            // 
            // labelTagComment
            // 
            this.labelTagComment.AutoSize = true;
            this.labelTagComment.Location = new System.Drawing.Point(6, 93);
            this.labelTagComment.Name = "labelTagComment";
            this.labelTagComment.Size = new System.Drawing.Size(84, 15);
            this.labelTagComment.TabIndex = 6;
            this.labelTagComment.Text = "Комментарий";
            // 
            // textBoxTagComment
            // 
            this.textBoxTagComment.Location = new System.Drawing.Point(137, 90);
            this.textBoxTagComment.Name = "textBoxTagComment";
            this.textBoxTagComment.Size = new System.Drawing.Size(461, 23);
            this.textBoxTagComment.TabIndex = 7;
            this.textBoxTagComment.TextChanged += new System.EventHandler(this.textBoxTagComment_TextChanged);
            // 
            // labelTagCreationTime
            // 
            this.labelTagCreationTime.AutoSize = true;
            this.labelTagCreationTime.Location = new System.Drawing.Point(6, 120);
            this.labelTagCreationTime.Name = "labelTagCreationTime";
            this.labelTagCreationTime.Size = new System.Drawing.Size(85, 15);
            this.labelTagCreationTime.TabIndex = 8;
            this.labelTagCreationTime.Text = "Дата создания";
            // 
            // textBoxTagTitle
            // 
            this.textBoxTagTitle.Location = new System.Drawing.Point(137, 7);
            this.textBoxTagTitle.Name = "textBoxTagTitle";
            this.textBoxTagTitle.Size = new System.Drawing.Size(461, 23);
            this.textBoxTagTitle.TabIndex = 1;
            this.textBoxTagTitle.TextChanged += new System.EventHandler(this.textBoxTagTitle_TextChanged);
            // 
            // labelTagTitle
            // 
            this.labelTagTitle.AutoSize = true;
            this.labelTagTitle.Location = new System.Drawing.Point(6, 10);
            this.labelTagTitle.Name = "labelTagTitle";
            this.labelTagTitle.Size = new System.Drawing.Size(65, 15);
            this.labelTagTitle.TabIndex = 0;
            this.labelTagTitle.Text = "Заголовок";
            // 
            // tabPageAudio
            // 
            this.tabPageAudio.Controls.Add(this.panelAudioParams);
            this.tabPageAudio.Controls.Add(this.panelAudioStreams);
            this.tabPageAudio.Location = new System.Drawing.Point(4, 24);
            this.tabPageAudio.Name = "tabPageAudio";
            this.tabPageAudio.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAudio.Size = new System.Drawing.Size(604, 183);
            this.tabPageAudio.TabIndex = 2;
            this.tabPageAudio.Text = "Аудио";
            this.tabPageAudio.UseVisualStyleBackColor = true;
            // 
            // panelAudioParams
            // 
            this.panelAudioParams.Controls.Add(this.labelAudioCodec);
            this.panelAudioParams.Controls.Add(this.comboBoxAudioCodec);
            this.panelAudioParams.Controls.Add(this.checkBoxConvertAudio);
            this.panelAudioParams.Controls.Add(this.comboBoxAudioBitrate);
            this.panelAudioParams.Controls.Add(this.labelAudioHz);
            this.panelAudioParams.Controls.Add(this.labelChannels);
            this.panelAudioParams.Controls.Add(this.labelFrequency);
            this.panelAudioParams.Controls.Add(this.labelAudioKbps);
            this.panelAudioParams.Controls.Add(this.comboBoxAudioSampleRate);
            this.panelAudioParams.Controls.Add(this.comboBoxAudioChannels);
            this.panelAudioParams.Controls.Add(this.labelAudioBitrate);
            this.panelAudioParams.Location = new System.Drawing.Point(6, 51);
            this.panelAudioParams.Name = "panelAudioParams";
            this.panelAudioParams.Size = new System.Drawing.Size(592, 126);
            this.panelAudioParams.TabIndex = 1;
            // 
            // labelAudioCodec
            // 
            this.labelAudioCodec.AutoSize = true;
            this.labelAudioCodec.Location = new System.Drawing.Point(3, 35);
            this.labelAudioCodec.Name = "labelAudioCodec";
            this.labelAudioCodec.Size = new System.Drawing.Size(39, 15);
            this.labelAudioCodec.TabIndex = 10;
            this.labelAudioCodec.Text = "Кодек";
            // 
            // comboBoxAudioCodec
            // 
            this.comboBoxAudioCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudioCodec.FormattingEnabled = true;
            this.comboBoxAudioCodec.Location = new System.Drawing.Point(77, 32);
            this.comboBoxAudioCodec.Name = "comboBoxAudioCodec";
            this.comboBoxAudioCodec.Size = new System.Drawing.Size(80, 23);
            this.comboBoxAudioCodec.TabIndex = 9;
            this.comboBoxAudioCodec.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioCodec_SelectedIndexChanged);
            // 
            // checkBoxConvertAudio
            // 
            this.checkBoxConvertAudio.AutoSize = true;
            this.checkBoxConvertAudio.Location = new System.Drawing.Point(6, 3);
            this.checkBoxConvertAudio.Name = "checkBoxConvertAudio";
            this.checkBoxConvertAudio.Size = new System.Drawing.Size(142, 19);
            this.checkBoxConvertAudio.TabIndex = 0;
            this.checkBoxConvertAudio.Text = "Переконвертировать";
            this.checkBoxConvertAudio.UseVisualStyleBackColor = true;
            this.checkBoxConvertAudio.CheckedChanged += new System.EventHandler(this.checkBoxConvertAudio_CheckedChanged);
            // 
            // comboBoxAudioBitrate
            // 
            this.comboBoxAudioBitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudioBitrate.FormattingEnabled = true;
            this.comboBoxAudioBitrate.Location = new System.Drawing.Point(284, 32);
            this.comboBoxAudioBitrate.Name = "comboBoxAudioBitrate";
            this.comboBoxAudioBitrate.Size = new System.Drawing.Size(80, 23);
            this.comboBoxAudioBitrate.TabIndex = 2;
            this.comboBoxAudioBitrate.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioBitrate_SelectedIndexChanged);
            // 
            // labelAudioHz
            // 
            this.labelAudioHz.AutoSize = true;
            this.labelAudioHz.Location = new System.Drawing.Point(163, 89);
            this.labelAudioHz.Name = "labelAudioHz";
            this.labelAudioHz.Size = new System.Drawing.Size(20, 15);
            this.labelAudioHz.TabIndex = 6;
            this.labelAudioHz.Text = "Гц";
            // 
            // labelChannels
            // 
            this.labelChannels.AutoSize = true;
            this.labelChannels.Location = new System.Drawing.Point(210, 89);
            this.labelChannels.Name = "labelChannels";
            this.labelChannels.Size = new System.Drawing.Size(49, 15);
            this.labelChannels.TabIndex = 7;
            this.labelChannels.Text = "Каналы";
            // 
            // labelFrequency
            // 
            this.labelFrequency.AutoSize = true;
            this.labelFrequency.Location = new System.Drawing.Point(3, 89);
            this.labelFrequency.Name = "labelFrequency";
            this.labelFrequency.Size = new System.Drawing.Size(50, 15);
            this.labelFrequency.TabIndex = 4;
            this.labelFrequency.Text = "Частота";
            // 
            // labelAudioKbps
            // 
            this.labelAudioKbps.AutoSize = true;
            this.labelAudioKbps.Location = new System.Drawing.Point(370, 35);
            this.labelAudioKbps.Name = "labelAudioKbps";
            this.labelAudioKbps.Size = new System.Drawing.Size(43, 15);
            this.labelAudioKbps.TabIndex = 3;
            this.labelAudioKbps.Text = "кбит/с";
            // 
            // comboBoxAudioSampleRate
            // 
            this.comboBoxAudioSampleRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudioSampleRate.FormattingEnabled = true;
            this.comboBoxAudioSampleRate.Location = new System.Drawing.Point(77, 86);
            this.comboBoxAudioSampleRate.Name = "comboBoxAudioSampleRate";
            this.comboBoxAudioSampleRate.Size = new System.Drawing.Size(80, 23);
            this.comboBoxAudioSampleRate.TabIndex = 5;
            this.comboBoxAudioSampleRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioSampleRate_SelectedIndexChanged);
            // 
            // comboBoxAudioChannels
            // 
            this.comboBoxAudioChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudioChannels.FormattingEnabled = true;
            this.comboBoxAudioChannels.Location = new System.Drawing.Point(284, 86);
            this.comboBoxAudioChannels.Name = "comboBoxAudioChannels";
            this.comboBoxAudioChannels.Size = new System.Drawing.Size(80, 23);
            this.comboBoxAudioChannels.TabIndex = 8;
            this.comboBoxAudioChannels.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioChannels_SelectedIndexChanged);
            // 
            // labelAudioBitrate
            // 
            this.labelAudioBitrate.AutoSize = true;
            this.labelAudioBitrate.Location = new System.Drawing.Point(210, 35);
            this.labelAudioBitrate.Name = "labelAudioBitrate";
            this.labelAudioBitrate.Size = new System.Drawing.Size(51, 15);
            this.labelAudioBitrate.TabIndex = 1;
            this.labelAudioBitrate.Text = "Битрейт";
            // 
            // panelAudioStreams
            // 
            this.panelAudioStreams.Controls.Add(this.comboBoxAudioStreams);
            this.panelAudioStreams.Controls.Add(this.labelSelectAudioStream);
            this.panelAudioStreams.Location = new System.Drawing.Point(6, 6);
            this.panelAudioStreams.Name = "panelAudioStreams";
            this.panelAudioStreams.Size = new System.Drawing.Size(364, 39);
            this.panelAudioStreams.TabIndex = 0;
            // 
            // comboBoxAudioStreams
            // 
            this.comboBoxAudioStreams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudioStreams.FormattingEnabled = true;
            this.comboBoxAudioStreams.Location = new System.Drawing.Point(77, 3);
            this.comboBoxAudioStreams.Name = "comboBoxAudioStreams";
            this.comboBoxAudioStreams.Size = new System.Drawing.Size(220, 23);
            this.comboBoxAudioStreams.TabIndex = 1;
            this.comboBoxAudioStreams.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioStreams_SelectedIndexChanged);
            // 
            // labelSelectAudioStream
            // 
            this.labelSelectAudioStream.AutoSize = true;
            this.labelSelectAudioStream.Location = new System.Drawing.Point(3, 6);
            this.labelSelectAudioStream.Name = "labelSelectAudioStream";
            this.labelSelectAudioStream.Size = new System.Drawing.Size(57, 15);
            this.labelSelectAudioStream.TabIndex = 0;
            this.labelSelectAudioStream.Text = "Дорожка";
            // 
            // tabPageVideo
            // 
            this.tabPageVideo.Controls.Add(this.checkBoxConvertVideo);
            this.tabPageVideo.Controls.Add(this.panelVideo);
            this.tabPageVideo.Location = new System.Drawing.Point(4, 24);
            this.tabPageVideo.Name = "tabPageVideo";
            this.tabPageVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVideo.Size = new System.Drawing.Size(604, 183);
            this.tabPageVideo.TabIndex = 0;
            this.tabPageVideo.Text = "Видео";
            this.tabPageVideo.UseVisualStyleBackColor = true;
            // 
            // panelVideo
            // 
            this.panelVideo.Controls.Add(this.comboBoxPreset);
            this.panelVideo.Controls.Add(this.labelCalcSize);
            this.panelVideo.Controls.Add(this.labelPreset);
            this.panelVideo.Controls.Add(this.labelCalcSizeText);
            this.panelVideo.Controls.Add(this.labelVideoCodec);
            this.panelVideo.Controls.Add(this.comboBoxVideoCodec);
            this.panelVideo.Controls.Add(this.labelVideoKbps);
            this.panelVideo.Controls.Add(this.labelFrameRate);
            this.panelVideo.Controls.Add(this.labelMinQ);
            this.panelVideo.Controls.Add(this.comboBoxFrameRate);
            this.panelVideo.Controls.Add(this.labelMaxQ);
            this.panelVideo.Controls.Add(this.labelCRF);
            this.panelVideo.Controls.Add(this.radioButtonBitrate);
            this.panelVideo.Controls.Add(this.radioButtonCRF);
            this.panelVideo.Controls.Add(this.trackBarCRF);
            this.panelVideo.Controls.Add(this.numericUpDownBitrate);
            this.panelVideo.Location = new System.Drawing.Point(6, 31);
            this.panelVideo.Name = "panelVideo";
            this.panelVideo.Size = new System.Drawing.Size(592, 148);
            this.panelVideo.TabIndex = 0;
            // 
            // labelCalcSize
            // 
            this.labelCalcSize.AutoSize = true;
            this.labelCalcSize.Location = new System.Drawing.Point(97, 127);
            this.labelCalcSize.Name = "labelCalcSize";
            this.labelCalcSize.Size = new System.Drawing.Size(12, 15);
            this.labelCalcSize.TabIndex = 9;
            this.labelCalcSize.Text = "-";
            // 
            // labelCalcSizeText
            // 
            this.labelCalcSizeText.AutoSize = true;
            this.labelCalcSizeText.Location = new System.Drawing.Point(3, 127);
            this.labelCalcSizeText.Name = "labelCalcSizeText";
            this.labelCalcSizeText.Size = new System.Drawing.Size(88, 15);
            this.labelCalcSizeText.TabIndex = 8;
            this.labelCalcSizeText.Text = "Размер файла:";
            // 
            // labelVideoKbps
            // 
            this.labelVideoKbps.AutoSize = true;
            this.labelVideoKbps.Location = new System.Drawing.Point(161, 95);
            this.labelVideoKbps.Name = "labelVideoKbps";
            this.labelVideoKbps.Size = new System.Drawing.Size(43, 15);
            this.labelVideoKbps.TabIndex = 7;
            this.labelVideoKbps.Text = "кбит/с";
            // 
            // labelMinQ
            // 
            this.labelMinQ.AutoSize = true;
            this.labelMinQ.Location = new System.Drawing.Point(216, 61);
            this.labelMinQ.Name = "labelMinQ";
            this.labelMinQ.Size = new System.Drawing.Size(87, 15);
            this.labelMinQ.TabIndex = 4;
            this.labelMinQ.Text = "Мин. качество";
            // 
            // labelMaxQ
            // 
            this.labelMaxQ.AutoSize = true;
            this.labelMaxQ.Location = new System.Drawing.Point(2, 61);
            this.labelMaxQ.Name = "labelMaxQ";
            this.labelMaxQ.Size = new System.Drawing.Size(91, 15);
            this.labelMaxQ.TabIndex = 3;
            this.labelMaxQ.Text = "Макс. качество";
            // 
            // labelCRF
            // 
            this.labelCRF.AutoSize = true;
            this.labelCRF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCRF.Location = new System.Drawing.Point(109, 5);
            this.labelCRF.Name = "labelCRF";
            this.labelCRF.Size = new System.Drawing.Size(31, 15);
            this.labelCRF.TabIndex = 1;
            this.labelCRF.Text = "20.0";
            // 
            // radioButtonBitrate
            // 
            this.radioButtonBitrate.AutoSize = true;
            this.radioButtonBitrate.Location = new System.Drawing.Point(2, 93);
            this.radioButtonBitrate.Name = "radioButtonBitrate";
            this.radioButtonBitrate.Size = new System.Drawing.Size(69, 19);
            this.radioButtonBitrate.TabIndex = 5;
            this.radioButtonBitrate.TabStop = true;
            this.radioButtonBitrate.Text = "Битрейт";
            this.radioButtonBitrate.UseVisualStyleBackColor = true;
            this.radioButtonBitrate.CheckedChanged += new System.EventHandler(this.radioButtonBitrate_CheckedChanged);
            // 
            // radioButtonCRF
            // 
            this.radioButtonCRF.AutoSize = true;
            this.radioButtonCRF.Location = new System.Drawing.Point(3, 3);
            this.radioButtonCRF.Name = "radioButtonCRF";
            this.radioButtonCRF.Size = new System.Drawing.Size(46, 19);
            this.radioButtonCRF.TabIndex = 0;
            this.radioButtonCRF.TabStop = true;
            this.radioButtonCRF.Text = "CRF";
            this.radioButtonCRF.UseVisualStyleBackColor = true;
            this.radioButtonCRF.CheckedChanged += new System.EventHandler(this.radioButtonCRF_CheckedChanged);
            // 
            // trackBarCRF
            // 
            this.trackBarCRF.BackColor = System.Drawing.SystemColors.Window;
            this.trackBarCRF.LargeChange = 10;
            this.trackBarCRF.Location = new System.Drawing.Point(2, 29);
            this.trackBarCRF.Maximum = 510;
            this.trackBarCRF.Name = "trackBarCRF";
            this.trackBarCRF.Size = new System.Drawing.Size(301, 45);
            this.trackBarCRF.TabIndex = 2;
            this.trackBarCRF.Value = 200;
            this.trackBarCRF.ValueChanged += new System.EventHandler(this.trackBarCRF_ValueChanged);
            // 
            // numericUpDownBitrate
            // 
            this.numericUpDownBitrate.Location = new System.Drawing.Point(75, 92);
            this.numericUpDownBitrate.Name = "numericUpDownBitrate";
            this.numericUpDownBitrate.Size = new System.Drawing.Size(80, 23);
            this.numericUpDownBitrate.TabIndex = 6;
            this.numericUpDownBitrate.ValueChanged += new System.EventHandler(this.numericUpDownBitrate_ValueChanged);
            // 
            // labelVideoCodec
            // 
            this.labelVideoCodec.AutoSize = true;
            this.labelVideoCodec.Location = new System.Drawing.Point(393, 13);
            this.labelVideoCodec.Name = "labelVideoCodec";
            this.labelVideoCodec.Size = new System.Drawing.Size(39, 15);
            this.labelVideoCodec.TabIndex = 3;
            this.labelVideoCodec.Text = "Кодек";
            // 
            // comboBoxVideoCodec
            // 
            this.comboBoxVideoCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVideoCodec.FormattingEnabled = true;
            this.comboBoxVideoCodec.Location = new System.Drawing.Point(488, 10);
            this.comboBoxVideoCodec.Name = "comboBoxVideoCodec";
            this.comboBoxVideoCodec.Size = new System.Drawing.Size(80, 23);
            this.comboBoxVideoCodec.TabIndex = 2;
            this.comboBoxVideoCodec.SelectedIndexChanged += new System.EventHandler(this.comboBoxVideoCodec_SelectedIndexChanged);
            // 
            // labelFrameRate
            // 
            this.labelFrameRate.AutoSize = true;
            this.labelFrameRate.Location = new System.Drawing.Point(393, 98);
            this.labelFrameRate.Name = "labelFrameRate";
            this.labelFrameRate.Size = new System.Drawing.Size(91, 15);
            this.labelFrameRate.TabIndex = 0;
            this.labelFrameRate.Text = "Частота кадров";
            // 
            // comboBoxFrameRate
            // 
            this.comboBoxFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrameRate.FormattingEnabled = true;
            this.comboBoxFrameRate.Location = new System.Drawing.Point(488, 95);
            this.comboBoxFrameRate.Name = "comboBoxFrameRate";
            this.comboBoxFrameRate.Size = new System.Drawing.Size(80, 23);
            this.comboBoxFrameRate.TabIndex = 1;
            this.comboBoxFrameRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxFrameRate_SelectedIndexChanged);
            // 
            // tabPagePicture
            // 
            this.tabPagePicture.Controls.Add(this.panelResize);
            this.tabPagePicture.Location = new System.Drawing.Point(4, 24);
            this.tabPagePicture.Name = "tabPagePicture";
            this.tabPagePicture.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePicture.Size = new System.Drawing.Size(604, 183);
            this.tabPagePicture.TabIndex = 1;
            this.tabPagePicture.Text = "Картинка";
            this.tabPagePicture.UseVisualStyleBackColor = true;
            // 
            // panelResize
            // 
            this.panelResize.Controls.Add(this.labelCrop);
            this.panelResize.Controls.Add(this.checkBoxFlip);
            this.panelResize.Controls.Add(this.buttonCrop);
            this.panelResize.Controls.Add(this.labelCropSize);
            this.panelResize.Controls.Add(this.buttonPreset480p);
            this.panelResize.Controls.Add(this.comboBoxRotate);
            this.panelResize.Controls.Add(this.labelRotate);
            this.panelResize.Controls.Add(this.labelPictureSize);
            this.panelResize.Controls.Add(this.labelSizePreset);
            this.panelResize.Controls.Add(this.buttonPresetOriginal);
            this.panelResize.Controls.Add(this.buttonPreset720p);
            this.panelResize.Controls.Add(this.buttonPreset1080p);
            this.panelResize.Controls.Add(this.labelInterpolation);
            this.panelResize.Controls.Add(this.comboBoxInterpolation);
            this.panelResize.Controls.Add(this.checkBoxKeepAspectRatio);
            this.panelResize.Controls.Add(this.numericUpDownWidth);
            this.panelResize.Controls.Add(this.pictureBoxRatioError);
            this.panelResize.Controls.Add(this.numericUpDownHeight);
            this.panelResize.Controls.Add(this.comboBoxAspectRatio);
            this.panelResize.Controls.Add(this.labelX);
            this.panelResize.Location = new System.Drawing.Point(6, 6);
            this.panelResize.Name = "panelResize";
            this.panelResize.Size = new System.Drawing.Size(592, 171);
            this.panelResize.TabIndex = 3;
            // 
            // labelCrop
            // 
            this.labelCrop.AutoSize = true;
            this.labelCrop.Location = new System.Drawing.Point(3, 8);
            this.labelCrop.Name = "labelCrop";
            this.labelCrop.Size = new System.Drawing.Size(86, 15);
            this.labelCrop.TabIndex = 2;
            this.labelCrop.Text = "Кадрирование";
            // 
            // checkBoxFlip
            // 
            this.checkBoxFlip.AutoSize = true;
            this.checkBoxFlip.Location = new System.Drawing.Point(6, 149);
            this.checkBoxFlip.Name = "checkBoxFlip";
            this.checkBoxFlip.Size = new System.Drawing.Size(166, 19);
            this.checkBoxFlip.TabIndex = 2;
            this.checkBoxFlip.Text = "Отразить по горизонтали";
            this.checkBoxFlip.UseVisualStyleBackColor = true;
            this.checkBoxFlip.CheckedChanged += new System.EventHandler(this.checkBoxFlip_CheckedChanged);
            // 
            // buttonCrop
            // 
            this.buttonCrop.Location = new System.Drawing.Point(111, 3);
            this.buttonCrop.Name = "buttonCrop";
            this.buttonCrop.Size = new System.Drawing.Size(120, 25);
            this.buttonCrop.TabIndex = 0;
            this.buttonCrop.Text = "Изменить";
            this.buttonCrop.UseVisualStyleBackColor = true;
            this.buttonCrop.Click += new System.EventHandler(this.buttonCrop_Click);
            // 
            // labelCropSize
            // 
            this.labelCropSize.AutoSize = true;
            this.labelCropSize.Location = new System.Drawing.Point(237, 8);
            this.labelCropSize.Name = "labelCropSize";
            this.labelCropSize.Size = new System.Drawing.Size(73, 15);
            this.labelCropSize.TabIndex = 1;
            this.labelCropSize.Text = "WxH → WxH";
            this.labelCropSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBoxRotate
            // 
            this.comboBoxRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRotate.FormattingEnabled = true;
            this.comboBoxRotate.Location = new System.Drawing.Point(111, 120);
            this.comboBoxRotate.Name = "comboBoxRotate";
            this.comboBoxRotate.Size = new System.Drawing.Size(120, 23);
            this.comboBoxRotate.TabIndex = 1;
            this.comboBoxRotate.SelectedIndexChanged += new System.EventHandler(this.comboBoxRotate_SelectedIndexChanged);
            // 
            // labelRotate
            // 
            this.labelRotate.AutoSize = true;
            this.labelRotate.Location = new System.Drawing.Point(3, 123);
            this.labelRotate.Name = "labelRotate";
            this.labelRotate.Size = new System.Drawing.Size(66, 15);
            this.labelRotate.TabIndex = 0;
            this.labelRotate.Text = "Повернуть";
            // 
            // labelPictureSize
            // 
            this.labelPictureSize.AutoSize = true;
            this.labelPictureSize.Location = new System.Drawing.Point(3, 51);
            this.labelPictureSize.Name = "labelPictureSize";
            this.labelPictureSize.Size = new System.Drawing.Size(56, 15);
            this.labelPictureSize.TabIndex = 37;
            this.labelPictureSize.Text = "Размеры";
            // 
            // labelSizePreset
            // 
            this.labelSizePreset.AutoSize = true;
            this.labelSizePreset.Location = new System.Drawing.Point(3, 80);
            this.labelSizePreset.Name = "labelSizePreset";
            this.labelSizePreset.Size = new System.Drawing.Size(102, 15);
            this.labelSizePreset.TabIndex = 36;
            this.labelSizePreset.Text = "Пресет размеров";
            // 
            // labelInterpolation
            // 
            this.labelInterpolation.AutoSize = true;
            this.labelInterpolation.Location = new System.Drawing.Point(306, 123);
            this.labelInterpolation.Name = "labelInterpolation";
            this.labelInterpolation.Size = new System.Drawing.Size(88, 15);
            this.labelInterpolation.TabIndex = 6;
            this.labelInterpolation.Text = "Интерполяция";
            // 
            // comboBoxInterpolation
            // 
            this.comboBoxInterpolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInterpolation.FormattingEnabled = true;
            this.comboBoxInterpolation.Location = new System.Drawing.Point(400, 120);
            this.comboBoxInterpolation.Name = "comboBoxInterpolation";
            this.comboBoxInterpolation.Size = new System.Drawing.Size(120, 23);
            this.comboBoxInterpolation.TabIndex = 7;
            this.comboBoxInterpolation.SelectedIndexChanged += new System.EventHandler(this.comboBoxInterpolation_SelectedIndexChanged);
            // 
            // checkBoxKeepAspectRatio
            // 
            this.checkBoxKeepAspectRatio.AutoSize = true;
            this.checkBoxKeepAspectRatio.Location = new System.Drawing.Point(246, 51);
            this.checkBoxKeepAspectRatio.Name = "checkBoxKeepAspectRatio";
            this.checkBoxKeepAspectRatio.Size = new System.Drawing.Size(149, 19);
            this.checkBoxKeepAspectRatio.TabIndex = 31;
            this.checkBoxKeepAspectRatio.Text = "Сохранять пропорции";
            this.checkBoxKeepAspectRatio.UseVisualStyleBackColor = true;
            this.checkBoxKeepAspectRatio.CheckedChanged += new System.EventHandler(this.checkBoxKeepAspectRatio_CheckedChanged);
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(111, 49);
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(50, 23);
            this.numericUpDownWidth.TabIndex = 26;
            this.numericUpDownWidth.ValueChanged += new System.EventHandler(this.numericUpDownWidth_ValueChanged);
            this.numericUpDownWidth.Leave += new System.EventHandler(this.numericUpDownWidth_Leave);
            // 
            // pictureBoxRatioError
            // 
            this.pictureBoxRatioError.Location = new System.Drawing.Point(526, 52);
            this.pictureBoxRatioError.Name = "pictureBoxRatioError";
            this.pictureBoxRatioError.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxRatioError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxRatioError.TabIndex = 30;
            this.pictureBoxRatioError.TabStop = false;
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(181, 49);
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(50, 23);
            this.numericUpDownHeight.TabIndex = 27;
            this.numericUpDownHeight.ValueChanged += new System.EventHandler(this.numericUpDownHeight_ValueChanged);
            this.numericUpDownHeight.Leave += new System.EventHandler(this.numericUpDownHeight_Leave);
            // 
            // comboBoxAspectRatio
            // 
            this.comboBoxAspectRatio.FormattingEnabled = true;
            this.comboBoxAspectRatio.Location = new System.Drawing.Point(400, 49);
            this.comboBoxAspectRatio.Name = "comboBoxAspectRatio";
            this.comboBoxAspectRatio.Size = new System.Drawing.Size(120, 23);
            this.comboBoxAspectRatio.TabIndex = 29;
            this.comboBoxAspectRatio.SelectedIndexChanged += new System.EventHandler(this.comboBoxAspectRatio_SelectedIndexChanged);
            this.comboBoxAspectRatio.TextUpdate += new System.EventHandler(this.comboBoxAspectRatio_TextUpdate);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(164, 51);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(15, 15);
            this.labelX.TabIndex = 28;
            this.labelX.Text = "×";
            // 
            // tabPageFile
            // 
            this.tabPageFile.Controls.Add(this.panelFile);
            this.tabPageFile.Location = new System.Drawing.Point(4, 24);
            this.tabPageFile.Name = "tabPageFile";
            this.tabPageFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFile.Size = new System.Drawing.Size(604, 183);
            this.tabPageFile.TabIndex = 3;
            this.tabPageFile.Text = "Файл";
            this.tabPageFile.UseVisualStyleBackColor = true;
            // 
            // panelFile
            // 
            this.panelFile.Controls.Add(this.checkBoxWebOptimized);
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
            this.panelFile.Size = new System.Drawing.Size(592, 171);
            this.panelFile.TabIndex = 0;
            // 
            // labelOut
            // 
            this.labelOut.AutoSize = true;
            this.labelOut.Location = new System.Drawing.Point(3, 78);
            this.labelOut.Name = "labelOut";
            this.labelOut.Size = new System.Drawing.Size(86, 15);
            this.labelOut.TabIndex = 5;
            this.labelOut.Text = "Сохранить как";
            // 
            // labelInputFile
            // 
            this.labelInputFile.AutoSize = true;
            this.labelInputFile.Location = new System.Drawing.Point(3, 8);
            this.labelInputFile.Name = "labelInputFile";
            this.labelInputFile.Size = new System.Drawing.Size(86, 15);
            this.labelInputFile.TabIndex = 0;
            this.labelInputFile.Text = "Выбрать файл";
            // 
            // textBoxOut
            // 
            this.textBoxOut.Location = new System.Drawing.Point(95, 74);
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.Size = new System.Drawing.Size(413, 23);
            this.textBoxOut.TabIndex = 6;
            // 
            // checkBoxKeepOutPath
            // 
            this.checkBoxKeepOutPath.AutoSize = true;
            this.checkBoxKeepOutPath.Location = new System.Drawing.Point(95, 103);
            this.checkBoxKeepOutPath.Name = "checkBoxKeepOutPath";
            this.checkBoxKeepOutPath.Size = new System.Drawing.Size(190, 19);
            this.checkBoxKeepOutPath.TabIndex = 8;
            this.checkBoxKeepOutPath.Text = "Запомнить выбранную папку";
            this.checkBoxKeepOutPath.UseVisualStyleBackColor = true;
            // 
            // buttonBrowseIn
            // 
            this.buttonBrowseIn.Location = new System.Drawing.Point(514, 3);
            this.buttonBrowseIn.Name = "buttonBrowseIn";
            this.buttonBrowseIn.Size = new System.Drawing.Size(75, 25);
            this.buttonBrowseIn.TabIndex = 2;
            this.buttonBrowseIn.Text = "Обзор";
            this.buttonBrowseIn.UseVisualStyleBackColor = true;
            this.buttonBrowseIn.Click += new System.EventHandler(this.buttonBrowseIn_Click);
            // 
            // buttonBrowseOut
            // 
            this.buttonBrowseOut.Location = new System.Drawing.Point(514, 73);
            this.buttonBrowseOut.Name = "buttonBrowseOut";
            this.buttonBrowseOut.Size = new System.Drawing.Size(75, 25);
            this.buttonBrowseOut.TabIndex = 7;
            this.buttonBrowseOut.Text = "Обзор";
            this.buttonBrowseOut.UseVisualStyleBackColor = true;
            this.buttonBrowseOut.Click += new System.EventHandler(this.buttonBrowseOut_Click);
            // 
            // textBoxIn
            // 
            this.textBoxIn.Location = new System.Drawing.Point(95, 4);
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.ReadOnly = true;
            this.textBoxIn.Size = new System.Drawing.Size(413, 23);
            this.textBoxIn.TabIndex = 1;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageFile);
            this.tabControlMain.Controls.Add(this.tabPageVideo);
            this.tabControlMain.Controls.Add(this.tabPagePicture);
            this.tabControlMain.Controls.Add(this.tabPageFilters);
            this.tabControlMain.Controls.Add(this.tabPageAudio);
            this.tabControlMain.Controls.Add(this.tabPageTags);
            this.tabControlMain.Location = new System.Drawing.Point(6, 6);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(612, 211);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageFilters
            // 
            this.tabPageFilters.Controls.Add(this.panelSubtitles);
            this.tabPageFilters.Controls.Add(this.panelColorFilter);
            this.tabPageFilters.Controls.Add(this.panelDeinterlace);
            this.tabPageFilters.Location = new System.Drawing.Point(4, 24);
            this.tabPageFilters.Name = "tabPageFilters";
            this.tabPageFilters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFilters.Size = new System.Drawing.Size(604, 183);
            this.tabPageFilters.TabIndex = 5;
            this.tabPageFilters.Text = "Фильтры";
            this.tabPageFilters.UseVisualStyleBackColor = true;
            // 
            // panelSubtitles
            // 
            this.panelSubtitles.Controls.Add(this.labelSubtitles);
            this.panelSubtitles.Controls.Add(this.buttonBrowseSubtitles);
            this.panelSubtitles.Controls.Add(this.textBoxSubtitlesPath);
            this.panelSubtitles.Location = new System.Drawing.Point(6, 119);
            this.panelSubtitles.Name = "panelSubtitles";
            this.panelSubtitles.Size = new System.Drawing.Size(592, 58);
            this.panelSubtitles.TabIndex = 4;
            // 
            // labelSubtitles
            // 
            this.labelSubtitles.AutoSize = true;
            this.labelSubtitles.Location = new System.Drawing.Point(3, 8);
            this.labelSubtitles.Name = "labelSubtitles";
            this.labelSubtitles.Size = new System.Drawing.Size(61, 15);
            this.labelSubtitles.TabIndex = 2;
            this.labelSubtitles.Text = "Субтитры";
            // 
            // buttonBrowseSubtitles
            // 
            this.buttonBrowseSubtitles.Location = new System.Drawing.Point(514, 3);
            this.buttonBrowseSubtitles.Name = "buttonBrowseSubtitles";
            this.buttonBrowseSubtitles.Size = new System.Drawing.Size(75, 25);
            this.buttonBrowseSubtitles.TabIndex = 1;
            this.buttonBrowseSubtitles.Text = "Обзор";
            this.buttonBrowseSubtitles.UseVisualStyleBackColor = true;
            this.buttonBrowseSubtitles.Click += new System.EventHandler(this.buttonBrowseSubtitles_Click);
            // 
            // textBoxSubtitlesPath
            // 
            this.textBoxSubtitlesPath.Location = new System.Drawing.Point(113, 4);
            this.textBoxSubtitlesPath.Name = "textBoxSubtitlesPath";
            this.textBoxSubtitlesPath.Size = new System.Drawing.Size(395, 23);
            this.textBoxSubtitlesPath.TabIndex = 0;
            // 
            // panelColorFilter
            // 
            this.panelColorFilter.Controls.Add(this.labelColorFilter);
            this.panelColorFilter.Controls.Add(this.comboBoxColorFilter);
            this.panelColorFilter.Location = new System.Drawing.Point(6, 74);
            this.panelColorFilter.Name = "panelColorFilter";
            this.panelColorFilter.Size = new System.Drawing.Size(293, 39);
            this.panelColorFilter.TabIndex = 3;
            // 
            // labelColorFilter
            // 
            this.labelColorFilter.AutoSize = true;
            this.labelColorFilter.Location = new System.Drawing.Point(3, 6);
            this.labelColorFilter.Name = "labelColorFilter";
            this.labelColorFilter.Size = new System.Drawing.Size(104, 15);
            this.labelColorFilter.TabIndex = 0;
            this.labelColorFilter.Text = "Цветовой фильтр";
            // 
            // comboBoxColorFilter
            // 
            this.comboBoxColorFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColorFilter.FormattingEnabled = true;
            this.comboBoxColorFilter.Location = new System.Drawing.Point(113, 3);
            this.comboBoxColorFilter.Name = "comboBoxColorFilter";
            this.comboBoxColorFilter.Size = new System.Drawing.Size(120, 23);
            this.comboBoxColorFilter.TabIndex = 1;
            this.comboBoxColorFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxColorFilter_SelectedIndexChanged);
            // 
            // panelDeinterlace
            // 
            this.panelDeinterlace.Controls.Add(this.labelFieldOrder);
            this.panelDeinterlace.Controls.Add(this.checkBoxDeinterlace);
            this.panelDeinterlace.Controls.Add(this.comboBoxFieldOrder);
            this.panelDeinterlace.Location = new System.Drawing.Point(6, 6);
            this.panelDeinterlace.Name = "panelDeinterlace";
            this.panelDeinterlace.Size = new System.Drawing.Size(293, 62);
            this.panelDeinterlace.TabIndex = 2;
            // 
            // labelFieldOrder
            // 
            this.labelFieldOrder.AutoSize = true;
            this.labelFieldOrder.Location = new System.Drawing.Point(3, 29);
            this.labelFieldOrder.Name = "labelFieldOrder";
            this.labelFieldOrder.Size = new System.Drawing.Size(92, 15);
            this.labelFieldOrder.TabIndex = 1;
            this.labelFieldOrder.Text = "Порядок полей";
            // 
            // checkBoxDeinterlace
            // 
            this.checkBoxDeinterlace.AutoSize = true;
            this.checkBoxDeinterlace.Location = new System.Drawing.Point(6, 3);
            this.checkBoxDeinterlace.Name = "checkBoxDeinterlace";
            this.checkBoxDeinterlace.Size = new System.Drawing.Size(117, 19);
            this.checkBoxDeinterlace.TabIndex = 0;
            this.checkBoxDeinterlace.Text = "Деинтерлейсинг";
            this.checkBoxDeinterlace.UseVisualStyleBackColor = true;
            this.checkBoxDeinterlace.CheckedChanged += new System.EventHandler(this.checkBoxDeinterlace_CheckedChanged);
            // 
            // comboBoxFieldOrder
            // 
            this.comboBoxFieldOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFieldOrder.FormattingEnabled = true;
            this.comboBoxFieldOrder.Location = new System.Drawing.Point(113, 26);
            this.comboBoxFieldOrder.Name = "comboBoxFieldOrder";
            this.comboBoxFieldOrder.Size = new System.Drawing.Size(120, 23);
            this.comboBoxFieldOrder.TabIndex = 2;
            this.comboBoxFieldOrder.SelectedIndexChanged += new System.EventHandler(this.comboBoxFieldOrder_SelectedIndexChanged);
            // 
            // labelOutputInfo
            // 
            this.labelOutputInfo.AutoSize = true;
            this.labelOutputInfo.Location = new System.Drawing.Point(60, 223);
            this.labelOutputInfo.Name = "labelOutputInfo";
            this.labelOutputInfo.Size = new System.Drawing.Size(16, 15);
            this.labelOutputInfo.TabIndex = 2;
            this.labelOutputInfo.Text = "...";
            // 
            // labelOutputInfoTitle
            // 
            this.labelOutputInfoTitle.AutoSize = true;
            this.labelOutputInfoTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOutputInfoTitle.Location = new System.Drawing.Point(7, 223);
            this.labelOutputInfoTitle.Name = "labelOutputInfoTitle";
            this.labelOutputInfoTitle.Size = new System.Drawing.Size(47, 30);
            this.labelOutputInfoTitle.TabIndex = 1;
            this.labelOutputInfoTitle.Text = "Видео:\r\nАудио:";
            // 
            // labelPreset
            // 
            this.labelPreset.AutoSize = true;
            this.labelPreset.Location = new System.Drawing.Point(393, 42);
            this.labelPreset.Name = "labelPreset";
            this.labelPreset.Size = new System.Drawing.Size(46, 15);
            this.labelPreset.TabIndex = 4;
            this.labelPreset.Text = "Пресет";
            // 
            // comboBoxPreset
            // 
            this.comboBoxPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPreset.FormattingEnabled = true;
            this.comboBoxPreset.Location = new System.Drawing.Point(488, 39);
            this.comboBoxPreset.Name = "comboBoxPreset";
            this.comboBoxPreset.Size = new System.Drawing.Size(80, 23);
            this.comboBoxPreset.TabIndex = 5;
            this.comboBoxPreset.SelectedIndexChanged += new System.EventHandler(this.comboBoxPreset_SelectedIndexChanged);
            // 
            // checkBoxConvertVideo
            // 
            this.checkBoxConvertVideo.AutoSize = true;
            this.checkBoxConvertVideo.Location = new System.Drawing.Point(6, 6);
            this.checkBoxConvertVideo.Name = "checkBoxConvertVideo";
            this.checkBoxConvertVideo.Size = new System.Drawing.Size(142, 19);
            this.checkBoxConvertVideo.TabIndex = 10;
            this.checkBoxConvertVideo.Text = "Переконвертировать";
            this.checkBoxConvertVideo.UseVisualStyleBackColor = true;
            this.checkBoxConvertVideo.CheckedChanged += new System.EventHandler(this.checkBoxConvertVideo_CheckedChanged);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(624, 261);
            this.Controls.Add(this.labelOutputInfoTitle);
            this.Controls.Add(this.labelOutputInfo);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.buttonGo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Simple Video Converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.tabPageTags.ResumeLayout(false);
            this.tabPageTags.PerformLayout();
            this.tabPageAudio.ResumeLayout(false);
            this.panelAudioParams.ResumeLayout(false);
            this.panelAudioParams.PerformLayout();
            this.panelAudioStreams.ResumeLayout(false);
            this.panelAudioStreams.PerformLayout();
            this.tabPageVideo.ResumeLayout(false);
            this.tabPageVideo.PerformLayout();
            this.panelVideo.ResumeLayout(false);
            this.panelVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarCRF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBitrate)).EndInit();
            this.tabPagePicture.ResumeLayout(false);
            this.panelResize.ResumeLayout(false);
            this.panelResize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRatioError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            this.tabPageFile.ResumeLayout(false);
            this.panelFile.ResumeLayout(false);
            this.panelFile.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.tabPageFilters.ResumeLayout(false);
            this.panelSubtitles.ResumeLayout(false);
            this.panelSubtitles.PerformLayout();
            this.panelColorFilter.ResumeLayout(false);
            this.panelColorFilter.PerformLayout();
            this.panelDeinterlace.ResumeLayout(false);
            this.panelDeinterlace.PerformLayout();
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
        private System.Windows.Forms.Label labelAudioBitrate;
        private System.Windows.Forms.Label labelChannels;
        private System.Windows.Forms.Label labelFrequency;
        private System.Windows.Forms.TabPage tabPageVideo;
        private System.Windows.Forms.Panel panelVideo;
        private System.Windows.Forms.Label labelCalcSize;
        private System.Windows.Forms.Label labelCalcSizeText;
        private System.Windows.Forms.Label labelVideoKbps;
        private System.Windows.Forms.Label labelMinQ;
        private System.Windows.Forms.Label labelMaxQ;
        private System.Windows.Forms.Label labelCRF;
        private System.Windows.Forms.Label labelFrameRate;
        private System.Windows.Forms.TabPage tabPagePicture;
        private System.Windows.Forms.Label labelInterpolation;
        private System.Windows.Forms.Button buttonCrop;
        private System.Windows.Forms.Label labelCropSize;
        private System.Windows.Forms.TabPage tabPageFile;
        private System.Windows.Forms.Panel panelFile;
        private System.Windows.Forms.Button buttonOpenInputFile;
        private System.Windows.Forms.Label labelOut;
        private System.Windows.Forms.Label labelInputFile;
        private System.Windows.Forms.Button buttonShowInfo;
        private System.Windows.Forms.CheckBox checkBoxKeepOutPath;
        private System.Windows.Forms.Button buttonBrowseIn;
        private System.Windows.Forms.Button buttonBrowseOut;
        private System.Windows.Forms.TextBox textBoxIn;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.Label labelOutputInfo;
        private System.Windows.Forms.Label labelOutputInfoTitle;
        private System.Windows.Forms.Label labelSelectAudioStream;
        private System.Windows.Forms.Panel panelAudioParams;
        private System.Windows.Forms.CheckBox checkBoxWebOptimized;
        private System.Windows.Forms.TabPage tabPageTags;
        private System.Windows.Forms.TextBox textBoxTagCreationTime;
        private System.Windows.Forms.Label labelTagCreationTime;
        private System.Windows.Forms.TextBox textBoxTagTitle;
        private System.Windows.Forms.Label labelTagTitle;
        private System.Windows.Forms.Label labelTagComment;
        private System.Windows.Forms.TextBox textBoxTagComment;
        private System.Windows.Forms.TextBox textBoxTagAuthor;
        private System.Windows.Forms.Label labelTagAuthor;
        private System.Windows.Forms.Label labelTagCopyright;
        private System.Windows.Forms.TextBox textBoxTagCopyright;
        private System.Windows.Forms.Label labelAudioCodec;
        private System.Windows.Forms.Label labelVideoCodec;
        private System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.ComboBox comboBoxAudioChannels;
        private System.Windows.Forms.ComboBox comboBoxAudioBitrate;
        private System.Windows.Forms.ComboBox comboBoxAudioSampleRate;
        private System.Windows.Forms.ComboBox comboBoxAudioCodec;
        private System.Windows.Forms.RadioButton radioButtonBitrate;
        private System.Windows.Forms.RadioButton radioButtonCRF;
        private System.Windows.Forms.TrackBar trackBarCRF;
        private System.Windows.Forms.NumericUpDown numericUpDownBitrate;
        private System.Windows.Forms.ComboBox comboBoxFrameRate;
        private System.Windows.Forms.ComboBox comboBoxInterpolation;
        private System.Windows.Forms.CheckBox checkBoxConvertAudio;
        private System.Windows.Forms.ComboBox comboBoxVideoCodec;
        private System.Windows.Forms.ComboBox comboBoxAudioStreams;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.ComboBox comboBoxAspectRatio;
        private System.Windows.Forms.PictureBox pictureBoxRatioError;
        private System.Windows.Forms.CheckBox checkBoxKeepAspectRatio;
        private System.Windows.Forms.Panel panelResize;
        private System.Windows.Forms.Button buttonPresetOriginal;
        private System.Windows.Forms.Button buttonPreset720p;
        private System.Windows.Forms.Button buttonPreset1080p;
        private System.Windows.Forms.Label labelSizePreset;
        private System.Windows.Forms.CheckBox checkBoxFlip;
        private System.Windows.Forms.ComboBox comboBoxRotate;
        private System.Windows.Forms.Label labelRotate;
        private System.Windows.Forms.Label labelPictureSize;
        private System.Windows.Forms.TabPage tabPageFilters;
        private System.Windows.Forms.Panel panelDeinterlace;
        private System.Windows.Forms.Label labelFieldOrder;
        private System.Windows.Forms.CheckBox checkBoxDeinterlace;
        private System.Windows.Forms.ComboBox comboBoxFieldOrder;
        private System.Windows.Forms.Panel panelColorFilter;
        private System.Windows.Forms.Label labelColorFilter;
        private System.Windows.Forms.ComboBox comboBoxColorFilter;
        private System.Windows.Forms.Button buttonPreset480p;
        private System.Windows.Forms.Label labelCrop;
        private System.Windows.Forms.Panel panelSubtitles;
        private System.Windows.Forms.Label labelSubtitles;
        private System.Windows.Forms.Button buttonBrowseSubtitles;
        private System.Windows.Forms.TextBox textBoxSubtitlesPath;
        private System.Windows.Forms.Button buttonDateHelp;
        private System.Windows.Forms.ComboBox comboBoxPreset;
        private System.Windows.Forms.Label labelPreset;
        private System.Windows.Forms.CheckBox checkBoxConvertVideo;
    }
}


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
            this.checkBoxConvertVideo = new System.Windows.Forms.CheckBox();
            this.panelVideo = new System.Windows.Forms.Panel();
            this.checkBoxCustomX265 = new System.Windows.Forms.CheckBox();
            this.comboBoxPreset = new System.Windows.Forms.ComboBox();
            this.labelCalcSize = new System.Windows.Forms.Label();
            this.labelPreset = new System.Windows.Forms.Label();
            this.labelCalcSizeText = new System.Windows.Forms.Label();
            this.labelVideoCodec = new System.Windows.Forms.Label();
            this.comboBoxVideoCodec = new System.Windows.Forms.ComboBox();
            this.labelVideoKbps = new System.Windows.Forms.Label();
            this.labelFrameRate = new System.Windows.Forms.Label();
            this.labelMinQ = new System.Windows.Forms.Label();
            this.comboBoxFrameRate = new System.Windows.Forms.ComboBox();
            this.labelMaxQ = new System.Windows.Forms.Label();
            this.labelCRF = new System.Windows.Forms.Label();
            this.radioButtonBitrate = new System.Windows.Forms.RadioButton();
            this.radioButtonCRF = new System.Windows.Forms.RadioButton();
            this.trackBarCRF = new System.Windows.Forms.TrackBar();
            this.numericUpDownBitrate = new System.Windows.Forms.NumericUpDown();
            this.tabPagePicture = new System.Windows.Forms.TabPage();
            this.panelResize = new System.Windows.Forms.Panel();
            this.numericCropRight = new System.Windows.Forms.NumericUpDown();
            this.numericCropLeft = new System.Windows.Forms.NumericUpDown();
            this.numericCropBottom = new System.Windows.Forms.NumericUpDown();
            this.numericCropTop = new System.Windows.Forms.NumericUpDown();
            this.labelCrop = new System.Windows.Forms.Label();
            this.checkBoxFlip = new System.Windows.Forms.CheckBox();
            this.buttonCropReset = new System.Windows.Forms.Button();
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
            this.buttonPreview = new System.Windows.Forms.Button();
            this.labelOutputInfo = new System.Windows.Forms.Label();
            this.labelOutputInfoTitle = new System.Windows.Forms.Label();
            this.buttonCopyToClipboard = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.numericCropRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropTop)).BeginInit();
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
            this.buttonGo.Location = new System.Drawing.Point(732, 334);
            this.buttonGo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(195, 48);
            this.buttonGo.TabIndex = 3;
            this.buttonGo.Text = "Конвертировать";
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // buttonShowInfo
            // 
            this.buttonShowInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonShowInfo.Location = new System.Drawing.Point(142, 50);
            this.buttonShowInfo.Margin = new System.Windows.Forms.Padding(4);
            this.buttonShowInfo.Name = "buttonShowInfo";
            this.buttonShowInfo.Size = new System.Drawing.Size(112, 38);
            this.buttonShowInfo.TabIndex = 3;
            this.buttonShowInfo.Text = "Инфо";
            this.toolTipHint.SetToolTip(this.buttonShowInfo, "Показать информацию об исходном файле");
            this.buttonShowInfo.UseVisualStyleBackColor = true;
            this.buttonShowInfo.Click += new System.EventHandler(this.buttonShowInfo_Click);
            // 
            // buttonOpenInputFile
            // 
            this.buttonOpenInputFile.Location = new System.Drawing.Point(264, 50);
            this.buttonOpenInputFile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenInputFile.Name = "buttonOpenInputFile";
            this.buttonOpenInputFile.Size = new System.Drawing.Size(112, 38);
            this.buttonOpenInputFile.TabIndex = 4;
            this.buttonOpenInputFile.Text = "Открыть";
            this.toolTipHint.SetToolTip(this.buttonOpenInputFile, "Открыть исходный файл в проигрывателе по умолчанию");
            this.buttonOpenInputFile.UseVisualStyleBackColor = true;
            this.buttonOpenInputFile.Click += new System.EventHandler(this.buttonOpenInputFile_Click);
            // 
            // checkBoxWebOptimized
            // 
            this.checkBoxWebOptimized.AutoSize = true;
            this.checkBoxWebOptimized.Location = new System.Drawing.Point(142, 220);
            this.checkBoxWebOptimized.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxWebOptimized.Name = "checkBoxWebOptimized";
            this.checkBoxWebOptimized.Size = new System.Drawing.Size(211, 29);
            this.checkBoxWebOptimized.TabIndex = 9;
            this.checkBoxWebOptimized.Text = "Web-оптимизирован";
            this.toolTipHint.SetToolTip(this.checkBoxWebOptimized, "Служебная информация будет перенесена в начало файла для быстрого старта воспроиз" +
        "ведения в браузерах");
            this.checkBoxWebOptimized.UseVisualStyleBackColor = true;
            // 
            // buttonPreset1080p
            // 
            this.buttonPreset1080p.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPreset1080p.Location = new System.Drawing.Point(213, 117);
            this.buttonPreset1080p.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPreset1080p.Name = "buttonPreset1080p";
            this.buttonPreset1080p.Size = new System.Drawing.Size(68, 32);
            this.buttonPreset1080p.TabIndex = 14;
            this.buttonPreset1080p.Text = "1080p";
            this.toolTipHint.SetToolTip(this.buttonPreset1080p, "Вписать в 1920x1080");
            this.buttonPreset1080p.UseVisualStyleBackColor = true;
            this.buttonPreset1080p.Click += new System.EventHandler(this.buttonPreset1080p_Click);
            // 
            // buttonPreset720p
            // 
            this.buttonPreset720p.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPreset720p.Location = new System.Drawing.Point(290, 117);
            this.buttonPreset720p.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPreset720p.Name = "buttonPreset720p";
            this.buttonPreset720p.Size = new System.Drawing.Size(68, 32);
            this.buttonPreset720p.TabIndex = 15;
            this.buttonPreset720p.Text = "720p";
            this.toolTipHint.SetToolTip(this.buttonPreset720p, "Вписать в 1280x720");
            this.buttonPreset720p.UseVisualStyleBackColor = true;
            this.buttonPreset720p.Click += new System.EventHandler(this.buttonPreset720p_Click);
            // 
            // buttonPresetOriginal
            // 
            this.buttonPresetOriginal.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPresetOriginal.Location = new System.Drawing.Point(442, 117);
            this.buttonPresetOriginal.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPresetOriginal.Name = "buttonPresetOriginal";
            this.buttonPresetOriginal.Size = new System.Drawing.Size(90, 32);
            this.buttonPresetOriginal.TabIndex = 17;
            this.buttonPresetOriginal.Text = "Сбросить";
            this.toolTipHint.SetToolTip(this.buttonPresetOriginal, "Задать исходный размер");
            this.buttonPresetOriginal.UseVisualStyleBackColor = true;
            this.buttonPresetOriginal.Click += new System.EventHandler(this.buttonPresetOriginal_Click);
            // 
            // buttonPreset480p
            // 
            this.buttonPreset480p.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonPreset480p.Location = new System.Drawing.Point(366, 117);
            this.buttonPreset480p.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPreset480p.Name = "buttonPreset480p";
            this.buttonPreset480p.Size = new System.Drawing.Size(68, 32);
            this.buttonPreset480p.TabIndex = 16;
            this.buttonPreset480p.Text = "480p";
            this.toolTipHint.SetToolTip(this.buttonPreset480p, "Вписать в 640x480");
            this.buttonPreset480p.UseVisualStyleBackColor = true;
            this.buttonPreset480p.Click += new System.EventHandler(this.buttonPreset480p_Click);
            // 
            // textBoxTagCreationTime
            // 
            this.textBoxTagCreationTime.Location = new System.Drawing.Point(206, 176);
            this.textBoxTagCreationTime.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTagCreationTime.Name = "textBoxTagCreationTime";
            this.textBoxTagCreationTime.Size = new System.Drawing.Size(268, 31);
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
            this.tabPageTags.Location = new System.Drawing.Point(4, 34);
            this.tabPageTags.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageTags.Name = "tabPageTags";
            this.tabPageTags.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageTags.Size = new System.Drawing.Size(910, 278);
            this.tabPageTags.TabIndex = 4;
            this.tabPageTags.Text = "Теги";
            this.tabPageTags.UseVisualStyleBackColor = true;
            // 
            // buttonDateHelp
            // 
            this.buttonDateHelp.Location = new System.Drawing.Point(484, 174);
            this.buttonDateHelp.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDateHelp.Name = "buttonDateHelp";
            this.buttonDateHelp.Size = new System.Drawing.Size(38, 38);
            this.buttonDateHelp.TabIndex = 10;
            this.buttonDateHelp.Text = "?";
            this.buttonDateHelp.UseVisualStyleBackColor = true;
            this.buttonDateHelp.Click += new System.EventHandler(this.buttonDateHelp_Click);
            // 
            // labelTagCopyright
            // 
            this.labelTagCopyright.AutoSize = true;
            this.labelTagCopyright.Location = new System.Drawing.Point(9, 99);
            this.labelTagCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTagCopyright.Name = "labelTagCopyright";
            this.labelTagCopyright.Size = new System.Drawing.Size(90, 25);
            this.labelTagCopyright.TabIndex = 4;
            this.labelTagCopyright.Text = "Копирайт";
            // 
            // textBoxTagCopyright
            // 
            this.textBoxTagCopyright.Location = new System.Drawing.Point(206, 94);
            this.textBoxTagCopyright.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTagCopyright.Name = "textBoxTagCopyright";
            this.textBoxTagCopyright.Size = new System.Drawing.Size(690, 31);
            this.textBoxTagCopyright.TabIndex = 5;
            this.textBoxTagCopyright.TextChanged += new System.EventHandler(this.textBoxTagCopyright_TextChanged);
            // 
            // labelTagAuthor
            // 
            this.labelTagAuthor.AutoSize = true;
            this.labelTagAuthor.Location = new System.Drawing.Point(9, 57);
            this.labelTagAuthor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTagAuthor.Name = "labelTagAuthor";
            this.labelTagAuthor.Size = new System.Drawing.Size(183, 25);
            this.labelTagAuthor.TabIndex = 2;
            this.labelTagAuthor.Text = "Автор (Исполнитель)";
            // 
            // textBoxTagAuthor
            // 
            this.textBoxTagAuthor.Location = new System.Drawing.Point(206, 52);
            this.textBoxTagAuthor.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTagAuthor.Name = "textBoxTagAuthor";
            this.textBoxTagAuthor.Size = new System.Drawing.Size(690, 31);
            this.textBoxTagAuthor.TabIndex = 3;
            this.textBoxTagAuthor.TextChanged += new System.EventHandler(this.textBoxTagAuthor_TextChanged);
            // 
            // labelTagComment
            // 
            this.labelTagComment.AutoSize = true;
            this.labelTagComment.Location = new System.Drawing.Point(9, 140);
            this.labelTagComment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTagComment.Name = "labelTagComment";
            this.labelTagComment.Size = new System.Drawing.Size(125, 25);
            this.labelTagComment.TabIndex = 6;
            this.labelTagComment.Text = "Комментарий";
            // 
            // textBoxTagComment
            // 
            this.textBoxTagComment.Location = new System.Drawing.Point(206, 135);
            this.textBoxTagComment.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTagComment.Name = "textBoxTagComment";
            this.textBoxTagComment.Size = new System.Drawing.Size(690, 31);
            this.textBoxTagComment.TabIndex = 7;
            this.textBoxTagComment.TextChanged += new System.EventHandler(this.textBoxTagComment_TextChanged);
            // 
            // labelTagCreationTime
            // 
            this.labelTagCreationTime.AutoSize = true;
            this.labelTagCreationTime.Location = new System.Drawing.Point(9, 180);
            this.labelTagCreationTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTagCreationTime.Name = "labelTagCreationTime";
            this.labelTagCreationTime.Size = new System.Drawing.Size(129, 25);
            this.labelTagCreationTime.TabIndex = 8;
            this.labelTagCreationTime.Text = "Дата создания";
            // 
            // textBoxTagTitle
            // 
            this.textBoxTagTitle.Location = new System.Drawing.Point(206, 10);
            this.textBoxTagTitle.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTagTitle.Name = "textBoxTagTitle";
            this.textBoxTagTitle.Size = new System.Drawing.Size(690, 31);
            this.textBoxTagTitle.TabIndex = 1;
            this.textBoxTagTitle.TextChanged += new System.EventHandler(this.textBoxTagTitle_TextChanged);
            // 
            // labelTagTitle
            // 
            this.labelTagTitle.AutoSize = true;
            this.labelTagTitle.Location = new System.Drawing.Point(9, 15);
            this.labelTagTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTagTitle.Name = "labelTagTitle";
            this.labelTagTitle.Size = new System.Drawing.Size(99, 25);
            this.labelTagTitle.TabIndex = 0;
            this.labelTagTitle.Text = "Заголовок";
            // 
            // tabPageAudio
            // 
            this.tabPageAudio.Controls.Add(this.panelAudioParams);
            this.tabPageAudio.Controls.Add(this.panelAudioStreams);
            this.tabPageAudio.Location = new System.Drawing.Point(4, 34);
            this.tabPageAudio.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageAudio.Name = "tabPageAudio";
            this.tabPageAudio.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageAudio.Size = new System.Drawing.Size(910, 278);
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
            this.panelAudioParams.Location = new System.Drawing.Point(9, 76);
            this.panelAudioParams.Margin = new System.Windows.Forms.Padding(4);
            this.panelAudioParams.Name = "panelAudioParams";
            this.panelAudioParams.Size = new System.Drawing.Size(888, 189);
            this.panelAudioParams.TabIndex = 1;
            // 
            // labelAudioCodec
            // 
            this.labelAudioCodec.AutoSize = true;
            this.labelAudioCodec.Location = new System.Drawing.Point(4, 52);
            this.labelAudioCodec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAudioCodec.Name = "labelAudioCodec";
            this.labelAudioCodec.Size = new System.Drawing.Size(61, 25);
            this.labelAudioCodec.TabIndex = 10;
            this.labelAudioCodec.Text = "Кодек";
            // 
            // comboBoxAudioCodec
            // 
            this.comboBoxAudioCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudioCodec.FormattingEnabled = true;
            this.comboBoxAudioCodec.Location = new System.Drawing.Point(116, 48);
            this.comboBoxAudioCodec.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAudioCodec.Name = "comboBoxAudioCodec";
            this.comboBoxAudioCodec.Size = new System.Drawing.Size(118, 33);
            this.comboBoxAudioCodec.TabIndex = 9;
            this.comboBoxAudioCodec.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioCodec_SelectedIndexChanged);
            // 
            // checkBoxConvertAudio
            // 
            this.checkBoxConvertAudio.AutoSize = true;
            this.checkBoxConvertAudio.Location = new System.Drawing.Point(9, 4);
            this.checkBoxConvertAudio.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxConvertAudio.Name = "checkBoxConvertAudio";
            this.checkBoxConvertAudio.Size = new System.Drawing.Size(214, 29);
            this.checkBoxConvertAudio.TabIndex = 0;
            this.checkBoxConvertAudio.Text = "Переконвертировать";
            this.checkBoxConvertAudio.UseVisualStyleBackColor = true;
            this.checkBoxConvertAudio.CheckedChanged += new System.EventHandler(this.checkBoxConvertAudio_CheckedChanged);
            // 
            // comboBoxAudioBitrate
            // 
            this.comboBoxAudioBitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudioBitrate.FormattingEnabled = true;
            this.comboBoxAudioBitrate.Location = new System.Drawing.Point(426, 48);
            this.comboBoxAudioBitrate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAudioBitrate.Name = "comboBoxAudioBitrate";
            this.comboBoxAudioBitrate.Size = new System.Drawing.Size(118, 33);
            this.comboBoxAudioBitrate.TabIndex = 2;
            this.comboBoxAudioBitrate.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioBitrate_SelectedIndexChanged);
            // 
            // labelAudioHz
            // 
            this.labelAudioHz.AutoSize = true;
            this.labelAudioHz.Location = new System.Drawing.Point(244, 134);
            this.labelAudioHz.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAudioHz.Name = "labelAudioHz";
            this.labelAudioHz.Size = new System.Drawing.Size(31, 25);
            this.labelAudioHz.TabIndex = 6;
            this.labelAudioHz.Text = "Гц";
            // 
            // labelChannels
            // 
            this.labelChannels.AutoSize = true;
            this.labelChannels.Location = new System.Drawing.Point(315, 134);
            this.labelChannels.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChannels.Name = "labelChannels";
            this.labelChannels.Size = new System.Drawing.Size(72, 25);
            this.labelChannels.TabIndex = 7;
            this.labelChannels.Text = "Каналы";
            // 
            // labelFrequency
            // 
            this.labelFrequency.AutoSize = true;
            this.labelFrequency.Location = new System.Drawing.Point(4, 134);
            this.labelFrequency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFrequency.Name = "labelFrequency";
            this.labelFrequency.Size = new System.Drawing.Size(75, 25);
            this.labelFrequency.TabIndex = 4;
            this.labelFrequency.Text = "Частота";
            // 
            // labelAudioKbps
            // 
            this.labelAudioKbps.AutoSize = true;
            this.labelAudioKbps.Location = new System.Drawing.Point(555, 52);
            this.labelAudioKbps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAudioKbps.Name = "labelAudioKbps";
            this.labelAudioKbps.Size = new System.Drawing.Size(63, 25);
            this.labelAudioKbps.TabIndex = 3;
            this.labelAudioKbps.Text = "кбит/с";
            // 
            // comboBoxAudioSampleRate
            // 
            this.comboBoxAudioSampleRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudioSampleRate.FormattingEnabled = true;
            this.comboBoxAudioSampleRate.Location = new System.Drawing.Point(116, 129);
            this.comboBoxAudioSampleRate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAudioSampleRate.Name = "comboBoxAudioSampleRate";
            this.comboBoxAudioSampleRate.Size = new System.Drawing.Size(118, 33);
            this.comboBoxAudioSampleRate.TabIndex = 5;
            this.comboBoxAudioSampleRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioSampleRate_SelectedIndexChanged);
            // 
            // comboBoxAudioChannels
            // 
            this.comboBoxAudioChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudioChannels.FormattingEnabled = true;
            this.comboBoxAudioChannels.Location = new System.Drawing.Point(426, 129);
            this.comboBoxAudioChannels.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAudioChannels.Name = "comboBoxAudioChannels";
            this.comboBoxAudioChannels.Size = new System.Drawing.Size(118, 33);
            this.comboBoxAudioChannels.TabIndex = 8;
            this.comboBoxAudioChannels.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioChannels_SelectedIndexChanged);
            // 
            // labelAudioBitrate
            // 
            this.labelAudioBitrate.AutoSize = true;
            this.labelAudioBitrate.Location = new System.Drawing.Point(315, 52);
            this.labelAudioBitrate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAudioBitrate.Name = "labelAudioBitrate";
            this.labelAudioBitrate.Size = new System.Drawing.Size(76, 25);
            this.labelAudioBitrate.TabIndex = 1;
            this.labelAudioBitrate.Text = "Битрейт";
            // 
            // panelAudioStreams
            // 
            this.panelAudioStreams.Controls.Add(this.comboBoxAudioStreams);
            this.panelAudioStreams.Controls.Add(this.labelSelectAudioStream);
            this.panelAudioStreams.Location = new System.Drawing.Point(9, 9);
            this.panelAudioStreams.Margin = new System.Windows.Forms.Padding(4);
            this.panelAudioStreams.Name = "panelAudioStreams";
            this.panelAudioStreams.Size = new System.Drawing.Size(546, 58);
            this.panelAudioStreams.TabIndex = 0;
            // 
            // comboBoxAudioStreams
            // 
            this.comboBoxAudioStreams.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAudioStreams.FormattingEnabled = true;
            this.comboBoxAudioStreams.Location = new System.Drawing.Point(116, 4);
            this.comboBoxAudioStreams.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAudioStreams.Name = "comboBoxAudioStreams";
            this.comboBoxAudioStreams.Size = new System.Drawing.Size(328, 33);
            this.comboBoxAudioStreams.TabIndex = 1;
            this.comboBoxAudioStreams.SelectedIndexChanged += new System.EventHandler(this.comboBoxAudioStreams_SelectedIndexChanged);
            // 
            // labelSelectAudioStream
            // 
            this.labelSelectAudioStream.AutoSize = true;
            this.labelSelectAudioStream.Location = new System.Drawing.Point(4, 9);
            this.labelSelectAudioStream.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSelectAudioStream.Name = "labelSelectAudioStream";
            this.labelSelectAudioStream.Size = new System.Drawing.Size(88, 25);
            this.labelSelectAudioStream.TabIndex = 0;
            this.labelSelectAudioStream.Text = "Дорожка";
            // 
            // tabPageVideo
            // 
            this.tabPageVideo.Controls.Add(this.checkBoxConvertVideo);
            this.tabPageVideo.Controls.Add(this.panelVideo);
            this.tabPageVideo.Location = new System.Drawing.Point(4, 34);
            this.tabPageVideo.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageVideo.Name = "tabPageVideo";
            this.tabPageVideo.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageVideo.Size = new System.Drawing.Size(910, 278);
            this.tabPageVideo.TabIndex = 0;
            this.tabPageVideo.Text = "Видео";
            this.tabPageVideo.UseVisualStyleBackColor = true;
            // 
            // checkBoxConvertVideo
            // 
            this.checkBoxConvertVideo.AutoSize = true;
            this.checkBoxConvertVideo.Location = new System.Drawing.Point(9, 9);
            this.checkBoxConvertVideo.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxConvertVideo.Name = "checkBoxConvertVideo";
            this.checkBoxConvertVideo.Size = new System.Drawing.Size(214, 29);
            this.checkBoxConvertVideo.TabIndex = 10;
            this.checkBoxConvertVideo.Text = "Переконвертировать";
            this.checkBoxConvertVideo.UseVisualStyleBackColor = true;
            this.checkBoxConvertVideo.CheckedChanged += new System.EventHandler(this.checkBoxConvertVideo_CheckedChanged);
            // 
            // panelVideo
            // 
            this.panelVideo.Controls.Add(this.checkBoxCustomX265);
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
            this.panelVideo.Location = new System.Drawing.Point(9, 46);
            this.panelVideo.Margin = new System.Windows.Forms.Padding(4);
            this.panelVideo.Name = "panelVideo";
            this.panelVideo.Size = new System.Drawing.Size(888, 222);
            this.panelVideo.TabIndex = 0;
            // 
            // checkBoxCustomX265
            // 
            this.checkBoxCustomX265.AutoSize = true;
            this.checkBoxCustomX265.Checked = true;
            this.checkBoxCustomX265.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCustomX265.Location = new System.Drawing.Point(594, 102);
            this.checkBoxCustomX265.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxCustomX265.Name = "checkBoxCustomX265";
            this.checkBoxCustomX265.Size = new System.Drawing.Size(237, 29);
            this.checkBoxCustomX265.TabIndex = 10;
            this.checkBoxCustomX265.Text = "Отключить SAO и cutree";
            this.checkBoxCustomX265.UseVisualStyleBackColor = true;
            // 
            // comboBoxPreset
            // 
            this.comboBoxPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPreset.FormattingEnabled = true;
            this.comboBoxPreset.Location = new System.Drawing.Point(732, 58);
            this.comboBoxPreset.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxPreset.Name = "comboBoxPreset";
            this.comboBoxPreset.Size = new System.Drawing.Size(118, 33);
            this.comboBoxPreset.TabIndex = 5;
            this.comboBoxPreset.SelectedIndexChanged += new System.EventHandler(this.comboBoxPreset_SelectedIndexChanged);
            // 
            // labelCalcSize
            // 
            this.labelCalcSize.AutoSize = true;
            this.labelCalcSize.Location = new System.Drawing.Point(146, 190);
            this.labelCalcSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCalcSize.Name = "labelCalcSize";
            this.labelCalcSize.Size = new System.Drawing.Size(19, 25);
            this.labelCalcSize.TabIndex = 9;
            this.labelCalcSize.Text = "-";
            // 
            // labelPreset
            // 
            this.labelPreset.AutoSize = true;
            this.labelPreset.Location = new System.Drawing.Point(590, 63);
            this.labelPreset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPreset.Name = "labelPreset";
            this.labelPreset.Size = new System.Drawing.Size(69, 25);
            this.labelPreset.TabIndex = 4;
            this.labelPreset.Text = "Пресет";
            // 
            // labelCalcSizeText
            // 
            this.labelCalcSizeText.AutoSize = true;
            this.labelCalcSizeText.Location = new System.Drawing.Point(4, 190);
            this.labelCalcSizeText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCalcSizeText.Name = "labelCalcSizeText";
            this.labelCalcSizeText.Size = new System.Drawing.Size(130, 25);
            this.labelCalcSizeText.TabIndex = 8;
            this.labelCalcSizeText.Text = "Размер файла:";
            // 
            // labelVideoCodec
            // 
            this.labelVideoCodec.AutoSize = true;
            this.labelVideoCodec.Location = new System.Drawing.Point(590, 20);
            this.labelVideoCodec.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVideoCodec.Name = "labelVideoCodec";
            this.labelVideoCodec.Size = new System.Drawing.Size(61, 25);
            this.labelVideoCodec.TabIndex = 3;
            this.labelVideoCodec.Text = "Кодек";
            // 
            // comboBoxVideoCodec
            // 
            this.comboBoxVideoCodec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVideoCodec.FormattingEnabled = true;
            this.comboBoxVideoCodec.Location = new System.Drawing.Point(732, 15);
            this.comboBoxVideoCodec.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxVideoCodec.Name = "comboBoxVideoCodec";
            this.comboBoxVideoCodec.Size = new System.Drawing.Size(118, 33);
            this.comboBoxVideoCodec.TabIndex = 2;
            this.comboBoxVideoCodec.SelectedIndexChanged += new System.EventHandler(this.comboBoxVideoCodec_SelectedIndexChanged);
            // 
            // labelVideoKbps
            // 
            this.labelVideoKbps.AutoSize = true;
            this.labelVideoKbps.Location = new System.Drawing.Point(242, 142);
            this.labelVideoKbps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVideoKbps.Name = "labelVideoKbps";
            this.labelVideoKbps.Size = new System.Drawing.Size(63, 25);
            this.labelVideoKbps.TabIndex = 7;
            this.labelVideoKbps.Text = "кбит/с";
            // 
            // labelFrameRate
            // 
            this.labelFrameRate.AutoSize = true;
            this.labelFrameRate.Location = new System.Drawing.Point(590, 147);
            this.labelFrameRate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFrameRate.Name = "labelFrameRate";
            this.labelFrameRate.Size = new System.Drawing.Size(140, 25);
            this.labelFrameRate.TabIndex = 0;
            this.labelFrameRate.Text = "Частота кадров";
            // 
            // labelMinQ
            // 
            this.labelMinQ.AutoSize = true;
            this.labelMinQ.Location = new System.Drawing.Point(324, 92);
            this.labelMinQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMinQ.Name = "labelMinQ";
            this.labelMinQ.Size = new System.Drawing.Size(130, 25);
            this.labelMinQ.TabIndex = 4;
            this.labelMinQ.Text = "Мин. качество";
            // 
            // comboBoxFrameRate
            // 
            this.comboBoxFrameRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFrameRate.FormattingEnabled = true;
            this.comboBoxFrameRate.Location = new System.Drawing.Point(732, 142);
            this.comboBoxFrameRate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxFrameRate.Name = "comboBoxFrameRate";
            this.comboBoxFrameRate.Size = new System.Drawing.Size(118, 33);
            this.comboBoxFrameRate.TabIndex = 1;
            this.comboBoxFrameRate.SelectedIndexChanged += new System.EventHandler(this.comboBoxFrameRate_SelectedIndexChanged);
            // 
            // labelMaxQ
            // 
            this.labelMaxQ.AutoSize = true;
            this.labelMaxQ.Location = new System.Drawing.Point(3, 92);
            this.labelMaxQ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMaxQ.Name = "labelMaxQ";
            this.labelMaxQ.Size = new System.Drawing.Size(136, 25);
            this.labelMaxQ.TabIndex = 3;
            this.labelMaxQ.Text = "Макс. качество";
            // 
            // labelCRF
            // 
            this.labelCRF.AutoSize = true;
            this.labelCRF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCRF.Location = new System.Drawing.Point(164, 8);
            this.labelCRF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCRF.Name = "labelCRF";
            this.labelCRF.Size = new System.Drawing.Size(47, 25);
            this.labelCRF.TabIndex = 1;
            this.labelCRF.Text = "20.0";
            // 
            // radioButtonBitrate
            // 
            this.radioButtonBitrate.AutoSize = true;
            this.radioButtonBitrate.Location = new System.Drawing.Point(3, 140);
            this.radioButtonBitrate.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonBitrate.Name = "radioButtonBitrate";
            this.radioButtonBitrate.Size = new System.Drawing.Size(101, 29);
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
            this.radioButtonCRF.Margin = new System.Windows.Forms.Padding(4);
            this.radioButtonCRF.Name = "radioButtonCRF";
            this.radioButtonCRF.Size = new System.Drawing.Size(68, 29);
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
            this.trackBarCRF.Location = new System.Drawing.Point(3, 44);
            this.trackBarCRF.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarCRF.Maximum = 510;
            this.trackBarCRF.Name = "trackBarCRF";
            this.trackBarCRF.Size = new System.Drawing.Size(452, 69);
            this.trackBarCRF.TabIndex = 2;
            this.trackBarCRF.Value = 200;
            this.trackBarCRF.ValueChanged += new System.EventHandler(this.trackBarCRF_ValueChanged);
            // 
            // numericUpDownBitrate
            // 
            this.numericUpDownBitrate.Location = new System.Drawing.Point(112, 138);
            this.numericUpDownBitrate.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownBitrate.Name = "numericUpDownBitrate";
            this.numericUpDownBitrate.Size = new System.Drawing.Size(120, 31);
            this.numericUpDownBitrate.TabIndex = 6;
            this.numericUpDownBitrate.ValueChanged += new System.EventHandler(this.numericUpDownBitrate_ValueChanged);
            // 
            // tabPagePicture
            // 
            this.tabPagePicture.Controls.Add(this.panelResize);
            this.tabPagePicture.Location = new System.Drawing.Point(4, 34);
            this.tabPagePicture.Margin = new System.Windows.Forms.Padding(4);
            this.tabPagePicture.Name = "tabPagePicture";
            this.tabPagePicture.Padding = new System.Windows.Forms.Padding(4);
            this.tabPagePicture.Size = new System.Drawing.Size(910, 278);
            this.tabPagePicture.TabIndex = 1;
            this.tabPagePicture.Text = "Картинка";
            this.tabPagePicture.UseVisualStyleBackColor = true;
            // 
            // panelResize
            // 
            this.panelResize.Controls.Add(this.numericCropRight);
            this.panelResize.Controls.Add(this.numericCropLeft);
            this.panelResize.Controls.Add(this.numericCropBottom);
            this.panelResize.Controls.Add(this.numericCropTop);
            this.panelResize.Controls.Add(this.labelCrop);
            this.panelResize.Controls.Add(this.checkBoxFlip);
            this.panelResize.Controls.Add(this.buttonCropReset);
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
            this.panelResize.Location = new System.Drawing.Point(9, 9);
            this.panelResize.Margin = new System.Windows.Forms.Padding(4);
            this.panelResize.Name = "panelResize";
            this.panelResize.Size = new System.Drawing.Size(888, 256);
            this.panelResize.TabIndex = 0;
            // 
            // numericCropRight
            // 
            this.numericCropRight.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericCropRight.Location = new System.Drawing.Point(488, 9);
            this.numericCropRight.Margin = new System.Windows.Forms.Padding(4);
            this.numericCropRight.Name = "numericCropRight";
            this.numericCropRight.Size = new System.Drawing.Size(82, 31);
            this.numericCropRight.TabIndex = 4;
            this.numericCropRight.ValueChanged += new System.EventHandler(this.numericCropRight_ValueChanged);
            this.numericCropRight.Enter += new System.EventHandler(this.numericCropRight_Enter);
            // 
            // numericCropLeft
            // 
            this.numericCropLeft.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericCropLeft.Location = new System.Drawing.Point(396, 9);
            this.numericCropLeft.Margin = new System.Windows.Forms.Padding(4);
            this.numericCropLeft.Name = "numericCropLeft";
            this.numericCropLeft.Size = new System.Drawing.Size(82, 31);
            this.numericCropLeft.TabIndex = 3;
            this.numericCropLeft.ValueChanged += new System.EventHandler(this.numericCropLeft_ValueChanged);
            this.numericCropLeft.Enter += new System.EventHandler(this.numericCropLeft_Enter);
            // 
            // numericCropBottom
            // 
            this.numericCropBottom.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericCropBottom.Location = new System.Drawing.Point(304, 9);
            this.numericCropBottom.Margin = new System.Windows.Forms.Padding(4);
            this.numericCropBottom.Name = "numericCropBottom";
            this.numericCropBottom.Size = new System.Drawing.Size(82, 31);
            this.numericCropBottom.TabIndex = 2;
            this.numericCropBottom.ValueChanged += new System.EventHandler(this.numericCropBottom_ValueChanged);
            this.numericCropBottom.Enter += new System.EventHandler(this.numericCropBottom_Enter);
            // 
            // numericCropTop
            // 
            this.numericCropTop.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericCropTop.Location = new System.Drawing.Point(213, 9);
            this.numericCropTop.Margin = new System.Windows.Forms.Padding(4);
            this.numericCropTop.Name = "numericCropTop";
            this.numericCropTop.Size = new System.Drawing.Size(82, 31);
            this.numericCropTop.TabIndex = 1;
            this.numericCropTop.ValueChanged += new System.EventHandler(this.numericCropTop_ValueChanged);
            this.numericCropTop.Enter += new System.EventHandler(this.numericCropTop_Enter);
            // 
            // labelCrop
            // 
            this.labelCrop.AutoSize = true;
            this.labelCrop.Location = new System.Drawing.Point(4, 12);
            this.labelCrop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCrop.Name = "labelCrop";
            this.labelCrop.Size = new System.Drawing.Size(205, 50);
            this.labelCrop.TabIndex = 0;
            this.labelCrop.Text = "Кадрирование\r\n(верх низ слева справа)";
            // 
            // checkBoxFlip
            // 
            this.checkBoxFlip.AutoSize = true;
            this.checkBoxFlip.Location = new System.Drawing.Point(9, 224);
            this.checkBoxFlip.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxFlip.Name = "checkBoxFlip";
            this.checkBoxFlip.Size = new System.Drawing.Size(247, 29);
            this.checkBoxFlip.TabIndex = 22;
            this.checkBoxFlip.Text = "Отразить по горизонтали";
            this.checkBoxFlip.UseVisualStyleBackColor = true;
            this.checkBoxFlip.CheckedChanged += new System.EventHandler(this.checkBoxFlip_CheckedChanged);
            // 
            // buttonCropReset
            // 
            this.buttonCropReset.Location = new System.Drawing.Point(579, 6);
            this.buttonCropReset.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCropReset.Name = "buttonCropReset";
            this.buttonCropReset.Size = new System.Drawing.Size(94, 38);
            this.buttonCropReset.TabIndex = 5;
            this.buttonCropReset.Text = "Сброс";
            this.buttonCropReset.UseVisualStyleBackColor = true;
            this.buttonCropReset.Click += new System.EventHandler(this.buttonCropReset_Click);
            // 
            // labelCropSize
            // 
            this.labelCropSize.AutoSize = true;
            this.labelCropSize.Location = new System.Drawing.Point(682, 14);
            this.labelCropSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCropSize.Name = "labelCropSize";
            this.labelCropSize.Size = new System.Drawing.Size(114, 25);
            this.labelCropSize.TabIndex = 6;
            this.labelCropSize.Text = "WxH → WxH";
            this.labelCropSize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBoxRotate
            // 
            this.comboBoxRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRotate.FormattingEnabled = true;
            this.comboBoxRotate.Location = new System.Drawing.Point(213, 180);
            this.comboBoxRotate.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxRotate.Name = "comboBoxRotate";
            this.comboBoxRotate.Size = new System.Drawing.Size(178, 33);
            this.comboBoxRotate.TabIndex = 19;
            this.comboBoxRotate.SelectedIndexChanged += new System.EventHandler(this.comboBoxRotate_SelectedIndexChanged);
            // 
            // labelRotate
            // 
            this.labelRotate.AutoSize = true;
            this.labelRotate.Location = new System.Drawing.Point(4, 184);
            this.labelRotate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRotate.Name = "labelRotate";
            this.labelRotate.Size = new System.Drawing.Size(101, 25);
            this.labelRotate.TabIndex = 18;
            this.labelRotate.Text = "Повернуть";
            // 
            // labelPictureSize
            // 
            this.labelPictureSize.AutoSize = true;
            this.labelPictureSize.Location = new System.Drawing.Point(4, 76);
            this.labelPictureSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPictureSize.Name = "labelPictureSize";
            this.labelPictureSize.Size = new System.Drawing.Size(85, 25);
            this.labelPictureSize.TabIndex = 7;
            this.labelPictureSize.Text = "Размеры";
            // 
            // labelSizePreset
            // 
            this.labelSizePreset.AutoSize = true;
            this.labelSizePreset.Location = new System.Drawing.Point(4, 120);
            this.labelSizePreset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSizePreset.Name = "labelSizePreset";
            this.labelSizePreset.Size = new System.Drawing.Size(156, 25);
            this.labelSizePreset.TabIndex = 13;
            this.labelSizePreset.Text = "Пресет размеров";
            // 
            // labelInterpolation
            // 
            this.labelInterpolation.AutoSize = true;
            this.labelInterpolation.Location = new System.Drawing.Point(506, 184);
            this.labelInterpolation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInterpolation.Name = "labelInterpolation";
            this.labelInterpolation.Size = new System.Drawing.Size(131, 25);
            this.labelInterpolation.TabIndex = 20;
            this.labelInterpolation.Text = "Интерполяция";
            // 
            // comboBoxInterpolation
            // 
            this.comboBoxInterpolation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInterpolation.FormattingEnabled = true;
            this.comboBoxInterpolation.Location = new System.Drawing.Point(646, 180);
            this.comboBoxInterpolation.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxInterpolation.Name = "comboBoxInterpolation";
            this.comboBoxInterpolation.Size = new System.Drawing.Size(178, 33);
            this.comboBoxInterpolation.TabIndex = 21;
            this.comboBoxInterpolation.SelectedIndexChanged += new System.EventHandler(this.comboBoxInterpolation_SelectedIndexChanged);
            // 
            // checkBoxKeepAspectRatio
            // 
            this.checkBoxKeepAspectRatio.AutoSize = true;
            this.checkBoxKeepAspectRatio.Location = new System.Drawing.Point(416, 76);
            this.checkBoxKeepAspectRatio.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxKeepAspectRatio.Name = "checkBoxKeepAspectRatio";
            this.checkBoxKeepAspectRatio.Size = new System.Drawing.Size(223, 29);
            this.checkBoxKeepAspectRatio.TabIndex = 11;
            this.checkBoxKeepAspectRatio.Text = "Сохранять пропорции";
            this.checkBoxKeepAspectRatio.UseVisualStyleBackColor = true;
            this.checkBoxKeepAspectRatio.CheckedChanged += new System.EventHandler(this.checkBoxKeepAspectRatio_CheckedChanged);
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(213, 74);
            this.numericUpDownWidth.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(75, 31);
            this.numericUpDownWidth.TabIndex = 8;
            this.numericUpDownWidth.ValueChanged += new System.EventHandler(this.numericUpDownWidth_ValueChanged);
            this.numericUpDownWidth.Leave += new System.EventHandler(this.numericUpDownWidth_Leave);
            // 
            // pictureBoxRatioError
            // 
            this.pictureBoxRatioError.Location = new System.Drawing.Point(836, 78);
            this.pictureBoxRatioError.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxRatioError.Name = "pictureBoxRatioError";
            this.pictureBoxRatioError.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxRatioError.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxRatioError.TabIndex = 30;
            this.pictureBoxRatioError.TabStop = false;
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(318, 74);
            this.numericUpDownHeight.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(75, 31);
            this.numericUpDownHeight.TabIndex = 10;
            this.numericUpDownHeight.ValueChanged += new System.EventHandler(this.numericUpDownHeight_ValueChanged);
            this.numericUpDownHeight.Leave += new System.EventHandler(this.numericUpDownHeight_Leave);
            // 
            // comboBoxAspectRatio
            // 
            this.comboBoxAspectRatio.FormattingEnabled = true;
            this.comboBoxAspectRatio.Location = new System.Drawing.Point(646, 74);
            this.comboBoxAspectRatio.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxAspectRatio.Name = "comboBoxAspectRatio";
            this.comboBoxAspectRatio.Size = new System.Drawing.Size(178, 33);
            this.comboBoxAspectRatio.TabIndex = 12;
            this.comboBoxAspectRatio.SelectedIndexChanged += new System.EventHandler(this.comboBoxAspectRatio_SelectedIndexChanged);
            this.comboBoxAspectRatio.TextUpdate += new System.EventHandler(this.comboBoxAspectRatio_TextUpdate);
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(292, 76);
            this.labelX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(24, 25);
            this.labelX.TabIndex = 9;
            this.labelX.Text = "×";
            // 
            // tabPageFile
            // 
            this.tabPageFile.Controls.Add(this.panelFile);
            this.tabPageFile.Location = new System.Drawing.Point(4, 34);
            this.tabPageFile.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageFile.Name = "tabPageFile";
            this.tabPageFile.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageFile.Size = new System.Drawing.Size(910, 278);
            this.tabPageFile.TabIndex = 3;
            this.tabPageFile.Text = "Файл";
            this.tabPageFile.UseVisualStyleBackColor = true;
            // 
            // panelFile
            // 
            this.panelFile.Controls.Add(this.buttonCopyToClipboard);
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
            this.panelFile.Location = new System.Drawing.Point(9, 9);
            this.panelFile.Margin = new System.Windows.Forms.Padding(4);
            this.panelFile.Name = "panelFile";
            this.panelFile.Size = new System.Drawing.Size(888, 256);
            this.panelFile.TabIndex = 0;
            // 
            // labelOut
            // 
            this.labelOut.AutoSize = true;
            this.labelOut.Location = new System.Drawing.Point(4, 117);
            this.labelOut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOut.Name = "labelOut";
            this.labelOut.Size = new System.Drawing.Size(130, 25);
            this.labelOut.TabIndex = 5;
            this.labelOut.Text = "Сохранить как";
            // 
            // labelInputFile
            // 
            this.labelInputFile.AutoSize = true;
            this.labelInputFile.Location = new System.Drawing.Point(4, 12);
            this.labelInputFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInputFile.Name = "labelInputFile";
            this.labelInputFile.Size = new System.Drawing.Size(126, 25);
            this.labelInputFile.TabIndex = 0;
            this.labelInputFile.Text = "Выбрать файл";
            // 
            // textBoxOut
            // 
            this.textBoxOut.Location = new System.Drawing.Point(142, 111);
            this.textBoxOut.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.Size = new System.Drawing.Size(618, 31);
            this.textBoxOut.TabIndex = 6;
            // 
            // checkBoxKeepOutPath
            // 
            this.checkBoxKeepOutPath.AutoSize = true;
            this.checkBoxKeepOutPath.Location = new System.Drawing.Point(142, 154);
            this.checkBoxKeepOutPath.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxKeepOutPath.Name = "checkBoxKeepOutPath";
            this.checkBoxKeepOutPath.Size = new System.Drawing.Size(281, 29);
            this.checkBoxKeepOutPath.TabIndex = 8;
            this.checkBoxKeepOutPath.Text = "Запомнить выбранную папку";
            this.checkBoxKeepOutPath.UseVisualStyleBackColor = true;
            // 
            // buttonBrowseIn
            // 
            this.buttonBrowseIn.Location = new System.Drawing.Point(771, 4);
            this.buttonBrowseIn.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBrowseIn.Name = "buttonBrowseIn";
            this.buttonBrowseIn.Size = new System.Drawing.Size(112, 38);
            this.buttonBrowseIn.TabIndex = 2;
            this.buttonBrowseIn.Text = "Обзор";
            this.buttonBrowseIn.UseVisualStyleBackColor = true;
            this.buttonBrowseIn.Click += new System.EventHandler(this.buttonBrowseIn_Click);
            // 
            // buttonBrowseOut
            // 
            this.buttonBrowseOut.Location = new System.Drawing.Point(771, 110);
            this.buttonBrowseOut.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBrowseOut.Name = "buttonBrowseOut";
            this.buttonBrowseOut.Size = new System.Drawing.Size(112, 38);
            this.buttonBrowseOut.TabIndex = 7;
            this.buttonBrowseOut.Text = "Обзор";
            this.buttonBrowseOut.UseVisualStyleBackColor = true;
            this.buttonBrowseOut.Click += new System.EventHandler(this.buttonBrowseOut_Click);
            // 
            // textBoxIn
            // 
            this.textBoxIn.Location = new System.Drawing.Point(142, 6);
            this.textBoxIn.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.ReadOnly = true;
            this.textBoxIn.Size = new System.Drawing.Size(618, 31);
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
            this.tabControlMain.Location = new System.Drawing.Point(9, 9);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(918, 316);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageFilters
            // 
            this.tabPageFilters.Controls.Add(this.panelSubtitles);
            this.tabPageFilters.Controls.Add(this.panelColorFilter);
            this.tabPageFilters.Controls.Add(this.panelDeinterlace);
            this.tabPageFilters.Location = new System.Drawing.Point(4, 34);
            this.tabPageFilters.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageFilters.Name = "tabPageFilters";
            this.tabPageFilters.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageFilters.Size = new System.Drawing.Size(910, 278);
            this.tabPageFilters.TabIndex = 5;
            this.tabPageFilters.Text = "Фильтры";
            this.tabPageFilters.UseVisualStyleBackColor = true;
            // 
            // panelSubtitles
            // 
            this.panelSubtitles.Controls.Add(this.labelSubtitles);
            this.panelSubtitles.Controls.Add(this.buttonBrowseSubtitles);
            this.panelSubtitles.Controls.Add(this.textBoxSubtitlesPath);
            this.panelSubtitles.Location = new System.Drawing.Point(9, 178);
            this.panelSubtitles.Margin = new System.Windows.Forms.Padding(4);
            this.panelSubtitles.Name = "panelSubtitles";
            this.panelSubtitles.Size = new System.Drawing.Size(888, 87);
            this.panelSubtitles.TabIndex = 4;
            // 
            // labelSubtitles
            // 
            this.labelSubtitles.AutoSize = true;
            this.labelSubtitles.Location = new System.Drawing.Point(4, 12);
            this.labelSubtitles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSubtitles.Name = "labelSubtitles";
            this.labelSubtitles.Size = new System.Drawing.Size(90, 25);
            this.labelSubtitles.TabIndex = 2;
            this.labelSubtitles.Text = "Субтитры";
            // 
            // buttonBrowseSubtitles
            // 
            this.buttonBrowseSubtitles.Location = new System.Drawing.Point(771, 4);
            this.buttonBrowseSubtitles.Margin = new System.Windows.Forms.Padding(4);
            this.buttonBrowseSubtitles.Name = "buttonBrowseSubtitles";
            this.buttonBrowseSubtitles.Size = new System.Drawing.Size(112, 38);
            this.buttonBrowseSubtitles.TabIndex = 1;
            this.buttonBrowseSubtitles.Text = "Обзор";
            this.buttonBrowseSubtitles.UseVisualStyleBackColor = true;
            this.buttonBrowseSubtitles.Click += new System.EventHandler(this.buttonBrowseSubtitles_Click);
            // 
            // textBoxSubtitlesPath
            // 
            this.textBoxSubtitlesPath.Location = new System.Drawing.Point(170, 6);
            this.textBoxSubtitlesPath.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSubtitlesPath.Name = "textBoxSubtitlesPath";
            this.textBoxSubtitlesPath.Size = new System.Drawing.Size(590, 31);
            this.textBoxSubtitlesPath.TabIndex = 0;
            // 
            // panelColorFilter
            // 
            this.panelColorFilter.Controls.Add(this.labelColorFilter);
            this.panelColorFilter.Controls.Add(this.comboBoxColorFilter);
            this.panelColorFilter.Location = new System.Drawing.Point(9, 111);
            this.panelColorFilter.Margin = new System.Windows.Forms.Padding(4);
            this.panelColorFilter.Name = "panelColorFilter";
            this.panelColorFilter.Size = new System.Drawing.Size(440, 58);
            this.panelColorFilter.TabIndex = 3;
            // 
            // labelColorFilter
            // 
            this.labelColorFilter.AutoSize = true;
            this.labelColorFilter.Location = new System.Drawing.Point(4, 9);
            this.labelColorFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelColorFilter.Name = "labelColorFilter";
            this.labelColorFilter.Size = new System.Drawing.Size(156, 25);
            this.labelColorFilter.TabIndex = 0;
            this.labelColorFilter.Text = "Цветовой фильтр";
            // 
            // comboBoxColorFilter
            // 
            this.comboBoxColorFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxColorFilter.FormattingEnabled = true;
            this.comboBoxColorFilter.Location = new System.Drawing.Point(170, 4);
            this.comboBoxColorFilter.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxColorFilter.Name = "comboBoxColorFilter";
            this.comboBoxColorFilter.Size = new System.Drawing.Size(178, 33);
            this.comboBoxColorFilter.TabIndex = 1;
            this.comboBoxColorFilter.SelectedIndexChanged += new System.EventHandler(this.comboBoxColorFilter_SelectedIndexChanged);
            // 
            // panelDeinterlace
            // 
            this.panelDeinterlace.Controls.Add(this.labelFieldOrder);
            this.panelDeinterlace.Controls.Add(this.checkBoxDeinterlace);
            this.panelDeinterlace.Controls.Add(this.comboBoxFieldOrder);
            this.panelDeinterlace.Location = new System.Drawing.Point(9, 9);
            this.panelDeinterlace.Margin = new System.Windows.Forms.Padding(4);
            this.panelDeinterlace.Name = "panelDeinterlace";
            this.panelDeinterlace.Size = new System.Drawing.Size(440, 93);
            this.panelDeinterlace.TabIndex = 2;
            // 
            // labelFieldOrder
            // 
            this.labelFieldOrder.AutoSize = true;
            this.labelFieldOrder.Location = new System.Drawing.Point(4, 44);
            this.labelFieldOrder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFieldOrder.Name = "labelFieldOrder";
            this.labelFieldOrder.Size = new System.Drawing.Size(140, 25);
            this.labelFieldOrder.TabIndex = 1;
            this.labelFieldOrder.Text = "Порядок полей";
            // 
            // checkBoxDeinterlace
            // 
            this.checkBoxDeinterlace.AutoSize = true;
            this.checkBoxDeinterlace.Location = new System.Drawing.Point(9, 4);
            this.checkBoxDeinterlace.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxDeinterlace.Name = "checkBoxDeinterlace";
            this.checkBoxDeinterlace.Size = new System.Drawing.Size(169, 29);
            this.checkBoxDeinterlace.TabIndex = 0;
            this.checkBoxDeinterlace.Text = "Деинтерлейсинг";
            this.checkBoxDeinterlace.UseVisualStyleBackColor = true;
            this.checkBoxDeinterlace.CheckedChanged += new System.EventHandler(this.checkBoxDeinterlace_CheckedChanged);
            // 
            // comboBoxFieldOrder
            // 
            this.comboBoxFieldOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFieldOrder.FormattingEnabled = true;
            this.comboBoxFieldOrder.Location = new System.Drawing.Point(170, 39);
            this.comboBoxFieldOrder.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxFieldOrder.Name = "comboBoxFieldOrder";
            this.comboBoxFieldOrder.Size = new System.Drawing.Size(178, 33);
            this.comboBoxFieldOrder.TabIndex = 2;
            this.comboBoxFieldOrder.SelectedIndexChanged += new System.EventHandler(this.comboBoxFieldOrder_SelectedIndexChanged);
            // 
            // buttonPreview
            // 
            this.buttonPreview.Location = new System.Drawing.Point(610, 334);
            this.buttonPreview.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPreview.Name = "buttonPreview";
            this.buttonPreview.Size = new System.Drawing.Size(112, 48);
            this.buttonPreview.TabIndex = 5;
            this.buttonPreview.Text = "Превью";
            this.buttonPreview.UseVisualStyleBackColor = true;
            this.buttonPreview.Click += new System.EventHandler(this.buttonPreview_Click);
            // 
            // labelOutputInfo
            // 
            this.labelOutputInfo.AutoSize = true;
            this.labelOutputInfo.Location = new System.Drawing.Point(90, 334);
            this.labelOutputInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOutputInfo.Name = "labelOutputInfo";
            this.labelOutputInfo.Size = new System.Drawing.Size(24, 25);
            this.labelOutputInfo.TabIndex = 2;
            this.labelOutputInfo.Text = "...";
            // 
            // labelOutputInfoTitle
            // 
            this.labelOutputInfoTitle.AutoSize = true;
            this.labelOutputInfoTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelOutputInfoTitle.Location = new System.Drawing.Point(10, 334);
            this.labelOutputInfoTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOutputInfoTitle.Name = "labelOutputInfoTitle";
            this.labelOutputInfoTitle.Size = new System.Drawing.Size(72, 50);
            this.labelOutputInfoTitle.TabIndex = 1;
            this.labelOutputInfoTitle.Text = "Видео:\r\nАудио:";
            // 
            // buttonCopyToClipboard
            // 
            this.buttonCopyToClipboard.Location = new System.Drawing.Point(652, 211);
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Size = new System.Drawing.Size(231, 38);
            this.buttonCopyToClipboard.TabIndex = 6;
            this.buttonCopyToClipboard.Text = "Копировать аргументы";
            this.buttonCopyToClipboard.UseVisualStyleBackColor = true;
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(936, 392);
            this.Controls.Add(this.buttonPreview);
            this.Controls.Add(this.labelOutputInfoTitle);
            this.Controls.Add(this.labelOutputInfo);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.buttonGo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(4);
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
            ((System.ComponentModel.ISupportInitialize)(this.numericCropRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropTop)).EndInit();
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
        private System.Windows.Forms.Button buttonCropReset;
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
        private System.Windows.Forms.Button buttonPreview;
        private System.Windows.Forms.CheckBox checkBoxCustomX265;
        private System.Windows.Forms.NumericUpDown numericCropTop;
        private System.Windows.Forms.NumericUpDown numericCropBottom;
        private System.Windows.Forms.NumericUpDown numericCropLeft;
        private System.Windows.Forms.NumericUpDown numericCropRight;
        private System.Windows.Forms.Button buttonCopyToClipboard;
    }
}


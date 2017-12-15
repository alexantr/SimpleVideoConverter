namespace Alexantr.SimpleVideoConverter
{
    partial class CropForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CropForm));
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.buttonRew = new System.Windows.Forms.Button();
            this.buttonFF = new System.Windows.Forms.Button();
            this.labelLoading = new System.Windows.Forms.Label();
            this.labelCropBottom = new System.Windows.Forms.Label();
            this.labelCropRight = new System.Windows.Forms.Label();
            this.labelCropLeft = new System.Windows.Forms.Label();
            this.labelCropTop = new System.Windows.Forms.Label();
            this.numericCropBottom = new System.Windows.Forms.NumericUpDown();
            this.numericCropRight = new System.Windows.Forms.NumericUpDown();
            this.numericCropLeft = new System.Windows.Forms.NumericUpDown();
            this.numericCropTop = new System.Windows.Forms.NumericUpDown();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.panelSelectFrame = new System.Windows.Forms.Panel();
            this.labelSelectFrame = new System.Windows.Forms.Label();
            this.panelCrop = new System.Windows.Forms.Panel();
            this.labelCrop = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropTop)).BeginInit();
            this.panelSelectFrame.SuspendLayout();
            this.panelCrop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackColor = System.Drawing.Color.Silver;
            this.pictureBoxPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview.Location = new System.Drawing.Point(6, 6);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(512, 384);
            this.pictureBoxPreview.TabIndex = 0;
            this.pictureBoxPreview.TabStop = false;
            // 
            // buttonRew
            // 
            this.buttonRew.Location = new System.Drawing.Point(6, 29);
            this.buttonRew.Name = "buttonRew";
            this.buttonRew.Size = new System.Drawing.Size(30, 23);
            this.buttonRew.TabIndex = 1;
            this.buttonRew.Text = "<";
            this.buttonRew.UseVisualStyleBackColor = true;
            this.buttonRew.Click += new System.EventHandler(this.buttonRew_Click);
            // 
            // buttonFF
            // 
            this.buttonFF.Location = new System.Drawing.Point(132, 29);
            this.buttonFF.Name = "buttonFF";
            this.buttonFF.Size = new System.Drawing.Size(30, 23);
            this.buttonFF.TabIndex = 2;
            this.buttonFF.Text = ">";
            this.buttonFF.UseVisualStyleBackColor = true;
            this.buttonFF.Click += new System.EventHandler(this.buttonFF_Click);
            // 
            // labelLoading
            // 
            this.labelLoading.BackColor = System.Drawing.Color.Silver;
            this.labelLoading.Location = new System.Drawing.Point(222, 188);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(80, 20);
            this.labelLoading.TabIndex = 3;
            this.labelLoading.Text = "Загрузка...";
            this.labelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCropBottom
            // 
            this.labelCropBottom.AutoSize = true;
            this.labelCropBottom.Location = new System.Drawing.Point(43, 58);
            this.labelCropBottom.Name = "labelCropBottom";
            this.labelCropBottom.Size = new System.Drawing.Size(37, 13);
            this.labelCropBottom.TabIndex = 16;
            this.labelCropBottom.Text = "Снизу";
            // 
            // labelCropRight
            // 
            this.labelCropRight.AutoSize = true;
            this.labelCropRight.Location = new System.Drawing.Point(36, 112);
            this.labelCropRight.Name = "labelCropRight";
            this.labelCropRight.Size = new System.Drawing.Size(44, 13);
            this.labelCropRight.TabIndex = 15;
            this.labelCropRight.Text = "Справа";
            // 
            // labelCropLeft
            // 
            this.labelCropLeft.AutoSize = true;
            this.labelCropLeft.Location = new System.Drawing.Point(42, 85);
            this.labelCropLeft.Name = "labelCropLeft";
            this.labelCropLeft.Size = new System.Drawing.Size(38, 13);
            this.labelCropLeft.TabIndex = 14;
            this.labelCropLeft.Text = "Слева";
            // 
            // labelCropTop
            // 
            this.labelCropTop.AutoSize = true;
            this.labelCropTop.Location = new System.Drawing.Point(36, 31);
            this.labelCropTop.Name = "labelCropTop";
            this.labelCropTop.Size = new System.Drawing.Size(44, 13);
            this.labelCropTop.TabIndex = 13;
            this.labelCropTop.Text = "Сверху";
            // 
            // numericCropBottom
            // 
            this.numericCropBottom.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericCropBottom.Location = new System.Drawing.Point(86, 56);
            this.numericCropBottom.Name = "numericCropBottom";
            this.numericCropBottom.Size = new System.Drawing.Size(55, 21);
            this.numericCropBottom.TabIndex = 12;
            this.numericCropBottom.ValueChanged += new System.EventHandler(this.numericCropBottom_ValueChanged);
            // 
            // numericCropRight
            // 
            this.numericCropRight.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericCropRight.Location = new System.Drawing.Point(86, 110);
            this.numericCropRight.Name = "numericCropRight";
            this.numericCropRight.Size = new System.Drawing.Size(55, 21);
            this.numericCropRight.TabIndex = 11;
            this.numericCropRight.ValueChanged += new System.EventHandler(this.numericCropRight_ValueChanged);
            // 
            // numericCropLeft
            // 
            this.numericCropLeft.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericCropLeft.Location = new System.Drawing.Point(86, 83);
            this.numericCropLeft.Name = "numericCropLeft";
            this.numericCropLeft.Size = new System.Drawing.Size(55, 21);
            this.numericCropLeft.TabIndex = 10;
            this.numericCropLeft.ValueChanged += new System.EventHandler(this.numericCropLeft_ValueChanged);
            // 
            // numericCropTop
            // 
            this.numericCropTop.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericCropTop.Location = new System.Drawing.Point(86, 29);
            this.numericCropTop.Name = "numericCropTop";
            this.numericCropTop.Size = new System.Drawing.Size(55, 21);
            this.numericCropTop.TabIndex = 9;
            this.numericCropTop.ValueChanged += new System.EventHandler(this.numericCropTop_ValueChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(524, 363);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(168, 27);
            this.buttonSave.TabIndex = 19;
            this.buttonSave.Text = "ОК";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(49, 34);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(73, 13);
            this.labelTime.TabIndex = 20;
            this.labelTime.Text = "00:00:00.000";
            // 
            // panelSelectFrame
            // 
            this.panelSelectFrame.Controls.Add(this.labelTime);
            this.panelSelectFrame.Controls.Add(this.labelSelectFrame);
            this.panelSelectFrame.Controls.Add(this.buttonRew);
            this.panelSelectFrame.Controls.Add(this.buttonFF);
            this.panelSelectFrame.Location = new System.Drawing.Point(524, 6);
            this.panelSelectFrame.Name = "panelSelectFrame";
            this.panelSelectFrame.Size = new System.Drawing.Size(168, 70);
            this.panelSelectFrame.TabIndex = 20;
            // 
            // labelSelectFrame
            // 
            this.labelSelectFrame.AutoSize = true;
            this.labelSelectFrame.Location = new System.Drawing.Point(3, 3);
            this.labelSelectFrame.Name = "labelSelectFrame";
            this.labelSelectFrame.Size = new System.Drawing.Size(93, 13);
            this.labelSelectFrame.TabIndex = 0;
            this.labelSelectFrame.Text = "Выбрать превью";
            // 
            // panelCrop
            // 
            this.panelCrop.Controls.Add(this.buttonReset);
            this.panelCrop.Controls.Add(this.numericCropTop);
            this.panelCrop.Controls.Add(this.labelCropRight);
            this.panelCrop.Controls.Add(this.labelCrop);
            this.panelCrop.Controls.Add(this.numericCropLeft);
            this.panelCrop.Controls.Add(this.labelCropLeft);
            this.panelCrop.Controls.Add(this.numericCropRight);
            this.panelCrop.Controls.Add(this.labelCropTop);
            this.panelCrop.Controls.Add(this.numericCropBottom);
            this.panelCrop.Controls.Add(this.labelCropBottom);
            this.panelCrop.Location = new System.Drawing.Point(524, 82);
            this.panelCrop.Name = "panelCrop";
            this.panelCrop.Size = new System.Drawing.Size(167, 179);
            this.panelCrop.TabIndex = 21;
            // 
            // labelCrop
            // 
            this.labelCrop.AutoSize = true;
            this.labelCrop.Location = new System.Drawing.Point(3, 3);
            this.labelCrop.Name = "labelCrop";
            this.labelCrop.Size = new System.Drawing.Size(76, 13);
            this.labelCrop.TabIndex = 0;
            this.labelCrop.Text = "Указать поля";
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(47, 153);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 17;
            this.buttonReset.Text = "Сбросить";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // CropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 396);
            this.Controls.Add(this.panelCrop);
            this.Controls.Add(this.panelSelectFrame);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelLoading);
            this.Controls.Add(this.pictureBoxPreview);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CropForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Обрезать края";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CropForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CropForm_FormClosed);
            this.Load += new System.EventHandler(this.CropForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropTop)).EndInit();
            this.panelSelectFrame.ResumeLayout(false);
            this.panelSelectFrame.PerformLayout();
            this.panelCrop.ResumeLayout(false);
            this.panelCrop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.Button buttonRew;
        private System.Windows.Forms.Button buttonFF;
        private System.Windows.Forms.Label labelLoading;
        private System.Windows.Forms.Label labelCropBottom;
        private System.Windows.Forms.Label labelCropRight;
        private System.Windows.Forms.Label labelCropLeft;
        private System.Windows.Forms.Label labelCropTop;
        private System.Windows.Forms.NumericUpDown numericCropBottom;
        private System.Windows.Forms.NumericUpDown numericCropRight;
        private System.Windows.Forms.NumericUpDown numericCropLeft;
        private System.Windows.Forms.NumericUpDown numericCropTop;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Panel panelSelectFrame;
        private System.Windows.Forms.Label labelSelectFrame;
        private System.Windows.Forms.Panel panelCrop;
        private System.Windows.Forms.Label labelCrop;
        private System.Windows.Forms.Button buttonReset;
    }
}
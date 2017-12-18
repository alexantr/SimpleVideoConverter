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
            this.labelSelectFrame = new System.Windows.Forms.Label();
            this.buttonReset = new System.Windows.Forms.Button();
            this.labelCrop = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropTop)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackColor = System.Drawing.Color.Silver;
            this.pictureBoxPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(512, 384);
            this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
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
            this.buttonFF.Location = new System.Drawing.Point(131, 29);
            this.buttonFF.Name = "buttonFF";
            this.buttonFF.Size = new System.Drawing.Size(30, 23);
            this.buttonFF.TabIndex = 3;
            this.buttonFF.Text = ">";
            this.buttonFF.UseVisualStyleBackColor = true;
            this.buttonFF.Click += new System.EventHandler(this.buttonFF_Click);
            // 
            // labelLoading
            // 
            this.labelLoading.BackColor = System.Drawing.Color.Silver;
            this.labelLoading.Location = new System.Drawing.Point(3, 3);
            this.labelLoading.Name = "labelLoading";
            this.labelLoading.Size = new System.Drawing.Size(80, 20);
            this.labelLoading.TabIndex = 0;
            this.labelLoading.Text = "Загрузка...";
            this.labelLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCropBottom
            // 
            this.labelCropBottom.AutoSize = true;
            this.labelCropBottom.Location = new System.Drawing.Point(43, 124);
            this.labelCropBottom.Name = "labelCropBottom";
            this.labelCropBottom.Size = new System.Drawing.Size(37, 13);
            this.labelCropBottom.TabIndex = 7;
            this.labelCropBottom.Text = "Снизу";
            // 
            // labelCropRight
            // 
            this.labelCropRight.AutoSize = true;
            this.labelCropRight.Location = new System.Drawing.Point(36, 178);
            this.labelCropRight.Name = "labelCropRight";
            this.labelCropRight.Size = new System.Drawing.Size(44, 13);
            this.labelCropRight.TabIndex = 11;
            this.labelCropRight.Text = "Справа";
            // 
            // labelCropLeft
            // 
            this.labelCropLeft.AutoSize = true;
            this.labelCropLeft.Location = new System.Drawing.Point(42, 151);
            this.labelCropLeft.Name = "labelCropLeft";
            this.labelCropLeft.Size = new System.Drawing.Size(38, 13);
            this.labelCropLeft.TabIndex = 9;
            this.labelCropLeft.Text = "Слева";
            // 
            // labelCropTop
            // 
            this.labelCropTop.AutoSize = true;
            this.labelCropTop.Location = new System.Drawing.Point(36, 97);
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
            this.numericCropBottom.Location = new System.Drawing.Point(86, 122);
            this.numericCropBottom.Name = "numericCropBottom";
            this.numericCropBottom.Size = new System.Drawing.Size(55, 21);
            this.numericCropBottom.TabIndex = 8;
            this.numericCropBottom.ValueChanged += new System.EventHandler(this.numericCropBottom_ValueChanged);
            this.numericCropBottom.Enter += new System.EventHandler(this.numericCropBottom_Enter);
            // 
            // numericCropRight
            // 
            this.numericCropRight.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericCropRight.Location = new System.Drawing.Point(86, 176);
            this.numericCropRight.Name = "numericCropRight";
            this.numericCropRight.Size = new System.Drawing.Size(55, 21);
            this.numericCropRight.TabIndex = 12;
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
            this.numericCropLeft.Location = new System.Drawing.Point(86, 149);
            this.numericCropLeft.Name = "numericCropLeft";
            this.numericCropLeft.Size = new System.Drawing.Size(55, 21);
            this.numericCropLeft.TabIndex = 10;
            this.numericCropLeft.ValueChanged += new System.EventHandler(this.numericCropLeft_ValueChanged);
            this.numericCropLeft.Enter += new System.EventHandler(this.numericCropLeft_Enter);
            // 
            // numericCropTop
            // 
            this.numericCropTop.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericCropTop.Location = new System.Drawing.Point(86, 95);
            this.numericCropTop.Name = "numericCropTop";
            this.numericCropTop.Size = new System.Drawing.Size(55, 21);
            this.numericCropTop.TabIndex = 6;
            this.numericCropTop.ValueChanged += new System.EventHandler(this.numericCropTop_ValueChanged);
            this.numericCropTop.Enter += new System.EventHandler(this.numericCropTop_Enter);
            // 
            // buttonSave
            // 
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonSave.Location = new System.Drawing.Point(0, 357);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(164, 27);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "ОК";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelTime
            // 
            this.labelTime.Location = new System.Drawing.Point(42, 34);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(83, 13);
            this.labelTime.TabIndex = 2;
            this.labelTime.Text = "00:00:00.000";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(47, 219);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 13;
            this.buttonReset.Text = "Сбросить";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // labelCrop
            // 
            this.labelCrop.AutoSize = true;
            this.labelCrop.Location = new System.Drawing.Point(3, 69);
            this.labelCrop.Name = "labelCrop";
            this.labelCrop.Size = new System.Drawing.Size(76, 13);
            this.labelCrop.TabIndex = 4;
            this.labelCrop.Text = "Указать поля";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(688, 390);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonReset);
            this.panel1.Controls.Add(this.buttonSave);
            this.panel1.Controls.Add(this.labelTime);
            this.panel1.Controls.Add(this.numericCropTop);
            this.panel1.Controls.Add(this.labelSelectFrame);
            this.panel1.Controls.Add(this.labelCropRight);
            this.panel1.Controls.Add(this.buttonFF);
            this.panel1.Controls.Add(this.labelCrop);
            this.panel1.Controls.Add(this.numericCropLeft);
            this.panel1.Controls.Add(this.buttonRew);
            this.panel1.Controls.Add(this.labelCropLeft);
            this.panel1.Controls.Add(this.labelCropBottom);
            this.panel1.Controls.Add(this.numericCropRight);
            this.panel1.Controls.Add(this.numericCropBottom);
            this.panel1.Controls.Add(this.labelCropTop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(521, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 384);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelLoading);
            this.panel2.Controls.Add(this.pictureBoxPreview);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(512, 384);
            this.panel2.TabIndex = 0;
            // 
            // CropForm
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 396);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(710, 435);
            this.Name = "CropForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Обрезать края";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CropForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CropForm_FormClosed);
            this.Load += new System.EventHandler(this.CropForm_Load);
            this.SizeChanged += new System.EventHandler(this.CropForm_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericCropTop)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Label labelSelectFrame;
        private System.Windows.Forms.Label labelCrop;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
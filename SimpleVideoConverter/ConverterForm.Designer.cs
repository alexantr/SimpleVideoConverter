namespace Alexantr.SimpleVideoConverter
{
    partial class ConverterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConverterForm));
            this.progressBarEncoding = new System.Windows.Forms.ProgressBar();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonPlay = new System.Windows.Forms.Button();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonToggleLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBarEncoding
            // 
            this.progressBarEncoding.Location = new System.Drawing.Point(6, 6);
            this.progressBarEncoding.Maximum = 1000;
            this.progressBarEncoding.Name = "progressBarEncoding";
            this.progressBarEncoding.Size = new System.Drawing.Size(612, 30);
            this.progressBarEncoding.TabIndex = 4;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(508, 42);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(110, 27);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(392, 42);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(110, 27);
            this.buttonPlay.TabIndex = 1;
            this.buttonPlay.Text = "Открыть файл";
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBoxOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxOutput.Location = new System.Drawing.Point(6, 76);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxOutput.Size = new System.Drawing.Size(612, 279);
            this.richTextBoxOutput.TabIndex = 3;
            this.richTextBoxOutput.Text = "";
            this.richTextBoxOutput.TextChanged += new System.EventHandler(this.richTextBoxOutput_TextChanged);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(6, 49);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(19, 13);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "...";
            // 
            // buttonToggleLog
            // 
            this.buttonToggleLog.Location = new System.Drawing.Point(331, 42);
            this.buttonToggleLog.Name = "buttonToggleLog";
            this.buttonToggleLog.Size = new System.Drawing.Size(55, 27);
            this.buttonToggleLog.TabIndex = 2;
            this.buttonToggleLog.Text = "Лог";
            this.buttonToggleLog.UseVisualStyleBackColor = true;
            this.buttonToggleLog.Click += new System.EventHandler(this.buttonToggleLog_Click);
            // 
            // ConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 361);
            this.Controls.Add(this.buttonToggleLog);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.richTextBoxOutput);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.progressBarEncoding);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConverterForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Конвертирование";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConverterForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConverterForm_FormClosed);
            this.Load += new System.EventHandler(this.ConverterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarEncoding;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonPlay;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonToggleLog;
    }
}
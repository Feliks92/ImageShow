namespace ImageShow
{
    partial class ProgressBarForm
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
            this.ProgressB = new System.Windows.Forms.ProgressBar();
            this.PostepLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ProgressB
            // 
            this.ProgressB.Location = new System.Drawing.Point(12, 59);
            this.ProgressB.Name = "ProgressB";
            this.ProgressB.Size = new System.Drawing.Size(211, 34);
            this.ProgressB.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressB.TabIndex = 0;
            // 
            // PostepLabel
            // 
            this.PostepLabel.AutoSize = true;
            this.PostepLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PostepLabel.Location = new System.Drawing.Point(12, 20);
            this.PostepLabel.Name = "PostepLabel";
            this.PostepLabel.Size = new System.Drawing.Size(48, 13);
            this.PostepLabel.TabIndex = 1;
            this.PostepLabel.Text = "Progress";
            // 
            // ProgressBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 121);
            this.Controls.Add(this.PostepLabel);
            this.Controls.Add(this.ProgressB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProgressBarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressB;
        private System.Windows.Forms.Label PostepLabel;
    }
}
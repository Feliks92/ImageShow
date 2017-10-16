namespace ImageShow
{
    partial class MenuForm
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
            this.button_browse = new System.Windows.Forms.Button();
            this.button_show = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_browse
            // 
            this.button_browse.Location = new System.Drawing.Point(95, 85);
            this.button_browse.Name = "button_browse";
            this.button_browse.Size = new System.Drawing.Size(103, 41);
            this.button_browse.TabIndex = 3;
            this.button_browse.Text = "Browse...";
            this.button_browse.UseVisualStyleBackColor = true;
            this.button_browse.Click += new System.EventHandler(this.button_browse_click);
            // 
            // button_show
            // 
            this.button_show.Location = new System.Drawing.Point(95, 12);
            this.button_show.Name = "button_show";
            this.button_show.Size = new System.Drawing.Size(103, 41);
            this.button_show.TabIndex = 4;
            this.button_show.Text = "Show";
            this.button_show.UseVisualStyleBackColor = true;
            this.button_show.Click += new System.EventHandler(this.button_show_click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(95, 161);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(103, 41);
            this.button_delete.TabIndex = 5;
            this.button_delete.Text = "Delete";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 225);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_show);
            this.Controls.Add(this.button_browse);
            this.Name = "MenuForm";
            this.Text = "SlideShow";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_browse;
        private System.Windows.Forms.Button button_show;
        private System.Windows.Forms.Button button_delete;
    }
}


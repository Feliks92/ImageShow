namespace ImageShow
{
    partial class BrowseForm
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
            this.button_add = new System.Windows.Forms.Button();
            this.button_replace = new System.Windows.Forms.Button();
            this.Question = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(40, 72);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(95, 37);
            this.button_add.TabIndex = 0;
            this.button_add.Text = "Add";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_replace
            // 
            this.button_replace.Location = new System.Drawing.Point(226, 72);
            this.button_replace.Name = "button_replace";
            this.button_replace.Size = new System.Drawing.Size(95, 37);
            this.button_replace.TabIndex = 1;
            this.button_replace.Text = "Replace";
            this.button_replace.UseVisualStyleBackColor = true;
            this.button_replace.Click += new System.EventHandler(this.button_replace_Click);
            // 
            // Question
            // 
            this.Question.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Question.Location = new System.Drawing.Point(12, 9);
            this.Question.Name = "Question";
            this.Question.Size = new System.Drawing.Size(341, 60);
            this.Question.TabIndex = 2;
            this.Question.Text = "Do you want to add images to DataBase or replace existing with the new ones ?";
            // 
            // BrowseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 138);
            this.Controls.Add(this.Question);
            this.Controls.Add(this.button_replace);
            this.Controls.Add(this.button_add);
            this.Name = "BrowseForm";
            this.Text = "Browse";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_replace;
        private System.Windows.Forms.Label Question;
    }
}
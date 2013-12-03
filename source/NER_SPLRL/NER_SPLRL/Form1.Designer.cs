namespace NER_SPLRL
{
    partial class Form1
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
            this.PersianLocationTaggerButton = new System.Windows.Forms.Button();
            this.SlovakLocationTaggerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PersianLocationTaggerButton
            // 
            this.PersianLocationTaggerButton.Location = new System.Drawing.Point(48, 40);
            this.PersianLocationTaggerButton.Name = "PersianLocationTaggerButton";
            this.PersianLocationTaggerButton.Size = new System.Drawing.Size(154, 36);
            this.PersianLocationTaggerButton.TabIndex = 0;
            this.PersianLocationTaggerButton.Text = "PersianLocationTagger";
            this.PersianLocationTaggerButton.UseVisualStyleBackColor = true;
            this.PersianLocationTaggerButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // SlovakLocationTaggerButton
            // 
            this.SlovakLocationTaggerButton.Location = new System.Drawing.Point(48, 107);
            this.SlovakLocationTaggerButton.Name = "SlovakLocationTaggerButton";
            this.SlovakLocationTaggerButton.Size = new System.Drawing.Size(154, 37);
            this.SlovakLocationTaggerButton.TabIndex = 1;
            this.SlovakLocationTaggerButton.Text = "SlovakLocationTagger";
            this.SlovakLocationTaggerButton.UseVisualStyleBackColor = true;
            this.SlovakLocationTaggerButton.Click += new System.EventHandler(this.SlovakLocationTaggerButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.SlovakLocationTaggerButton);
            this.Controls.Add(this.PersianLocationTaggerButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PersianLocationTaggerButton;
        private System.Windows.Forms.Button SlovakLocationTaggerButton;
    }
}
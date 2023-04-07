namespace AlgorithmsLab4_WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listEditButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listEditButton
            // 
            this.listEditButton.Location = new System.Drawing.Point(12, 12);
            this.listEditButton.Name = "listEditButton";
            this.listEditButton.Size = new System.Drawing.Size(342, 29);
            this.listEditButton.TabIndex = 0;
            this.listEditButton.Text = "Редагувати списки";
            this.listEditButton.UseVisualStyleBackColor = true;
            this.listEditButton.Click += new System.EventHandler(this.listEditButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listEditButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button listEditButton;
    }
}
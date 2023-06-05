namespace AlgorithmsLab8_WinForms
{
    partial class FormMain
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
            button1 = new Button();
            button2 = new Button();
            textBoxLess = new TextBox();
            textBoxGreater = new TextBox();
            textBoxCount = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(12, 144);
            button1.Name = "button1";
            button1.Size = new Size(155, 52);
            button1.TabIndex = 0;
            button1.TabStop = false;
            button1.Text = "AVL tree";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(254, 144);
            button2.Name = "button2";
            button2.Size = new Size(155, 52);
            button2.TabIndex = 1;
            button2.TabStop = false;
            button2.Text = "Red-black tree";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBoxLess
            // 
            textBoxLess.Location = new Point(12, 12);
            textBoxLess.Name = "textBoxLess";
            textBoxLess.Size = new Size(125, 27);
            textBoxLess.TabIndex = 2;
            // 
            // textBoxGreater
            // 
            textBoxGreater.Location = new Point(284, 12);
            textBoxGreater.Name = "textBoxGreater";
            textBoxGreater.Size = new Size(125, 27);
            textBoxGreater.TabIndex = 3;
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(151, 108);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(125, 27);
            textBoxCount.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(151, 8);
            label1.Name = "label1";
            label1.Size = new Size(120, 28);
            label1.TabIndex = 5;
            label1.Text = "< element <";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(161, 85);
            label2.Name = "label2";
            label2.Size = new Size(110, 20);
            label2.TabIndex = 6;
            label2.Text = "Elements count";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(421, 208);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxCount);
            Controls.Add(textBoxGreater);
            Controls.Add(textBoxLess);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "FormMain";
            Text = "FormMain";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBoxLess;
        private TextBox textBoxGreater;
        private TextBox textBoxCount;
        private Label label1;
        private Label label2;
    }
}
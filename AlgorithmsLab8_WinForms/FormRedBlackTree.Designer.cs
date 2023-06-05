namespace AlgorithmsLab8_WinForms
{
    partial class FormRedBlackTree
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
            panel1 = new Panel();
            labelTimer = new Label();
            buttonAdd = new Button();
            textBoxData = new TextBox();
            buttonRemove = new Button();
            buttonFind = new Button();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Location = new Point(12, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(536, 488);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // labelTimer
            // 
            labelTimer.AutoSize = true;
            labelTimer.Location = new Point(467, 10);
            labelTimer.Name = "labelTimer";
            labelTimer.Size = new Size(0, 20);
            labelTimer.TabIndex = 2;
            labelTimer.Click += labelTimer_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(125, 5);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(108, 29);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // textBoxData
            // 
            textBoxData.Location = new Point(11, 5);
            textBoxData.Name = "textBoxData";
            textBoxData.Size = new Size(108, 27);
            textBoxData.TabIndex = 4;
            textBoxData.TextChanged += textBoxData_TextChanged;
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new Point(239, 6);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(108, 29);
            buttonRemove.TabIndex = 5;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // buttonFind
            // 
            buttonFind.Location = new Point(353, 6);
            buttonFind.Name = "buttonFind";
            buttonFind.Size = new Size(108, 29);
            buttonFind.TabIndex = 6;
            buttonFind.Text = "Find";
            buttonFind.UseVisualStyleBackColor = true;
            buttonFind.Click += buttonFind_Click;
            // 
            // FormRedBlackTree
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(560, 540);
            Controls.Add(textBoxData);
            Controls.Add(buttonFind);
            Controls.Add(buttonRemove);
            Controls.Add(buttonAdd);
            Controls.Add(labelTimer);
            Controls.Add(panel1);
            MinimumSize = new Size(578, 587);
            Name = "FormRedBlackTree";
            Text = "FormRedBlackTree";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label labelTimer;
        private Button buttonAdd;
        private TextBox textBoxData;
        private Button buttonRemove;
        private Button buttonFind;
    }
}
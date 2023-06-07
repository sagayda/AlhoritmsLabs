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
            panel2 = new Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Location = new Point(3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(0, 0);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // labelTimer
            // 
            labelTimer.AutoSize = true;
            labelTimer.BackColor = SystemColors.Control;
            labelTimer.FlatStyle = FlatStyle.Flat;
            labelTimer.Location = new Point(467, 10);
            labelTimer.Name = "labelTimer";
            labelTimer.Size = new Size(0, 20);
            labelTimer.TabIndex = 2;
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = SystemColors.Control;
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.Location = new Point(125, 5);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(108, 29);
            buttonAdd.TabIndex = 3;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // textBoxData
            // 
            textBoxData.Location = new Point(11, 5);
            textBoxData.Name = "textBoxData";
            textBoxData.Size = new Size(108, 27);
            textBoxData.TabIndex = 4;
            // 
            // buttonRemove
            // 
            buttonRemove.BackColor = SystemColors.Control;
            buttonRemove.FlatStyle = FlatStyle.Flat;
            buttonRemove.Location = new Point(239, 6);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(108, 29);
            buttonRemove.TabIndex = 5;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = false;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // buttonFind
            // 
            buttonFind.BackColor = SystemColors.Control;
            buttonFind.FlatStyle = FlatStyle.Flat;
            buttonFind.Location = new Point(353, 6);
            buttonFind.Name = "buttonFind";
            buttonFind.Size = new Size(108, 29);
            buttonFind.TabIndex = 6;
            buttonFind.Text = "Find";
            buttonFind.UseVisualStyleBackColor = false;
            buttonFind.Click += buttonFind_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.AutoScroll = true;
            panel2.Controls.Add(panel1);
            panel2.Location = new Point(12, 38);
            panel2.Name = "panel2";
            panel2.Size = new Size(534, 489);
            panel2.TabIndex = 7;
            // 
            // FormRedBlackTree
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(560, 540);
            Controls.Add(textBoxData);
            Controls.Add(buttonFind);
            Controls.Add(buttonRemove);
            Controls.Add(buttonAdd);
            Controls.Add(labelTimer);
            Controls.Add(panel2);
            MinimumSize = new Size(578, 587);
            Name = "FormRedBlackTree";
            Text = "FormRedBlackTree";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Panel panel2;
    }
}
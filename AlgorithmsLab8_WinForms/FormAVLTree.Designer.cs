﻿namespace AlgorithmsLab8_WinForms
{
    partial class FormAVLTree
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
            panel1 = new Panel();
            textBoxData = new TextBox();
            buttonFind = new Button();
            buttonRemove = new Button();
            buttonAdd = new Button();
            labelTimer = new Label();
            panel2 = new Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.BackColor = SystemColors.GradientActiveCaption;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(0, 0);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // textBoxData
            // 
            textBoxData.Location = new Point(12, 6);
            textBoxData.Name = "textBoxData";
            textBoxData.Size = new Size(108, 27);
            textBoxData.TabIndex = 9;
            // 
            // buttonFind
            // 
            buttonFind.BackColor = SystemColors.Control;
            buttonFind.FlatStyle = FlatStyle.Flat;
            buttonFind.Location = new Point(354, 7);
            buttonFind.Name = "buttonFind";
            buttonFind.Size = new Size(108, 29);
            buttonFind.TabIndex = 11;
            buttonFind.Text = "Find";
            buttonFind.UseVisualStyleBackColor = false;
            buttonFind.Click += buttonFind_Click;
            // 
            // buttonRemove
            // 
            buttonRemove.BackColor = SystemColors.Control;
            buttonRemove.FlatStyle = FlatStyle.Flat;
            buttonRemove.Location = new Point(240, 7);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(108, 29);
            buttonRemove.TabIndex = 10;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = false;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // buttonAdd
            // 
            buttonAdd.BackColor = SystemColors.Control;
            buttonAdd.FlatStyle = FlatStyle.Flat;
            buttonAdd.Location = new Point(126, 6);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(108, 29);
            buttonAdd.TabIndex = 8;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = false;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // labelTimer
            // 
            labelTimer.AutoSize = true;
            labelTimer.BackColor = SystemColors.Control;
            labelTimer.FlatStyle = FlatStyle.Flat;
            labelTimer.Location = new Point(468, 11);
            labelTimer.Name = "labelTimer";
            labelTimer.Size = new Size(0, 20);
            labelTimer.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.AutoScroll = true;
            panel2.Controls.Add(panel1);
            panel2.Location = new Point(12, 42);
            panel2.Name = "panel2";
            panel2.Size = new Size(534, 482);
            panel2.TabIndex = 12;
            // 
            // FormAVLTree
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(558, 536);
            Controls.Add(textBoxData);
            Controls.Add(buttonFind);
            Controls.Add(buttonRemove);
            Controls.Add(buttonAdd);
            Controls.Add(labelTimer);
            Controls.Add(panel2);
            MinimumSize = new Size(576, 583);
            Name = "FormAVLTree";
            Text = "FormAVLTree";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox textBoxData;
        private Button buttonFind;
        private Button buttonRemove;
        private Button buttonAdd;
        private Label labelTimer;
        private Panel panel2;
    }
}
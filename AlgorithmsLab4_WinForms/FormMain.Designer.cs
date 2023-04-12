namespace AlgorithmsLab4_WinForms
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.listEditButton = new System.Windows.Forms.Button();
            this.studentsMainComboBox = new System.Windows.Forms.ComboBox();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.addToQueueButton = new System.Windows.Forms.Button();
            this.removeFromQueueButton = new System.Windows.Forms.Button();
            this.queueByArrayListBox = new System.Windows.Forms.ListBox();
            this.queueByIndexListBox = new System.Windows.Forms.ListBox();
            this.gradeTextBox = new System.Windows.Forms.TextBox();
            this.gradeInQueueTextBox = new System.Windows.Forms.TextBox();
            this.studentInQueueTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.restoreQueueButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // listEditButton
            // 
            this.listEditButton.Location = new System.Drawing.Point(12, 431);
            this.listEditButton.Name = "listEditButton";
            this.listEditButton.Size = new System.Drawing.Size(706, 29);
            this.listEditButton.TabIndex = 0;
            this.listEditButton.Text = "Редагувати списки";
            this.listEditButton.UseVisualStyleBackColor = true;
            this.listEditButton.Click += new System.EventHandler(this.listEditButton_Click);
            // 
            // studentsMainComboBox
            // 
            this.studentsMainComboBox.FormattingEnabled = true;
            this.studentsMainComboBox.Location = new System.Drawing.Point(12, 34);
            this.studentsMainComboBox.Name = "studentsMainComboBox";
            this.studentsMainComboBox.Size = new System.Drawing.Size(579, 28);
            this.studentsMainComboBox.TabIndex = 1;
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataSource = typeof(AlgorithmsLab4_WinForms.Student);
            // 
            // studentsBindingSource
            // 
            this.studentsBindingSource.DataSource = typeof(AlgorithmsLab4_WinForms.Students);
            // 
            // addToQueueButton
            // 
            this.addToQueueButton.Location = new System.Drawing.Point(12, 68);
            this.addToQueueButton.Name = "addToQueueButton";
            this.addToQueueButton.Size = new System.Drawing.Size(579, 29);
            this.addToQueueButton.TabIndex = 2;
            this.addToQueueButton.Text = "Додати до черги";
            this.addToQueueButton.UseVisualStyleBackColor = true;
            this.addToQueueButton.Click += new System.EventHandler(this.addToQueueButton_Click);
            // 
            // removeFromQueueButton
            // 
            this.removeFromQueueButton.Location = new System.Drawing.Point(12, 346);
            this.removeFromQueueButton.Name = "removeFromQueueButton";
            this.removeFromQueueButton.Size = new System.Drawing.Size(706, 29);
            this.removeFromQueueButton.TabIndex = 3;
            this.removeFromQueueButton.Text = "Зняти з черги";
            this.removeFromQueueButton.UseVisualStyleBackColor = true;
            this.removeFromQueueButton.Click += new System.EventHandler(this.removeFromQueueButton_Click);
            // 
            // queueByArrayListBox
            // 
            this.queueByArrayListBox.FormattingEnabled = true;
            this.queueByArrayListBox.ItemHeight = 20;
            this.queueByArrayListBox.Location = new System.Drawing.Point(12, 103);
            this.queueByArrayListBox.Name = "queueByArrayListBox";
            this.queueByArrayListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.queueByArrayListBox.Size = new System.Drawing.Size(350, 204);
            this.queueByArrayListBox.TabIndex = 4;
            // 
            // queueByIndexListBox
            // 
            this.queueByIndexListBox.FormattingEnabled = true;
            this.queueByIndexListBox.ItemHeight = 20;
            this.queueByIndexListBox.Location = new System.Drawing.Point(368, 103);
            this.queueByIndexListBox.Name = "queueByIndexListBox";
            this.queueByIndexListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.queueByIndexListBox.Size = new System.Drawing.Size(350, 204);
            this.queueByIndexListBox.TabIndex = 5;
            // 
            // gradeTextBox
            // 
            this.gradeTextBox.Location = new System.Drawing.Point(597, 70);
            this.gradeTextBox.Name = "gradeTextBox";
            this.gradeTextBox.Size = new System.Drawing.Size(117, 27);
            this.gradeTextBox.TabIndex = 6;
            // 
            // gradeInQueueTextBox
            // 
            this.gradeInQueueTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.gradeInQueueTextBox.Location = new System.Drawing.Point(601, 313);
            this.gradeInQueueTextBox.Name = "gradeInQueueTextBox";
            this.gradeInQueueTextBox.ReadOnly = true;
            this.gradeInQueueTextBox.Size = new System.Drawing.Size(117, 27);
            this.gradeInQueueTextBox.TabIndex = 7;
            this.gradeInQueueTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // studentInQueueTextBox
            // 
            this.studentInQueueTextBox.Location = new System.Drawing.Point(12, 313);
            this.studentInQueueTextBox.Name = "studentInQueueTextBox";
            this.studentInQueueTextBox.ReadOnly = true;
            this.studentInQueueTextBox.Size = new System.Drawing.Size(583, 27);
            this.studentInQueueTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Виберіть студента";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(597, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Введіть оцінку";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(12, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(442, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "УВАГА! При редагуванні списку актуальна черга буде скинута!";
            // 
            // restoreQueueButton
            // 
            this.restoreQueueButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.restoreQueueButton.FlatAppearance.BorderSize = 0;
            this.restoreQueueButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restoreQueueButton.Location = new System.Drawing.Point(293, 466);
            this.restoreQueueButton.Name = "restoreQueueButton";
            this.restoreQueueButton.Size = new System.Drawing.Size(150, 29);
            this.restoreQueueButton.TabIndex = 12;
            this.restoreQueueButton.Text = "Скинути чергу";
            this.restoreQueueButton.UseVisualStyleBackColor = true;
            this.restoreQueueButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 505);
            this.Controls.Add(this.restoreQueueButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.studentInQueueTextBox);
            this.Controls.Add(this.gradeInQueueTextBox);
            this.Controls.Add(this.gradeTextBox);
            this.Controls.Add(this.queueByIndexListBox);
            this.Controls.Add(this.queueByArrayListBox);
            this.Controls.Add(this.removeFromQueueButton);
            this.Controls.Add(this.addToQueueButton);
            this.Controls.Add(this.studentsMainComboBox);
            this.Controls.Add(this.listEditButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Перевірка";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button listEditButton;
        private ComboBox studentsMainComboBox;
        private BindingSource studentBindingSource;
        private BindingSource studentsBindingSource;
        private Button addToQueueButton;
        private Button removeFromQueueButton;
        private ListBox queueByArrayListBox;
        private ListBox queueByIndexListBox;
        private TextBox gradeTextBox;
        private TextBox gradeInQueueTextBox;
        private TextBox studentInQueueTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button restoreQueueButton;
    }
}
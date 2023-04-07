namespace AlgorithmsLab4_WinForms
{
    partial class ListEditingForm
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
            this.components = new System.ComponentModel.Container();
            this.sexComboBox = new System.Windows.Forms.ComboBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.studentAddButton = new System.Windows.Forms.Button();
            this.groupComboBox = new System.Windows.Forms.ComboBox();
            this.studentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.serializeButton = new System.Windows.Forms.Button();
            this.studentsListView = new System.Windows.Forms.ListView();
            this.studentRemoveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sexComboBox
            // 
            this.sexComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sexComboBox.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.sexComboBox.Location = new System.Drawing.Point(410, 176);
            this.sexComboBox.Name = "sexComboBox";
            this.sexComboBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.sexComboBox.Size = new System.Drawing.Size(378, 28);
            this.sexComboBox.TabIndex = 1;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(410, 46);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(378, 27);
            this.nameTextBox.TabIndex = 2;
            // 
            // studentAddButton
            // 
            this.studentAddButton.Location = new System.Drawing.Point(410, 311);
            this.studentAddButton.Name = "studentAddButton";
            this.studentAddButton.Size = new System.Drawing.Size(184, 29);
            this.studentAddButton.TabIndex = 5;
            this.studentAddButton.Text = "Add";
            this.studentAddButton.UseVisualStyleBackColor = true;
            this.studentAddButton.Click += new System.EventHandler(this.studentAddButton_Click);
            // 
            // groupComboBox
            // 
            this.groupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Items.AddRange(new object[] {
            "ІС-21",
            "ІС-22",
            "ІС-23"});
            this.groupComboBox.Location = new System.Drawing.Point(410, 112);
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(378, 28);
            this.groupComboBox.TabIndex = 7;
            // 
            // studentsBindingSource
            // 
            this.studentsBindingSource.DataSource = typeof(AlgorithmsLab4_WinForms.Students);
            // 
            // serializeButton
            // 
            this.serializeButton.Location = new System.Drawing.Point(410, 356);
            this.serializeButton.Name = "serializeButton";
            this.serializeButton.Size = new System.Drawing.Size(378, 29);
            this.serializeButton.TabIndex = 9;
            this.serializeButton.Text = "Save";
            this.serializeButton.UseVisualStyleBackColor = true;
            this.serializeButton.Click += new System.EventHandler(this.serializeButton_Click);
            // 
            // studentsListView
            // 
            this.studentsListView.Location = new System.Drawing.Point(12, 13);
            this.studentsListView.Name = "studentsListView";
            this.studentsListView.Size = new System.Drawing.Size(392, 425);
            this.studentsListView.TabIndex = 10;
            this.studentsListView.UseCompatibleStateImageBehavior = false;
            this.studentsListView.View = System.Windows.Forms.View.List;
            // 
            // studentRemoveButton
            // 
            this.studentRemoveButton.Location = new System.Drawing.Point(600, 311);
            this.studentRemoveButton.Name = "studentRemoveButton";
            this.studentRemoveButton.Size = new System.Drawing.Size(188, 29);
            this.studentRemoveButton.TabIndex = 11;
            this.studentRemoveButton.Text = "Remove";
            this.studentRemoveButton.UseVisualStyleBackColor = true;
            this.studentRemoveButton.Click += new System.EventHandler(this.studentRemoveButton_Click);
            // 
            // ListEditingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.studentRemoveButton);
            this.Controls.Add(this.studentsListView);
            this.Controls.Add(this.serializeButton);
            this.Controls.Add(this.groupComboBox);
            this.Controls.Add(this.studentAddButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.sexComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ListEditingForm";
            this.Text = "ListEditingForm";
            this.Load += new System.EventHandler(this.ListEditingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.studentsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComboBox sexComboBox;
        private TextBox nameTextBox;
        private Button studentAddButton;
        private ComboBox groupComboBox;
        private BindingSource studentsBindingSource;
        private Button serializeButton;
        private ListView studentsListView;
        private Button studentRemoveButton;
    }
}
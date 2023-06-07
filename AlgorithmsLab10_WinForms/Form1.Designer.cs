namespace AlgorithmsLab10_WinForms
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
            dataGridViewFleet = new DataGridView();
            crewSize = new DataGridViewTextBoxColumn();
            comboBoxFleet = new ComboBox();
            dataGridViewSortedFleet = new DataGridView();
            crewSizeSorted = new DataGridViewTextBoxColumn();
            button1 = new Button();
            button2 = new Button();
            buttonAddFleet = new Button();
            comboBoxSortingAlgoritm = new ComboBox();
            labelTime = new Label();
            checkBoxOptimize = new CheckBox();
            numericTimesToSort = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFleet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSortedFleet).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericTimesToSort).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewFleet
            // 
            dataGridViewFleet.AllowUserToAddRows = false;
            dataGridViewFleet.AllowUserToDeleteRows = false;
            dataGridViewFleet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFleet.Columns.AddRange(new DataGridViewColumn[] { crewSize });
            dataGridViewFleet.Location = new Point(12, 45);
            dataGridViewFleet.Name = "dataGridViewFleet";
            dataGridViewFleet.ReadOnly = true;
            dataGridViewFleet.RowHeadersWidth = 51;
            dataGridViewFleet.RowTemplate.Height = 29;
            dataGridViewFleet.Size = new Size(344, 462);
            dataGridViewFleet.TabIndex = 0;
            // 
            // crewSize
            // 
            crewSize.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            crewSize.HeaderText = "Crew size";
            crewSize.MinimumWidth = 6;
            crewSize.Name = "crewSize";
            crewSize.ReadOnly = true;
            crewSize.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // comboBoxFleet
            // 
            comboBoxFleet.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFleet.FormattingEnabled = true;
            comboBoxFleet.Location = new Point(12, 11);
            comboBoxFleet.Name = "comboBoxFleet";
            comboBoxFleet.Size = new Size(344, 28);
            comboBoxFleet.TabIndex = 1;
            comboBoxFleet.SelectedIndexChanged += comboBoxFleet_SelectedIndexChanged;
            // 
            // dataGridViewSortedFleet
            // 
            dataGridViewSortedFleet.AllowUserToAddRows = false;
            dataGridViewSortedFleet.AllowUserToDeleteRows = false;
            dataGridViewSortedFleet.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSortedFleet.Columns.AddRange(new DataGridViewColumn[] { crewSizeSorted });
            dataGridViewSortedFleet.Location = new Point(656, 45);
            dataGridViewSortedFleet.Name = "dataGridViewSortedFleet";
            dataGridViewSortedFleet.ReadOnly = true;
            dataGridViewSortedFleet.RowHeadersWidth = 51;
            dataGridViewSortedFleet.RowTemplate.Height = 29;
            dataGridViewSortedFleet.Size = new Size(344, 462);
            dataGridViewSortedFleet.TabIndex = 2;
            // 
            // crewSizeSorted
            // 
            crewSizeSorted.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            crewSizeSorted.HeaderText = "Crew size";
            crewSizeSorted.MinimumWidth = 6;
            crewSizeSorted.Name = "crewSizeSorted";
            crewSizeSorted.ReadOnly = true;
            crewSizeSorted.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // button1
            // 
            button1.Location = new Point(391, 97);
            button1.Name = "button1";
            button1.Size = new Size(219, 29);
            button1.TabIndex = 3;
            button1.Text = ">>>";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(391, 430);
            button2.Name = "button2";
            button2.Size = new Size(219, 29);
            button2.TabIndex = 4;
            button2.Text = "<<<";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // buttonAddFleet
            // 
            buttonAddFleet.Location = new Point(12, 513);
            buttonAddFleet.Name = "buttonAddFleet";
            buttonAddFleet.Size = new Size(344, 29);
            buttonAddFleet.TabIndex = 5;
            buttonAddFleet.Text = "Add fleet";
            buttonAddFleet.UseVisualStyleBackColor = true;
            buttonAddFleet.Click += buttonAddFleet_Click;
            // 
            // comboBoxSortingAlgoritm
            // 
            comboBoxSortingAlgoritm.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSortingAlgoritm.FormattingEnabled = true;
            comboBoxSortingAlgoritm.Items.AddRange(new object[] { "QuickSort", "QuickSort (repeats)", "QuickSort (particaly sort)", "Heapsort", "Smooth sort" });
            comboBoxSortingAlgoritm.Location = new Point(391, 260);
            comboBoxSortingAlgoritm.Name = "comboBoxSortingAlgoritm";
            comboBoxSortingAlgoritm.Size = new Size(219, 28);
            comboBoxSortingAlgoritm.TabIndex = 6;
            // 
            // labelTime
            // 
            labelTime.AutoSize = true;
            labelTime.Location = new Point(391, 237);
            labelTime.Name = "labelTime";
            labelTime.Size = new Size(17, 20);
            labelTime.TabIndex = 7;
            labelTime.Text = "0";
            // 
            // checkBoxOptimize
            // 
            checkBoxOptimize.AutoSize = true;
            checkBoxOptimize.Checked = true;
            checkBoxOptimize.CheckState = CheckState.Checked;
            checkBoxOptimize.Location = new Point(656, 15);
            checkBoxOptimize.Name = "checkBoxOptimize";
            checkBoxOptimize.Size = new Size(110, 24);
            checkBoxOptimize.TabIndex = 9;
            checkBoxOptimize.Text = "Optimize UI";
            checkBoxOptimize.UseVisualStyleBackColor = true;
            // 
            // numericTimesToSort
            // 
            numericTimesToSort.Location = new Point(391, 132);
            numericTimesToSort.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericTimesToSort.Name = "numericTimesToSort";
            numericTimesToSort.Size = new Size(219, 27);
            numericTimesToSort.TabIndex = 10;
            numericTimesToSort.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1017, 551);
            Controls.Add(numericTimesToSort);
            Controls.Add(checkBoxOptimize);
            Controls.Add(labelTime);
            Controls.Add(comboBoxSortingAlgoritm);
            Controls.Add(buttonAddFleet);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridViewSortedFleet);
            Controls.Add(comboBoxFleet);
            Controls.Add(dataGridViewFleet);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridViewFleet).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSortedFleet).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericTimesToSort).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewFleet;
        private ComboBox comboBoxFleet;
        private DataGridView dataGridViewSortedFleet;
        private Button button1;
        private Button button2;
        private Button buttonAddFleet;
        private ComboBox comboBoxSortingAlgoritm;
        private Label labelTime;
        private CheckBox checkBoxOptimize;
        private NumericUpDown numericTimesToSort;
        private DataGridViewTextBoxColumn crewSize;
        private DataGridViewTextBoxColumn crewSizeSorted;
    }
}
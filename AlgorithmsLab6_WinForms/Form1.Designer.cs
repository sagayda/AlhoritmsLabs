namespace AlgorithmsLab6_WinForms
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
            buttonCreateTables = new Button();
            buttonInsert = new Button();
            buttonSearch = new Button();
            buttonDelete = new Button();
            buttonExtract = new Button();
            textBoxSize = new TextBox();
            textBoxInsertValue = new TextBox();
            textBoxInsertKey = new TextBox();
            textBoxFindKey = new TextBox();
            textBoxFindValueDouble = new TextBox();
            textBoxDeleteKey = new TextBox();
            textBoxExtractKey = new TextBox();
            textBoxExtractValueDouble = new TextBox();
            textBoxFindValueLinear = new TextBox();
            dataGridViewDouble = new DataGridView();
            dataGridViewLinear = new DataGridView();
            textBoxExtractValueLinear = new TextBox();
            label1 = new Label();
            dataGridViewQuad = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            textBoxFindValueQuad = new TextBox();
            textBoxExtractValueQuad = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDouble).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLinear).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQuad).BeginInit();
            SuspendLayout();
            // 
            // buttonCreateTables
            // 
            buttonCreateTables.Location = new Point(12, 10);
            buttonCreateTables.Name = "buttonCreateTables";
            buttonCreateTables.Size = new Size(119, 29);
            buttonCreateTables.TabIndex = 3;
            buttonCreateTables.TabStop = false;
            buttonCreateTables.Text = "Create tables";
            buttonCreateTables.UseVisualStyleBackColor = true;
            buttonCreateTables.Click += buttonCreateTables_Click;
            // 
            // buttonInsert
            // 
            buttonInsert.Location = new Point(813, 55);
            buttonInsert.Name = "buttonInsert";
            buttonInsert.Size = new Size(359, 29);
            buttonInsert.TabIndex = 4;
            buttonInsert.TabStop = false;
            buttonInsert.Text = "Insert";
            buttonInsert.UseVisualStyleBackColor = true;
            buttonInsert.Click += buttonInsert_Click;
            // 
            // buttonSearch
            // 
            buttonSearch.Location = new Point(813, 142);
            buttonSearch.Name = "buttonSearch";
            buttonSearch.Size = new Size(361, 29);
            buttonSearch.TabIndex = 5;
            buttonSearch.TabStop = false;
            buttonSearch.Text = "Find";
            buttonSearch.UseVisualStyleBackColor = true;
            buttonSearch.Click += buttonSearch_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(813, 264);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(361, 29);
            buttonDelete.TabIndex = 6;
            buttonDelete.TabStop = false;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonExtract
            // 
            buttonExtract.Location = new Point(813, 346);
            buttonExtract.Name = "buttonExtract";
            buttonExtract.Size = new Size(361, 29);
            buttonExtract.TabIndex = 7;
            buttonExtract.TabStop = false;
            buttonExtract.Text = "Extract";
            buttonExtract.UseVisualStyleBackColor = true;
            buttonExtract.Click += buttonExtract_Click;
            // 
            // textBoxSize
            // 
            textBoxSize.Location = new Point(137, 12);
            textBoxSize.Name = "textBoxSize";
            textBoxSize.Size = new Size(125, 27);
            textBoxSize.TabIndex = 8;
            textBoxSize.TabStop = false;
            // 
            // textBoxInsertValue
            // 
            textBoxInsertValue.Location = new Point(1047, 90);
            textBoxInsertValue.Name = "textBoxInsertValue";
            textBoxInsertValue.Size = new Size(125, 27);
            textBoxInsertValue.TabIndex = 9;
            textBoxInsertValue.TabStop = false;
            // 
            // textBoxInsertKey
            // 
            textBoxInsertKey.Location = new Point(813, 90);
            textBoxInsertKey.Name = "textBoxInsertKey";
            textBoxInsertKey.Size = new Size(228, 27);
            textBoxInsertKey.TabIndex = 10;
            textBoxInsertKey.TabStop = false;
            // 
            // textBoxFindKey
            // 
            textBoxFindKey.Location = new Point(813, 177);
            textBoxFindKey.Name = "textBoxFindKey";
            textBoxFindKey.Size = new Size(361, 27);
            textBoxFindKey.TabIndex = 11;
            textBoxFindKey.TabStop = false;
            // 
            // textBoxFindValueDouble
            // 
            textBoxFindValueDouble.Location = new Point(813, 210);
            textBoxFindValueDouble.Name = "textBoxFindValueDouble";
            textBoxFindValueDouble.ReadOnly = true;
            textBoxFindValueDouble.Size = new Size(120, 27);
            textBoxFindValueDouble.TabIndex = 12;
            textBoxFindValueDouble.TabStop = false;
            // 
            // textBoxDeleteKey
            // 
            textBoxDeleteKey.Location = new Point(813, 299);
            textBoxDeleteKey.Name = "textBoxDeleteKey";
            textBoxDeleteKey.Size = new Size(361, 27);
            textBoxDeleteKey.TabIndex = 13;
            textBoxDeleteKey.TabStop = false;
            // 
            // textBoxExtractKey
            // 
            textBoxExtractKey.Location = new Point(813, 381);
            textBoxExtractKey.Name = "textBoxExtractKey";
            textBoxExtractKey.Size = new Size(361, 27);
            textBoxExtractKey.TabIndex = 14;
            textBoxExtractKey.TabStop = false;
            // 
            // textBoxExtractValueDouble
            // 
            textBoxExtractValueDouble.Location = new Point(813, 414);
            textBoxExtractValueDouble.Name = "textBoxExtractValueDouble";
            textBoxExtractValueDouble.ReadOnly = true;
            textBoxExtractValueDouble.Size = new Size(120, 27);
            textBoxExtractValueDouble.TabIndex = 15;
            textBoxExtractValueDouble.TabStop = false;
            // 
            // textBoxFindValueLinear
            // 
            textBoxFindValueLinear.Location = new Point(939, 210);
            textBoxFindValueLinear.Name = "textBoxFindValueLinear";
            textBoxFindValueLinear.ReadOnly = true;
            textBoxFindValueLinear.Size = new Size(121, 27);
            textBoxFindValueLinear.TabIndex = 17;
            textBoxFindValueLinear.TabStop = false;
            // 
            // dataGridViewDouble
            // 
            dataGridViewDouble.AllowUserToAddRows = false;
            dataGridViewDouble.AllowUserToDeleteRows = false;
            dataGridViewDouble.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDouble.Location = new Point(12, 90);
            dataGridViewDouble.Name = "dataGridViewDouble";
            dataGridViewDouble.ReadOnly = true;
            dataGridViewDouble.RowHeadersWidth = 51;
            dataGridViewDouble.RowTemplate.Height = 29;
            dataGridViewDouble.Size = new Size(250, 351);
            dataGridViewDouble.TabIndex = 18;
            // 
            // dataGridViewLinear
            // 
            dataGridViewLinear.AllowUserToAddRows = false;
            dataGridViewLinear.AllowUserToDeleteRows = false;
            dataGridViewLinear.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLinear.Location = new Point(268, 90);
            dataGridViewLinear.Name = "dataGridViewLinear";
            dataGridViewLinear.ReadOnly = true;
            dataGridViewLinear.RowHeadersWidth = 51;
            dataGridViewLinear.RowTemplate.Height = 29;
            dataGridViewLinear.Size = new Size(250, 351);
            dataGridViewLinear.TabIndex = 20;
            // 
            // textBoxExtractValueLinear
            // 
            textBoxExtractValueLinear.Location = new Point(939, 414);
            textBoxExtractValueLinear.Name = "textBoxExtractValueLinear";
            textBoxExtractValueLinear.ReadOnly = true;
            textBoxExtractValueLinear.Size = new Size(121, 27);
            textBoxExtractValueLinear.TabIndex = 22;
            textBoxExtractValueLinear.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 61);
            label1.Name = "label1";
            label1.Size = new Size(65, 23);
            label1.TabIndex = 23;
            label1.Text = "Double";
            // 
            // dataGridViewQuad
            // 
            dataGridViewQuad.AllowUserToAddRows = false;
            dataGridViewQuad.AllowUserToDeleteRows = false;
            dataGridViewQuad.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewQuad.Location = new Point(524, 90);
            dataGridViewQuad.Name = "dataGridViewQuad";
            dataGridViewQuad.ReadOnly = true;
            dataGridViewQuad.RowHeadersWidth = 51;
            dataGridViewQuad.RowTemplate.Height = 29;
            dataGridViewQuad.Size = new Size(250, 351);
            dataGridViewQuad.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(268, 61);
            label2.Name = "label2";
            label2.Size = new Size(56, 23);
            label2.TabIndex = 25;
            label2.Text = "Linear";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(524, 61);
            label3.Name = "label3";
            label3.Size = new Size(52, 23);
            label3.TabIndex = 26;
            label3.Text = "Quad";
            // 
            // textBoxFindValueQuad
            // 
            textBoxFindValueQuad.Location = new Point(1066, 210);
            textBoxFindValueQuad.Name = "textBoxFindValueQuad";
            textBoxFindValueQuad.ReadOnly = true;
            textBoxFindValueQuad.Size = new Size(108, 27);
            textBoxFindValueQuad.TabIndex = 27;
            textBoxFindValueQuad.TabStop = false;
            // 
            // textBoxExtractValueQuad
            // 
            textBoxExtractValueQuad.Location = new Point(1066, 414);
            textBoxExtractValueQuad.Name = "textBoxExtractValueQuad";
            textBoxExtractValueQuad.ReadOnly = true;
            textBoxExtractValueQuad.Size = new Size(106, 27);
            textBoxExtractValueQuad.TabIndex = 28;
            textBoxExtractValueQuad.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 453);
            Controls.Add(textBoxExtractValueQuad);
            Controls.Add(textBoxFindValueQuad);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dataGridViewQuad);
            Controls.Add(dataGridViewLinear);
            Controls.Add(dataGridViewDouble);
            Controls.Add(label1);
            Controls.Add(textBoxExtractValueLinear);
            Controls.Add(textBoxFindValueLinear);
            Controls.Add(textBoxExtractValueDouble);
            Controls.Add(textBoxExtractKey);
            Controls.Add(textBoxDeleteKey);
            Controls.Add(textBoxFindValueDouble);
            Controls.Add(textBoxFindKey);
            Controls.Add(textBoxInsertKey);
            Controls.Add(textBoxInsertValue);
            Controls.Add(textBoxSize);
            Controls.Add(buttonExtract);
            Controls.Add(buttonDelete);
            Controls.Add(buttonSearch);
            Controls.Add(buttonInsert);
            Controls.Add(buttonCreateTables);
            MaximumSize = new Size(1200, 900);
            MinimumSize = new Size(1200, 500);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDouble).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLinear).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQuad).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxDouble;
        private ListBox listBoxQuad;
        private ListBox listBoxLinear;
        private Button buttonCreateTables;
        private Button buttonInsert;
        private Button buttonSearch;
        private Button buttonDelete;
        private Button buttonExtract;
        private TextBox textBoxSize;
        private TextBox textBoxInsertValue;
        private TextBox textBoxInsertKey;
        private TextBox textBoxFindKey;
        private TextBox textBoxFindValueDouble;
        private TextBox textBoxDeleteKey;
        private TextBox textBoxExtractKey;
        private TextBox textBoxExtractValueDouble;
        private TextBox textBoxFindValueLinear;
        private DataGridView dataGridViewDouble;
        private DataGridView dataGridViewLinear;
        private TextBox textBoxExtractValueLinear;
        private Label label1;
        private DataGridView dataGridViewQuad;
        private Label label2;
        private Label label3;
        private TextBox textBoxFindValueQuad;
        private TextBox textBoxExtractValueQuad;
    }
}
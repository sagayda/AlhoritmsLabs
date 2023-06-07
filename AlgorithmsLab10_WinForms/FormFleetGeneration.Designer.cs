namespace AlgorithmsLab10_WinForms
{
    partial class FormFleetGeneration
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
            numericCrewFloor = new NumericUpDown();
            numericCrewCeil = new NumericUpDown();
            numericUniqueness = new NumericUpDown();
            buttonCreateMultiple = new Button();
            numericFleetsCount = new NumericUpDown();
            numericShipsCount = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            buttonClearFleets = new Button();
            numericSortingFactor = new NumericUpDown();
            label5 = new Label();
            textBoxName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericCrewFloor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCrewCeil).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUniqueness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericFleetsCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericShipsCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericSortingFactor).BeginInit();
            SuspendLayout();
            // 
            // numericCrewFloor
            // 
            numericCrewFloor.Location = new Point(12, 29);
            numericCrewFloor.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericCrewFloor.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericCrewFloor.Name = "numericCrewFloor";
            numericCrewFloor.Size = new Size(150, 27);
            numericCrewFloor.TabIndex = 2;
            numericCrewFloor.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericCrewCeil
            // 
            numericCrewCeil.Location = new Point(335, 29);
            numericCrewCeil.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            numericCrewCeil.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericCrewCeil.Name = "numericCrewCeil";
            numericCrewCeil.Size = new Size(154, 27);
            numericCrewCeil.TabIndex = 3;
            numericCrewCeil.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // numericUniqueness
            // 
            numericUniqueness.DecimalPlaces = 4;
            numericUniqueness.Location = new Point(12, 164);
            numericUniqueness.Name = "numericUniqueness";
            numericUniqueness.Size = new Size(150, 27);
            numericUniqueness.TabIndex = 4;
            numericUniqueness.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // buttonCreateMultiple
            // 
            buttonCreateMultiple.Location = new Point(12, 337);
            buttonCreateMultiple.Name = "buttonCreateMultiple";
            buttonCreateMultiple.Size = new Size(154, 29);
            buttonCreateMultiple.TabIndex = 6;
            buttonCreateMultiple.Text = "Create multiple";
            buttonCreateMultiple.UseVisualStyleBackColor = true;
            buttonCreateMultiple.Click += buttonCreateMultiple_Click;
            // 
            // numericFleetsCount
            // 
            numericFleetsCount.Location = new Point(12, 304);
            numericFleetsCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericFleetsCount.Name = "numericFleetsCount";
            numericFleetsCount.Size = new Size(154, 27);
            numericFleetsCount.TabIndex = 7;
            numericFleetsCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericShipsCount
            // 
            numericShipsCount.Location = new Point(12, 98);
            numericShipsCount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericShipsCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericShipsCount.Name = "numericShipsCount";
            numericShipsCount.Size = new Size(150, 27);
            numericShipsCount.TabIndex = 8;
            numericShipsCount.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 75);
            label1.Name = "label1";
            label1.Size = new Size(85, 20);
            label1.TabIndex = 9;
            label1.Text = "Ships count";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 141);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 10;
            label2.Text = "Uniqueness";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 6);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 11;
            label3.Text = "Crew floor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(335, 6);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 12;
            label4.Text = "Crew ceil";
            // 
            // buttonClearFleets
            // 
            buttonClearFleets.Location = new Point(335, 337);
            buttonClearFleets.Name = "buttonClearFleets";
            buttonClearFleets.Size = new Size(154, 29);
            buttonClearFleets.TabIndex = 13;
            buttonClearFleets.Text = "Delete all fleets";
            buttonClearFleets.UseVisualStyleBackColor = true;
            buttonClearFleets.Click += buttonClearFleets_Click;
            // 
            // numericSortingFactor
            // 
            numericSortingFactor.DecimalPlaces = 5;
            numericSortingFactor.Location = new Point(335, 164);
            numericSortingFactor.Name = "numericSortingFactor";
            numericSortingFactor.Size = new Size(154, 27);
            numericSortingFactor.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(335, 141);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 15;
            label5.Text = "Sorting factor";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(12, 230);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(154, 27);
            textBoxName.TabIndex = 16;
            // 
            // FormFleetGeneration
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 386);
            Controls.Add(textBoxName);
            Controls.Add(label5);
            Controls.Add(numericSortingFactor);
            Controls.Add(buttonClearFleets);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numericShipsCount);
            Controls.Add(numericFleetsCount);
            Controls.Add(buttonCreateMultiple);
            Controls.Add(numericUniqueness);
            Controls.Add(numericCrewCeil);
            Controls.Add(numericCrewFloor);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormFleetGeneration";
            Text = "FormFleetGeneration";
            ((System.ComponentModel.ISupportInitialize)numericCrewFloor).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCrewCeil).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUniqueness).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericFleetsCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericShipsCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericSortingFactor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numericCrewFloor;
        private NumericUpDown numericCrewCeil;
        private NumericUpDown numericUniqueness;
        private Button buttonCreateMultiple;
        private NumericUpDown numericFleetsCount;
        private NumericUpDown numericShipsCount;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button buttonClearFleets;
        private NumericUpDown numericSortingFactor;
        private Label label5;
        private TextBox textBoxName;
    }
}
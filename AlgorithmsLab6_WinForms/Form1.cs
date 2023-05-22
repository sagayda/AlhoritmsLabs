using AlgorithmsLab6;
using System.ComponentModel;
using System.Windows.Forms;

namespace AlgorithmsLab6_WinForms
{
    public partial class Form1 : Form
    {
        public HashTableDouble HashTableDouble;
        public HashTableLinear HashTableLinear;
        public HashTableQuad HashTableQuad;
        public bool isTablesCreated = false;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonCreateTables_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSize.Text))
            {
                MessageBox.Show("������ �����!");
                return;
            }

            if (!int.TryParse(textBoxSize.Text, out int size))
            {
                MessageBox.Show("������� �����!");
                return;
            }

            if (size <= 0)
            {
                MessageBox.Show("������� �����!");
                return;
            }

            HashTableDouble = new HashTableDouble(size);
            BindingSource sourceDouble = new BindingSource();
            sourceDouble.DataSource = HashTableDouble.HashNodes;
            dataGridViewDouble.DataSource = sourceDouble;
            dataGridViewDouble.Columns.Remove("Key");
            dataGridViewDouble.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            HashTableLinear = new HashTableLinear(size);
            BindingSource sourceLinear = new BindingSource();
            sourceLinear.DataSource = HashTableLinear.HashNodes;
            dataGridViewLinear.DataSource = sourceLinear;
            dataGridViewLinear.Columns.Remove("Key");
            dataGridViewLinear.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            HashTableQuad = new HashTableQuad(size);
            BindingSource sourceQuad = new BindingSource();
            sourceQuad.DataSource = HashTableQuad.HashNodes;
            dataGridViewQuad.DataSource = sourceQuad;
            dataGridViewQuad.Columns.Remove("Key");
            dataGridViewQuad.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            isTablesCreated = true;

            MessageBox.Show("������� ������ ��������!");
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (!isTablesCreated)
            {
                MessageBox.Show("������� �� ��������!");
                return;
            }

            if (string.IsNullOrEmpty(textBoxInsertKey.Text) || string.IsNullOrEmpty(textBoxInsertValue.Text))
            {
                MessageBox.Show("������ ��'� �� ����!");
                return;
            }

            try
            {
                HashTableDouble.Insert(textBoxInsertKey.Text, textBoxInsertValue.Text);
                ((BindingSource)dataGridViewDouble.DataSource).ResetBindings(false);
            }
            catch (OverflowException)
            {
                MessageBox.Show("������� HashTableDouble �����������!");
            }

            try
            {
                HashTableLinear.Insert(textBoxInsertKey.Text, textBoxInsertValue.Text);
                ((BindingSource)dataGridViewLinear.DataSource).ResetBindings(false);
            }
            catch (OverflowException)
            {
                MessageBox.Show("������� HashTableLinear �����������!");
            }

            try
            {
                HashTableQuad.Insert(textBoxInsertKey.Text, textBoxInsertValue.Text);
                ((BindingSource)dataGridViewQuad.DataSource).ResetBindings(false);
            }
            catch (OverflowException)
            {
                MessageBox.Show("������� HashTableQuad �����������!");
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (!isTablesCreated)
            {
                MessageBox.Show("������� �� ��������!");
                return;
            }

            if (string.IsNullOrEmpty(textBoxFindKey.Text))
            {
                MessageBox.Show("������ ��'�!");
                return;
            }

            textBoxFindValueDouble.Text = HashTableDouble.Search(textBoxFindKey.Text);
            textBoxFindValueLinear.Text = HashTableLinear.Search(textBoxFindKey.Text);
            textBoxFindValueQuad.Text = HashTableQuad.Search(textBoxFindKey.Text);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (!isTablesCreated)
            {
                MessageBox.Show("������� �� ��������!");
                return;
            }

            if (string.IsNullOrEmpty(textBoxDeleteKey.Text))
            {
                MessageBox.Show("������ ��'�!");
                return;
            }

            try
            {
                HashTableDouble.Delete(textBoxDeleteKey.Text);
                ((BindingSource)dataGridViewDouble.DataSource).ResetBindings(false);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("�������� � ����� ������ � HashTableDouble �� ��������!");
            }

            try
            {
                HashTableLinear.Delete(textBoxDeleteKey.Text);
                ((BindingSource)dataGridViewLinear.DataSource).ResetBindings(false);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("�������� � ����� ������ � HashTableLinear �� ��������!");
            }

            try
            {
                HashTableQuad.Delete(textBoxDeleteKey.Text);
                ((BindingSource)dataGridViewQuad.DataSource).ResetBindings(false);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("�������� � ����� ������ � HashTableQuad �� ��������!");
            }
        }

        private void buttonExtract_Click(object sender, EventArgs e)
        {
            if (!isTablesCreated)
            {
                MessageBox.Show("������� �� ��������!");
                return;
            }

            if (string.IsNullOrEmpty(textBoxExtractKey.Text))
            {
                MessageBox.Show("������ ��'�!");
                return;
            }

            try
            {
                textBoxExtractValueDouble.Text = HashTableDouble.Extract(textBoxExtractKey.Text);
                ((BindingSource)dataGridViewDouble.DataSource).ResetBindings(false);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("�������� � ����� ������ � HashTableDouble �� ��������!");
            }

            try
            {
                textBoxExtractValueLinear.Text = HashTableLinear.Extract(textBoxExtractKey.Text);
                ((BindingSource)dataGridViewLinear.DataSource).ResetBindings(false);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("�������� � ����� ������ � HashTableLinear �� ��������!");
            }

            try
            {
                textBoxExtractValueQuad.Text = HashTableQuad.Extract(textBoxExtractKey.Text);
                ((BindingSource)dataGridViewQuad.DataSource).ResetBindings(false);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("�������� � ����� ������ � HashTableQuad �� ��������!");
            }
        }
    }
}
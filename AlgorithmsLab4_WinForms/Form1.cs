namespace AlgorithmsLab4_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listEditButton_Click(object sender, EventArgs e)
        {
            var FormTar = new ListEditingForm();
            FormTar.Show();
        }
    }
}
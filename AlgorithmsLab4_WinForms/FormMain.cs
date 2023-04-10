namespace AlgorithmsLab4_WinForms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            studentsMainComboBox.DataSource = Serializer.DeserializeStudentsXML().students;
            studentsMainComboBox.DisplayMember = "Description";
        }
        
        public void UpdateData()
        {
            studentsMainComboBox.DataSource = Serializer.DeserializeStudentsXML().students;
        }
        private void listEditButton_Click(object sender, EventArgs e)
        {
            var FormTar = new ListEditingForm(this);
            FormTar.ShowDialog(this);
        }
    }
}
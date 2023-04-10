namespace AlgorithmsLab4_WinForms
{
    public partial class FormMain : Form
    {
        QueueByArray<Student> queueByArray;
        QueueByIndex<Student> queueByIndex;
        Students students;

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            students = Serializer.DeserializeStudentsXML();

            studentsMainComboBox.DataSource = students.students;
            studentsMainComboBox.DisplayMember = "Description";
            queueByArray = new QueueByArray<Student>(students.students.Count);
            queueByIndex = new QueueByIndex<Student>();

            queueByArrayListBox.DisplayMember = "Description";
            queueByIndexListBox.DisplayMember = "Description";
        }

        public void UpdateData()
        {
            students = Serializer.DeserializeStudentsXML();
            studentsMainComboBox.DataSource = students.students;

            queueByArray = new QueueByArray<Student>(students.students.Count);
            queueByIndex = new QueueByIndex<Student>();
            queueByIndexListBox.Items.Clear();
            queueByArrayListBox.Items.Clear();

            studentInQueueTextBox.Text = "";
            gradeInQueueTextBox.Text = "";
        }
        private void listEditButton_Click(object sender, EventArgs e)
        {
            var FormTar = new ListEditingForm(this);
            FormTar.ShowDialog(this);
        }
        private void addToQueueButton_Click(object sender, EventArgs e)
        {
            if (students.students.Count == 0)
            {
                MessageBox.Show("Всі студенти перевірені!");
                return;
            }

            var selectedStudent = (Student)studentsMainComboBox.SelectedItem;

            try
            {
                var grade = byte.Parse(gradeTextBox.Text);

                if(grade > 100 || grade < 0) 
                    throw new Exception();

                selectedStudent.Grade = byte.Parse(gradeTextBox.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Оцінка введена невірно!");
                return;
            }

            if (queueByArrayListBox.Items.Contains(selectedStudent))
            {
                MessageBox.Show("Цей студент вже в черзі!");
                return;
            }


            if (queueByIndexListBox.Items.Contains(selectedStudent))
            {
                MessageBox.Show("Цей студент вже в черзі!");
                return;
            }
            gradeTextBox.Text = "";

            queueByArray.Enqueue(selectedStudent);
            queueByArrayListBox.Items.Add(selectedStudent);

            queueByIndex.Enqueue(selectedStudent);
            queueByIndexListBox.Items.Add(selectedStudent);

            studentInQueueTextBox.Text = queueByIndex.GetFirstInQueue().Description;
            gradeInQueueTextBox.Text = queueByIndex.GetFirstInQueue().Grade.ToString();

            students.students.Remove(selectedStudent);
        }

        private void removeFromQueueButton_Click(object sender, EventArgs e)
        {
            try
            {
                var studentForRemoving = queueByArray.Dequeue();
                queueByArrayListBox.Items.Remove(studentForRemoving);

                studentForRemoving = queueByIndex.Dequeue();
                queueByIndexListBox.Items.Remove(studentForRemoving);

                if(queueByIndex.IsEmpty)
                {
                    studentInQueueTextBox.Text = "";
                    gradeInQueueTextBox.Text = "";
                    return;
                }

                studentInQueueTextBox.Text = queueByIndex.GetFirstInQueue().Description;
                gradeInQueueTextBox.Text = queueByIndex.GetFirstInQueue().Grade.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateData();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace AlgorithmsLab4_WinForms
{
    public partial class ListEditingForm : Form
    {
        string[] groups = { "ІС-21", "ІС-22", "ІС-23" };

        public ListEditingForm()
        {
            InitializeComponent();
        }

        private void studentAddButton_Click(object sender, EventArgs e)
        {
            Student student = new Student(nameTextBox.Text, sexComboBox.SelectedIndex, groupComboBox.Text);
            ListViewItem lvi = new ListViewItem(student.Description);
            lvi.Tag = student;

            studentsListView.Items.Add(lvi);
            CleanInput();
        }

        private void CleanInput()
        {
            nameTextBox.Text = string.Empty;
        }

        private void ListEditingForm_Load(object sender, EventArgs e)
        {
            var students = DeserializeXML();

            foreach (var student in students.students)
            {
                ListViewItem lvi = new ListViewItem(student.Description);
                lvi.Tag = student;

                studentsListView.Items.Add(lvi);
            }
        }

        private void serializeButton_Click(object sender, EventArgs e)
        {
            Students students = new Students();

            foreach (ListViewItem item in studentsListView.Items)
            {
                if(item.Tag != null)
                {
                    students.students.Add((Student)item.Tag);
                }
            }

            SerializeXML(students);
        }

        private void SerializeXML(Students students)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Students));

            using (FileStream fs = new FileStream("Students.xml", FileMode.Create))
            {
                xml.Serialize(fs, students);
            }
        }

        private Students DeserializeXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Students));

            using (FileStream fs = new FileStream("Students.xml", FileMode.OpenOrCreate))
            {
                Students students = xml.Deserialize(fs) as Students;

                return students;
            }
        }

        private void studentRemoveButton_Click(object sender, EventArgs e)
        {
            if (studentsListView.SelectedItems.Count <= 0)
                return;

            foreach (ListViewItem selectedItem in studentsListView.SelectedItems)
            {
                studentsListView.Items.Remove(selectedItem);
            }
        }
    }
}

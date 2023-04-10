using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private Students students = Serializer.DeserializeStudentsXML();
        private Form mainForm;

        public ListEditingForm(object sender)
        {
            InitializeComponent();
            mainForm = (Form)sender;
            FormClosing += TransferData;
        }

        private void studentAddButton_Click(object sender, EventArgs e)
        {
            Student student = new Student(nameTextBox.Text, sexComboBox.SelectedIndex, groupComboBox.Text);
            students.students.Add(student);
            CleanInput();
        }

        private void CleanInput()
        {
            nameTextBox.Text = string.Empty;
        }
        private void TransferData(Object sender, FormClosingEventArgs e)
        {
            ((FormMain)mainForm).UpdateData();
        }
        private void ListEditingForm_Load(object sender, EventArgs e)
        {
            studentsListBox.DataSource = students.students;
            studentsListBox.DisplayMember = "Description";
        }

        private void serializeButton_Click(object sender, EventArgs e)
        {
            Serializer.SerializeStudentsXML(students);
        }

        private void studentRemoveButton_Click(object sender, EventArgs e)
        {
            if (studentsListBox.SelectedItems.Count <= 0)
                return;

            Student[] selected = new Student[studentsListBox.SelectedItems.Count];
            studentsListBox.SelectedItems.CopyTo(selected, 0);

            foreach (var selectedItem in selected)
            {
                students.students.Remove(selectedItem);
            }
        }
    }
}

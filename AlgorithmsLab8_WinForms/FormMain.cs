using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgorithmsLab8_WinForms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAVLTree formAVLTree = new FormAVLTree();
            formAVLTree.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRedBlackTree formRedBlackTree = new FormRedBlackTree();
            formRedBlackTree.Show();
        }
    }
}

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
            int less;
            int greater;
            int count;

            try
            {
                less = int.Parse(textBoxLess.Text);
                greater = int.Parse(textBoxGreater.Text);
                count = int.Parse(textBoxCount.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input!", "Error!");
                return;
            }

            if (less > greater || count < 0)
            {
                MessageBox.Show("Invalid input!", "Error!");
                return;
            }

            FormAVLTree formAVLTree = new FormAVLTree(less, greater, count);
            formAVLTree.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int less;
            int greater;
            int count;

            try
            {
                less = int.Parse(textBoxLess.Text);
                greater = int.Parse(textBoxGreater.Text);
                count = int.Parse(textBoxCount.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input!", "Error!");
                return;
            }

            if (less > greater || count < 0)
            {
                MessageBox.Show("Invalid input!", "Error!");
                return;
            }

            FormRedBlackTree formRedBlackTree = new FormRedBlackTree(less, greater, count);
            formRedBlackTree.Show();
        }
    }
}

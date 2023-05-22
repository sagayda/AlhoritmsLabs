using AlgoritmsLab8;
using System.Drawing;

namespace AlgorithmsLab8_WinForms
{
    public partial class Form1 : Form
    {
        private AVLTree AVLTree = new AVLTree();
        public Form1()
        {
            InitializeComponent();

            AVLTree.Add(71);
            AVLTree.Add(348);
            AVLTree.Add(466);
            AVLTree.Add(361);
            AVLTree.Add(308);
            AVLTree.Add(214);
            AVLTree.Add(231);
            AVLTree.Add(413);
            AVLTree.Add(83);
            //AVLTree.Add(53);
            //AVLTree.Add(2);
            //AVLTree.Add(88);
            //AVLTree.Add(456);
            //AVLTree.Add(54);
            //AVLTree.Add(86);
            //AVLTree.Add(66);
            //AVLTree.Add(4);
            //AVLTree.Add(5);
            //AVLTree.Add(8);
            //AVLTree.Add(9);





            //Random random = new Random();
            //for (int i = 0; i < 20; i++)
            //{
            //    int rnd = random.Next(0, 500);
            //    AVLTree.Add(rnd);
            //    label1.Text += "\n" + rnd.ToString();
            //}

            CreateTree();
        }

        private void CreateTree()
        {
            Button button = new Button()
            {
                Top = 80,
                Left = 250,
                Height = 50,
                Width = 50,
                Text = "ROOT " + AVLTree.root.Data.ToString(),
            };
            panel1.Controls.Add(button);

            CreateTreeElement(AVLTree.root.RightChild, 350, 180, true);
            CreateTreeElement(AVLTree.root.LeftChild, 150, 180, false);

            foreach (Control control in panel1.Controls)
            {
                if (control is Button)
                {
                    Button button2 = (Button)control;
                    button2.BringToFront();
                }
            }
        }

        private void CreateTreeElement(AVLTree.AVLTreeNode treeNode, int x, int y, bool isRight)
        {
            if (treeNode == null)
            {
                return;
            }

            Random random = new Random();

            Panel panel = new Panel()
            {
                Top = y - 10,
                Left = x - 10,
                Height = 135,
                BackColor = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)),
            };

            if (treeNode.LeftChild != null || treeNode.RightChild != null)
            {
                panel1.Controls.Add(panel);
            }

            Button button = new Button()
            {
                Top = y,
                Left = x,
                Height = 50,
                Width = 50,
                Text = treeNode.Data.ToString(),
            };
            panel1.Controls.Add(button);


            if (isRight)
            {

                int multiplier = 0;

                if (treeNode.LeftChild != null)
                    multiplier = treeNode.LeftChild.GetRightSeperation();

                if (treeNode.RightChild == null)
                    panel.Width = (int)((100 * multiplier) + 70);
                else
                    panel.Width = (int)(100 + (100 * multiplier) + 70);

                CreateTreeElement(treeNode.LeftChild, x, y + 100, true);
                CreateTreeElement(treeNode.RightChild, x + 100 + (100 * multiplier), y + 100, true);
            }
            else
            {
                int multiplier = 0;

                if (treeNode.RightChild != null)
                    multiplier = treeNode.RightChild.GetLeftSeperation();

                if (x - 100 - (100 * multiplier) < 0)
                {
                    MoveElementsToRight(Math.Abs(x - 100 - (100 * multiplier)) + 50);
                    x += Math.Abs(x - 100 - (100 * multiplier)) + 50;
                }

                if (treeNode.LeftChild == null)
                {
                    panel.Width = (100 * multiplier) + 70;
                    panel.Left = x - ((+100 * multiplier) + 10);
                }
                else
                {
                    panel.Width = 100 + (100 * multiplier) + 70;
                    panel.Left = x - (100 + (100 * multiplier) + 10);
                }

                CreateTreeElement(treeNode.RightChild, x, y + 100, false);
                CreateTreeElement(treeNode.LeftChild, x - 100 - (100 * multiplier), y + 100, false);
            }

            panel.BringToFront();
            button.BringToFront();
        }

        private void MoveElementsToRight(int distance)
        {
            foreach (Control item in panel1.Controls)
            {
                item.Left += distance;
            }

            panel1.PerformLayout();
        }
    }
}
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

            AVLTree.Add(50);
            AVLTree.Add(2);
            AVLTree.Add(7);
            AVLTree.Add(8);
            AVLTree.Add(9);
            AVLTree.Add(22);
            AVLTree.Add(85);
            AVLTree.Add(100);
            AVLTree.Add(3);
            AVLTree.Add(90);

            //Random random = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    AVLTree.Add(random.Next(0, 100));
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

        }

        private void CreateTreeElement(AVLTree.AVLTreeNode treeNode, int x, int y, bool isRight)
        {
            if (treeNode == null)
            {
                return;
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

            var gr = panel1.CreateGraphics();

            if (isRight)
            {
                gr.DrawLine(new Pen(Color.Red, 4), x, y, x, y+100);
                CreateTreeElement(treeNode.LeftChild, x, y + 100, true);
                
                gr.DrawLine(new Pen(Color.Red, 4), x, y, x +100, y + 100);
                CreateTreeElement(treeNode.RightChild, x + 100, y + 100, true);
            }
            else
            {
                //if (x - 100 < 0)
                //{
                //    MoveElementsToRight();
                //    x += 100;
                //}

                gr.DrawLine(new Pen(Color.Red, 4), x, y, x -100, y + 100);
                CreateTreeElement(treeNode.LeftChild, x - 100, y + 100, false);

                gr.DrawLine(new Pen(Color.Red, 4), x, y, x, y + 100);
                CreateTreeElement(treeNode.RightChild, x, y + 100, false);
            }
        }

        private void MoveElementsToRight()
        {
            foreach (Button item in panel1.Controls)
            {
                item.Left += 100;
            }

            panel1.PerformLayout();
        }
    }
}
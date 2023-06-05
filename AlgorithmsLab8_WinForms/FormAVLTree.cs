using AlgoritmsLab8;
using System.Diagnostics;
using System.Drawing;

namespace AlgorithmsLab8_WinForms
{
    public partial class FormAVLTree : Form
    {
        private AVLTree AVLTree = new AVLTree();

        private List<VisualEdge> VisualEdges = new();
        public FormAVLTree(int less, int greater, int count)
        {
            InitializeComponent();

            Random random = new Random();

            try
            {
                for (int i = 0; i < count; i++)
                {
                    int rnd = random.Next(less, greater);
                    AVLTree.Insert(rnd);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to create tree!", "Error");
                return;
            }

            CreateAVLTree();
        }

        private void CreateAVLTree()
        {
            Button button = new Button()
            {
                Top = 80,
                Left = 250,
                Height = 50,
                Width = 50,
                Text = AVLTree.Root.Data.ToString(),
            };
            button.FlatStyle = FlatStyle.Flat;

            if (AVLTree.Root.Triggered)
            {
                button.FlatAppearance.BorderSize = 4;
                button.FlatAppearance.BorderColor = Color.BlueViolet;
            }

            panel1.Controls.Add(button);


            if (AVLTree.Root.RightChild != null)
            {
                VisualEdge edgeRight = new(new(250 + 25, 80 + 25), new(350 + 25, 180 + 25), Color.Black);
                VisualEdges.Add(edgeRight);

                CreateTreeElement(AVLTree.Root.RightChild, 350, 180, true);
            }

            if (AVLTree.Root.LeftChild != null)
            {
                VisualEdge edgeLeft = new(new(250 + 25, 80 + 25), new(150 + 25, 180 + 25), Color.Black);
                VisualEdges.Add(edgeLeft);

                CreateTreeElement(AVLTree.Root.LeftChild, 150, 180, false);
            }

            //CreateTreeElement(AVLTree.root.RightChild, 350, 180, true);
            //CreateTreeElement(AVLTree.root.LeftChild, 150, 180, false);

            foreach (Control control in panel1.Controls)
            {
                if (control is Button)
                {
                    Button button2 = (Button)control;
                    button2.BringToFront();
                }
            }
        }

        private void CreateTreeElement(AVLTree.Node treeNode, int x, int y, bool isRight)
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
                Text = treeNode == AVLTree.Nil ? "NIL" : treeNode.Data.ToString(),

            };
            button.FlatStyle = FlatStyle.Flat;

            if (treeNode.Triggered)
            {
                button.FlatAppearance.BorderSize = 4;
                button.FlatAppearance.BorderColor = Color.BlueViolet;
            }

            panel1.Controls.Add(button);


            if (isRight)
            {
                int multiplier = treeNode.LeftChild == null ? 0 : treeNode.LeftChild.GetRightSeperation();

                if (treeNode.LeftChild != null)
                {
                    int newX = x;
                    int newY = y + 100;

                    VisualEdge edgeLeft = new(new(x + 25, y), new(newX + 25, newY), Color.Black);
                    VisualEdges.Add(edgeLeft);

                    CreateTreeElement(treeNode.LeftChild, newX, newY, true);
                }

                if (treeNode.RightChild != null)
                {
                    int newX = x + 100 + (100 * multiplier);
                    int newY = y + 100;

                    VisualEdge edgeRight = new(new(x + 25, y + 25), new(newX + 25, newY + 25), Color.Black);
                    VisualEdges.Add(edgeRight);

                    CreateTreeElement(treeNode.RightChild, newX, newY, true);
                }
            }
            else
            {
                int multiplier = treeNode.RightChild == null ? 0 : treeNode.RightChild.GetLeftSeperation();

                if (x - 100 - (100 * multiplier) < 0 && treeNode.LeftChild != null)
                {
                    MoveElementsToRight(Math.Abs(x - 100 - (100 * multiplier)));
                    x += Math.Abs(x - 100 - (100 * multiplier));
                }

                if (treeNode.RightChild != null)
                {
                    int newX = x;
                    int newY = y + 100;

                    VisualEdge edgeRight = new(new(x + 25, y), new(newX + 25, newY), Color.Black);
                    VisualEdges.Add(edgeRight);

                    CreateTreeElement(treeNode.RightChild, newX, newY, false);
                }

                if (treeNode.LeftChild != null)
                {
                    int newX = x - 100 - (100 * multiplier);
                    int newY = y + 100;

                    VisualEdge edgeLeft = new(new(x + 25, y + 25), new(newX + 25, newY + 25), Color.Black);
                    VisualEdges.Add(edgeLeft);

                    CreateTreeElement(treeNode.LeftChild, newX, newY, false);
                }
            }

            //if (isRight)
            //{

            //    int multiplier = 0;

            //    if (treeNode.LeftChild != null)
            //        multiplier = treeNode.LeftChild.GetRightSeperation();

            //    CreateTreeElement(treeNode.LeftChild, x, y + 100, true);
            //    CreateTreeElement(treeNode.RightChild, x + 100 + (100 * multiplier), y + 100, true);
            //}
            //else
            //{
            //    int multiplier = 0;

            //    if (treeNode.RightChild != null)
            //        multiplier = treeNode.RightChild.GetLeftSeperation();

            //    if (x - 100 - (100 * multiplier) < 0)
            //    {
            //        MoveElementsToRight(Math.Abs(x - 100 - (100 * multiplier)) + 50);
            //        x += Math.Abs(x - 100 - (100 * multiplier)) + 50;
            //    }

            //    CreateTreeElement(treeNode.RightChild, x, y + 100, false);
            //    CreateTreeElement(treeNode.LeftChild, x - 100 - (100 * multiplier), y + 100, false);
            //}

            button.BringToFront();
        }

        private void MoveElementsToRight(int distance)
        {
            foreach (Control item in panel1.Controls)
            {
                item.Left += distance;
            }

            foreach (VisualEdge edge in VisualEdges)
            {
                edge.StartPoint = new Point(edge.StartPoint.X + distance, edge.StartPoint.Y);
                edge.EndPoint = new Point(edge.EndPoint.X + distance, edge.EndPoint.Y);
            }

            panel1.PerformLayout();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var gr = panel1.CreateGraphics();
            foreach (VisualEdge edge in VisualEdges)
            {
                edge.Draw(gr);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AVLTree.ClearTriggered();

            Stopwatch stopwatch = new();
            stopwatch.Start();
            try
            {
                AVLTree.Insert(int.Parse(textBoxData.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                stopwatch.Stop();
                return;
            }
            stopwatch.Stop();
            labelTimer.Text = stopwatch.Elapsed.TotalNanoseconds.ToString() + "ns";

            panel1.Controls.Clear();
            VisualEdges.Clear();
            CreateAVLTree();
            panel1.Refresh();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            AVLTree.ClearTriggered();

            Stopwatch stopwatch = new();
            stopwatch.Start();
            try
            {
                AVLTree.Delete(int.Parse(textBoxData.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                stopwatch.Stop();
                return;
            }
            stopwatch.Stop();
            labelTimer.Text = stopwatch.Elapsed.TotalNanoseconds.ToString() + "ns";

            panel1.Controls.Clear();
            VisualEdges.Clear();
            CreateAVLTree();
            panel1.Refresh();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            AVLTree.ClearTriggered();
            bool result;

            Stopwatch stopwatch = new();
            stopwatch.Start();
            try
            {
                result = AVLTree.Search(int.Parse(textBoxData.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                stopwatch.Stop();
                buttonFind.BackColor = SystemColors.Control;
                return;
            }
            stopwatch.Stop();
            labelTimer.Text = stopwatch.Elapsed.TotalNanoseconds.ToString() + "ns";

            if (result)
                buttonFind.BackColor = Color.Green;
            else
                buttonFind.BackColor = Color.Red;

            panel1.Controls.Clear();
            VisualEdges.Clear();
            CreateAVLTree();
            panel1.Refresh();
        }
    }
}
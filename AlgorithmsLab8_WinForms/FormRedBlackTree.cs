﻿using AlgoritmsLab8;
using System.Diagnostics;
using System.Windows.Forms;

namespace AlgorithmsLab8_WinForms
{
    public partial class FormRedBlackTree : Form
    {
        private readonly Font font = new("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);

        private RedBlackTree RedBlackTree = new();

        private List<VisualEdge> VisualEdges = new();

        public FormRedBlackTree(int less, int greater, int count)
        {
            InitializeComponent();

            Random random = new Random();
            try
            {
                for (int i = 0; i < count; i++)
                {
                    int rnd = random.Next(less, greater);
                    RedBlackTree.Insert(rnd);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to create tree!", "Error");
                return;
            }

            CreateRedBlackTree();
        }

        private void CreateRedBlackTree()
        {
            Button button = new Button()
            {
                Top = 80,
                Left = 250,
                Height = 50,
                Width = 50,
                Text = RedBlackTree.Root.Data.ToString(),
                Font = font,
                BackColor = RedBlackTree.Root.Color == RedBlackTree.Color.Red ? Color.Red : Color.Black,
                ForeColor = RedBlackTree.Root.Color == RedBlackTree.Color.Red ? Color.Black : Color.White,
            };
            button.FlatStyle = FlatStyle.Flat;

            if (RedBlackTree.Root.Triggered)
            {
                button.FlatAppearance.BorderSize = 4;
                button.FlatAppearance.BorderColor = Color.BlueViolet;
            }

            panel1.Controls.Add(button);

            if (RedBlackTree.Root.RightChild != null)
            {
                VisualEdge edgeRight = new(new(250 + 25, 80 + 25), new(350 + 25, 180 + 25), RedBlackTree.Root.RightChild.GetColor());
                VisualEdges.Add(edgeRight);

                CreateTreeElement(RedBlackTree.Root.RightChild, 350, 180, true);
            }

            if (RedBlackTree.Root.LeftChild != null)
            {
                VisualEdge edgeLeft = new(new(250 + 25, 80 + 25), new(150 + 25, 180 + 25), RedBlackTree.Root.LeftChild.GetColor());
                VisualEdges.Add(edgeLeft);

                CreateTreeElement(RedBlackTree.Root.LeftChild, 150, 180, false);
            }

            foreach (Control control in panel1.Controls)
            {
                if (control is Button)
                {
                    Button button2 = (Button)control;
                    button2.BringToFront();
                }
            }
        }

        private void CreateTreeElement(RedBlackTree.Node treeNode, int x, int y, bool isRight)
        {
            if (treeNode == null)
                return;

            Button button = new Button()
            {
                Top = y,
                Left = x,
                Height = 50,
                Width = 50,
                Font = font,
                Text = treeNode == RedBlackTree.Nil ? "NIL" : treeNode.Data.ToString(),
                BackColor = treeNode.GetColor(),
                ForeColor = treeNode.GetColor() == Color.Red ? Color.Black : Color.White,
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

                    VisualEdge edgeLeft = new(new(x + 25, y), new(newX + 25, newY), treeNode.LeftChild.GetColor());
                    VisualEdges.Add(edgeLeft);

                    CreateTreeElement(treeNode.LeftChild, newX, newY, true);
                }

                if (treeNode.RightChild != null)
                {
                    int newX = x + 100 + (100 * multiplier);
                    int newY = y + 100;

                    VisualEdge edgeRight = new(new(x + 25, y + 25), new(newX + 25, newY + 25), treeNode.RightChild.GetColor());
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

                    VisualEdge edgeRight = new(new(x + 25, y), new(newX + 25, newY), treeNode.RightChild.GetColor());
                    VisualEdges.Add(edgeRight);

                    CreateTreeElement(treeNode.RightChild, newX, newY, false);
                }

                if (treeNode.LeftChild != null)
                {
                    int newX = x - 100 - (100 * multiplier);
                    int newY = y + 100;

                    VisualEdge edgeLeft = new(new(x + 25, y + 25), new(newX + 25, newY + 25), treeNode.LeftChild.GetColor());
                    VisualEdges.Add(edgeLeft);

                    CreateTreeElement(treeNode.LeftChild, newX, newY, false);
                }
            }

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
            RedBlackTree.ClearTriggered();

            Stopwatch stopwatch = new();
            stopwatch.Start();
            try
            {
                RedBlackTree.Insert(int.Parse(textBoxData.Text));
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
            CreateRedBlackTree();
            panel1.Refresh();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            RedBlackTree.ClearTriggered();

            Stopwatch stopwatch = new();
            stopwatch.Start();
            try
            {
                RedBlackTree.Delete(int.Parse(textBoxData.Text));
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
            CreateRedBlackTree();
            panel1.Refresh();
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            RedBlackTree.ClearTriggered();

            bool result;

            Stopwatch stopwatch = new();
            stopwatch.Start();
            try
            {
                result = RedBlackTree.Search(int.Parse(textBoxData.Text));
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
            CreateRedBlackTree();
            panel1.Refresh();
        }
    }
}

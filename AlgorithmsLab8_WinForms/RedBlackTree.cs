using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsLab8
{
    public class RedBlackTree
    {
        public Node Root { get; private set; }

        public Node Nil { get; private set; }

        public enum Color
        {
            Red,
            Black,
        }

        public class Node
        {
            public int Data { get; set; }
            public Node Parent { get; set; }
            public Node? LeftChild { get; set; }
            public Node? RightChild { get; set; }
            public Color Color { get; set; }
            public bool Triggered { get; set; } = false;

            public Node(int value)
            {
                this.Data = value;
                Parent = null;
                LeftChild = null;
                RightChild = null;
                Color = Color.Red;
            }

            public System.Drawing.Color GetColor()
            {
                return Color == RedBlackTree.Color.Red ? System.Drawing.Color.Red : System.Drawing.Color.Black;
            }

            public int GetRightSeperation()
            {
                if (RightChild == null && LeftChild == null)
                    return 0;

                if (RightChild == null)
                    return LeftChild.GetRightSeperation();

                if (LeftChild == null)
                    return RightChild.GetRightSeperation() + 1;

                return LeftChild.GetRightSeperation() + RightChild.GetRightSeperation() + 1;
            }

            public int GetLeftSeperation()
            {
                if (RightChild == null && LeftChild == null)
                    return 0;

                if (RightChild == null)
                    return LeftChild.GetLeftSeperation() + 1;

                if (LeftChild == null)
                    return RightChild.GetLeftSeperation();

                return LeftChild.GetLeftSeperation() + RightChild.GetLeftSeperation() + 1;
            }
        }

        public RedBlackTree()
        {
            Nil = new Node(default);
            Nil.Color = Color.Black;
            Root = Nil;
        }

        public void ClearTriggered()
        {
            if (Root == null || Root == Nil)
                return;

            if (!Root.Triggered)
                return;

            ClearTriggeredNode(Root);
        }

        private void ClearTriggeredNode(Node node)
        {
            if(node == Nil) 
                return;

            if (!node.LeftChild.Triggered && !node.RightChild.Triggered)
            {
                node.Triggered = false;
                return;
            }

            if(node.LeftChild.Triggered)
                ClearTriggeredNode(node.LeftChild);
            else
                ClearTriggeredNode(node.RightChild);

            node.Triggered = false;
        }

        public void Insert(int value)
        {
            var newNode = new Node(value);
            var current = Root;
            Node parent = null;

            while (current != Nil)
            {
                parent = current;

                if (value < current.Data)
                    current = current.LeftChild;
                else if (value > current.Data)
                    current = current.RightChild;
                else
                    throw new ArgumentException("This element already exist!");
            }

            newNode.Parent = parent;

            if (parent == null)
                Root = newNode;
            else if (value < parent.Data)
                parent.LeftChild = newNode;
            else
                parent.RightChild = newNode;

            newNode.LeftChild = Nil;
            newNode.RightChild = Nil;
            newNode.Color = Color.Red;

            InsertFixup(newNode);
        }

        private void InsertFixup(Node node)
        {
            while (node.Parent?.Color == Color.Red)
            {
                if (node.Parent == node.Parent.Parent.LeftChild)
                {
                    var uncle = node.Parent.Parent.RightChild;

                    if (uncle.Color == Color.Red)
                    {
                        node.Parent.Color = Color.Black;
                        uncle.Color = Color.Black;
                        node.Parent.Parent.Color = Color.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.RightChild)
                        {
                            node = node.Parent;
                            RotateLeft(node);
                        }

                        node.Parent.Color = Color.Black;
                        node.Parent.Parent.Color = Color.Red;
                        RotateRight(node.Parent.Parent);
                    }
                }
                else
                {
                    var uncle = node.Parent.Parent.LeftChild;

                    if (uncle.Color == Color.Red)
                    {
                        node.Parent.Color = Color.Black;
                        uncle.Color = Color.Black;
                        node.Parent.Parent.Color = Color.Red;
                        node = node.Parent.Parent;
                    }
                    else
                    {
                        if (node == node.Parent.LeftChild)
                        {
                            node = node.Parent;
                            RotateRight(node);
                        }

                        node.Parent.Color = Color.Black;
                        node.Parent.Parent.Color = Color.Red;
                        RotateLeft(node.Parent.Parent);
                    }
                }
            }

            Root.Color = Color.Black;
        }

        private void RotateLeft(Node node)
        {
            var rightChild = node.RightChild;
            node.RightChild = rightChild.LeftChild;

            if (rightChild.LeftChild != Nil)
                rightChild.LeftChild.Parent = node;

            rightChild.Parent = node.Parent;

            if (node.Parent == null)
                Root = rightChild;
            else if (node == node.Parent.LeftChild)
                node.Parent.LeftChild = rightChild;
            else
                node.Parent.RightChild = rightChild;

            rightChild.LeftChild = node;
            node.Parent = rightChild;
        }

        private void RotateRight(Node node)
        {
            var leftChild = node.LeftChild;
            node.LeftChild = leftChild.RightChild;

            if (leftChild.RightChild != Nil)
                leftChild.RightChild.Parent = node;

            leftChild.Parent = node.Parent;

            if (node.Parent == null)
                Root = leftChild;
            else if (node == node.Parent.LeftChild)
                node.Parent.LeftChild = leftChild;
            else
                node.Parent.RightChild = leftChild;

            leftChild.RightChild = node;
            node.Parent = leftChild;
        }

        public bool Search(int value)
        {
            Root.Triggered = true;
            return Search(Root, value);
        }

        private bool Search(Node node, int value)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            if (node == Nil)
                return false;

            node.Triggered = true;

            if (value == node.Data)
                return true;

            if (value < node.Data)
                return Search(node.LeftChild, value);
            else
                return Search(node.RightChild, value);
        }

        public void Delete(int value)
        {
            var node = SearchNode(Root, value);

            if (node != Nil)
                DeleteNode(node);
            else
                throw new ArgumentException("No such element exists!");
        }

        private Node SearchNode(Node node, int data)
        {
            if (node == Nil || data == node.Data)
                return node;

            if (data < node.Data)
                return SearchNode(node.LeftChild, data);
            else
                return SearchNode(node.RightChild, data);
        }

        private void DeleteNode(Node node)
        {
            Node target;
            if (node.LeftChild == Nil || node.RightChild == Nil)
                target = node;
            else
                target = Successor(node);

            Node child;
            if (target.LeftChild != Nil)
                child = target.LeftChild;
            else
                child = target.RightChild;

            child.Parent = target.Parent;

            if (target.Parent == null)
                Root = child;
            else if (target == target.Parent.LeftChild)
                target.Parent.LeftChild = child;
            else
                target.Parent.RightChild = child;

            if (target != node)
                node.Data = target.Data;

            if (target.Color == Color.Black)
                DeleteFixup(child);
        }

        private Node Successor(Node node)
        {
            if (node.RightChild != Nil)
                return Minimum(node.RightChild);

            var parent = node.Parent;
            while (parent != null && node == parent.RightChild)
            {
                node = parent;
                parent = parent.Parent;
            }
            return parent;
        }

        private Node Minimum(Node node)
        {
            while (node.LeftChild != Nil)
                node = node.LeftChild;
            return node;
        }

        private void DeleteFixup(Node node)
        {
            while (node != Root && node.Color == Color.Black)
            {
                if (node == node.Parent.LeftChild)
                {
                    var sibling = node.Parent.RightChild;

                    if (sibling.Color == Color.Red)
                    {
                        sibling.Color = Color.Black;
                        node.Parent.Color = Color.Red;
                        RotateLeft(node.Parent);
                        sibling = node.Parent.RightChild;
                    }

                    if (sibling.LeftChild.Color == Color.Black && sibling.RightChild.Color == Color.Black)
                    {
                        sibling.Color = Color.Red;
                        node = node.Parent;
                    }
                    else
                    {
                        if (sibling.RightChild.Color == Color.Black)
                        {
                            sibling.LeftChild.Color = Color.Black;
                            sibling.Color = Color.Red;
                            RotateRight(sibling);
                            sibling = node.Parent.RightChild;
                        }

                        sibling.Color = node.Parent.Color;
                        node.Parent.Color = Color.Black;
                        sibling.RightChild.Color = Color.Black;
                        RotateLeft(node.Parent);
                        node = Root;
                    }
                }
                else
                {
                    var sibling = node.Parent.LeftChild;

                    if (sibling.Color == Color.Red)
                    {
                        sibling.Color = Color.Black;
                        node.Parent.Color = Color.Red;
                        RotateRight(node.Parent);
                        sibling = node.Parent.LeftChild;
                    }

                    if (sibling.RightChild.Color == Color.Black && sibling.LeftChild.Color == Color.Black)
                    {
                        sibling.Color = Color.Red;
                        node = node.Parent;
                    }
                    else
                    {
                        if (sibling.LeftChild.Color == Color.Black)
                        {
                            sibling.RightChild.Color = Color.Black;
                            sibling.Color = Color.Red;
                            RotateLeft(sibling);
                            sibling = node.Parent.LeftChild;
                        }

                        sibling.Color = node.Parent.Color;
                        node.Parent.Color = Color.Black;
                        sibling.LeftChild.Color = Color.Black;
                        RotateRight(node.Parent);
                        node = Root;
                    }
                }
            }

            node.Color = Color.Black;
        }

    }
}

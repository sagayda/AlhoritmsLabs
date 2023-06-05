using System;
using System.CodeDom;

namespace AlgoritmsLab8
{
    public class AVLTree
    {
        public class Node
        {
            public int Data { get; set; }

            public Node? LeftChild { get; set; }

            public Node? RightChild { get; set; }

            public bool Triggered { get; set; } = false;

            public int Height { get; set; } = 1;

            public Node(int data)
            {
                Data = data;

                LeftChild = null;
                RightChild = null;
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

        public Node Root { get; private set; }

        public Node Nil { get; private set; }

        public AVLTree()
        {
            Nil = new Node(default);
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
            if (node == Nil)
                return;

            if (!node.LeftChild.Triggered && !node.RightChild.Triggered)
            {
                node.Triggered = false;
                return;
            }

            if (node.LeftChild.Triggered)
                ClearTriggeredNode(node.LeftChild);
            else
                ClearTriggeredNode(node.RightChild);

            node.Triggered = false;
        }

        public void Insert(int data)
        {
            Root = Insert(Root, data);
        }

        private Node Insert(Node node, int data)
        {
            if (node == Nil)
            {
                Node newNode = new(data);
                newNode.RightChild = Nil;
                newNode.LeftChild = Nil;

                return newNode;
            }

            if (data < node.Data)
                node.LeftChild = Insert(node.LeftChild, data);
            else if (data > node.Data)
                node.RightChild = Insert(node.RightChild, data);
            else
                throw new ArgumentException("This element already exist!");

            node.Height = 1 + Math.Max(Height(node.LeftChild), Height(node.RightChild));

            int balance = GetBalance(node);

            if (balance > 1)
            {
                if (data < node.LeftChild.Data)
                    return RotateRight(node);

                if (data > node.LeftChild.Data)
                {
                    node.LeftChild = RotateLeft(node.LeftChild);
                    return RotateRight(node);
                }
            }

            if (balance < -1)
            {
                if (data > node.RightChild.Data)
                    return RotateLeft(node);

                if (data < node.RightChild.Data)
                {
                    node.RightChild = RotateRight(node.RightChild);
                    return RotateLeft(node);
                }
            }

            return node;
        }

        public bool Search(int data)
        {
            return Search(Root, data);
        }

        private bool Search(Node node, int data)
        {
            if (node == Nil)
                return false;

            if (data < node.Data)
            {
                node.Triggered = true;
                return Search(node.LeftChild, data);
            }
            else if (data > node.Data)
            {
                node.Triggered = true;
                return Search(node.RightChild, data);
            }

            node.Triggered = true;
            return true;
        }

        public void Delete(int data)
        {
            Root = Delete(Root, data);
        }

        private Node Delete(Node node, int data)
        {
            if (node == Nil)
                throw new ArgumentException("No such element exists!");

            if (data < node.Data)
                node.LeftChild = Delete(node.LeftChild, data);
            else if (data > node.Data)
                node.RightChild = Delete(node.RightChild, data);
            else
            {
                if (node.LeftChild == Nil || node.RightChild == Nil)
                {
                    Node temp = node.LeftChild != Nil ? node.LeftChild : node.RightChild;

                    if (temp == Nil)
                    {
                        temp = node;
                        node = Nil;
                    }
                    else
                        node = temp;
                }
                else
                {
                    Node temp = GetMinValueNode(node.RightChild);
                    node.Data = temp.Data;
                    node.RightChild = Delete(node.RightChild, temp.Data);
                }
            }

            if (node == Nil)
                return node;

            node.Height = 1 + Math.Max(Height(node.LeftChild), Height(node.RightChild));

            int balance = GetBalance(node);

            if (balance > 1)
            {
                if (GetBalance(node.LeftChild) >= 0)
                    return RotateRight(node);

                node.LeftChild = RotateLeft(node.LeftChild);
                return RotateRight(node);
            }

            if (balance < -1)
            {
                if (GetBalance(node.RightChild) <= 0)
                    return RotateLeft(node);

                node.RightChild = RotateRight(node.RightChild);
                return RotateLeft(node);
            }

            return node;
        }

        private Node GetMinValueNode(Node node)
        {
            Node current = node;

            while (current.LeftChild != Nil)
                current = current.LeftChild;

            return current;
        }

        private int Height(Node node)
        {
            if (node == Nil)
                return 0;

            return node.Height;
        }

        private int GetBalance(Node node)
        {
            if (node == Nil)
                return 0;

            return Height(node.LeftChild) - Height(node.RightChild);
        }

        private Node RotateRight(Node y)
        {
            Node x = y.LeftChild;
            Node T2 = x.RightChild;

            x.RightChild = y;
            y.LeftChild = T2;

            y.Height = 1 + Math.Max(Height(y.LeftChild), Height(y.RightChild));
            x.Height = 1 + Math.Max(Height(x.LeftChild), Height(x.RightChild));

            return x;
        }

        private Node RotateLeft(Node x)
        {
            Node y = x.RightChild;
            Node T2 = y.LeftChild;

            y.LeftChild = x;
            x.RightChild = T2;

            x.Height = 1 + Math.Max(Height(x.LeftChild), Height(x.RightChild));
            y.Height = 1 + Math.Max(Height(y.LeftChild), Height(y.RightChild));

            return y;
        }
    }
}

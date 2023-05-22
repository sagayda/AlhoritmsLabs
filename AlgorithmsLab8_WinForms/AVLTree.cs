using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AlgoritmsLab8
{
    public class AVLTree
    {
        public class AVLTreeNode 
        {
            public int Data { get; set; }

            public AVLTreeNode? LeftChild { get; set; }

            public AVLTreeNode? RightChild { get; set; }

            public int NodeHeight { get; set; }

            public AVLTreeNode(int data, int nodeHeight)
            {
                Data = data;
                NodeHeight = nodeHeight;

                LeftChild = null;
                RightChild = null;
            }

            public int GetHeight()
            {
                int leftH = LeftChild == null ? 0 : LeftChild.GetHeight();
                int rightH = RightChild == null ? 0 : RightChild.GetHeight();

                return leftH > rightH ? leftH : rightH;
            }
        }

        public AVLTreeNode root;

        public AVLTree()
        {
            
        }

        public void Add(int data)
        {
            if(root == null)
            {
                root = new(data, 0);
                return;
            }

            RecursiveInsert(root, data, 0);
        }

        private AVLTreeNode RecursiveInsert(AVLTreeNode current, int newData, int height)
        {
            if(current == null)
            {
                current = new(newData, height);
                return current;
            }

            if(newData < current.Data)
            {
                current.LeftChild = RecursiveInsert(current.LeftChild, newData, ++height);
                current = BalanceTree(current);
            }

            if(newData > current.Data)
            {
                current.RightChild = RecursiveInsert(current.RightChild, newData, ++height);
                current = BalanceTree(current);
            }
            return current;
        }

        private AVLTreeNode BalanceTree(AVLTreeNode current)
        {
            int balanceFactor = BalanceFactor(current);

            if(balanceFactor > 1)
            {
                if (BalanceFactor(current.LeftChild) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if(balanceFactor < -1)
            {
                if (BalanceFactor(current.RightChild) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }

            return current;

        }

        private int BalanceFactor(AVLTreeNode current)
        {
            int left = current.LeftChild == null ? 0 : current.LeftChild.GetHeight();
            int right = current.RightChild == null ? 0 : current.RightChild.GetHeight();
            int b_factor = left - right;
            return b_factor;
        }

        private AVLTreeNode RotateRR(AVLTreeNode parent)
        {
            AVLTreeNode pivot = parent.RightChild;
            parent.RightChild = pivot.LeftChild;
            pivot.LeftChild = parent;
            return pivot;
        }
        private AVLTreeNode RotateLL(AVLTreeNode parent)
        {
            AVLTreeNode pivot = parent.LeftChild;
            parent.LeftChild = pivot.RightChild;
            pivot.RightChild = parent;
            return pivot;
        }
        private AVLTreeNode RotateLR(AVLTreeNode parent)
        {
            AVLTreeNode pivot = parent.LeftChild;
            parent.LeftChild = RotateRR(pivot);
            return RotateLL(parent);
        }
        private AVLTreeNode RotateRL(AVLTreeNode parent)
        {
            AVLTreeNode pivot = parent.RightChild;
            parent.RightChild = RotateLL(pivot);
            return RotateRR(parent);
        }

        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
                return;
            }
            InOrderDisplayTree(root);
            Console.WriteLine();
        }
        private void InOrderDisplayTree(AVLTreeNode current)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.LeftChild);
                Console.Write("({0}) ", current.Data);
                InOrderDisplayTree(current.RightChild);
            }
        }
    }
}

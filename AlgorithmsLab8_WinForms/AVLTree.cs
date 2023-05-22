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

            public int NodeHeight => GetHeight();

            public AVLTreeNode(int data)
            {
                Data = data;

                LeftChild = null;
                RightChild = null;
            }

            public int GetHeight()
            {
                int leftH = LeftChild == null ? 0 : LeftChild.GetHeight();
                int rightH = RightChild == null ? 0 : RightChild.GetHeight();

                return leftH > rightH ? leftH +1 : rightH+1;
            }

            public AVLTreeNode Clone()
            {
                AVLTreeNode copy = new(this.Data);

                if (LeftChild != null)
                    copy.LeftChild = LeftChild.Clone();

                if(RightChild != null)
                    copy.RightChild = RightChild.Clone();

                return copy;
            }

            public int GetRightSeperation()
            {
                if(RightChild == null && LeftChild == null) 
                    return 0;

                if (RightChild == null)
                    return LeftChild.GetRightSeperation();

                if(LeftChild == null)
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

        public AVLTreeNode root;

        public AVLTree()
        {
            
        }

        public void Add(int data)
        {
            if(root == null)
            {
                root = new(data);
                return;
            }

            RecursiveInsert(root, data);
        }

        private AVLTreeNode RecursiveInsert(AVLTreeNode current, int newData)
        {
            if(current == null)
            {
                current = new(newData);
                return current;
            }

            if (newData == current.Data)
                throw new ArgumentException();

            if(newData < current.Data)
            {
                current.LeftChild = RecursiveInsert(current.LeftChild, newData);
                current = BalanceTree(current);
            }
            else if(newData > current.Data)
            {
                current.RightChild = RecursiveInsert(current.RightChild, newData);
                current = BalanceTree(current);
            }

            return current;
        }

        private AVLTreeNode BalanceTree(AVLTreeNode current)
        {
            int balanceFactor = BalanceFactor(current);

            if(balanceFactor < -1)
            {
                if(current.RightChild != null)
                {
                    if(current.RightChild.RightChild != null && current.RightChild.LeftChild != null)
                    {
                        if(current.RightChild.RightChild.NodeHeight > current.RightChild.LeftChild.NodeHeight)
                        {


                            //right-left
                            return RightLeftRotation(current);
                        }
                    }
                }

                //left
                return LeftRotation(current);
            }
            else if(balanceFactor > 1)
            {
                if (current.LeftChild != null)
                {
                    if(current.LeftChild.LeftChild != null && current.LeftChild.RightChild != null)
                    {
                        if(current.LeftChild.LeftChild.NodeHeight > current.LeftChild.RightChild.NodeHeight)
                        {
                            //left-right
                            return LeftRightRotation(current);
                        }
                    }

                }

                //right
                return RightRotation(current);
            }



            //if(balanceFactor > 1)
            //{
            //    if (BalanceFactor(current.LeftChild) > 0)
            //    {
            //        current = RotateLL(current);
            //    }
            //    else
            //    {
            //        current = RotateLR(current);
            //    }
            //}
            //else if(balanceFactor < -1)
            //{
            //    if (BalanceFactor(current.RightChild) > 0)
            //    {
            //        current = RotateRL(current);
            //    }
            //    else
            //    {
            //        current = RotateRR(current);
            //    }
            //}

            return current;

        }

        private int BalanceFactor(AVLTreeNode current)
        {
            int left = current.LeftChild == null ? 0 : current.LeftChild.GetHeight();
            int right = current.RightChild == null ? 0 : current.RightChild.GetHeight();
            int balanceFactor = left - right;
            return balanceFactor;
        }

        private AVLTreeNode LeftRotation(AVLTreeNode parent)
        {
            AVLTreeNode pivot = parent.RightChild;
            parent.RightChild = pivot.LeftChild;
            pivot.LeftChild = parent;

            if (root == parent)
                root = pivot;

            return parent;
        }

        private AVLTreeNode RightRotation(AVLTreeNode parent)
        {
            AVLTreeNode pivot = parent.LeftChild;
            parent.LeftChild = pivot.RightChild;
            pivot.RightChild = parent;

            if (root == parent)
                root = pivot;

            return pivot;
        }

        private AVLTreeNode LeftRightRotation(AVLTreeNode parent)
        {
            LeftRotation(parent.LeftChild);
            return RightRotation(parent);
        }

        private AVLTreeNode RightLeftRotation(AVLTreeNode parent)
        {
            RightRotation(parent.RightChild);
            return LeftRotation(parent);
        }
        //private AVLTreeNode RotateRR(AVLTreeNode parent)
        //{
        //    AVLTreeNode pivot = parent.RightChild;
        //    parent.RightChild = pivot.LeftChild;
        //    pivot.LeftChild = parent;
        //    return pivot;
        //}
        //private AVLTreeNode RotateLL(AVLTreeNode parent)
        //{
        //    AVLTreeNode pivot = parent.LeftChild;
        //    parent.LeftChild = pivot.RightChild;
        //    pivot.RightChild = parent;
        //    return pivot;
        //}
        //private AVLTreeNode RotateLR(AVLTreeNode parent)
        //{
        //    AVLTreeNode pivot = parent.LeftChild;
        //    parent.LeftChild = RotateRR(pivot);
        //    return RotateLL(parent);
        //}
        //private AVLTreeNode RotateRL(AVLTreeNode parent)
        //{
        //    AVLTreeNode pivot = parent.RightChild;
        //    parent.RightChild = RotateLL(pivot);
        //    return RotateRR(parent);
        //}

        private int GetMaxHeightFromNode(AVLTreeNode node)
        {
            if(node.RightChild == null && node.LeftChild == null) 
            {
                return 1;
            }

            if(node.RightChild == null)
            {
                return 1 + GetMaxHeightFromNode(node.LeftChild);
            }

            if(node.LeftChild == null)
            {
                return 1 + GetMaxHeightFromNode(node.RightChild);
            }

            int r = 1 + GetMaxHeightFromNode(node.RightChild);
            int l = 1 + GetMaxHeightFromNode(node.LeftChild);

            return r > l ? r : l;
        }

    }
}

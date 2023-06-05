using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmsLab8
{
    public class RedBlackTree
    {
        private Node root;
        private Node sentinel;

        private enum Color
        {
            Red,
            Black
        }

        private class Node
        {
            public int value;
            public Node parent;
            public Node left;
            public Node right;
            public Color color;

            public Node(int value)
            {
                this.value = value;
                parent = null;
                left = null;
                right = null;
                color = Color.Red;
            }
        }

        public RedBlackTree()
        {
            sentinel = new Node(default);
            sentinel.color = Color.Black;
            root = sentinel;
        }

        public void Insert(int value)
        {
            var newNode = new Node(value);
            var current = root;
            Node parent = null;

            while (current != sentinel)
            {
                parent = current;

                if (value < current.value)
                    current = current.left;
                else if (value > current.value)
                    current = current.right;
                else
                    return; // Duplicate value, do nothing
            }

            newNode.parent = parent;

            if (parent == null)
                root = newNode;
            else if (value < parent.value)
                parent.left = newNode;
            else
                parent.right = newNode;

            newNode.left = sentinel;
            newNode.right = sentinel;
            newNode.color = Color.Red;

            InsertFixup(newNode);
        }

        private void InsertFixup(Node node)
        {
            while (node.parent.color == Color.Red)
            {
                if (node.parent == node.parent.parent.left)
                {
                    var uncle = node.parent.parent.right;

                    if (uncle.color == Color.Red)
                    {
                        node.parent.color = Color.Black;
                        uncle.color = Color.Black;
                        node.parent.parent.color = Color.Red;
                        node = node.parent.parent;
                    }
                    else
                    {
                        if (node == node.parent.right)
                        {
                            node = node.parent;
                            RotateLeft(node);
                        }

                        node.parent.color = Color.Black;
                        node.parent.parent.color = Color.Red;
                        RotateRight(node.parent.parent);
                    }
                }
                else
                {
                    var uncle = node.parent.parent.left;

                    if (uncle.color == Color.Red)
                    {
                        node.parent.color = Color.Black;
                        uncle.color = Color.Black;
                        node.parent.parent.color = Color.Red;
                        node = node.parent.parent;
                    }
                    else
                    {
                        if (node == node.parent.left)
                        {
                            node = node.parent;
                            RotateRight(node);
                        }

                        node.parent.color = Color.Black;
                        node.parent.parent.color = Color.Red;
                        RotateLeft(node.parent.parent);
                    }
                }
            }

            root.color = Color.Black;
        }

        private void RotateLeft(Node node)
        {
            var rightChild = node.right;
            node.right = rightChild.left;

            if (rightChild.left != sentinel)
                rightChild.left.parent = node;

            rightChild.parent = node.parent;

            if (node.parent == null)
                root = rightChild;
            else if (node == node.parent.left)
                node.parent.left = rightChild;
            else
                node.parent.right = rightChild;

            rightChild.left = node;
            node.parent = rightChild;
        }

        private void RotateRight(Node node)
        {
            var leftChild = node.left;
            node.left = leftChild.right;

            if (leftChild.right != sentinel)
                leftChild.right.parent = node;

            leftChild.parent = node.parent;

            if (node.parent == null)
                root = leftChild;
            else if (node == node.parent.left)
                node.parent.left = leftChild;
            else
                node.parent.right = leftChild;

            leftChild.right = node;
            node.parent = leftChild;
        }

        public void PrintTree()
        {
            PrintTree(root);
        }

        private void PrintTree(Node node)
        {
            if (node != sentinel)
            {
                PrintTree(node.left);
                Console.WriteLine($"{node.value} ({node.color})");
                PrintTree(node.right);
            }
        }
    }
}

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
        public class Node 
        {
            public int Data { get; set; }

            public Node? LeftChild { get; set; }

            public Node? RightChild { get; set; }

            public bool Triggered { get; set; } = false;

            public Node(int data)
            {
                Data = data;

                LeftChild = null;
                RightChild = null;
            }

            public int GetHeight(Node nil)
            {
                int leftH = LeftChild == nil ? 0 : LeftChild.GetHeight(nil);
                int rightH = RightChild == nil ? 0 : RightChild.GetHeight(nil);

                return leftH > rightH ? leftH +1 : rightH+1;
            }

            public Node Clone()
            {
                Node copy = new(this.Data);

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
            Root = InsertNode(Root, data);
        }

        private Node InsertNode(Node node, int data)
        {
            if (node == Nil)
            {
                Node newNode = new(data);
                newNode.RightChild = Nil;
                newNode.LeftChild = Nil;

                return newNode;
            }

            if (data < node.Data)
            {
                node.LeftChild = InsertNode(node.LeftChild, data);
            }
            else if (data > node.Data)
            {
                node.RightChild = InsertNode(node.RightChild, data);
            }
            else
            {
                return node;
            }

            int balanceFactor = GetBalanceFactor(node);
            if (balanceFactor > 1 || balanceFactor < -1)
            {
                if (data < node.Data)
                {
                    if (data < node.LeftChild!.Data)
                    {
                        // Лево-левый случай
                        node = RotateRight(node);
                    }
                    else
                    {
                        // Лево-правый случай
                        node.LeftChild = RotateLeft(node.LeftChild);
                        node = RotateRight(node);
                    }
                }
                else
                {
                    if (data > node.RightChild!.Data)
                    {
                        // Право-правый случай
                        node = RotateLeft(node);
                    }
                    else
                    {
                        // Право-левый случай
                        node.RightChild = RotateRight(node.RightChild);
                        node = RotateLeft(node);
                    }
                }
            }

            return node;
        }

        public bool Search(int data)
        {
            Root.Triggered = true;

            return SearchNode(Root, data) != Nil;
        }

        private Node SearchNode(Node node, int data)
        {
            if (node == Nil)
                return node;

            node.Triggered = true;

            if (node.Data == data)
            {
                return node;
            }

            if (data < node.Data)
            {
                // Рекурсивный поиск в левом поддереве
                return SearchNode(node.LeftChild, data);
            }
            else
            {
                // Рекурсивный поиск в правом поддереве
                return SearchNode(node.RightChild, data);
            }
        }

        public void Delete(int data)
        {
            Root = DeleteNode(Root, data);
        }

        private Node DeleteNode(Node node, int data)
        {
            if (node == Nil)
            {
                // Узел не найден, возвращаем null
                return null;
            }

            if (data < node.Data)
            {
                // Рекурсивное удаление из левого поддерева
                node.LeftChild = DeleteNode(node.LeftChild, data);
            }
            else if (data > node.Data)
            {
                // Рекурсивное удаление из правого поддерева
                node.RightChild = DeleteNode(node.RightChild, data);
            }
            else
            {
                // Найден узел для удаления

                if (node.LeftChild == Nil && node.RightChild == Nil)
                {
                    // Узел является листом
                    return null;
                }
                else if (node.LeftChild == Nil)
                {
                    // Узел имеет только правого потомка
                    return node.RightChild;
                }
                else if (node.RightChild == Nil)
                {
                    // Узел имеет только левого потомка
                    return node.LeftChild;
                }
                else
                {
                    // Узел имеет оба потомка

                    // Находим наименьший элемент в правом поддереве
                    Node minValueNode = FindMinValueNode(node.RightChild);

                    // Заменяем значение удаляемого узла на найденное минимальное значение
                    node.Data = minValueNode.Data;

                    // Рекурсивно удаляем найденный минимальный узел из правого поддерева
                    node.RightChild = DeleteNode(node.RightChild, minValueNode.Data);
                }
            }

            // После удаления, выполняем повороты и обновляем высоты узлов
            int balanceFactor = GetBalanceFactor(node);
            if (balanceFactor > 1 || balanceFactor < -1)
            {
                // Нарушен баланс, выполняем повороты
                if (data < node.Data)
                {
                    // Удаленный элемент находился в левом поддереве левого потомка
                    if (data < node.LeftChild!.Data)
                    {
                        // Лево-левый случай
                        node = RotateRight(node);
                    }
                    else
                    {
                        // Лево-правый случай
                        node.LeftChild = RotateLeft(node.LeftChild);
                        node = RotateRight(node);
                    }
                }
                else
                {
                    // Удаленный элемент находился в правом поддереве правого потомка
                    if (data > node.RightChild!.Data)
                    {
                        // Право-правый случай
                        node = RotateLeft(node);
                    }
                    else
                    {
                        // Право-левый случай
                        node.RightChild = RotateRight(node.RightChild);
                        node = RotateLeft(node);
                    }
                }
            }

            return node;
        }

        private Node FindMinValueNode(Node node)
        {
            if (node.LeftChild == Nil)
            {
                return node;
            }
            else
            {
                return FindMinValueNode(node.LeftChild);
            }
        }

        private int GetBalanceFactor(Node node)
        {
            int leftHeight = node.LeftChild == Nil ? 0 : node.LeftChild.GetHeight(Nil);
            int rightHeight = node.RightChild == Nil ? 0 : node.RightChild.GetHeight(Nil);

            return leftHeight - rightHeight;
        }

        private Node RotateLeft(Node node)
        {
            Node pivot = node.RightChild!;
            node.RightChild = pivot.LeftChild;
            pivot.LeftChild = node;

            if(Root == node)
                Root = pivot;

            return pivot;
        }

        private Node RotateRight(Node node)
        {
            Node pivot = node.LeftChild!;
            node.LeftChild = pivot.RightChild;
            pivot.RightChild = node;

            if (Root == node)
                Root = pivot;

            return pivot;
        }
    }
}

namespace AlgoritmsLab8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AVLTree aVLTree = new AVLTree();

            //aVLTree.Add(5);
            //aVLTree.Add(3);
            //aVLTree.Add(7);
            //aVLTree.Add(2);
            //aVLTree.DisplayTree();

            //aVLTree.Add(2);

            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                aVLTree.Add(random.Next(0, 100));
            }
            aVLTree.DisplayTree();

            //while (true)
            //{
            //    aVLTree.Add(random.Next(1, 99));
            //    Console.Write("-----------------------");
            //    aVLTree.DisplayTree();
            //}

        }
    }
}
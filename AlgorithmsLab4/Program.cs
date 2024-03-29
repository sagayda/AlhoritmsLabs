﻿namespace AlgorithmsLab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QueueByArray<string> queue = new QueueByArray<string>(1);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

            queue.Enqueue("F");

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

            QueueByIndex<string> queueByIndex = new QueueByIndex<string>();
            queueByIndex.Enqueue("A");
            queueByIndex.Enqueue("B");
            queueByIndex.Enqueue("C");
            queueByIndex.Enqueue("D");
            queueByIndex.Enqueue("E");

            Console.WriteLine(queueByIndex.Dequeue());
            Console.WriteLine(queueByIndex.Dequeue());

            queueByIndex.Enqueue("F");
            Console.WriteLine(queueByIndex.Dequeue());
        }
    }
}
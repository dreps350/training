using System;
using System.Threading;

namespace AlgorithmsDataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<int>();
            foreach (var item in new int[] { 1, 2, 3, 4, 5 }) {
                queue.Enqueue(item);
            }
            for (var counter = 0; queue.Size() > 0; counter++)
            {
                var item = queue.Dequeue();
                Console.WriteLine($"Handling item #{item}");
                Thread.Sleep(1000);
                if (counter % 2 == 0)
                {
                    queue.Enqueue(item);
                }
            }
        }
    }
}

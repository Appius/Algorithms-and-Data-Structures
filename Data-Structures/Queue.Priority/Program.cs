#region

using System;

#endregion

namespace Queue.Priority
{
    internal class Program
    {
        private static void Main()
        {
            var queue = new PriorityQueue<int>();

            queue.Push(184);
            queue.Push(54);
            queue.Push(58);
            queue.Push(568);
            queue.Push(214);
            queue.Push(652);
            Console.WriteLine(queue);

            queue.Pop();
            Console.WriteLine(queue);

            queue.Pop();
            queue.Peek();
            Console.WriteLine(queue);

            Console.ReadKey();
        }
    }
}
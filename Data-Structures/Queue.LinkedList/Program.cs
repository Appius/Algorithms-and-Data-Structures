#region

using System;

#endregion

namespace Queue.LinkedList
{
    internal class Program
    {
        private static void Main()
        {
            var queue = new Queue<int>();

            queue.Push(3);
            queue.Push(5);
            queue.Push(7);
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
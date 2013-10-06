#region

using System;
using DoublyLinkedList.Models;

#endregion

namespace DoublyLinkedList
{
    internal class Program
    {
        private static void Main()
        {
            var list = new LinkedList<int>();
            list.AddLast(3);
            list.AddLast(5);
            list.AddLast(7);
            Console.WriteLine(list);

            list.RemoveFirst();
            Console.WriteLine(list);

            list.AddFirst(9);
            Console.WriteLine(list);

            list.RemoveLast();
            Console.WriteLine(list);

            Console.ReadKey();
        }
    }
}
#region

using System;

#endregion

namespace Stack.Array
{
    internal class Program
    {
        private static void Main()
        {
            var stack = new Stack<int>();

            stack.Push(3);
            stack.Push(5);
            stack.Push(7);
            Console.WriteLine(stack);

            stack.Pop();
            Console.WriteLine(stack);

            stack.Pop();
            stack.Peek();
            Console.WriteLine(stack);

            Console.ReadKey();
        }
    }
}
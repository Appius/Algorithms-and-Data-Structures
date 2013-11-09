#region

using System;
using BinaryTree.Models;

#endregion

namespace BinaryTree
{
    internal class Program
    {
        private static void Main()
        {
            var binaryTree = new BinaryTree<int> {5, 3, 9, 1, -5, 0, 2};

            Console.WriteLine("{0}, count of items: {1}", binaryTree, binaryTree.Count);

            const int val = 1;
            Console.WriteLine("Removing value - {0}...", val);
            binaryTree.Remove(val);

            Console.WriteLine("{0}, count of items: {1}", binaryTree, binaryTree.Count);
            Console.ReadKey();
        }
    }
}
#region

using System;

#endregion

namespace SortingAlgorimths
{
    internal class Program
    {
        private static void Display(params int[] data)
        {
            Console.WriteLine(string.Join(" ", data));
        }

        private static void Main()
        {
            var data = new[] {6, 4, 1, 4, 7, -6, 7};
            Display(data);

//            Display(SortingAlgorithms<int>.BubbleSort(data));
//            Display(SortingAlgorithms<int>.InsertionSort(data));
//            Display(SortingAlgorithms<int>.SelectionSort(data));
//            Display(SortingAlgorithms<int>.MergeSort(data));
            Display(SortingAlgorithms<int>.QuickSort(data));

            Console.ReadKey();
        }
    }
}
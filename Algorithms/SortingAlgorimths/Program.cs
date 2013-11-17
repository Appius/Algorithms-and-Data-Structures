using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorimths
{
    class Program
    {
        private static void Display(params int[] data)
        {
            Console.WriteLine(string.Join(" ",data));
        }

        static void Main(string[] args)
        {
            var data = new[] {1, 6, 9, 4, 7, -6, 7};
            Display(data);
            
//            Display(SortingAlgorithms<int>.BubbleSort(data));
//            Display(SortingAlgorithms<int>.InsertionSort(data));
            Display(SortingAlgorithms<int>.SelectionSort(data));

            Console.ReadKey();
        }
    }
}

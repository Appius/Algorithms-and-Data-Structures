using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingAlgorimths;

namespace Algorithms.Tests.SortingAlgorithms
{
    [TestClass]
    public class QuickSortTests
    {
        private readonly Random _random = new Random();

        [TestMethod]
        public void QuickTest()
        {
            const int n = 1000000; // 1.000.000

            var array = new int[n];
            for (int i = 0; i < n; i++)
                array[i] = _random.Next();

            var newArray = new int[n];
            array.CopyTo(newArray, 0);

            array = SortingAlgorithms<int>.QuickSort(array);
            Array.Sort(newArray);

            for(int i=0;i<n;i++)
                Assert.AreEqual(array[i], newArray[i], "Arrays aren't equals.");
        }
    }
}
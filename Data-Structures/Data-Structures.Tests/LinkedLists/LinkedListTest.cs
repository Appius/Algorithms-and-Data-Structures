using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data_Structures.Tests.LinkedLists
{
    [TestClass]
    public class LinkedListTest
    {
        private static readonly int[] TestData = {0, 1, 2, 3, -6, 10, -3};

        #region Adding tests

        [TestMethod]
        [TestCategory("Add")]
        public void Add_Raw_Value_Success_Cases()
        {
            var list = new LinkedList.LinkedList<int>();
            foreach (int value in TestData)
            {
                list.Add(value);
            }

            Assert.AreEqual(TestData.Length, list.Count,
                "There was an unexpected number of list items");

            Assert.AreEqual(TestData.Last(), list.Head.Value,
                "The first item value was incorrect");

            Assert.AreEqual(TestData.First(), list.Tail.Value,
                "The last item value was incorrect");

            int[] reversed = TestData.Reverse().ToArray();
            int current = 0;

            foreach (int value in list)
            {
                Assert.AreEqual(reversed[current], value, "The list value at index {0} was incorrect.", current);
                current++;
            }
        }

        [TestMethod]
        [TestCategory("Add")]
        public void AddFirst_Node_Value_Success_Cases()
        {
            var list = new LinkedList.LinkedList<int>();
            foreach (int value in TestData)
            {
                list.AddFirst(new LinkedList.LinkedListNode<int>(value));
            }

            Assert.AreEqual(TestData.Length, list.Count,
                "There was an unexpected number of list items");

            Assert.AreEqual(TestData.Last(), list.Head.Value,
                "The first item value was incorrect");

            Assert.AreEqual(TestData.First(), list.Tail.Value,
                "The last item value was incorrect");

            int[] reversed = TestData.Reverse().ToArray();
            int current = 0;

            foreach (int value in list)
            {
                Assert.AreEqual(reversed[current], value, "The list value at index {0} was incorrect.", current);
                current++;
            }
        }

        [TestMethod]
        [TestCategory("Add")]
        public void AddLast_Raw_Value_Success_Cases()
        {
            var list = new LinkedList.LinkedList<int>();
            foreach (int value in TestData)
            {
                list.AddLast(value);
            }

            Assert.AreEqual(TestData.Length, list.Count,
                "There was an unexpected number of list items");

            Assert.AreEqual(TestData.First(), list.Head.Value,
                "The first item value was incorrect");

            Assert.AreEqual(TestData.Last(), list.Tail.Value,
                "The last item value was incorrect");

            int current = 0;
            foreach (int value in list)
            {
                Assert.AreEqual(TestData[current], value, "The list value at index {0} was incorrect.", current);
                current++;
            }
        }

        [TestMethod]
        [TestCategory("Add")]
        public void AddLast_Node_Value_Success_Cases()
        {
            var list = new LinkedList.LinkedList<int>();
            foreach (int value in TestData)
            {
                list.AddLast(new LinkedList.LinkedListNode<int>(value));
            }

            Assert.AreEqual(TestData.Length, list.Count,
                "There was an unexpected number of list items");

            Assert.AreEqual(TestData.First(), list.Head.Value,
                "The first item value was incorrect");

            Assert.AreEqual(TestData.Last(), list.Tail.Value,
                "The last item value was incorrect");

            int current = 0;
            foreach (int value in list)
            {
                Assert.AreEqual(TestData[current], value, "The list value at index {0} was incorrect.", current);
                current++;
            }
        }

        #endregion

        #region Clearing tests

        [TestMethod]
        [TestCategory("Clear")]
        public void Clear_Empty()
        {
            var list = new LinkedList.LinkedList<int>();

            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(0, list.Count);

            list.Clear();

            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        [TestCategory("Clear")]
        public void Clear_VariousItems()
        {
            var list = new LinkedList.LinkedList<int>();
            foreach (int value in TestData)
            {
                list.AddLast(new LinkedList.LinkedListNode<int>(value));
            }

            Assert.IsNotNull(list.Head);
            Assert.IsNotNull(list.Tail);
            Assert.AreEqual(TestData.Length, list.Count);

            list.Clear();

            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
            Assert.AreEqual(0, list.Count);
        }

        #endregion

        #region CopyTo tests

        [TestMethod]
        [TestCategory("CopyTo")]
        public void CopyTo_Empty_List()
        {
            var list = new LinkedList.LinkedList<int>();
            var array = new int[1];
            list.CopyTo(array, 0);
        }

        [TestMethod]
        [TestCategory("CopyTo")]
        public void CopyTo_Zero_Index()
        {
            var list = new LinkedList.LinkedList<int>();
            foreach (int data in TestData)
            {
                list.AddLast(data);
            }

            var newArray = new int[TestData.Length];
            list.CopyTo(newArray, 0);

            for (int i=0;i<newArray.Length;i++)
            {
                Assert.AreEqual(TestData[i], newArray[i], "The resulting array was not correct");
                
            }
//            Assert.AreEqual(TestData, newArray, "The resulting array was not correct");
        }

        [TestMethod]
        [TestCategory("CopyTo")]
        public void CopyTo_Nth_Index()
        {
            var list = new LinkedList.LinkedList<int>();
            foreach (int data in TestData)
            {
                list.AddLast(data);
            }

            int preOffset = (DateTime.Now.Millisecond%20) + 1;
            int postOffset = preOffset;

            var newArray = new int[preOffset + TestData.Length + postOffset];
            list.CopyTo(newArray, preOffset);

            for (int i = preOffset, x = 0; i < (preOffset + TestData.Length); i++, x++)
            {
                Assert.AreEqual(TestData[x], newArray[i], "The expected value was not correct");
            }
        }

        #endregion

        #region Enumerating tests

        [TestMethod]
        [TestCategory("Enumerate")]
        public void Enumerate_Empty()
        {
            var list = new LinkedList.LinkedList<int>();
            foreach (int value in list)
            {
                Assert.Fail("There should be nothing to enumerate");
            }
        }

        [TestMethod]
        [TestCategory("Enumerate")]
        public void Enumerate_Various()
        {
            var list = new LinkedList.LinkedList<int>();
            foreach (int value in TestData)
            {
                list.AddLast(new LinkedList.LinkedListNode<int>(value));
            }

            // repeat enumeration multiple times
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(TestData.Length, list.Count,
                    "The list length was not the expected value.");

                int expectedIndex = 0;
                foreach (int value in list)
                {
                    Assert.AreEqual(TestData[expectedIndex], value,
                        "The enumerated node value was not the expected value.");

                    expectedIndex++;
                }
            }
        }

        [TestMethod]
        [TestCategory("Enumerate")]
        public void Enumerate_Raw_Various()
        {
            var list = new LinkedList.LinkedList<int>();
            foreach (int value in TestData)
            {
                list.AddLast(new LinkedList.LinkedListNode<int>(value));
            }

            // repeat enumeration multiple times
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(TestData.Length, list.Count,
                    "The list length was not the expected value.");

                int expectedIndex = 0;

                IEnumerable<int> rawEnum = list;

                foreach (int value in rawEnum)
                {
                    Assert.AreEqual(TestData[expectedIndex], value,
                        "The enumerated value was not the expected value.");

                    expectedIndex++;
                }
            }
        }

        #endregion

        #region Finding tests

        [TestMethod]
        [TestCategory("Find")]
        public void Find_Empty()
        {
            var list = new LinkedList.LinkedList<int>();
            Assert.IsFalse(list.Contains(10), "Nothing should have been found.");
        }

        [TestMethod]
        [TestCategory("Find")]
        public void Find_Found()
        {
            var list = new LinkedList.LinkedList<int>();
            foreach (int data in TestData)
            {
                list.AddLast(new LinkedList.LinkedListNode<int>(data));
            }

            Assert.IsTrue(list.Contains(10), "There should have been a node found");
        }

        [TestMethod]
        [TestCategory("Find")]
        public void Find_Missing()
        {
            var list = new LinkedList.LinkedList<int>();
            foreach (int data in TestData)
            {
                list.AddLast(new LinkedList.LinkedListNode<int>(data));
            }

            Assert.IsFalse(list.Contains(-8), "There should have been a node found");
        }

        #endregion

        #region Removing tests

        [TestMethod]
        [TestCategory("Remove")]
        public void RemoveFirstLast_Empty_Lists()
        {
            var list = new LinkedList.LinkedList<int>();
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);

            list.RemoveFirst();
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);

            list.RemoveLast();
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        [TestCategory("Remove")]
        public void RemoveFirstLast_One_Node()
        {
            var list = new LinkedList.LinkedList<int>();

            list.AddFirst(10);
            list.RemoveFirst();
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);

            list.AddFirst(10);
            list.RemoveLast();
            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        [TestCategory("Remove")]
        public void RemoveFirstLast_Two_Node()
        {
            var list = new LinkedList.LinkedList<int>();

            list.AddFirst(10);
            list.AddFirst(20);

            list.RemoveFirst();
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(10, list.Head.Value);
            Assert.AreEqual(10, list.Tail.Value);

            list.AddFirst(10);
            list.RemoveLast();
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(10, list.Head.Value);
            Assert.AreEqual(10, list.Tail.Value);
        }

        [TestMethod]
        [TestCategory("Remove")]
        public void RemoveFirst_Ten_Nodes()
        {
            var list = new LinkedList.LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.AddFirst(i);
            }

            for (int i = 10; i > 0; i--)
            {
                Assert.AreEqual(i, list.Count, "Unexpected list count");
                list.RemoveFirst();
            }

            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        [TestCategory("Remove")]
        public void RemoveLast_Ten_Nodes()
        {
            var list = new LinkedList.LinkedList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.AddFirst(i);
            }

            for (int i = 10; i > 0; i--)
            {
                Assert.AreEqual(i, list.Count, "Unexpected list count");
                list.RemoveLast();
            }

            Assert.AreEqual(0, list.Count);
            Assert.IsNull(list.Head);
            Assert.IsNull(list.Tail);
        }

        [TestMethod]
        [TestCategory("Remove")]
        public void Remove_Missing()
        {
            var list = new LinkedList.LinkedList<int>();
            foreach (int data in TestData)
            {
                list.AddLast(new LinkedList.LinkedListNode<int>(data));
            }

            Assert.IsFalse(list.Remove(99), "Nothing should have been removed");
            Assert.AreEqual(TestData.Length, list.Count, "The expected list count was incorrect");
        }

        public void Remove_Found()
        {
            var list = new LinkedList.LinkedList<int>();
            foreach (int data in TestData)
            {
                list.AddLast(new LinkedList.LinkedListNode<int>(data));
            }

            Assert.IsTrue(list.Remove(10), "A node should have been removed");
            Assert.AreEqual(TestData.Length - 1, list.Count, "The expected list count was incorrect");
        }

        #endregion
    }
}
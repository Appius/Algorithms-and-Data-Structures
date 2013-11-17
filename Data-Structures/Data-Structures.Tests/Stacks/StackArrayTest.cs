using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stack.Array;

namespace Data_Structures.Tests.Stacks
{
    [TestClass]
    public class StackArrayTest
    {
        private static readonly int[] TestData = { 0, 1, 2, 3, -6, 10, -3 };

        [TestMethod]
        public void Stack_Success_Cases()
        {
            var stack = new Stack<int>();

            for (int i = 0; i < TestData.Length; i++)
            {
                Assert.AreEqual(stack.Count, i, "The stack count is off");

                stack.Push(TestData[i]);

                Assert.AreEqual(stack.Count, i + 1, "The stack count is off");

                Assert.AreEqual(TestData[i], stack.Peek(), "The recently pushed value is not peeking");

                int counter = i;
                foreach (int value in stack)
                {
                    Assert.AreEqual(TestData[counter], value, "The enumeration is not accurate");
                    counter--;
                }
            }

            Assert.AreEqual(TestData.Length, stack.Count, "The end count was not as expected");

            for (int i = TestData.Length - 1; i >= 0; i--)
            {
                int expected = TestData[i];
                Assert.AreEqual(expected, stack.Peek(), "The peeked value was not expected");
                Assert.AreEqual(expected, stack.Pop(), "The popped value was not expected");
                Assert.AreEqual(i, stack.Count, "The popped value was not expected");
            }
        }

        [TestMethod]
        public void Clear_Success_Cases()
        {
            var s = new Stack<int>();

            foreach (int i in TestData)
            {
                s.Push(i);
            }

            Assert.AreEqual(TestData.Length, s.Count, "Count is not accurate");

            s.Clear();

            Assert.AreEqual(0, s.Count);

            foreach (int missing in s)
            {
                Assert.Fail("There should be nothing in the list");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_From_Empty_Throws()
        {
            var s = new Stack<int>();
            s.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_From_Empty_Throws_After_Push()
        {
            var s = new Stack<int>();
            s.Push(1);
            s.Pop();
            s.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_From_Empty_Throws()
        {
            var s = new Stack<int>();
            s.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_From_Empty_Throws_After_Push()
        {
            var s = new Stack<int>();
            s.Push(1);
            s.Pop();
            s.Peek();
        }
    }
}

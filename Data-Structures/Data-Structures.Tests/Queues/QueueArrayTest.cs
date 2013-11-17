using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Queue.Array;

namespace Data_Structures.Tests.Queues
{
    [TestClass]
    public class QueueArrayTest
    {
        [TestMethod]
        public void Enqueue_Updates_Count()
        {
            var queue = new Queue<int>();

            Assert.AreEqual(0, queue.Count, "The count should start at 0");

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i, queue.Count, "The count was off before calling Enqueue...");
                queue.Push(i);
                Assert.AreEqual(i + 1, queue.Count, "The count was off after calling Enqueue...");
            }
        }

        [TestMethod]
        public void Dequeue_Peek_Correct_Order()
        {
            var queue = new Queue<int>();
            for (int i = 0; i < 10; i++)
            {
                queue.Push(i);
            }

            int expectedCount = queue.Count;

            for (int expected = 0; expected < 10; expected++)
            {
                Assert.AreEqual(expectedCount, queue.Count, "The count was off before Peek");

                Assert.AreEqual(expected, queue.Peek(), "Peek returned an unexpected result");

                Assert.AreEqual(expectedCount, queue.Count, "The count was off after Peek");

                Assert.AreEqual(expected, queue.Pop(), "Dequeue returned an unexpected result");

                Assert.AreEqual(expectedCount - 1, queue.Count, "The count was off after Dequeue");

                expectedCount--;
            }
        }

        [TestMethod]
        public void Enqueue_Wrapping()
        {
            var queue = new Queue<int>();
            // fills the array (growth is 0 -> 4 -> 8)
            for (int i = 0; i < 8; i++)
            {
                queue.Push(i);
            }

            var expected = 0;
            foreach (int actual in queue)
            {
                Assert.AreEqual(expected++, actual, "The enumerated value was not what was expected");
            }

            // now remove three items 
            Assert.AreEqual(0, queue.Pop(), "Unexpected dequeue value");
            Assert.AreEqual(1, queue.Pop(), "Unexpected dequeue value");
            Assert.AreEqual(2, queue.Pop(), "Unexpected dequeue value");

            // now 3..7 are left

            // put three more items back in to cause wrapping without growth
            for (int i = 0; i < 4; i++)
            {
                queue.Push(i);
            }

            Assert.AreEqual(3, queue.Pop(), "Unexpected dequeue value");
            Assert.AreEqual(4, queue.Pop(), "Unexpected dequeue value");
            Assert.AreEqual(5, queue.Pop(), "Unexpected dequeue value");
            Assert.AreEqual(6, queue.Pop(), "Unexpected dequeue value");
            Assert.AreEqual(7, queue.Pop(), "Unexpected dequeue value");
            Assert.AreEqual(0, queue.Pop(), "Unexpected dequeue value");
            Assert.AreEqual(1, queue.Pop(), "Unexpected dequeue value");
            Assert.AreEqual(2, queue.Pop(), "Unexpected dequeue value");
        }

        [TestMethod]
        public void Enumeration_Simple()
        {
            var queue = new Queue<int>();
            for (int i = 0; i < 10; i++)
            {
                queue.Push(i);
            }

            int expected = 0;

            foreach (int i in queue)
            {
                Assert.AreEqual(expected, i, "The enumerated value was not expected");
                expected++;
            }
        }
    }
}

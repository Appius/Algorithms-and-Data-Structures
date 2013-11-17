using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Queue.Priority;

namespace Data_Structures.Tests.Queues
{
    [TestClass]
    public class QueuePriorityTest
    {
        [TestMethod]
        public void Enqueue_Simple()
        {
            var q = new PriorityQueue<int>();
            for (int i = 0; i < 10; i++)
            {
                q.Push(i);
            }

            Assert.AreEqual(q.Count, 10, "The wrong number of items are in the queue");

            var expected = 9;
            while (q.Count > 0)
            {
                Assert.AreEqual(expected, q.Pop(), "The expected priority value was not dequeued");
                expected--;
            }
        }

        [TestMethod]
        public void Enqueue_Specific()
        {
            var q = new PriorityQueue<int>();

            q.Push(5);
            q.Push(4);
            q.Push(2);
            q.Push(4);
            q.Push(6);
            q.Push(3);

            Assert.AreEqual(6, q.Pop(), "Unexpected pq value");
            Assert.AreEqual(5, q.Pop(), "Unexpected pq value");
            Assert.AreEqual(4, q.Pop(), "Unexpected pq value");
            Assert.AreEqual(4, q.Pop(), "Unexpected pq value");
            Assert.AreEqual(3, q.Pop(), "Unexpected pq value");
            Assert.AreEqual(2, q.Pop(), "Unexpected pq value");
        }

        [TestMethod]
        public void Enumeration_Simple()
        {
            int[] input = { 2, 4, 7, 4, 2, 8, 1 };
            int[] expected = { 8, 7, 4, 4, 2, 2, 1 };

            var queue = new PriorityQueue<int>();

            foreach (int i in input)
            {
                queue.Push(i);
            }

            var index = 0;

            foreach (int i in queue)
            {
                Assert.AreEqual(expected[index], i, "The enumerated value was unexpected");
                index++;
            }
        }
    }
}
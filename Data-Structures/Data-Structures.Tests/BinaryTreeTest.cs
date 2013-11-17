#region

using System;
using BinaryTree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#endregion

namespace Data_Structures.Tests
{
    [TestClass]
    public class BinaryTreeTest
    {
        [TestMethod]
        public void Remove_Head()
        {
            var tree = new BinaryTree<int>();

            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8

            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(3);
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);

            tree.Remove(4);

            //        5
            //       /   \
            //      2      7
            //     / \    / \
            //    1   3  6  8


            int[] expected = {1, 3, 2, 6, 8, 7, 5};

            var index = 0;

            tree.PostOrderTraversals(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [TestMethod]
        public void Remove_Head_Line_Right()
        {
            var tree = new BinaryTree<int>();

            // 1
            //  \
            //   2
            //    \
            //     3


            tree.Add(1);
            tree.Add(2);
            tree.Add(3);

            tree.Remove(1);

            // 2
            //  \
            //   3


            int[] expected = {3, 2};

            var index = 0;

            tree.PostOrderTraversals(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [TestMethod]
        public void Remove_Head_Line_Left()
        {
            var tree = new BinaryTree<int>();

            //     3
            //    /
            //   2
            //  /
            // 1


            tree.Add(3);
            tree.Add(2);
            tree.Add(1);

            tree.Remove(3);

            //   2
            //  /
            // 1

            int[] expected = {1, 2};

            var index = 0;

            tree.PostOrderTraversals(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [TestMethod]
        public void Remove_Head_Only_Node()
        {
            var tree = new BinaryTree<int>();

            tree.Add(4);

            Assert.IsTrue(tree.Remove(4), "Remove should return true for found node");

            foreach (var item in tree)
            {
                Assert.Fail("An empty tree should not enumerate any values");
            }
        }

        [TestMethod]
        public void Remove_Node_No_Left_Child()
        {
            var tree = new BinaryTree<int>();

            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8

            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(3);
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);

            Assert.IsTrue(tree.Remove(5), "Remove should return true for found node");

            //        4
            //       /  \
            //      2    6
            //     / \    \
            //    1   3    7
            //              \
            //               8

            int[] expected = {1, 3, 2, 8, 7, 6, 4};

            var index = 0;

            tree.PostOrderTraversals(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [TestMethod]
        public void Remove_Node_Right_Leaf()
        {
            var tree = new BinaryTree<int>();

            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8

            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(3);
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);

            Assert.IsTrue(tree.Remove(8), "Remove should return true for found node");

            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           /
            //          6

            int[] expected = {1, 3, 2, 6, 7, 5, 4};

            var index = 0;

            tree.PostOrderTraversals(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [TestMethod]
        public void Remove_Node_Left_Leaf()
        {
            var tree = new BinaryTree<int>();

            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8

            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(3);
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);

            Assert.IsTrue(tree.Remove(1), "Remove should return true for found node");

            //        4
            //       / \
            //      2   5
            //       \   \
            //        3   7
            //           / \
            //          6   8

            int[] expected = {3, 2, 6, 8, 7, 5, 4};

            var index = 0;

            tree.PostOrderTraversals(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [TestMethod]
        public void Remove_Current_Right_Has_No_Left()
        {
            var tree = new BinaryTree<int>();

            //         4
            //       /   \
            //      2     6
            //     / \    /\
            //    1   3  5  7
            //               \
            //                8

            tree.Add(4);
            tree.Add(6);
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(3);
            tree.Add(1);
            tree.Add(8);

            Assert.IsTrue(tree.Remove(6), "Remove should return true for found node");

            //          4
            //       /    \
            //      2      7
            //     / \    / \
            //    1   3  5   8

            int[] expected = {1, 3, 2, 5, 8, 7, 4};

            var index = 0;

            tree.PostOrderTraversals(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [TestMethod]
        public void Remove_Current_Has_No_Right()
        {
            var tree = new BinaryTree<int>();

            //         4
            //       /   \
            //      2     8 
            //     / \    /
            //    1   3  6
            //          / \
            //         5   7   

            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(3);
            tree.Add(8);
            tree.Add(6);
            tree.Add(7);
            tree.Add(5);

            Assert.IsTrue(tree.Remove(8), "Remove should return true for found node");

            //         4
            //       /   \
            //      2      6 
            //     / \    / \
            //    1   3  5   7

            int[] expected = {1, 3, 2, 5, 7, 6, 4};

            var index = 0;

            tree.PostOrderTraversals(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [TestMethod]
        public void Remove_Current_Right_Has_Left()
        {
            var tree = new BinaryTree<int>();

            //         4
            //       /    \
            //      2      6 
            //     / \    / \
            //    1   3  5   8
            //              /
            //             7

            tree.Add(4);
            tree.Add(2);
            tree.Add(1);
            tree.Add(3);
            tree.Add(6);
            tree.Add(5);
            tree.Add(8);
            tree.Add(7);

            Assert.IsTrue(tree.Remove(6), "Remove should return true for found node");

            //         4
            //       /    \
            //      2      7 
            //     / \    / \
            //    1   3  5   8

            int[] expected = {1, 3, 2, 5, 8, 7, 4};

            var index = 0;

            tree.PostOrderTraversals(
                item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [TestMethod]
        public void Remove_From_Empty()
        {
            var tree = new BinaryTree<int>();
            Assert.IsFalse(tree.Remove(10));
        }

        [TestMethod]
        public void Remove_Missing_From_Tree()
        {
            var tree = new BinaryTree<int>();

            //         4
            //       /   \
            //      2     8 
            //     / \    /
            //    1   3  6
            //          / \
            //         5   7   

            int[] values = {4, 2, 1, 3, 8, 6, 7, 5};

            foreach (var i in values)
            {
                Assert.IsFalse(tree.Contains(10), "Tree should not contain 10");
                tree.Add(i);
            }
        }

        [TestMethod]
        public void Enumerator_Of_Single()
        {
            var tree = new BinaryTree<int>();

            foreach (int item in tree)
            {
                Assert.Fail("An empty tree should not enumerate any values");
            }

            Assert.IsFalse(tree.Contains(10), "Tree should not contain 10 yet");

            tree.Add(10);

            Assert.IsTrue(tree.Contains(10), "Tree should contain 10");

            var count = 0;
            foreach (int item in tree)
            {
                count++;
                Assert.AreEqual(1, count, "There should be exactly one item");
                Assert.AreEqual(item, 10, "The item value should be 10");
            }
        }

        [TestMethod]
        public void InOrder_Enumerator()
        {
            var tree = new BinaryTree<int>();

            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8

            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(3);
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);

            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8 };

            var index = 0;

            foreach (int actual in tree)
            {
                Assert.AreEqual(expected[index++], actual, "The item enumerated in the wrong order");
            }
        }


        [TestMethod]
        public void InOrder_Delegate()
        {
            var tree = new BinaryTree<int>();

            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8

            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(3);
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);

            int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8 };

            var index = 0;

            tree.InOrderTraversals(item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [TestMethod]
        public void PreOrder_Delegate()
        {
            var tree = new BinaryTree<int>();

            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8

            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(3);
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);

            int[] expected = { 4, 2, 1, 3, 5, 7, 6, 8 };

            var index = 0;

            tree.PreOrderTraversals(item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }

        [TestMethod]
        public void PostOrder_Delegate()
        {
            var tree = new BinaryTree<int>();

            //        4
            //       / \
            //      2   5
            //     / \   \
            //    1   3   7
            //           / \
            //          6   8

            tree.Add(4);
            tree.Add(5);
            tree.Add(2);
            tree.Add(7);
            tree.Add(3);
            tree.Add(6);
            tree.Add(1);
            tree.Add(8);

            int[] expected = { 1, 3, 2, 6, 8, 7, 5, 4 };

            var index = 0;

            tree.PostOrderTraversals(item => Assert.AreEqual(expected[index++], item, "The item enumerated in the wrong order"));
        }
    }
}
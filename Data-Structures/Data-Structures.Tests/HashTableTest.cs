using System;
using System.Collections.Generic;
using System.Globalization;
using HashTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Data_Structures.Tests
{
    [TestClass]
    public class HashTableTest
    {
        private readonly Random _rng = new Random();

        #region Adding tests

        [TestMethod]
        [TestCategory("Add")]
        public void Add_Unique_Adds()
        {
            var table = new HashTable<string, int>();
            var added = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(i, table.Count, "The count was incorrect");

                int value = _rng.Next();
                var key = value.ToString(CultureInfo.InvariantCulture);

                while (table.ContainsKey(key))
                {
                    value = _rng.Next();
                    key = value.ToString(CultureInfo.InvariantCulture);
                }

                table.Add(key, value);
                added.Add(value);
            }

            foreach (int value in added)
            {
                Assert.IsTrue(table.ContainsKey(value.ToString(CultureInfo.InvariantCulture)),
                    "ContainsKey returned false?");
                Assert.IsTrue(table.ContainsValue(value), "ContainsValue returned false?");

                int found = table[value.ToString(CultureInfo.InvariantCulture)];
                Assert.AreEqual(value, found, "The indexed value was incorrect");
            }
        }

        [TestMethod]
        [TestCategory("Add")]
        public void Add_Duplicate_Throws()
        {
            var table = new HashTable<string, int>();
            var added = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(i, table.Count, "The count was incorrect");

                int value = _rng.Next();
                string key = value.ToString(CultureInfo.InvariantCulture);

                while (table.ContainsKey(key))
                {
                    value = _rng.Next();
                    key = value.ToString(CultureInfo.InvariantCulture);
                }

                table.Add(key, value);
                added.Add(value);
            }

            foreach (int value in added)
            {
                try
                {
                    table.Add(value.ToString(CultureInfo.InvariantCulture), value);
                    Assert.Fail("The Add operation should have thrown with the duplicate key");
                }
                catch (ArgumentException)
                {
                    // correct!
                }
            }
        }

        #endregion

        #region Enumerating tests

        [TestMethod]
        [TestCategory("Enumerate")]
        public void Enumerate_Keys_Empty()
        {
            var table = new HashTable<string, string>();

// ReSharper disable once UnusedVariable
            foreach (string key in table.Keys)
                Assert.Fail("There should be nothing in the Keys collection");
        }

        [TestMethod]
        [TestCategory("Enumerate")]
        public void Enumerate_Values_Empty()
        {
            var table = new HashTable<string, string>();

// ReSharper disable once UnusedVariable
            foreach (string key in table.Values)
                Assert.Fail("There should be nothing in the Values collection");
        }

        [TestMethod]
        [TestCategory("Enumerate")]
        public void Enumerate_Keys_Populated()
        {
            var table = new HashTable<int, string>();

            var keys = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                int value = _rng.Next();
                while (table.ContainsKey(value))
                    value = _rng.Next();

                keys.Add(value);
                table.Add(value, value.ToString(CultureInfo.InvariantCulture));
            }

            foreach (int key in table.Keys)
                Assert.IsTrue(keys.Remove(key), "The key was missing from the keys collection");

            Assert.AreEqual(0, keys.Count, "There were left over values in the keys collection");
        }

        [TestMethod]
        [TestCategory("Enumerate")]
        public void Enumerate_Values_Populated()
        {
            var table = new HashTable<int, string>();

            var values = new List<string>();
            for (int i = 0; i < 100; i++)
            {
                int value = _rng.Next();
                while (table.ContainsKey(value))
                    value = _rng.Next();

                values.Add(value.ToString(CultureInfo.InvariantCulture));
                table.Add(value, value.ToString(CultureInfo.InvariantCulture));
            }

            foreach (string value in table.Values)
                Assert.IsTrue(values.Remove(value), "The key was missing from the values collection");

            Assert.AreEqual(0, values.Count, "There were left over values in the value collection");
        }

        #endregion

        #region Getting tests

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [TestCategory("Get")]
        public void Get_From_Empty()
        {
            var table = new HashTable<string, int>();
// ReSharper disable once UnusedVariable
            int value = table["missing"];
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        [TestCategory("Get")]
        public void Get_Missing()
        {
            var table = new HashTable<string, int>();
            table.Add("100", 100);

// ReSharper disable once UnusedVariable
            int value = table["missing"];
        }

        [TestMethod]
        [TestCategory("Get")]
        public void Get_Succeeds()
        {
            var table = new HashTable<string, int>();
            table.Add("100", 100);

            int value = table["100"];
            Assert.AreEqual(100, value, "The returned value was incorrect");

            for (int i = 0; i < 100; i++)
            {
                table.Add(i.ToString(CultureInfo.InvariantCulture), i);

                value = table["100"];
                Assert.AreEqual(100, value, "The returned value was incorrect");
            }
        }

        [TestMethod]
        [TestCategory("Get")]
        public void TryGet_From_Empty()
        {
            var table = new HashTable<string, int>();
            int value;

            Assert.IsFalse(table.TryGetValue("missing", out value));
        }

        [TestMethod]
        [TestCategory("Get")]
        public void TryGet_Missing()
        {
            var table = new HashTable<string, int>();
            table.Add("100", 100);

            int value;
            Assert.IsFalse(table.TryGetValue("missing", out value));
        }

        [TestMethod]
        [TestCategory("Get")]
        public void TryGet_Succeeds()
        {
            var table = new HashTable<string, int>();
            table.Add("100", 100);

            int value;
            Assert.IsTrue(table.TryGetValue("100", out value));
            Assert.AreEqual(100, value, "The returned value was incorrect");

            for (int i = 0; i < 100; i++)
            {
                table.Add(i.ToString(CultureInfo.InvariantCulture), i);

                Assert.IsTrue(table.TryGetValue("100", out value));
                Assert.AreEqual(100, value, "The returned value was incorrect");
            }
        }

        #endregion

        #region Removing tests

        [TestMethod]
        [TestCategory("Remove")]
        public void Remove_Empty()
        {
            var table = new HashTable<string, int>();
            Assert.IsFalse(table.Remove("missing"), "Remove on an empty collection should return false");
        }

        [TestMethod]
        [TestCategory("Remove")]
        public void Remove_Missing()
        {
            var table = new HashTable<string, int>();
            table.Add("100", 100);

            Assert.IsFalse(table.Remove("missing"), "Remove on an empty collection should return false");
        }

        [TestMethod]
        [TestCategory("Remove")]
        public void Remove_Found()
        {
            var table = new HashTable<string, int>();
            for (int i = 0; i < 100; i++)
                table.Add(i.ToString(CultureInfo.InvariantCulture), i);

            for (int i = 0; i < 100; i++)
            {
                Assert.IsTrue(table.ContainsKey(i.ToString(CultureInfo.InvariantCulture)),
                    "The key was not found in the collection");
                Assert.IsTrue(table.Remove(i.ToString(CultureInfo.InvariantCulture)),
                    "The value was not removed (or remove returned false)");
                Assert.IsFalse(table.ContainsKey(i.ToString(CultureInfo.InvariantCulture)),
                    "The key should not have been found in the collection");
            }
        }

        #endregion

    }
}
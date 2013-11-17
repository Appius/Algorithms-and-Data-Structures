#region

using System;

#endregion

namespace HashTable
{
    internal class Program
    {
        private static void Main()
        {
            var table = new HashTable<string, int>();

            table.Add("firstkey", 5);
            table.Add("secondkey", -1);
            table.Add("anotherkey", 3);
            Console.WriteLine(table);

            Console.WriteLine("'firstkey' is removing...");
            table.Remove("firstkey");
            Console.WriteLine(table);

            Console.WriteLine("'secondkey' is contained? {0}", table.ContainsKey("secondkey"));
            Console.WriteLine("'SecondKey' is contained? {0}", table.ContainsKey("SecondKey"));
            Console.ReadKey();
        }
    }
}
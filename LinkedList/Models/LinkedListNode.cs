using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedList.Models
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Значение вершины
        /// </summary>
        public T Value { set; get; }

        /// <summary>
        /// Ссылка на следующую вершину
        /// </summary>
        public LinkedListNode<T> Next { get; set; }
    }
}

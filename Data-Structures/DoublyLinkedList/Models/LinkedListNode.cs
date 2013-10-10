using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkedList.Models
{
    /// <summary>
    /// Класс вершини двусвязного списка
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedListNode<T>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="value">Значение вершини</param>
        public LinkedListNode(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Значение вершини
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        /// Ссылка на следующую вершину
        /// </summary>
        public LinkedListNode<T> Next { get; set; }

        /// <summary>
        /// Ссылка на предедущую вершину
        /// </summary>
        public LinkedListNode<T> Previous { get; set; }
    }
}

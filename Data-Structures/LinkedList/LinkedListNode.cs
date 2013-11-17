#region

using System;

#endregion

namespace LinkedList
{
    /// <summary>
    ///     Класс вершины списка
    /// </summary>
    /// <typeparam name="T">Тип значения вершини</typeparam>
    public class LinkedListNode<T>
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="value"></param>
        public LinkedListNode(T value)
        {
            Value = value;
        }

        /// <summary>
        ///     Значение вершины
        /// </summary>
        public T Value { set; get; }

        /// <summary>
        ///     Ссылка на следующую вершину
        /// </summary>
        public LinkedListNode<T> Next { get; set; }
    }
}
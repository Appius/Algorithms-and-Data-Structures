#region

using System;

#endregion

namespace Queue
{
    /// <summary>
    ///     Элемент очереди
    /// </summary>
    /// <typeparam name="T">Тип данных в очереди</typeparam>
    public class QueueNode<T>
    {
        public QueueNode(T value)
        {
            Value = value;
        }

        /// <summary>
        ///     Значение
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        ///     Ссылка на предедущий элемент
        /// </summary>
        public QueueNode<T> Previous { get; set; }

        /// <summary>
        ///     Ссылка на следующий элемент
        /// </summary>
        public QueueNode<T> Next { get; set; }
    }
}
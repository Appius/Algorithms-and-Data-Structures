#region

using System;

#endregion

namespace Stack
{
    /// <summary>
    ///     Элемент в стеке
    /// </summary>
    /// <typeparam name="T">Тип данных в стеке</typeparam>
    public class StackNode<T>
    {
        public StackNode(T value)
        {
            Value = value;
        }

        /// <summary>
        ///     Значение в стеке
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        ///     Ссылка на следующий элемент
        /// </summary>
        public StackNode<T> Next { get; set; }
    }
}
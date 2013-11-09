#region

using System;

#endregion

namespace BinaryTree.Models
{
    /// <summary>
    ///     Класс вершины бинарного дерева
    /// </summary>
    /// <typeparam name="T">Тип данных в вершине дерева</typeparam>
    public class BinaryTreeNode<T> : IComparable<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="value">Значение в вершине</param>
        public BinaryTreeNode(T value)
        {
            Value = value;
        }

        /// <summary>
        ///     Значение в вершине
        /// </summary>
        public T Value { get; set; }

        /// <summary>
        ///     Левая вершина
        /// </summary>
        public BinaryTreeNode<T> Left { get; set; }

        /// <summary>
        ///     Правая вершина
        /// </summary>
        public BinaryTreeNode<T> Right { get; set; }

        /// <summary>
        ///     Сравнение элемента с другим значением
        /// </summary>
        /// <param name="other">Другое значение</param>
        /// <returns>1 если значение больше, -1 если меньше и 0 если они равны между собой</returns>
        public int CompareTo(T other)
        {
            return Value.CompareTo(other);
        }
    }
}
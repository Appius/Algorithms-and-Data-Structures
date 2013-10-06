#region

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace Stack.LinkedList.Models
{
    /// <summary>
    ///     Реализация стека на основе стандартного списка из .NET
    /// </summary>
    /// <typeparam name="T">Тип значений в стеке</typeparam>
    public class Stack<T> : IEnumerable<T>
    {
        /// <summary>
        ///     Внутренний список для хранения значений
        /// </summary>
        private readonly LinkedList<T> _list = new LinkedList<T>();

        /// <summary>
        ///     Количество элементов в списке
        /// </summary>
        public int Count
        {
            get { return _list.Count; }
        }

        /// <summary>
        ///     Получение GetEnumerator
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        ///     Получение GetEnumerator
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        ///     Положить элемент
        /// </summary>
        /// <param name="value">Элемент</param>
        public void Push(T value)
        {
            _list.AddFirst(value);
        }

        /// <summary>
        ///     Достать элемент из стека
        /// </summary>
        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty");
            T temp = _list.First.Value;
            _list.RemoveFirst();
            return temp;
        }

        /// <summary>
        ///     Получение первого элемента без его удаления
        /// </summary>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty");
            return _list.First.Value;
        }

        /// <summary>
        ///     Перегрузка метода преоброзования в строку
        /// </summary>
        public override string ToString()
        {
            return string.Join("<-", _list);
        }
    }
}
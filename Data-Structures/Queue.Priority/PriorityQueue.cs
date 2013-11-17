#region

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace Queue.Priority
{
    /// <summary>
    /// Очередь с приоритетом (более приоритетные элементы выполняються раньше других)
    /// </summary>
    /// <typeparam name="T">Тип данных в очереди</typeparam>
    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        /// <summary>
        ///     Внутренняя коллекция элементов
        /// </summary>
        private readonly LinkedList<T> _list = new LinkedList<T>();

        /// <summary>
        ///     Количество элементов в очпереди
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
            return GetEnumerator();
        }

        /// <summary>
        ///     Положить элемент в очередь
        /// </summary>
        /// <param name="value">Элемент</param>
        public void Push(T value)
        {
            if (_list.Count == 0)
            {
                _list.AddLast(value);
            }
            else
            {
                var current = _list.First;

                while (current != null && current.Value.CompareTo(value) > 0)
                    current = current.Next;

                if (current == null)
                    _list.AddLast(value);
                else
                    _list.AddBefore(current, value);
            }
        }

        /// <summary>
        ///     Изъять следующее значение из очереди
        /// </summary>
        public T Pop()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");

            T temp = _list.First.Value;
            _list.RemoveFirst();
            return temp;
        }

        /// <summary>
        ///     Считать первый элемент в очереди, но не вынимать его от туда
        /// </summary>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Queue is empty");

            return _list.First.Value;
        }

        /// <summary>
        ///     Очистка очереди
        /// </summary>
        public void Clear()
        {
            _list.Clear();
        }

        /// <summary>
        ///     Перегрузка метода преоброзания обьекта в строку
        /// </summary>
        public override string ToString()
        {
            return string.Join("<->", this);
        }
    }
}
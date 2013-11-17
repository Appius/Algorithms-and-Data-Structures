#region

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace Queue
{
    /// <summary>
    ///     Очеридь, реализованая на основе своего собственного двусвязного списка
    /// </summary>
    /// <typeparam name="T">Тип значения в очереди</typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        /// <summary>
        ///     Первый элемент очереди (крайний, последний в очереди на вынимание)
        /// </summary>
        private QueueNode<T> _head;

        /// <summary>
        ///     Последний элемент (крайний, первый на очереди на вынимание)
        /// </summary>
        private QueueNode<T> _tail;

        /// <summary>
        ///     Количество элементов в очереди
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///     Возвращает обьект Enumerator
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        ///     Возвращает обьект Enumerator
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Поставить элемент в очередь
        /// </summary>
        /// <param name="node">Элемент</param>
        public void Push(QueueNode<T> node)
        {
            if (_head == null)
            {
                _head = node;
                _tail = _head;
            }
            else
            {
                var temp = _head;
                _head = node;
                _head.Next = temp;
                temp.Previous = _head;
            }

            Count++;
        }

        /// <summary>
        ///     Поставить элемент в очередь
        /// </summary>
        /// <param name="value">Значение элемента</param>
        public void Push(T value)
        {
            Push(new QueueNode<T>(value));
        }

        /// <summary>
        ///     Взять элемент из очереди
        /// </summary>
        public T Pop()
        {
            if (_tail == null)
                throw new InvalidOperationException("Queue is empty");

            var temp = _tail;
            _tail = _tail.Previous;
            _tail.Next = null;
            Count--;
            return temp.Value;
        }

        /// <summary>
        ///     Взять элемент из очереди
        /// </summary>
        public T Peek()
        {
            if (_tail == null)
                throw new InvalidOperationException("Queue is empty");

            return _tail.Value;
        }

        /// <summary>
        ///     Очистить очередь от элементов
        /// </summary>
        public void Clear()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        /// <summary>
        ///     Перегрузка метода преоброзования в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join("->", this);
        }
    }
}
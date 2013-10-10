#region

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace Stack.Models
{
    public class Stack<T> : IEnumerable<T>
    {
        /// <summary>
        ///     Первый элемент стека (крайний, первый на вытаскивание)
        /// </summary>
        private StackNode<T> _head;

        /// <summary>
        ///     Количество элементов в стеке
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///     Возвращает элемент Enumerator
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
        ///     Возвращает элемент Enumerator
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Положить элемент в стек
        /// </summary>
        /// <param name="node">Элемент</param>
        public void Push(StackNode<T> node)
        {
            if (_head == null)
            {
                _head = node;
            }
            else
            {
                var temp = _head;
                _head = node;
                _head.Next = temp;
            }

            Count++;
        }

        /// <summary>
        ///     Положить элемент в стек
        /// </summary>
        /// <param name="value">Значение элемента</param>
        public void Push(T value)
        {
            Push(new StackNode<T>(value));
        }

        /// <summary>
        ///     Вытащить элемент из стека
        /// </summary>
        public T Pop()
        {
            if (_head == null)
                throw new InvalidOperationException("Stack is empty");

            var temp = _head;
            _head = _head.Next;
            Count--;
            return temp.Value;
        }

        /// <summary>
        ///     Прочитать крайний элемент стека (но не вытаскивать)
        /// </summary>
        public T Peek()
        {
            if (_head == null)
                throw new InvalidOperationException("Stack is empty");

            return _head.Value;
        }

        /// <summary>
        ///     Очистка стека от элементов
        /// </summary>
        public void Clear()
        {
            _head = null;
            Count = 0;
        }

        /// <summary>
        ///     Перегрузка метода преоброзвания обьекта в строку
        /// </summary>
        public override string ToString()
        {
            return string.Join("<-", this);
        }
    }
}
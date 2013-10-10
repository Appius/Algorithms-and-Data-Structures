#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Stack.Array.Models
{
    /// <summary>
    ///     Реализация стека через массив
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T> : IEnumerable<T>
    {
        /// <summary>
        ///     Размер массива по-умолчанию (в начале)
        /// </summary>
        private const int DefaultSize = 4;

        /// <summary>
        ///     Массив для хранения значений стека
        /// </summary>
        private T[] _array = new T[0];

        /// <summary>
        ///     Количество элементов в стеке
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///     Возвращает элемент GetEnumerator
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
                yield return _array[i];
        }

        /// <summary>
        ///     Возвращает элемент GetEnumerator
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Положить элемент в стек
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (_array.Length == Count)
            {
                var newLength = Count == 0 ? DefaultSize : Count*2;
                var newArray = new T[newLength];
                _array.CopyTo(newArray, 0);

                _array = newArray;
            }

            _array[Count] = item;
            Count++;
        }

        /// <summary>
        ///     Взять элемент из стека
        /// </summary>
        public T Pop()
        {
            if (Count==0)
                throw new InvalidOperationException("Stack is empty");

            Count--;
            return _array[Count];
        }

        /// <summary>
        ///     Считать крайний элемент из стека, но оставить его там
        /// </summary>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack is empty");

            return _array[Count - 1];
        }

        /// <summary>
        ///     Очистка стека от всех элементов
        /// </summary>
        public void Clear()
        {
            Count = 0;
        }

        /// <summary>
        ///     Перегрузка метода преоброзования в строку
        /// </summary>
        public override string ToString()
        {
            return string.Join("<-", _array.Take(Count));
        }
    }
}
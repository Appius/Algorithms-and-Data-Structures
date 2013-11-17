#region

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace Queue.Array
{
    /// <summary>
    ///     Реализация очереди через массив
    /// </summary>
    /// <typeparam name="T">Тип данных в очереди</typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        /// <summary>
        ///     Начальный размер очереди
        /// </summary>
        private const int DefaultLength = 4;

        /// <summary>
        ///     Внутренняя коллекция хранения данных
        /// </summary>
        private T[] _array = new T[0];

        /// <summary>
        ///     Индекс первого элемента в очереди (самого старого)
        /// </summary>
        private int _head;

        /// <summary>
        ///     Количество элементов в очереди
        /// </summary>
        private int _size;

        /// <summary>
        ///     Индекс самого последнего добавленого элемента (самого нового)
        /// </summary>
        private int _tail = -1;

        /// <summary>
        ///     Количество элементов в очереди
        /// </summary>
        public int Count
        {
            get { return _size; }
        }

        /// <summary>
        ///     Возвращает обьект Enumerator
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            if (_size > 0)
            {
                if (_tail < _head)
                {
                    for (var i = _head; i < _array.Length; i++)
                        yield return _array[i];
                    for (var i = 0; i <= _tail; i++)
                        yield return _array[i];
                }
                else
                    for (var i = _head; i <= _tail; i++)
                        yield return _array[i];
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
        ///     Положить элемент в очередь (поставить в очередь)
        /// </summary>
        /// <param name="item">Элемент</param>
        public void Push(T item)
        {
            if (_array.Length == _size)
            {
                var newLength = _size == 0 ? DefaultLength : _size*2;
                var newArray = new T[newLength];

                if (_size > 0)
                {
                    int targetIndex = 0;

                    if (_tail < _head)
                    {
                        for (var i = _head; i < _array.Length; i++)
                        {
                            newArray[targetIndex] = _array[i];
                            targetIndex++;
                        }

                        for (var i = 0; i <= _tail; i++)
                        {
                            newArray[targetIndex] = _array[i];
                            targetIndex++;
                        }
                    }
                    else
                    {
                        for (var i = _head; i <= _tail; i++)
                        {
                            newArray[targetIndex] = _array[i];
                            targetIndex++;
                        }
                    }
                    _head = 0;
                    _tail = targetIndex - 1;
                }
                else
                {
                    _head = 0;
                    _tail = -1;
                }

                _array = newArray;
            }

            if (_tail == _array.Length - 1)
                _tail = 0;
            else
                _tail++;

            _array[_tail] = item;
            _size++;
        }

        /// <summary>
        ///     Забрать элемент из очереди
        /// </summary>
        public T Pop()
        {
            if (_size == 0)
                throw new InvalidOperationException("Queue is empty");

            T temp = _array[_head];
            if (_head == _array.Length - 1)
                _head = 0;
            else
                _head++;

            _size--;
            return temp;
        }

        /// <summary>
        ///     Вернуть крайний элемент в очереди без удаления его из очереди
        /// </summary>
        public T Peek()
        {
            if (_size == 0)
                throw new InvalidOperationException("Queue is empty");

            return _array[_head];
        }

        /// <summary>
        ///     Очистить очередь от элементов
        /// </summary>
        public void Clear()
        {
            _head = 0;
            _tail = -1;
            _size = 0;
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
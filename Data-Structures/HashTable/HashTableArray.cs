#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace HashTable
{
    /// <summary>
    ///     Реализация внутренней структуры ключ-значение
    /// </summary>
    /// <typeparam name="TKey">Тип данных ключа</typeparam>
    /// <typeparam name="TValue">Тип данных значения</typeparam>
    internal class HashTableArray<TKey, TValue>
    {
        /// <summary>
        ///     Массив значений
        /// </summary>
        private readonly HashTableArrayNode<TKey, TValue>[] _array;

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="capacity">Размер массива</param>
        public HashTableArray(int capacity)
        {
            _array = new HashTableArrayNode<TKey, TValue>[capacity];
            for (int i = 0; i < capacity; i++)
                _array[i] = new HashTableArrayNode<TKey, TValue>();
        }

        /// <summary>
        ///     Общая вместительность массива
        /// </summary>
        public int Capacity
        {
            get { return _array.Length; }
        }

        /// <summary>
        ///     Возвращает значения в массиве
        /// </summary>
        public IEnumerable<HashTableNodePair<TKey, TValue>> Items
        {
            get { return _array.SelectMany(node => node.Items); }
        }

        /// <summary>
        ///     Возвращает все значения из массива
        /// </summary>
        public IEnumerable<TValue> Values
        {
            get { return _array.SelectMany(hashTableArrayNode => hashTableArrayNode.Values); }
        }

        /// <summary>
        ///     Получение списка ключей в коллекции
        /// </summary>
        public IEnumerable<TKey> Keys
        {
            get { return _array.SelectMany(node => node.Keys); }
        }

        /// <summary>
        ///     Добавление элемента в массив
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        /// <param name="value">Значение</param>
        public void Add(TKey key, TValue value)
        {
            _array[GetIndex(key)].Add(key, value);
        }

        /// <summary>
        ///     Обновление элемента
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        /// <param name="value">Значение</param>
        public void Update(TKey key, TValue value)
        {
            _array[GetIndex(key)].Update(key, value);
        }

        /// <summary>
        ///     Удаление элемента
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        public bool Remove(TKey key)
        {
            return _array[GetIndex(key)].Remove(key);
        }

        /// <summary>
        ///     Попытка вытащить элемент по его ключу
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        /// <param name="value">Значение элемента</param>
        /// <returns>True, если элемент был найден, false иначе</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _array[GetIndex(key)].TryGetValue(key, out value);
        }

        /// <summary>
        ///     Очистка массива
        /// </summary>
        public void Clear()
        {
            foreach (var hashTableArrayNode in _array)
            {
                hashTableArrayNode.Clear();
            }
        }

        /// <summary>
        ///     Получение индекса элемента в массиве по его ключу
        /// </summary>
        /// <param name="key">Ключ</param>
        private int GetIndex(TKey key)
        {
            return Math.Abs(key.GetHashCode()%Capacity);
        }
    }
}
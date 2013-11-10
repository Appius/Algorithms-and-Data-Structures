#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace HashTable
{
    /// <summary>
    ///     Реализация хеш таблицы как структуры ключ-значение
    /// </summary>
    /// <typeparam name="TKey">Тип данных ключа</typeparam>
    /// <typeparam name="TValue">Тип данных значения</typeparam>
    public class HashTable<TKey, TValue>
    {
        /// <summary>
        ///     Критерий заполнености массива
        /// </summary>
        private const double FillFactor = 0.75;

        /// <summary>
        ///     Массив элементов
        /// </summary>
        private HashTableArray<TKey, TValue> _array;

        /// <summary>
        ///     Максимальная вместительность массива
        /// </summary>
        private int _maxCount;

        /// <summary>
        ///     Конструктор, по-умолчанию вместительность массива - 1000 едениц
        /// </summary>
        public HashTable() : this(1000)
        {
        }

        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="initialcapacity">Начальная вместительность массива</param>
        public HashTable(int initialcapacity)
        {
            if (initialcapacity < 1)
                throw new ArgumentOutOfRangeException("initialcapacity");
            _array = new HashTableArray<TKey, TValue>(initialcapacity);

            _maxCount = (int) (initialcapacity*FillFactor) + 1;
        }

        /// <summary>
        ///     Количество элементов в массиве
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///     Получение элемента по его индексу
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        public TValue this[TKey key]
        {
            get
            {
                TValue value;
                if (!_array.TryGetValue(key, out value))
                    throw new ArgumentException("key");
                return value;
            }
            set { _array.Update(key, value); }
        }

        /// <summary>
        ///     Получение списка ключей
        /// </summary>
        public IEnumerable<TKey> Keys
        {
            get { return _array.Keys; }
        }

        /// <summary>
        ///     Возвращает список значений в коллекции
        /// </summary>
        public IEnumerable<TValue> Values
        {
            get { return _array.Values; }
        }

        /// <summary>
        ///     Добавление элемента в массив
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        /// <param name="value">Значение</param>
        public void Add(TKey key, TValue value)
        {
            if (Count >= _maxCount)
            {
                var newArray = new HashTableArray<TKey, TValue>(_array.Capacity*2);
                foreach (var item in _array.Items)
                    newArray.Add(item.Key, item.Value);

                _array = newArray;
                _maxCount = (int) (_array.Capacity*FillFactor) + 1;
            }
            _array.Add(key, value);
            Count++;
        }

        /// <summary>
        ///     Удаление элемента из массива
        /// </summary>
        /// <param name="key">Ключ элемента</param>
        public bool Remove(TKey key)
        {
            bool removed = _array.Remove(key);
            if (removed) Count--;
            return removed;
        }

        /// <summary>
        ///     Получение значения объекта
        /// </summary>
        /// <param name="key">Ключ объекта</param>
        /// <param name="value">Значение объекта</param>
        public bool TryGetArray(TKey key, out TValue value)
        {
            return _array.TryGetValue(key, out value);
        }

        /// <summary>
        ///     Проверка, есть ли ключ в коллекции
        /// </summary>
        /// <param name="key">Ключ</param>
        public bool ContainsKey(TKey key)
        {
            TValue value;
            return _array.TryGetValue(key, out value);
        }

        /// <summary>
        ///     Проверка есть ли значение в коллекции
        /// </summary>
        /// <param name="value">Значение</param>
        public bool ContainsValue(TValue value)
        {
            return _array.Values.Contains(value);
        }

        /// <summary>
        ///     Попытка получить значение из коллекции по ключу объекта
        /// </summary>
        /// <param name="key">Ключ объекта</param>
        /// <param name="value">Значение объекта</param>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _array.TryGetValue(key, out value);
        }
    }
}
#region

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace HashTable
{
    /// <summary>
    ///     Класс, который представляет массив объектов ключ-значение
    /// </summary>
    /// <typeparam name="TKey">Тип ключа</typeparam>
    /// <typeparam name="TValue">Тип значения</typeparam>
    internal class HashTableArrayNode<TKey, TValue>
    {
        /// <summary>
        ///     Элементы хеш-таблицы
        /// </summary>
        private LinkedList<HashTableNodePair<TKey, TValue>> _items;

        /// <summary>
        ///     Возвращает коллекцию всех ключей
        /// </summary>
        public IEnumerable<TKey> Keys
        {
            get
            {
                if (_items != null)
                {
                    foreach (var hashTableNodePair in _items)
                    {
                        yield return hashTableNodePair.Key;
                    }
                }
            }
        }

        /// <summary>
        ///     Возвращает коллекцию всех значений
        /// </summary>
        public IEnumerable<TValue> Values
        {
            get
            {
                if (_items != null)
                {
                    foreach (var hashTableNodePair in _items)
                    {
                        yield return hashTableNodePair.Value;
                    }
                }
            }
        }

        /// <summary>
        ///     Возвращает коллекцию всех значений
        /// </summary>
        public IEnumerable<HashTableNodePair<TKey, TValue>> Items
        {
            get
            {
                if (_items != null)
                {
                    foreach (var hashTableNodePair in _items)
                    {
                        yield return hashTableNodePair;
                    }
                }
            }
        }

        /// <summary>
        ///     Добавление элемента в список
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение</param>
        public void Add(TKey key, TValue value)
        {
            if (_items == null)
                _items = new LinkedList<HashTableNodePair<TKey, TValue>>();
            else if (_items.Any(hashTableNodePair => hashTableNodePair.Key.Equals(key)))
                throw new ArgumentException("Key is already exist in hashtable.");
            _items.AddFirst(new HashTableNodePair<TKey, TValue>(key, value));
        }

        /// <summary>
        ///     Обновление значения объекта
        /// </summary>
        /// <param name="key">Ключ объекта</param>
        /// <param name="value">Новое значение</param>
        public void Update(TKey key, TValue value)
        {
            var updated = false;

            if (_items != null)
            {
                foreach (var hashTableNodePair in _items.Where(hashTableNodePair => hashTableNodePair.Key.Equals(key)))
                {
                    hashTableNodePair.Value = value;
                    updated = true;
                    break;
                }
            }

            if (!updated) throw new ArgumentException("HashTable doesn't contain current key.");
        }

        /// <summary>
        ///     Попытка получить значение объекта по его ключу
        /// </summary>
        /// <param name="key">Ключ объекта</param>
        /// <param name="value">Значение объекта</param>
        /// <returns>True, если объект был найден, false иначе</returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            value = default(TValue);
            if (_items == null) return false;

            var found = false;
            foreach (var hashTableNodePair in _items.Where(hashTableNodePair => hashTableNodePair.Key.Equals(key)))
            {
                value = hashTableNodePair.Value;
                found = true;
                break;
            }
            return found;
        }

        /// <summary>
        ///     Удаление элемента из хеш-таблицы
        /// </summary>
        /// <param name="key">Ключ объекта</param>
        /// <returns>True, если объект был найден и удален, false иначе</returns>
        public bool Remove(TKey key)
        {
            if (_items == null || _items.Count == 0) return false;

            var removed = false;
            LinkedListNode<HashTableNodePair<TKey, TValue>> hashTableNodePair = _items.First;
            while (hashTableNodePair != null)
            {
                if (hashTableNodePair.Value.Key.Equals(key))
                {
                    _items.Remove(hashTableNodePair);
                    removed = true;
                    break;
                }
                hashTableNodePair = hashTableNodePair.Next;
            }
            return removed;
        }

        /// <summary>
        ///     Очистка хеш-таблицы от элементов
        /// </summary>
        public void Clear()
        {
            if (_items != null) _items.Clear();
        }
    }
}
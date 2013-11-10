#region

using System;

#endregion

namespace HashTable
{
    /// <summary>
    ///     Элемент таблицы (ключ-значение)
    /// </summary>
    /// <typeparam name="TKey">Тип ключа</typeparam>
    /// <typeparam name="TValue">Тип значения</typeparam>
    internal class HashTableNodePair<TKey, TValue>
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="key">Ключ</param>
        /// <param name="value">Значение</param>
        public HashTableNodePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        ///     Ключ элемента
        /// </summary>
        public TKey Key { get; private set; }

        /// <summary>
        ///     Значение элемента
        /// </summary>
        public TValue Value { get; set; }
    }
}
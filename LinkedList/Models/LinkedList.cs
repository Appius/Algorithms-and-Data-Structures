#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace LinkedList.Models
{
    /// <summary>
    ///     Односвязный список
    /// </summary>
    /// <typeparam name="T">Тип значения в вершинах</typeparam>
    public class LinkedList<T> : ICollection<T>
    {
        /// <summary>
        ///     Конструктор по-умолчанию
        /// </summary>
        public LinkedList()
        {
            Head = null;
            Tail = null;
        }

        #region Adding

        /// <summary>
        ///     Добавление значения в начало списка
        /// </summary>
        /// <param name="value">Значение</param>
        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        /// <summary>
        ///     Добавление элемента в начало списка
        /// </summary>
        /// <param name="node">Вершина для добавления</param>
        public void AddFirst(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = Head;
            Head = node;
            Head.Next = temp;
            if (Count == 1)
                Tail = Head;
            Count++;
        }

        /// <summary>
        ///     Добавление значения элемента в конец списка
        /// </summary>
        /// <param name="value">Значение</param>
        public void AddLast(T value)
        {
            AddLast(new LinkedListNode<T>(value));
        }

        /// <summary>
        ///     Добавление вершины в конец списка
        /// </summary>
        /// <param name="node">Вершина для добавления</param>
        public void AddLast(LinkedListNode<T> node)
        {
            if (Count == 0)
                Head = node;
            else
                Tail.Next = node;

            Tail = node;
            Count++;
        }

        #endregion

        #region Remove

        /// <summary>
        ///     Удаление элемента в начале списка
        /// </summary>
        public void RemoveFirst()
        {
            if (Count != 0)
            {
                Head = Head.Next;
                Count--;
                if (Count == 0)
                    Tail = null;
            }
        }

        /// <summary>
        ///     Удаление элемента в конце списка
        /// </summary>
        public void RemoveLast()
        {
            if (Count != 0)
            {
                if (Count == 1)
                {
                    Head = null;
                    Tail = null;
                }
                else
                {
                    LinkedListNode<T> temp = Head;
                    while (temp.Next != Tail)
                        temp = temp.Next;

                    temp.Next = null;
                    Tail = temp;
                }
                Count--;
            }
        }

        #endregion

        #region ICollection

        /// <summary>
        ///     Возвращает список как тип IEnumerator
        /// </summary>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>) this).GetEnumerator();
        }

        /// <summary>
        ///     Добавление значения элемента в начало списка
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            AddFirst(item);
        }

        /// <summary>
        ///     Очищение списка от всех элементов
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        /// <summary>
        ///     Определяет содержит ли список данный элемент или нет
        /// </summary>
        /// <param name="item">Элемент лоя поиска</param>
        /// <returns>Да, если элемент содержиться, нет в противном случае.</returns>
        public bool Contains(T item)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Next.Equals(item))
                    return true;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        ///     Копирует значения вершин в массив
        /// </summary>
        /// <param name="array">Массив для записи</param>
        /// <param name="arrayIndex">Начальный индекс для записи</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        /// <summary>
        ///     Удаление первой попавшейся вершини с данным значением
        /// </summary>
        /// <param name="item">Значение для удаления</param>
        /// <returns>Да, если элемент был найден и удален, нет в остальных случаях</returns>
        public bool Remove(T item)
        {
            LinkedListNode<T> previous = null;
            LinkedListNode<T> current = Head;

            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous == null)
                        RemoveFirst();
                    else
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            Tail = previous;
                    }
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        /// <summary>
        ///     Количество элементов в списке
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///     Текущая коллекция всегда доступна для записи
        /// </summary>
        public bool IsReadOnly
        {
            get { return false; }
        }

        #endregion

        /// <summary>
        ///     Первый элемент списка
        /// </summary>
        public LinkedListNode<T> Head { get; private set; }

        /// <summary>
        ///     Последний элемент списка
        /// </summary>
        public LinkedListNode<T> Tail { get; private set; }

        /// <summary>
        ///     Перегрузка операции получения строки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Join("->", this);
        }
    }
}
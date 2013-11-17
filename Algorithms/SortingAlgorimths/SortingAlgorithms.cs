#region

using System;

#endregion

namespace SortingAlgorimths
{
    /// <summary>
    ///     Алгоритмы сортировки
    /// </summary>
    /// <typeparam name="T">Тип данных, коллекцию которых надо отсортировать</typeparam>
    public static class SortingAlgorithms<T> where T : IComparable
    {
        /// <summary>
        ///     Сортировка пузырем
        /// </summary>
        /// <param name="array">Массив данных</param>
        public static T[] BubbleSort(params T[] array)
        {
            for (int n = array.Length - 1; n >= 0; n--)
            {
                var isSwaped = false;
                for (int i = 0; i < n; i++)
                {
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        T temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                        isSwaped = true;
                    }
                }
                if (!isSwaped) break;
            }
            return array;
        }

        /// <summary>
        ///     Сортировка вставками
        /// </summary>
        /// <param name="array">Коллекция данных</param>
        public static T[] InsertionSort(params T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(array[i - 1]) < 0)
                {
                    var temp = array[i];
                    var j = i - 1;
                    while (j >= 0 && array[j].CompareTo(temp) > 0)
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                    array[j + 1] = temp;
                }
            }
            return array;
        }

        /// <summary>
        ///     Сортировка выборкой
        /// </summary>
        /// <param name="array">Коллекция данных</param>
        public static T[] SelectionSort(params T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                T min = array[i];
                int index = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(min) < 0)
                    {
                        min = array[j];
                        index = j;
                    }
                }
                int k = index - 1;
                while (k >= i)
                {
                    array[k + 1] = array[k];
                    k--;
                }
                array[k + 1] = min;
            }
            return array;
        }
    }
}
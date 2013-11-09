#region

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace BinaryTree.Models
{
    /// <summary>
    ///     Релизация структуры бинарного дерева
    /// </summary>
    /// <typeparam name="T">Тип данных в вершинах дерева</typeparam>
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        /// <summary>
        ///     Корень дерева (начальная вершина)
        /// </summary>
        private BinaryTreeNode<T> _root;

        /// <summary>
        ///     Количество вершин дерева
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///     Предостовляет объект Enumerator
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversals();
        }

        /// <summary>
        ///     Предостовляет объект Enumerator
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        ///     Очистка дерева (удаление всех вершин)
        /// </summary>
        public void Clear()
        {
            _root = null;
            Count = 0;
        }

        /// <summary>
        ///     Содержит ли дерево данное значение
        /// </summary>
        /// <param name="value">Значение</param>
        /// <returns>Да, если есть, нет в противном случае</returns>
        public bool Contains(T value)
        {
            if (_root == null) return false;

            BinaryTreeNode<T> parent;
            return FindWithParent(value, out parent) != null;
        }

        /// <summary>
        ///     Ищет значение в дереве
        /// </summary>
        /// <param name="value">Значение</param>
        /// <param name="parent">Родитель вершины</param>
        private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
        {
            var current = _root;
            parent = null;

            while (current != null)
            {
                int comparing = value.CompareTo(current.Value);
                if (comparing < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if (comparing > 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else break;
            }
            return current;
        }

        #region Removing

        /// <summary>
        ///     Удалить вершину из дерева
        /// </summary>
        /// <param name="value">Значение в вершине</param>
        /// <returns>True, если вершина была удалена, false иначе</returns>
        public bool Remove(T value)
        {
            BinaryTreeNode<T> parent;
            var current = FindWithParent(value, out parent);

            if (current == null) return false;

            Count--;
            if (current.Right == null)
            {
                if (parent == null) _root = current.Left;
                else
                {
                    int comparing = parent.CompareTo(current.Value);
                    if (comparing > 0)
                        parent.Left = current.Left;
                    else if (comparing < 0)
                        parent.Right = current.Left;
                }
            }
            else if (current.Right.Left == null)
            {
                current.Right.Left = current.Left;
                if (parent == null) _root = current.Right;
                else
                {
                    int comparing = parent.CompareTo(current.Value);
                    if (comparing > 0)
                        parent.Left = current.Right;
                    else if (comparing < 0)
                        parent.Right = current.Right;
                    }
            }
            else
            {
                BinaryTreeNode<T> mostleftNode = current.Right.Left;
                BinaryTreeNode<T> mostleftParentNode = current.Right;

                while (mostleftNode.Left != null)
                {
                    mostleftParentNode = mostleftNode;
                    mostleftNode = mostleftNode.Left;
                }

                mostleftParentNode.Left = mostleftNode.Right;
                mostleftNode.Left = current.Left;
                mostleftNode.Right = current.Right;

                if (parent == null) _root = mostleftNode;
                else
                {
                    int comparing = parent.CompareTo(current.Value);
                    if (comparing > 0)
                        parent.Left = mostleftNode;
                    else if (comparing < 0)
                        parent.Right = mostleftNode;
                }
            }
            return true;
        }

        #endregion

        #region PreOrderTraversals

        public void PreOrderTraversals(Action<T> action)
        {
            PreOrderTraversals(action, _root);
        }

        private void PreOrderTraversals(Action<T> action, BinaryTreeNode<T> current)
        {
            if (current != null)
            {
                action(current.Value);
                PreOrderTraversals(action, current.Left);
                PreOrderTraversals(action, current.Right);
            }
        }

        #endregion

        #region PostOrderTraversals

        public void PostOrderTraversals(Action<T> action)
        {
            PostOrderTraversals(action, _root);
        }

        private void PostOrderTraversals(Action<T> action, BinaryTreeNode<T> current)
        {
            if (current != null)
            {
                PostOrderTraversals(action, current.Left);
                PostOrderTraversals(action, current.Right);
                action(current.Value);
            }
        }

        #endregion

        #region InOrderTraversals

        public void InOrderTraversals(Action<T> action)
        {
            InOrderTraversals(action, _root);
        }

        private void InOrderTraversals(Action<T> action, BinaryTreeNode<T> current)
        {
            if (current != null)
            {
                InOrderTraversals(action, current.Left);
                action(current.Value);
                InOrderTraversals(action, current.Right);
            }
        }

        public IEnumerator<T> InOrderTraversals()
        {
            var current = _root;
            if (current != null)
            {
                var stack = new Stack<BinaryTreeNode<T>>();

                bool isGoLeft = true;

                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (isGoLeft)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    yield return current.Value;

                    if (current.Right != null)
                    {
                        current = current.Right;
                        isGoLeft = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        isGoLeft = false;
                    }
                }
            }
        }

        #endregion

        #region Adding

        /// <summary>
        ///     Добавление значения в дерево
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            Add(new BinaryTreeNode<T>(value));
        }

        /// <summary>
        ///     Добавление вершины в дерево
        /// </summary>
        /// <param name="node">Вершина</param>
        public void Add(BinaryTreeNode<T> node)
        {
            if (_root == null)
                _root = node;
            else
                AddTo(_root, node);
            Count++;
        }

        /// <summary>
        ///     Добавление листка в вершине
        /// </summary>
        /// <param name="root">Вершина</param>
        /// <param name="node">Значение</param>
        private void AddTo(BinaryTreeNode<T> root, BinaryTreeNode<T> node)
        {
            if (node.CompareTo(root.Value) < 0)
            {
                if (root.Left == null)
                    root.Left = node;
                else AddTo(root.Left, node);
            }
            else
            {
                if (root.Right == null)
                    root.Right = node;
                else AddTo(root.Right, node);
            }
        }

        #endregion

        /// <summary>
        /// Перегрузка стандартного метода .ToString()
        /// </summary>
        public override string ToString()
        {
            return string.Join(" - ", this);
        }
    }
}
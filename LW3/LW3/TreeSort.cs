using System;
using System.Collections.Generic;

namespace LW3
{
    // Узел бинарного дерева для сортировки
    internal sealed class TreeNode
    {
        public int Value { get; }
        public TreeNode? Left { get; set; }
        public TreeNode? Right { get; set; }

        public TreeNode(int value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }

    // Реализация сортировки с использованием бинарного дерева (Tree Sort)
    public static class TreeSort
    {
        public static void Sort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                return;
            }

            TreeNode? root = null;

            // Построение дерева
            foreach (var num in array)
            {
                root = Insert(root, num);
            }

            // Обход дерева и заполнение массива
            int index = 0;
            InOrderTraversal(root, array, ref index);
        }

        // Вставка значения в дерево
        private static TreeNode Insert(TreeNode? root, int value)
        {
            if (root == null)
            {
                return new TreeNode(value);
            }

            if (value < root.Value)
            {
                root.Left = Insert(root.Left, value);
            }
            else
            {
                root.Right = Insert(root.Right, value);
            }

            return root;
        }

        // Центрированный обход дерева
        private static void InOrderTraversal(TreeNode? node, int[] result, ref int index)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal(node.Left, result, ref index);
            result[index++] = node.Value;
            InOrderTraversal(node.Right, result, ref index);
        }
    }
}
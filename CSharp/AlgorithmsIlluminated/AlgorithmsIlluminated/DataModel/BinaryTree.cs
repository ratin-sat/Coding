using System;

namespace AlgorithmsIlluminated.DataModel
{
    public static class BinaryTree
    {
        public static int CountNodes<T>(BinaryTreeNode<T> t)
        {
            return t == null ? 0 : 1 + CountNodes(t.LeftChild) + CountNodes(t.RightChild);
        }

        public static (int Height, bool IsBalanced) HeightBalanced<T>(BinaryTreeNode<T> t)
        {
            if (t == null)
            {
                return (0, true);
            }

            (var lh, var lb) = HeightBalanced(t.LeftChild);
            (var rh, var rb) = HeightBalanced(t.RightChild);

            var h = 1 + Math.Max(lh, rh);
            var dh = Math.Abs(lh - rh);

            return dh > 1 ? (h, false) : (h, lb && rb);
        }

        public static bool IsSearchTree<T>(BinaryTreeNode<T> t) where T : IComparable<T>
        {
            if (t == null)
            {
                return true;
            }

            var check = (t.LeftChild == null || t.LeftChild.Content.CompareTo(t.Content) < 0)
                && (t.RightChild == null || t.RightChild.Content.CompareTo(t.Content) > 0);

            return check && IsSearchTree(t.LeftChild) && IsSearchTree(t.RightChild);
        }
    }
}

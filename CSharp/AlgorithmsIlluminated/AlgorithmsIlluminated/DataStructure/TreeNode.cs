using System;

namespace AlgorithmsIlluminated.DataStructure
{
    public class TreeNode<T> where T : IComparable<T>
    {
        public T Content { get; }

        public TreeNode<T> LeftChild { get; set; }

        public TreeNode<T> RightChild { get; set; }

        public TreeNode(T content)
        {
            this.Content = content;
        }
    }
}

namespace AlgorithmsIlluminated.DataModel
{
    public class BinaryTreeNode<T>
    {
        public T Content { get; }

        public BinaryTreeNode<T> LeftChild { get; set; }

        public BinaryTreeNode<T> RightChild { get; set; }

        public BinaryTreeNode(T content)
        {
            this.Content = content;
        }
    }
}

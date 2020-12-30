using System.Linq;
using AlgorithmsIlluminated.DataModel;
using AlgorithmsIlluminated.DataStructure;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class SearchTreeTest
    {
        [Theory]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 4, 4)]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 13, 13)]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 12, null)]
        public void SearchTree_Search(string binTree, int key, int? expected)
        {
            var root = TreeFactory.CreateBinaryTree(binTree, int.Parse);
            var t = new SearchTree<int>(root);

            var node = t.Search(key);

            var actual = node?.Content;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 1)]
        public void SearchTree_Min(string binTree, int expected)
        {
            var root = TreeFactory.CreateBinaryTree(binTree, int.Parse);
            var t = new SearchTree<int>(root);

            var min = t.Min();

            var actual = min.Content;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 14)]
        public void SearchTree_Max(string binTree, int expected)
        {
            var root = TreeFactory.CreateBinaryTree(binTree, int.Parse);
            var t = new SearchTree<int>(root);

            var max = t.Max();

            var actual = max.Content;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 8, 7)]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 14, 13)]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 4, 3)]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 1, null)]
        public void SearchTree_Predecessor(string binTree, int k, int? expected)
        {
            var root = TreeFactory.CreateBinaryTree(binTree, int.Parse);
            var t = new SearchTree<int>(root);
            var x = t.Search(k);

            var node = t.Predecessor(x);

            var actual = node?.Content;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 7, 8)]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 13, 14)]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 3, 4)]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 14, null)]
        public void SearchTree_Successor(string binTree, int k, int? expected)
        {
            var root = TreeFactory.CreateBinaryTree(binTree, int.Parse);
            var t = new SearchTree<int>(root);
            var x = t.Search(k);

            var node = t.Successor(x);

            var actual = node?.Content;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", new[] { 1, 3, 4, 6, 7, 8, 9, 10, 13, 14 })]
        public void SearchTree_OutputSorted(string binTree, int[] expected)
        {
            var root = TreeFactory.CreateBinaryTree(binTree, int.Parse);
            var t = new SearchTree<int>(root);

            var output = t.OutputSorted();

            var actual = output.ToArray();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 5, 11)]
        public void SearchTree_Insert_IncreaseNodesCount(string binTree, int k, int expected)
        {
            var root = TreeFactory.CreateBinaryTree(binTree, int.Parse);
            var t = new SearchTree<int>(root);

            t.Insert(k);

            var actual = BinaryTree.CountNodes(t.Root);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 5)]
        public void SearchTree_Insert_HoldProperties(string binTree, int k)
        {
            var root = TreeFactory.CreateBinaryTree(binTree, int.Parse);
            var t = new SearchTree<int>(root);

            t.Insert(k);

            Assert.True(BinaryTree.IsSearchTree(t.Root));
        }

        [Theory]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 5)]
        public void SearchTree_Insert_IsBalanced(string binTree, int k)
        {
            var root = TreeFactory.CreateBinaryTree(binTree, int.Parse);
            var t = new SearchTree<int>(root);

            t.Insert(k);

            (var height, var isBalanced) = BinaryTree.HeightBalanced(t.Root);
            Assert.True(isBalanced);
        }

        [Theory]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 14, 9)]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 10, 9)]
        public void SearchTree_Delete_DecreaseNodesCount(string binTree, int k, int expected)
        {
            var root = TreeFactory.CreateBinaryTree(binTree, int.Parse);
            var t = new SearchTree<int>(root);
            var count = BinaryTree.CountNodes(t.Root);

            t.Delete(k);

            var actual = BinaryTree.CountNodes(t.Root);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 14)]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 10)]
        public void SearchTree_Delete_HoldProperties(string binTree, int k)
        {
            var root = TreeFactory.CreateBinaryTree(binTree, int.Parse);
            var t = new SearchTree<int>(root);

            t.Delete(k);

            Assert.True(BinaryTree.IsSearchTree(t.Root));
        }

        [Theory]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 14)]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 10)]
        public void SearchTree_Delete_IsBalanced(string binTree, int k)
        {
            var root = TreeFactory.CreateBinaryTree(binTree, int.Parse);
            var t = new SearchTree<int>(root);

            t.Delete(k);

            (var height, var isBalanced) = BinaryTree.HeightBalanced(t.Root);
            Assert.True(isBalanced);
        }

        [Theory]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 1, 1)]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 5, 7)]
        [InlineData("8 3 10 1 6 9 14 null null 4 7 null null 13 null", 10, 14)]
        public void SearchTree_Select(string binTree, int i, int expected)
        {
            var root = TreeFactory.CreateBinaryTree(binTree, int.Parse);
            var t = new SearchTree<int>(root);

            var node = t.Select(i);

            var actual = node.Content;
            Assert.Equal(expected, actual);
        }
    }
}

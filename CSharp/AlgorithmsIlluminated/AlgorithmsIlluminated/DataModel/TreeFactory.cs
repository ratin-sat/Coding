using System;
using System.Collections.Generic;

namespace AlgorithmsIlluminated.DataModel
{
    public static class TreeFactory
    {
        public static BinaryTreeNode<T> CreateBinaryTree<T>(string inlineData, Func<string, T> parser, string nilKey = "null")
        {
            var contents = inlineData.Split(' ');
            var root = new BinaryTreeNode<T>(parser(contents[0]));
            var current = root;
            var queue = new Queue<BinaryTreeNode<T>>();
            var count = 0;

            for (var i = 1; i < contents.Length; i++)
            {
                if (contents[i] != nilKey)
                {
                    var newNode = new BinaryTreeNode<T>(parser(contents[i]));
                    queue.Enqueue(newNode);

                    if (i % 2 == 1)
                    {
                        current.LeftChild = newNode;
                    }
                    else
                    {
                        current.RightChild = newNode;
                    }
                }

                // update count and current node
                if (i / 2 > count)
                {
                    // check parent node
                    var p = (i - 1) / 2;
                    if (contents[p] != nilKey)
                    {
                        current = queue.Dequeue();
                    }
                    count++;
                }
            }

            return root;
        }
    }
}

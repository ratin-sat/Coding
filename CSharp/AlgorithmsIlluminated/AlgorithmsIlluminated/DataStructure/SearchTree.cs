using System;
using System.Collections.Generic;

namespace AlgorithmsIlluminated.DataStructure
{
    public class SearchTree<T> where T : IComparable<T>
    {
        // return node with key k if such node exists, otherwise report "none"
        public TreeNode<T> Search(T k)
        {
            throw new NotImplementedException();
        }

        // return node with the smallest key
        public TreeNode<T> Min()
        {
            throw new NotImplementedException();
        }

        // return node with the largest key
        public TreeNode<T> Max()
        {
            throw new NotImplementedException();
        }

        // given a node n in the search tree, return node with the next-smallest key
        // if n has the minimum key, report "none"
        public TreeNode<T> Predecessor(TreeNode<T> n)
        {
            throw new NotImplementedException();
        }

        // given a node n in the search tree, return node with the next-largest key
        // if n has the maximum key, report "none"
        public TreeNode<T> Successor(TreeNode<T> n)
        {
            throw new NotImplementedException();
        }

        // output the objects in the search tree one by one in order of their keys
        public IEnumerable<T> OutputSorted()
        {
            throw new NotImplementedException();
        }

        // add a new node with object x to the search tree
        public void Insert(T x)
        {
            throw new NotImplementedException();
        }

        // delete node with key k from the search tree
        public void Delete(T k)
        {
            throw new NotImplementedException();
        }

        // return node in the search tree with the ith-smallest key
        public TreeNode<T> Select(int i)
        {
            throw new NotImplementedException();
        }
    }
}

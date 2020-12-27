using System;
using System.Collections.Generic;
using AlgorithmsIlluminated.DataModel;

namespace AlgorithmsIlluminated.DataStructure
{
    public class SearchTree<T> where T : IComparable<T>
    {
        // root node
        public BinaryTreeNode<T> Root { get; private set; }

        public SearchTree(BinaryTreeNode<T> root)
        {
            this.Root = root;
        }

        // return node with key k if such node exists, otherwise report "none"
        public BinaryTreeNode<T> Search(T k)
        {
            throw new NotImplementedException();
        }

        // return node with the smallest key
        public BinaryTreeNode<T> Min()
        {
            throw new NotImplementedException();
        }

        // return node with the largest key
        public BinaryTreeNode<T> Max()
        {
            throw new NotImplementedException();
        }

        // given a node n in the search tree, return node with the next-smallest key
        // if n has the minimum key, report "none"
        public BinaryTreeNode<T> Predecessor(BinaryTreeNode<T> n)
        {
            throw new NotImplementedException();
        }

        // given a node n in the search tree, return node with the next-largest key
        // if n has the maximum key, report "none"
        public BinaryTreeNode<T> Successor(BinaryTreeNode<T> n)
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
        public BinaryTreeNode<T> Select(int i)
        {
            throw new NotImplementedException();
        }
    }
}

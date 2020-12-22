using System;
using System.Collections.Generic;

namespace AlgorithmsIlluminated.DataStructure
{
    public class Heap<T> where T : IComparable<T>
    {
        private int count = 0;

        private IList<T> BinaryHeap { get; } = new List<T>();

        private IDictionary<T, int> Indices { get; } = new Dictionary<T, int>();

        // add a new object x to Heap
        public void Insert(T x)
        {
            // i = index of x
            var i = this.count;

            // overwrite an existing object at i if i < current number of heap, otherwise add a new object to heap
            if (i < this.BinaryHeap.Count)
            {
                this.BinaryHeap[i] = x;
            }
            else
            {
                this.BinaryHeap.Add(x);
            }

            // keep track the index of x
            this.Indices[x] = i;

            // update count
            this.count += 1;

            if (this.count < 2)
            {
                return;
            }

            // maintain heap's property
            var j = ParentIndex(i);
            var p = this.BinaryHeap[j];
            while (i > 0 && p.CompareTo(x) > 0)
            {
                this.Swap(i, j);
                i = j;
                j = ParentIndex(i);
                p = this.BinaryHeap[j];
            }
        }

        // remove and return from Heap an object with the smallest key
        public T ExtractMin()
        {
            var min = this.BinaryHeap[0];

            // j = index of the last element
            var j = this.count - 1;
            // swap the last element and the first element
            this.Swap(0, j);
            // restore heap's property
            this.BubbleDown(0, j);

            // update count
            this.count = this.count - 1;

            return min;
        }

        // return an object with the smallest key
        public T FindMin()
        {
            return this.BinaryHeap[0];
        }

        // given objects x1, x2, ..., xn, create a heap containing them
        public void Heapify(IEnumerable<T> x)
        {
            foreach (var xi in x)
            {
                this.Insert(xi);
            }
        }

        // delete the object x from Heap
        public void Delete(T x)
        {
            // i = index of x
            var i = this.Indices[x];
            if (i >= this.count)
            {
                return;
            }

            // j = index of the last element
            var j = this.count - 1;
            // swap the last element and x
            this.Swap(i, j);
            // restore heap's property
            this.BubbleDown(i, j);

            // update count
            this.count = this.count - 1;
        }

        // return the number of objects in Heap
        public int Count()
        {
            return this.count;
        }

        // return parent index of node i
        private static int ParentIndex(int i) => (i - 1) / 2;

        // return left child index of node i
        private static int LeftIndex(int i) => (2 * i) + 1;

        // return right child index of node i
        private static int RightIndex(int i) => 2 * (i + 1);

        // swap the values between node i and node j
        private void Swap(int i, int j)
        {
            var tmp = this.BinaryHeap[j];
            this.BinaryHeap[j] = this.BinaryHeap[i];
            this.BinaryHeap[i] = tmp;

            this.Indices[this.BinaryHeap[i]] = i;
            this.Indices[this.BinaryHeap[j]] = j;
        }

        // restore heap's property using bubble-down from node i to node j
        private void BubbleDown(int i, int j)
        {
            var current = this.BinaryHeap[i];
            while (i < j)
            {
                var l = LeftIndex(i);
                if (l >= j)
                {
                    // node i is a leaf
                    break;
                }
                var r = RightIndex(i);
                // k = left child index if right child doesn't exist, otherwise index of the smaller child
                var k = r >= j || this.BinaryHeap[l].CompareTo(this.BinaryHeap[r]) <= 0 ? l : r;
                if (current.CompareTo(this.BinaryHeap[k]) > 0)
                {
                    this.Swap(i, k);
                    i = k;
                }
                else
                {
                    break;
                }
            }
        }
    }
}

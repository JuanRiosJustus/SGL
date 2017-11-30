

using System;
using System.Collections;
using System.Collections.Generic;

namespace StandardGuidedLibrary.SGLCollections
{
    class SGLHeap<T> where T : IComparable<T>
    {
        private int Size;
        private static T[] Heap;

        public SGLHeap()
        {
            Heap = new T[10];
            Size = 0;
        }
        /// <summary>
        /// Swap the given inices sint the heap.
        /// </summary>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        private void Swap(int index1, int index2)
        {
            T temp = Heap[index1];
            Heap[index1] = Heap[index2];
            Heap[index2] = temp;
        }
        public bool IsEmpty()
        {
            return Size == 0;
        }
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new ArgumentOutOfRangeException();
            }

            return Heap[1];
        }
        public T Remove()
        {
            T result = Peek();

            // remove last leaf
            Heap[1] = Heap[Size];
            Heap[Size] = default(T);
            Size--;

            HeapifyDown();

            return result;
        }
        public void Add(T data)
        {

            if (Size >= Heap.Length - 1)
            {
                Resize();
            }

            Size++;
            int index = Size;
            Heap[index] = data;

            HeapifyUp();
        }
        public override string ToString()
        {
            string str = "[";

            for (int i = 1; i < Size + 1; i++)
            {
                str = str + Heap[i] + (i == Size ? "]" : ", ");
            }
            return str;
        }
        /// <summary>
        /// places a newly inserted element into it's proper place.
        /// </summary>
        private void HeapifyUp()
        {
            int index = Size;

            while(HasParent(index) && Comparer<T>.Default.Compare(Parent(index), Heap[index]) > 0)
            {
                // theyre out of order
                Swap(index, ParentIndex(index));
                index = ParentIndex(index);
            }
        }
        /// <summary>
        /// Places the element at the root of the heap in its correct place to 
        /// maintain min heap order property.
        /// </summary>
        private void HeapifyDown()
        {
            int index = 1;

            // we have children to check
            while (HasLeftChild(index))
            {

                int smallerChild = LeftChildIndex(index);

                // bubble down smaller child 
                if (HasRightChild(index) && Comparer<T>.Default.Compare(Heap[LeftChildIndex(index)], Heap[RightChildIndex(index)]) > 0)
                {
                    smallerChild = RightChildIndex(index);
                }

                if (Comparer<T>.Default.Compare(Heap[index], Heap[smallerChild]) > 0)
                {
                    Swap(index, smallerChild);
                }
                else
                {
                    break;
                }

                //update loop pointer to where last element was put.
                index = smallerChild;
            }
        }
        /// <summary>
        /// Resizes the array for more elements.
        /// </summary>
        private void Resize()
        {
            T[] newArray = new T[Heap.Length * 2];
            Array.Copy(Heap, newArray, Heap.Length);
            Heap = newArray;
        }
        /// <summary>
        /// Determines whether or not the given index has a parent.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool HasParent(int index) { return index > 1; }
        /// <summary>
        /// Determines whether the given index has a right child.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool HasRightChild(int index) { return RightChildIndex(index) <= Size; }
        /// <summary>
        /// Determines whether the given index has a leftchild.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool HasLeftChild(int index) { return LeftChildIndex(index) <= Size; }
        /// <summary>
        /// Returns the parent of the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private T Parent(int index) { return Heap[ParentIndex(index)]; }
        /// <summary>
        /// Retrieves the left child index o the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int LeftChildIndex(int index) { return index * 2; }
        /// <summary>
        /// Retireves the right child index of the given index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int RightChildIndex(int index) { return index * 2 + 1; }
        /// <summary>
        /// Retrieves the parent index of thegiven index.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int ParentIndex(int index) { return index / 2; }
    }
}
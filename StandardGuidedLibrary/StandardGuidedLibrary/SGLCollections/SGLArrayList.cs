using StandardGuidedLibrary.SGLCollections.SGLNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardGuidedLibrary.SGLCollections
{
    class SGLArrayList<T>
    {
        private T[] Array;
        private int Index;

        public SGLArrayList()
        {
            this.Array = new T[10];
            this.Index = 0;
        }
        /// <summary>
        /// Adds an element to the ArrayList.
        /// </summary>
        /// <param name="data"></param>
        public void Add(T data)
        {
            if (this.Array.Length - 1 == this.Index)
            {
                T[] NewArray = new T[this.Array.Length * 2];
                for (int index = 0; index < this.Array.Length; index++)
                {
                    NewArray[index] = Array[index];
                }
                this.Array = NewArray;
            }

            this.Array[Index] = data;
            this.Index = this.Index + 1;
        }
        /// <summary>
        /// Replaces the element at the index with the given element.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="data"></param>
        public void Replace(int index, T data)
        {
            this.Array[index] = data;
        }
        /// <summary>
        /// Method used to delete a particular index from an array.
        /// </summary>
        /// <param name="index"></param>
        public void Delete(int index)
        {
            T[] NewArray = new T[this.Array.Length - 1];

            for (int otherIndex = 0, secondOtherIndex = 0; otherIndex < this.Array.Length; otherIndex++)
            {
                if (otherIndex != index)
                {
                    NewArray[secondOtherIndex] = this.Array[otherIndex];
                    secondOtherIndex++;
                }
            }
            this.Index = this.Index - 1;
            this.Array = NewArray;
        }
        /// <summary>
        /// Retrieves the current size of the ArrayList.
        /// </summary>
        /// <returns></returns>
        public int Length()
        {
            return this.Index;
        }
        /// <summary>
        /// Gets a particular element from the ArrayList given an index.
        /// </summary>
        /// <param name="index"></param>
        public T Get(int index)
        {
            return this.Array[index];
        }

        /// <summary>
        /// Given an index and an element add an element to the particular
        /// index and shifting all other elements to the right one
        /// (increase every element's original index by one) 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="element"></param>
        public void Insert(int index, T element)
        {
            int Flag = 0;
            T[] Temp = new T[this.Array.Length + 1];
            // Copying all elements of the current arry to the new array until wee get to the index
            for (int position = 0; position < index; position++)
            {
                Temp[position] = this.Array[position];
                // Adds 

                if (position == index - 1)
                {
                    Flag = position + 2;
                    Temp[position + 1] = element;
                }
            }
            for (int position = Flag; position < Temp.Length - 1; position++)
            {
                Temp[position] = this.Array[position - 1];
                if (position == index - 1)
                {
                    Temp[index] = this.Array[index - 2];
                }
            }
            this.Index = this.Index + 1;
            this.Array = Temp;
        }
    }
}

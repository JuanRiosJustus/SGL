using StandardGuidedLibrary.SGLCollections.SGLNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardGuidedLibrary.SGLCollections
{
    class SGLQueue<T>
    {
        private SGLNode<T> Front;
        private SGLNode<T> Back;
        private int Size;

        public SGLQueue() { }
        public SGLQueue(T data)
        {
            Front = new SGLNode<T>(data);
        }
        /// <summary>
        /// Used to add an element ot the next most position of the Queue.
        /// </summary>
        /// <param name="data"></param>
        public void Enqueue(T data)
        {
            SGLNode<T> Node = new SGLNode<T>(data);
            if (Front == null)
            {
                Front = Node;
                Front.SetNext(Back);
                Back = Front;
            } else {
                Back.SetNext(Node);
                Back = Node;
            }
            Size = Size + 1;
        }
        /// <summary>
        /// Used take out the front element of the Queue.
        /// </summary>
        public T Dequeue()
        {
            if (Front == null)
            {
                return default(T);
            } else {
                SGLNode<T> Temporary = Front;
                Front = Front.GetNext();
                Size = Size - 1;
                return Temporary.GetData();
            }
        }
        public T Peek()
        {
            if (Front == null)
            {
                return default(T);
            } else {
                return Front.GetData();
            }
        }
        /// <summary>
        /// Checks to see if the Queue has any elements within it.
        /// </summary>
        public bool IsEmpty()
        {
            return (Size > 0 ? false : true);
        }
        /// <summary>
        /// Used to get the size of the Queue.
        /// </summary>
        public int Length()
        {
            return Size;
        }
    }
}

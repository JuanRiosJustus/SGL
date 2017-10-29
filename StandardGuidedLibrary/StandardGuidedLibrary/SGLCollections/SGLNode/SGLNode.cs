using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardGuidedLibrary.SGLCollections.SGLNode
{
    class SGLNode<T>
    {
        private T Data;
        private SGLNode<T> Next;
        private SGLNode<T> Previous;
        private int Identification;

        public SGLNode(T data)
        {
            Data = data;
        }
        public SGLNode(T data, int identification)
        {
            Data = data;
            Identification = identification;
        }
        /// <summary>
        /// Retrieve the data located within the current Node.
        /// </summary>
        public T GetData() { return Data; }
        /// <summary>
        /// Get the left child of the current Node.
        /// </summary>
        public SGLNode<T> GetLeft() { return Previous; }
        /// <summary>
        /// Set the left child of the current Node.
        /// </summary>
        /// <param name="node"></param>
        public void SetLeft(SGLNode<T> node) { Previous = node; }
        /// <summary>
        /// Get the right child of the current Node.
        /// </summary>
        public SGLNode<T> GetRight() { return Next; }
        /// <summary>
        /// Set the right child fo the current Node.
        /// </summary>
        /// <param name="node"></param>
        public void SetRight(SGLNode<T> node) { Next = node; }
        /// <summary>
        /// Retrieve the next Node relative to the current Node.
        /// </summary>
        public SGLNode<T> GetNext() { return Next; }
        /// <summary>
        /// Set the value of the next StackNode relative to the current Node.
        /// </summary>
        /// <param name="data"></param>
        public void SetNext(SGLNode<T> data) { Next = data; }
        /// <summary>
        /// Retrieve the previous Node relative to the current Node.
        /// </summary>
        public SGLNode<T> GetPrevious() { return Previous; }
        /// <summary>
        /// Set the value of the previous StackNode relative to the current Node.
        /// </summary>
        /// <param name="data"></param>
        public void SetPrevious(SGLNode<T> data) { Previous = data; }
        /// <summary>
        /// Return the integer representing the Identity of the Node.
        /// </summary>
        public int Identifier() { return Identification; }
        public override int GetHashCode()
        {
            return string.Format("{0}-{1}", Data, Identification).GetHashCode();
        }
        
    }
}

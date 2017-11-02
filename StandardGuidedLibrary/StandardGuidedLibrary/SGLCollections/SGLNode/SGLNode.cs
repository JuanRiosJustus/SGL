using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardGuidedLibrary.SGLCollections.SGLNode
{
    class SGLNode<T>
    {
        private int ID;
        private T Data;
        private SGLNode<T> Next;
        private SGLNode<T> Previous;
        public SGLArrayList<SGLNode<T>> AdjacencyList;

        /// <summary>
        /// Default constructor for SGLnode.
        /// </summary>
        public SGLNode()
        {
            this.ID = 0;
            this.Data = default(T);
            this.AdjacencyList = null;
        }
        /// <summary>
        /// Constructor for SGLNode taking in data.
        /// </summary>
        /// <param name="data"></param>
        public SGLNode(T data)
        {
            this.ID = 0;
            this.Data = data;
            this.AdjacencyList = new SGLArrayList<SGLNode<T>>();
        }
        /// <summary>
        /// Constructor for SGLNode taking in data and identification.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id"></param>
        public SGLNode(T data, int id)
        {
            ID = id;
            Data = data;
            AdjacencyList = new SGLArrayList<SGLNode<T>>();
        }
        /// <summary>
        /// Constructor for SGLNode taking in data, identification, and associated SGLNodes
        /// where associated SGLNodes are synonymous with adjacent SGLNodes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id"></param>
        /// <param name="associates"></param>
        public SGLNode(T data, int id, SGLArrayList<SGLNode<T>> associates)
        {
            ID = id;
            Data = data;
            AdjacencyList = associates;
        }

        /// <summary>
        /// Returns an SGLNode at the given index associated with the current SGLNode.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public SGLNode<T> GetAdjacentNode(int index) { return AdjacencyList.Get(index); }
        /// <summary>
        /// Adds an SGLNode to the list of associated SGLNodes.
        /// </summary>
        /// <param name="node"></param>
        public void AddAdjacentNode(SGLNode<T> node) { AdjacencyList.Add(node); }
        /// <summary>
        /// Deletes an SGLNode at the given index associated with the current SGLNode.
        /// </summary>
        /// <param name="index"></param>
        public void DeleteAdjacentNode(SGLNode<T> node) { AdjacencyList.Delete(node); }

        /// <summary>
        /// Return the integer representing the Identity of the Node.
        /// </summary>
        public int Id() { return ID; }
        /// <summary>
        /// Retrieves the core information of the current SGLNode.
        /// </summary>
        public T GetData() { return Data; }

        /// <summary>
        /// Gets the left child of the current SGLNode.
        /// </summary>
        public SGLNode<T> GetLeft() { return Previous; }
        /// <summary>
        /// Sets the left child of the current SGLNode.
        /// </summary>
        /// <param name="node"></param>
        public void SetLeft(SGLNode<T> node) { Previous = node; }
        /// <summary>
        /// Gets the right child of the current SGLNode.
        /// </summary>
        public SGLNode<T> GetRight() { return Next; }
        /// <summary>
        /// Sets the right child fo the current SGLNode.
        /// </summary>
        /// <param name="node"></param>
        public void SetRight(SGLNode<T> node) { Next = node; }

        /// <summary>
        /// Retrieves the next SGLNode relative to the current SGLNode.
        /// </summary>
        public SGLNode<T> GetNext() { return Next; }
        /// <summary>
        /// Sets the next SGLNode relative to the current SGLNode.
        /// </summary>
        /// <param name="data"></param>
        public void SetNext(SGLNode<T> data) { Next = data; }
        /// <summary>
        /// Retrieves the previous SGLNode relative to the current SGLNode.
        /// </summary>
        public SGLNode<T> GetPrevious() { return Previous; }
        /// <summary>
        /// Set the value of the previous SGLNode relative to the current SGLNode.
        /// </summary>
        /// <param name="data"></param>
        public void SetPrevious(SGLNode<T> data) { Previous = data; }

        /// <summary>
        /// Returns a string representation of the associated SGLNodes
        /// with respect to the longevity of their relationship to 
        /// the current SGLNode.
        /// </summary>
        /// <returns></returns>
        public string AssociatesToString() { return AdjacencyList.ToString(); }
        /// <summary>
        /// Returns a string representation of the curent node.
        /// </summary>
        /// <returns></returns>
        public override string ToString()  { return Data.ToString(); }
        /// <summary>
        /// Return the hash code for this SGLNode.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return string.Format("{0}-{1}", Data, ID).GetHashCode();
        }
        
    }
}

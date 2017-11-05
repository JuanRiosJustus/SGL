using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardGuidedLibrary.SGLCollections
{
    class SGLNode<T>
    {
        private int ID;
        private T Data;
        private SGLNode<T> Next;
        private SGLNode<T> Previous;
        public SGLArrayList<SGLEdge<T>> AdjacencyList;

        /// <summary>
        /// Default constructor for SGLNode.
        /// </summary>
        public SGLNode()
        {
            this.ID = 0;
            this.Data = default(T);
            this.AdjacencyList = null;
        }
        /// <summary>
        /// Constructor for SGLNode.
        /// </summary>
        /// <param name="data"></param>
        public SGLNode(T data)
        {
            this.ID = 0;
            this.Data = data;
            this.AdjacencyList = new SGLArrayList<SGLEdge<T>>();
        }
        /// <summary>
        /// Constructor for SGLNode.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id"></param>
        public SGLNode(T data, int id)
        {
            ID = id;
            Data = data;
            AdjacencyList = new SGLArrayList<SGLEdge<T>>();
        }
        /// <summary>
        /// Constructor for SGLNode.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="id"></param>
        /// <param name="associates"></param>
        public SGLNode(T data, int id, SGLArrayList<SGLEdge<T>> associates)
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
        public SGLNode<T> GetNode(int index)
        {
            return AdjacencyList.Get(index).EndingVertex();
        }
        /// <summary>
        /// Adds an SGLNode to the list of associated SGLNodes.
        /// </summary>
        /// <param name="SGLNode"></param>
        public void AddNode(SGLNode<T> SGLNode)
        {
            SGLEdge<T> edge = new SGLEdge<T>(this,SGLNode);
            AdjacencyList.Add(edge);
        }
        /// <summary>
        /// Deletes an SGLNode with the reference to the given SGLNode.
        /// Returns true if and only if a SGLNode of the same reference is deleted.
        /// </summary>
        /// <param name="index"></param>
        public bool DeleteNode(SGLNode<T> SGLNode)
        {
            for (int i = 0; i < AdjacencyList.Length(); i++)
            {
                if (Object.ReferenceEquals(AdjacencyList.Get(i), SGLNode))
                {
                    AdjacencyList.Delete(i);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Deletes an SGLNode at the given index.
        /// </summary>
        /// <param name="index"></param>
        public void DeleteNode(int index) { AdjacencyList.Delete(index); }

        /// <summary>
        /// Return the integer representing the Identity of the SGLNode.
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
        /// <param name="SGLNode"></param>
        public void SetLeft(SGLNode<T> SGLNode) { Previous = SGLNode; }
        /// <summary>
        /// Gets the right child of the current SGLNode.
        /// </summary>
        public SGLNode<T> GetRight() { return Next; }
        /// <summary>
        /// Sets the right child fo the current SGLNode.
        /// </summary>
        /// <param name="SGLNode"></param>
        public void SetRight(SGLNode<T> SGLNode) { Next = SGLNode; }
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
        public string ListToString()
        {
            return AdjacencyList.ToString();
        }
        /// <summary>
        /// Returns a string representation of the curent SGLNode.
        /// </summary>
        /// <returns></returns>
        public override string ToString() { return Data.ToString(); }
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

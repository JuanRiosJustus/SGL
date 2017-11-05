using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardGuidedLibrary.SGLCollections
{
    class SGLEdge<T>
    {
        int Weight;
        bool Directed;
        SGLNode<T> StartingSGLNode;
        SGLNode<T> EndingSGLNode;

        public SGLEdge() { }
        public SGLEdge(SGLNode<T> startingSGLNode, SGLNode<T> endingSGLNode)
        {
            Directed = false;
            Weight = 0;
            StartingSGLNode = startingSGLNode;
            EndingSGLNode = endingSGLNode;
        }
        public SGLEdge(SGLNode<T> startingSGLNode, SGLNode<T> endingSGLNode, int weight)
        {
            Directed = false;
            Weight = weight;
            StartingSGLNode = startingSGLNode;
            EndingSGLNode = endingSGLNode;
        }
        public SGLEdge(SGLNode<T> startingSGLNode, SGLNode<T> endingSGLNode, bool directed)
        {

            Directed = directed;
            Weight = 0;
            StartingSGLNode = startingSGLNode;
            EndingSGLNode = endingSGLNode;
        }
        public SGLEdge(SGLNode<T> startingSGLNode, SGLNode<T> endingSGLNode, int weight, bool directed)
        {
            Directed = directed;
            Weight = weight;
            StartingSGLNode = startingSGLNode;
            EndingSGLNode = endingSGLNode;
        }
        /// <summary>
        /// Returns the starting vertex of this SGLEdge.
        /// </summary>
        /// <returns></returns>
        public SGLNode<T> StartingVertex()
        {
            return StartingSGLNode;
        }
        /// <summary>
        /// Returns the ending vertex of this SGLEdge.
        /// </summary>
        /// <returns></returns>
        public SGLNode<T> EndingVertex()
        {
            return EndingSGLNode;
        }
        /// <summary>
        /// Returns the weight of this SGLEdge.
        /// </summary>
        /// <returns></returns>
        public int GetWeight()
        {
            return Weight;
        }
        /// <summary>
        /// Returns the string representation of this SGLEdge.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Directed == true)
            {
                return StartingSGLNode.ToString() + " ---> " + (EndingSGLNode == null ? "null" : EndingSGLNode.ToString());
            }
            else
            {
                return StartingSGLNode.ToString() + " <---> " + (EndingSGLNode == null ? "null" : EndingSGLNode.ToString());
            }
        }
    }
}

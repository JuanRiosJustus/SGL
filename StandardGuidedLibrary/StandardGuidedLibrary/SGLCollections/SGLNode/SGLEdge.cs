using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardGuidedLibrary.SGLCollections.SGLNode
{
    class SGLEdge<T>
    {
        int Weight;
        SGLNode<T> StartingNode;
        SGLNode<T> EndingNode;

        public SGLEdge() { }
        public SGLEdge(SGLNode<T> startingNode, SGLNode<T> endingNode)
        {
            Weight = 0;
            StartingNode = startingNode;
            EndingNode = endingNode;
        }
        public SGLEdge(SGLNode<T> startingNode, SGLNode<T> endingNode, int weight)
        {
            Weight = weight;
            StartingNode = startingNode;
            EndingNode = endingNode;
        }
        public SGLNode<T> StartingVertex()
        {
            return StartingNode;
        }
        public SGLNode<T> EndingVertex()
        {
            return EndingNode;
        }
        public int GetWeight()
        {
            return Weight;
        }
    }
}

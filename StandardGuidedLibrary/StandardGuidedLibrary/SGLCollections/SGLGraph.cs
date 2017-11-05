using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardGuidedLibrary.SGLCollections
{
    class SGLGraph<T>
    {
        private int SGLNodes;
        private bool Directed;
        private SGLArrayList<SGLNode<T>> Vertices;

        public SGLGraph()
        {
            SGLNodes = 0;
            Directed = false;
            Vertices = new SGLArrayList<SGLNode<T>>();
        }
        public SGLGraph(SGLNode<T> SGLNode)
        {
            Directed = false;
            Vertices = new SGLArrayList<SGLNode<T>>();
            Vertices.Add(SGLNode);
            SGLNodes = 1;
        }
        public SGLGraph(bool directed)
        {
            SGLNodes = 0;
            Directed = directed;
            Vertices = new SGLArrayList<SGLNode<T>>();
        }
        public SGLGraph(SGLNode<T> SGLNode, bool directed)
        {
            Directed = directed;
            Vertices = new SGLArrayList<SGLNode<T>>();
            Vertices.Add(SGLNode);
            SGLNodes = 1;
        }
        /// <summary>
        /// Adds a vertex to the list of vertices associated with this graph.
        /// </summary>
        /// <param name="data"></param>
        public void AddVertex(T data)
        {
            Vertices.Add(new SGLNode<T>(data));
        }
        /// <summary>
        /// Returns a vertex at the given index in the list of vertices
        /// associated with this graph.
        /// </summary>
        /// <param name="index"></param>
        public SGLNode<T> GetVertexAt(int index)
        {
            return Vertices.Get(index);
        }
        /// <summary>
        /// Deletes a vertex in the list of avaialable vertices associated with the graph.
        /// </summary>
        /// <param name="index"></param>
        public void DeleteVertex(int index)
        {
            SGLNode<T> toDelete = Vertices.Get(index);

            for (int i = 0; i < Vertices.Length(); i++)
            {
                for (int j = 0; j < Vertices.Get(i).AdjacencyList.Length(); j++)
                {
                    if (Object.ReferenceEquals(Vertices.Get(i).AdjacencyList.Get(j), toDelete))
                    {
                        Vertices.Get(i).AdjacencyList.Delete(j);
                    }
                }
            }
        }
        /// <summary>
        /// If the list of Vertices contains the source vertex, Add the destination
        /// to the list of the source's adjacent vertices and return true. Otherwise
        /// false.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public bool AddEdge(SGLNode<T> source, SGLNode<T> destination)
        {
            if (Vertices.Contains(source) && Vertices.Contains(destination))
            {
                Vertices.Get(source).AddNode(destination);
                if (Directed == false)
                {
                    Vertices.Get(destination).AddNode(source);
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Returns true if and only i fthe graph is directed.
        /// Differs from the Adding an edge given a SGLNode in that it will
        /// only return false if the graph is no directed.
        /// </summary>
        /// <param name="SGLNode_index_one"></param>
        /// <param name="SGLNode_index_two"></param>
        /// <returns></returns>
        public bool AddEdge(int SGLNode_index_one, int SGLNode_index_two)
        {
            
            if (Directed == false)
            {
                Vertices.Get(SGLNode_index_one).AddNode(Vertices.Get(SGLNode_index_two));
                Vertices.Get(SGLNode_index_two).AddNode(Vertices.Get(SGLNode_index_one));
                return false;
            }
            else
            {
                Vertices.Get(SGLNode_index_one).AddNode(Vertices.Get(SGLNode_index_two));
                return true;
            }
        }
        /// <summary>
        /// Given two vertices, if they contain a reference to one another
        /// it is set to null. will return true if and only if they are 
        /// part of the collection of SGLNodes related to the graph
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public bool DeleteEdge(SGLNode<T> source, SGLNode<T> destination)
        {
            if (Vertices.Contains(source) && Vertices.Contains(destination))
            {
                Vertices.Get(source).DeleteNode(destination);
                Vertices.Get(destination).DeleteNode(source);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Given two vertices that exist inside the ist of vertices of this graph
        /// Delete the connections between them if they refer to the same object.
        /// 
        /// </summary>
        /// <param name="SGLNode_index_one"></param>
        /// <param name="SGLNode_index_two"></param>
        public void DeleteEdge(int SGLNode_index_one, int SGLNode_index_two)
        {
            Vertices.Get(SGLNode_index_one).DeleteNode(Vertices.Get(SGLNode_index_two));
            Vertices.Get(SGLNode_index_two).DeleteNode(Vertices.Get(SGLNode_index_one));
        }
        /// <summary>
        /// Deletes a SGLNode by removing all references from the colection
        /// of vertices of the graph and its Nodes.
        /// </summary>
        /// <param name="SGLNode"></param>
        /// <returns></returns>
        public bool DeleteVertex(SGLNode<T> SGLNode)
        {
            Console.WriteLine(SGLNode.ToString() + " is the SGLNode");
            for (int i = 0; i < Vertices.Length(); i++)
            {
                for (int j = 0; j < Vertices.Get(i).AdjacencyList.Length(); j++)
                {
                    if (Object.ReferenceEquals(Vertices.Get(i).AdjacencyList.Get(j), SGLNode))
                    {
                        Vertices.Get(i).DeleteNode(SGLNode);
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Rturns the amount of SGLNode associated with this graph.
        /// </summary>
        /// <returns></returns>
        public int Size() { return Vertices.Length(); }
        /// <summary>
        /// Returns the list of available vertices.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Vertices.ToString();
        }
    }
}

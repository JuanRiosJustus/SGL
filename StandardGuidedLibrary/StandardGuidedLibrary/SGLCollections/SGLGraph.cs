using StandardGuidedLibrary.SGLCollections.SGLNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardGuidedLibrary.SGLCollections
{
    class SGLGraph<T>
    {
        private SGLArrayList<SGLNode<T>> Vertices;
        private SGLArrayList<SGLEdge<T>> Edges;
        private int Nodes;

        public SGLGraph()
        {
            Vertices = new SGLArrayList<SGLNode<T>>();
            Nodes = 0;
        }
        public SGLGraph(SGLNode<T> node)
        {
            Vertices = new SGLArrayList<SGLNode<T>>();
            Vertices.Add(node);
            Nodes = 1;
        }
        /// <summary>
        /// Adds a vertex to the list of vertices associated with this graph.
        /// </summary>
        /// <param name="data"></param>
        public void AddVertex(T data)
        {
            Vertices.Add(new SGLNode<T>(data));
            Nodes++;
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
        /// Deletes a vertex in the avaialable vertices associated with the graph.
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
                Vertices.Get(source).AddAdjacentNode(destination);
                Vertices.Get(destination).AddAdjacentNode(source);
                return true;
            }
            return false;
        }
        public bool AddEdge(int node_index_one, int node_index_two)
        {
        }
        /// <summary>
        /// Given two vertices, if they contain a reference to one another
        /// it is set to null. will return true if and only if they are 
        /// part of the collection of nodes related to the graph
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public bool DeleteEdge(SGLNode<T> source, SGLNode<T> destination)
        {
            if (Vertices.Contains(source) && Vertices.Contains(destination))
            {
                Vertices.Get(source).DeleteAdjacentNode(destination);
                Vertices.Get(destination).DeleteAdjacentNode(source);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Deletes a ndoe by removing all rferences from the entries
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool DeleteVertex(SGLNode<T> node)
        {
            Console.WriteLine(node.ToString() + " is the node");
            for (int i = 0; i < Vertices.Length(); i++)
            {
                for (int j = 0; j < Vertices.Get(i).AdjacencyList.Length(); j++)
                {
                    if(Vertices.Get(i).AdjacencyList.Get(j) == node)
                    {
                        Console.WriteLine("This node was related to: " + Vertices.Get(i));
                        Vertices.Get(i).DeleteAdjacentNode(node);
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Rturns the amount of node associated with this graph.
        /// </summary>
        /// <returns></returns>
        public int Size() { return Nodes; }
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

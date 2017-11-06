using StandardGuidedLibrary.SGLCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardGuidedLibrary.SGLAlgorithms
{
    class GraphUtils<T>
    {
        public static SGLGraph<T> ConstructGraph(int maxChildCount, int edgeDeter,bool isDirected, SGLArrayList<T> nodeList)
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("Constructing graph...");
            Console.WriteLine("Max edges per node: " + maxChildCount);
            Console.WriteLine("Chance to add an edge: " + (100 - edgeDeter) + "%");
            Console.WriteLine("Constructing graph from: " + nodeList.ToString());
            Console.WriteLine("****************************************");
            SGLGraph<T> graph = new SGLGraph<T>(isDirected);
            Random random = new Random();
            HashSet<SGLNode<T>> nodes = new HashSet<SGLNode<T>>();
            for (int index = 0; index < nodeList.Length(); index++)
            {
                graph.AddVertex(nodeList.Get(index));
            }
            for (int index = 0; index < nodeList.Length(); index++)
            {
                nodes.Add(graph.GetVertexAt(index));
                Console.WriteLine("Node: " + graph.GetVertexAt(index).ToString() + " was added");
                int chance = random.Next(100);

                int availableNodes = graph.Size();
                for (int i = 0; i < maxChildCount; i++)
                {
                    if (chance > edgeDeter && availableNodes > 0) //??? hmm maybe -1
                    {
                        int nodeIndex = random.Next(availableNodes);
                        if (!nodes.Contains(graph.GetVertexAt(nodeIndex)))
                        {
                            graph.AddEdge(index, nodeIndex);
                            nodes.Add(graph.GetVertexAt(nodeIndex));
                            Console.Write(graph.GetVertexAt(index).ToString() + (isDirected == true ? " ---> " : " <---> ") + graph.GetVertexAt(nodeIndex).ToString());
                            Console.WriteLine();
                        }
                        availableNodes--;
                        chance = chance - random.Next(chance) - random.Next(chance);
                    }
                }
                nodes.Clear();
                Console.WriteLine("Initial relations: " + graph.GetVertexAt(index).AdjacentsToString());
                Console.WriteLine("-------------------------------------------");
            }

            Console.WriteLine("****************************************");
            Console.WriteLine("final graph's nodes: " + graph.ToString());
            Console.WriteLine("****************************************");
            return graph;
        }
        
        /// <summary>
        /// Conducts a breadth first search to check if the destination node is an 
        /// available path from the source node.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static bool HasBFSPath(SGLNode<T> source, SGLNode<T> destination)
        {
            HashSet<SGLNode<T>> visited = new HashSet<SGLNode<T>>();
            SGLQueue<SGLNode<T>> queue = new SGLQueue<SGLNode<T>>();
            Console.WriteLine("****************************************");
            Console.Write("(BFS) From node: [" + source.GetData().ToString() + "] | To node: [" + destination.GetData().ToString() + "]");
            Console.WriteLine();
            Console.WriteLine("****************************************");
            queue.Enqueue(source);
            while (queue.IsEmpty() == false)
            {
                SGLNode<T> current = queue.Dequeue();
                
                Console.Write("Visiting: [" + (current.GetData() != null ? current.GetData().ToString() : "null") + "]"); // TODO
                Console.WriteLine(" | Relations: " + current.AdjacentsToString());
                if (visited.Contains(current))
                {
                    continue;
                }
                if (object.ReferenceEquals(current, destination))
                {
                    Console.WriteLine("We have found our node [" + source.GetData().ToString() + "] ---> [" + destination.GetData().ToString() + "]");
                    return true;
                }

                visited.Add(current);
                for (int i = 0; i < current.GetAdjacencyList().Length(); i++)
                {
                    if (!visited.Contains(current.GetAdjacencyList().Get(i).EndingVertex()))
                    {
                        queue.Enqueue(current.GetAdjacencyList().Get(i).EndingVertex());
                    }
                }
                Console.WriteLine("Queue: " + queue.ToString());
            }
            Console.WriteLine("We found nothing...");
            return false;
        }

        /// <summary>
        /// Conducts a depth frist search to check if the destination
        /// node is an available node from the source node.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static bool HasDFSPath(SGLNode<T> source, SGLNode<T> destination)
        {
            HashSet<SGLNode<T>> visited = new HashSet<SGLNode<T>>();
            SGLStack<SGLNode<T>> stack = new SGLStack<SGLNode<T>>();
            Console.WriteLine("****************************************");
            Console.Write("(DFS) From node: [" + source.GetData().ToString() + "] | To node: [" + destination.GetData().ToString() + "]");
            Console.WriteLine();
            Console.WriteLine("****************************************");
            stack.Push(source);

            while(stack.IsEmpty() == false)
            {
                SGLNode<T> current = stack.Pop();
                Console.Write("Visitng: [" + (current.GetData() == null ? "null" : current.GetData().ToString()) + "]");
                Console.WriteLine(" | Relations: " + current.AdjacentsToString());
                if (object.ReferenceEquals(current, destination))
                {
                    Console.WriteLine("We have found our node [" + source.GetData().ToString() + "] ---> [" + destination.GetData().ToString() + "]");
                    return true;
                }
                if (visited.Contains(current))
                {
                    continue;
                }

                visited.Add(current);

                for (int i = 0; i < current.GetAdjacencyList().Length(); i++)
                {
                    if (!visited.Contains(current.GetAdjacencyList().Get(i).EndingVertex()))
                    {
                        stack.Push(current.GetAdjacencyList().Get(i).EndingVertex());
                    }
                }
                Console.WriteLine("Stack: " + stack.ToString());
            }
            Console.WriteLine("We found nothing...");
            return false;
        }

        /// <summary>
        /// Prints a possible path from current noe to the destination node.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public static void PrintAllPaths(SGLNode<T> source, SGLNode<T> destination)
        {
            HashSet<SGLNode<T>> visited = new HashSet<SGLNode<T>>();
            SGLArrayList<SGLNode<T>> path = new SGLArrayList<SGLNode<T>>();

            PrintAllPaths(source, destination, visited, path);
        }
        /// <summary>
        /// Prints all the possble paths from Soure node to a destination node.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="destination"></param>
        public static void PrintAllPaths(SGLGraph<T> graph, SGLNode<T> destination)
        {

            for (int i = 0; i < graph.Size(); i++)
            {
                PrintAllPaths(graph.GetVertexAt(i), destination, new HashSet<SGLNode<T>>(), new SGLArrayList<SGLNode<T>>());
            }
        }
        private static void PrintAllPaths(SGLNode<T> source, SGLNode<T> destination, HashSet<SGLNode<T>> visited, SGLArrayList<SGLNode<T>> path)
        {
            visited.Add(source);
            path.Add(source);
            if (Object.ReferenceEquals(source, destination))
            {
                Console.Write("Possible Path [");
                for (int i = 0; i < path.Length(); i++)
                {
                    
                    Console.Write(path.Get(i).GetData().ToString() + (path.Length() - 1 == i ? "" : " --> "));
                }
                Console.WriteLine("]");
            }
            else
            {
                for (int i = 0; i < source.GetAdjacencyList().Length(); i++)
                {
                    if (!visited.Contains(source.GetAdjacencyList().Get(i).EndingVertex()))
                    {
                        PrintAllPaths(source.GetAdjacencyList().Get(i).EndingVertex(), destination, visited, path);
                    }
                }
            }
            path.Delete(source);
        }
    }
}

using StandardGuidedLibrary.SGLCollections.SGLNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardGuidedLibrary.SGLCollections
{
    class SGLBinarySearchTree<T>
    {
        private SGLNode<T> Root;
        private int Size = 0;

        public SGLBinarySearchTree() { }
        public SGLBinarySearchTree(T data, int identifier)
        {
            Root = new SGLNode<T>(data, identifier);
            Size++;
        }
        /// <summary>
        /// Add an object to the tree using an id.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="Identifier"></param>
        public void Add(T data, int Identifier)
        {
            SGLNode<T> Node = new SGLNode<T>(data, Identifier);
            if (Root == null)
            {
                Root = Node;
            }
            else
            {
                TraverseAndAdd(Root, Node);
            }
            Size++;
        }
        /// <summary>
        /// Traverse the tree until the next available spot, maintaining the search property using an id.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="node"></param>
        private void TraverseAndAdd(SGLNode<T> parent, SGLNode<T> node)
        {
            if (parent.Identifier() < node.Identifier())
            {
                if (parent.GetRight() == null)
                {
                    parent.SetRight(node);
                }
                else
                {
                    TraverseAndAdd(parent.GetRight(), node);
                }
            }
            else
            {
                // The Root identifier is larger than the new node.
                if (parent.GetLeft() == null)
                {
                    Root.SetLeft(node);
                }
                else
                {
                    TraverseAndAdd(parent.GetLeft(), node);
                }
            }
        }
        public int Length() { return Size; }
        /// <summary>
        /// Gets the root of the tree.
        /// </summary>
        /// <returns></returns>
        public SGLNode<T> GetRoot() { Console.WriteLine(Root.GetData() + ""); return Root; }
        /// <summary>
        /// Determines if the current tree has a root.
        /// </summary>
        /// <returns></returns>
        public bool HasRoot() { return (Root == null ? false : true); }
        /// <summary>
        /// Writes the post order traversal of tree given a Node, to console.
        /// </summary>
        /// <param name="root"></param>
        public void PreOrderTraversal(SGLNode<T> root)
        {
            if (root != null)
            {
                Console.Write(root.GetData() + " ");
                PreOrderTraversal(root.GetLeft());
                PreOrderTraversal(root.GetRight());
            }
        }
        /// <summary>
        /// Writes the in order traversal of tree given a Node. to the console.
        /// </summary>
        /// <param name="root"></param>
        public void InOrderTraversal(SGLNode<T> root)
        {
            if (root != null)
            {
                InOrderTraversal(root.GetLeft());
                Console.Write(root.GetData() + " ");
                InOrderTraversal(root.GetRight());
            }
        }
        /// <summary>
        /// Writes the post order traversal of a tree given a Node to console.
        /// </summary>
        /// <param name="root"></param>
        public void PostOrderTraversal(SGLNode<T> root)
        {
            if (root != null)
            {
                PostOrderTraversal(root.GetLeft());
                PostOrderTraversal(root.GetRight());
                Console.Write(root.GetData() + " ");
            }
        }
    }
}

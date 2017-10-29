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

        public SGLBinarySearchTree() { Root = null; }
        public SGLBinarySearchTree(T data, int identifier)
        {
            Root = new SGLNode<T>(data, identifier);
            Size++;
        }
        /// <summary>
        /// Add an object to the tree.
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
        private void TraverseAndAdd(SGLNode<T> parent, SGLNode<T> newNode)
        {
            if (parent.Identifier() < newNode.Identifier())
            {
                if (parent.GetRight() == null)
                {
                    parent.SetRight(newNode);
                }
                else
                {
                    TraverseAndAdd(parent.GetRight(), newNode);
                }
            }
            else
            {
                if (parent.GetLeft() == null)
                {
                    parent.SetLeft(newNode);
                }
                else
                {
                    TraverseAndAdd(parent.GetLeft(), newNode);
                }
            }
        }
        /// <summary>
        /// Returns a string representation of the InOrder traversal of the current collection.
        /// </summary>
        public string InOrderTraversal()
        {
            return "[ " + InOrderTraversal(Root, "") + "]";
        }
        private string InOrderTraversal(SGLNode<T> node, string data)
        {
            if (node != null)
            {
                data = InOrderTraversal(node.GetLeft(), data) + node.Identifier().ToString() + " " + InOrderTraversal(node.GetRight(), data);
            }
            return data;
        }
        /// <summary>
        /// Returns a string representation of the PreOrder traversal of the current collection.
        /// </summary>
        public string PreOrderTraversal()
        {
            return "[ " + PreOrderTraversal(Root, "") + "]";
        }
        private string PreOrderTraversal(SGLNode<T> node, string data)
        {
            if (node != null)
            {
                data = node.Identifier().ToString() + " " + PreOrderTraversal(node.GetLeft(), data) + PreOrderTraversal(node.GetRight(), data);
            }
            return data;
            
        }
        /// <summary>
        /// Returns a string representation of the PostOrder traversal of the current collection.
        /// </summary>
        public string PostOrderTraversal()
        {
            return "[ " + PostOrderTraversal(Root, "") + "]";
            
        }
        public string PostOrderTraversal(SGLNode<T> node, string data)
        {
            if (node != null)
            {
                data = PostOrderTraversal(node.GetLeft(), data) + PostOrderTraversal(node.GetRight(), data) + node.Identifier().ToString() + " ";
            }
            return data;
        }
    }
}

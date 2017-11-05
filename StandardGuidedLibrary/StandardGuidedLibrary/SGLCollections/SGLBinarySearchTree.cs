using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardGuidedLibrary.SGLCollections
{
    class SGLBinarySearchTree<T>
    {
        private int Size = 0;
        private SGLNode<T> Root;

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
            SGLNode<T> SGLNode = new SGLNode<T>(data, Identifier);
            if (Root == null)
            {
                Root = SGLNode;
            }
            else
            {
                TraverseAndAdd(Root, SGLNode);
            }
            Size++;
        }
        private void TraverseAndAdd(SGLNode<T> parent, SGLNode<T> newSGLNode)
        {
            if (parent.Id() < newSGLNode.Id())
            {
                if (parent.GetRight() == null)
                {
                    parent.SetRight(newSGLNode);
                }
                else
                {
                    TraverseAndAdd(parent.GetRight(), newSGLNode);
                }
            }
            else
            {
                if (parent.GetLeft() == null)
                {
                    parent.SetLeft(newSGLNode);
                }
                else
                {
                    TraverseAndAdd(parent.GetLeft(), newSGLNode);
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
        private string InOrderTraversal(SGLNode<T> SGLNode, string arg)
        {
            if (SGLNode != null)
            {
                arg = InOrderTraversal(SGLNode.GetLeft(), arg) + SGLNode.Id().ToString() + " " + InOrderTraversal(SGLNode.GetRight(), arg);
            }
            return arg;
        }
        /// <summary>
        /// Returns a string representation of the PreOrder traversal of the current collection.
        /// </summary>
        public string PreOrderTraversal()
        {
            return "[" + PreOrderTraversal(Root, "") + "]";
        }
        private string PreOrderTraversal(SGLNode<T> SGLNode, string arg)
        {
            if (SGLNode != null)
            {
                arg = SGLNode.Id().ToString() + " " + PreOrderTraversal(SGLNode.GetLeft(), arg) + PreOrderTraversal(SGLNode.GetRight(), arg);
            }
            return arg;

        }
        /// <summary>
        /// Returns a string representation of the PostOrder traversal of the current collection.
        /// </summary>
        public string PostOrderTraversal()
        {
            return "[ " + PostOrderTraversal(Root, "") + "]";

        }
        public string PostOrderTraversal(SGLNode<T> SGLNode, string arg)
        {
            if (SGLNode != null)
            {
                arg = PostOrderTraversal(SGLNode.GetLeft(), arg) + PostOrderTraversal(SGLNode.GetRight(), arg) + SGLNode.Id().ToString() + " ";
            }
            return arg;
        }
    }
}

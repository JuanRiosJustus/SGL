using StandardGuidedLibrary.SGLCollections.SGLNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardGuidedLibrary.SGLCollections
{
    class SGLStack<T>
    {
        private SGLNode<T> Top;
        private int Size;

        public SGLStack() { }
        public SGLStack(T data)
        {
            Top = new SGLNode<T>(data);
        }

        /// <summary>
        /// Add an element to the top of the Stack.
        /// </summary>
        /// <param name="data"></param>
        public void Push(T data)
        {
            SGLNode<T> Node = new SGLNode<T>(data);
            if (Top == null)
            {
                Top = Node;
            } else {
                Top.SetPrevious(Node);
                Node.SetNext(Top);
                Top = Node;
            }
            Size = Size + 1;
        }
        /// <summary>
        /// Take an element off the top of the Stack.
        /// </summary>
        public T Pop()
        {
            if (Top == null)
            {
                return default(T);
            }  else {
                SGLNode<T> Temporary = Top;
                Top = Top.GetNext();
                Size = Size - 1;
                return Temporary.GetData();
            }
        }
        /// <summary>
        /// Get the first element at the top of the stack.
        /// </summary>
        public T Peek()
        {
            if (Top == null)
            {
                return default(T);
            }  else {
                return Top.GetData();
            }
        }
        /// <summary>
        /// Determine whether the Stack is empty
        /// </summary>
        public bool IsEmpty()
        {
            return (Size == 0 ? true : false);
        }
        /// <summary>
        /// Get the amount of elements within the Stack.
        /// </summary>
        /// <returns></returns>
        public int Height()
        {
            return Size;
        }
        /// <summary>
        /// Returns a string representation of the stack where
        /// the first element is the first element si the bottom
        /// of the stack.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "[" + StringForm("") + "]";
        }
        private string StringForm(string data)
        {
            SGLArrayList<SGLNode<T>> nodes = new SGLArrayList<SGLNode<T>>();
            SGLNode<T> current = Reverse(Top);
            nodes.Add(current);
            while (current != null)
            {
                data = data + current.ToString() + (current.GetNext() == null ? "" : ", ");
                current = current.GetNext();
            }
            Top = Reverse(nodes.Get(0));
            return data;
        }
        private SGLNode<T> Reverse(SGLNode<T> node)
        {
            SGLNode<T> prev = null;
            SGLNode<T> current = node;
            SGLNode<T> next = null;
            while (current != null)
            {
                next = current.GetNext();
                current.SetNext(prev);
                prev = current;
                current = next;
            }
            node = prev;
            return node;
        }
    }
}

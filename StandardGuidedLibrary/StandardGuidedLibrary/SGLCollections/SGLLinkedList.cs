using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StandardGuidedLibrary.SGLCollections
{
    class SGLLinkedList<T>
    {
        SGLNode<T> Head;
        SGLNode<T> Tail;
        
        public SGLLinkedList() { }
        public SGLLinkedList(SGLNode<T> node)
        {
            Head = node;
            Tail = node;
        }
        public SGLLinkedList(SGLNode<T> head, SGLNode<T> tail)
        {
            Head = head;
            Tail = tail;
        }
        public void AppendToTail(T data)
        {
            SGLNode<T> node = new SGLNode<T>(data);

            if (Head == null || Tail == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.SetNext(node);
                node.SetPrevious(Tail);
                Tail = node;
            }
        }
        public void AppendToHead(T data)
        {
            SGLNode<T> node = new SGLNode<T>(data);
            if (Head == null || Tail == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Head.SetPrevious(node);
                node.SetNext(Head);
                Head = node;
            }
        }

        public SGLNode<T> GetHead()
        {
            return Head;
        }

        public SGLNode<T> GetTail()
        {
            return Tail;
        }

    }
}

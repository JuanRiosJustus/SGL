using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StandardGuidedLibrary.SGLCollections;

namespace StandardGuidedLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            SGLArrayList<int> list = new SGLArrayList<int>();
            SGLBinarySearchTree<string> tree = new SGLBinarySearchTree<string>();

            Random rand = new Random();
            for(int i = 0; i < 20; i++)
            {
                list.Add(rand.Next(50));
                Console.Write(list.Get(i) + " ");
            }

            Console.ReadKey();


            // TODO THE OPPERAND STACK
            // CONVERT INFX TO POSTFIX
            // FULLY PARENTHESIS
            // MOVE EACH OPERATOR TO LOCATION OF ITS CLOSED PARENTHESIS
            // DROP ALL PARENTHSIS

            // PUSH OPPERAND INTO THE STACK

            // PUSH OPERATOR INTO ANOTHE RSTACK
        }
    }
}

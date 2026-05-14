using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScience
{
    public class StackNodes
    {
        private Node Top;

        public StackNodes()
        {
            Top = null;
        }
        public void Push(int element)
        {
            var node = new Node(element);
            node.Next = Top;
            Top = node;
        }
        public int Pop()
        {
            var node = Top;
            Top = node.Next;
            return node.Value;
        }

        public class Node
        {
            public int Value;
            public Node Next;
            public Node(int value)
            {
                Value = value;
                Next = null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScience
{
    public class QueueNodes
    {
        private Node _head;
        private Node _tail;


        public QueueNodes()
        {
            _head = null;
            _tail = null;
        }

        public void Enqueue(int element)
        {
            var node = new Node(element);
            if (_head == null)
            {
                _head = node;
                _tail = node;
                return;
            }
            _tail.Next = node;
            _tail = node;
        }
        public int Dequeue()
        {
            var node = _head;
            _head = node.Next;
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

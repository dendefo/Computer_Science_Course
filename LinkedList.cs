using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScience
{
    internal class LinkedList<T>
    {
        LinkedListNode<T> head;
        LinkedListNode<T> tail;
        int _count;
        public LinkedList(T head)
        {
            this.head = new LinkedListNode<T>(head);
            this.tail = this.head;
        }
        public LinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void AddFirst(T value)
        {
            _count++;
            if (this.head == null)
            {
                head = new LinkedListNode<T>(value);
                tail = head;
                return;
            }
            var temp = head;
            head = new LinkedListNode<T>(value);
            head.Next = temp;
        }
        public void AddLast(T value)
        {
            _count++;
            if (this.tail == null)
            {
                tail = new LinkedListNode<T>(value);
                head = tail;
                return;
            }
            var temp = tail;
            tail = new LinkedListNode<T>(value);
            temp.Next = tail;
        }

        public void InsertAfter(LinkedListNode<T> node, T value)
        {
            if (node == tail)
            {
                AddLast(value);
                return;
            }
            _count++;
            var next = node.Next;
            node.Next = new LinkedListNode<T>(value, next);
        }

        public LinkedListNode<T> ElementAt(int index)
        {
            if (head == null) throw new NullReferenceException("No values in the list");
            var current = head;
            for (int i = 0; i < index; i++)
            {
                if (current.Next == null) throw new ArgumentOutOfRangeException("WRONG NUMBER");
                current = current.Next;
            }
            return current;
        }
        public void InsertAt(int index, T value)
        {
            var element = ElementAt(index);
            InsertAfter(element, value);
        }

        public void RemoveFirst()
        {
            if (head == null) throw new NullReferenceException("No values in the list");
            _count--;
            head = head.Next;
            if (head == null)
            {
                tail = null;
            }
        }
        public void RemoveLast()
        {
            if (tail == null) throw new NullReferenceException("No values in the list");
            if (tail == head)
            {
                RemoveFirst();
                return;
            }
            _count--;
            var current = head;
            while (current.Next != tail)
            {
                current = current.Next;
            }
            tail = current;
            current.Next = null;
        }
        public void RemoveAt(int index)
        {
            if (index == 0)
            {
                RemoveFirst();
                return;
            }
            var before = ElementAt(index - 1);
            if (before == tail) throw new ArgumentOutOfRangeException("WRONG NUMBER");
            if (before.Next == tail)
            {
                RemoveLast();
                return;
            }
            _count--;
            before.Next = before.Next.Next;
        }
        public bool Contains(T value)
        {
            var current = head;
            while (current != null)
            {
                if (current.Value.Equals(value)) return true;
            }
            return false;
        }
        public int Count => _count;



        public class LinkedListNode<T>
        {
            public T Value;
            public LinkedListNode<T> Next;
            public LinkedListNode(T value, LinkedListNode<T> next = null)
            {
                this.Value = value;
                this.Next = next;
            }
        }
    }
}

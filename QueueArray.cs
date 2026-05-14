using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScience
{
    public class QueueArray
    {
        private int[] _array;
        private int head;
        private int tail;
        public int Length;

        public QueueArray(int size = 4)
        {
            _array = new int[size];
            head = 0;
            tail = 0;
            Length = 0;
        }

        public void Enqueue(int element)
        {
            if ((tail + 1) % _array.Length == head && Length ==_array.Length)
            {
                throw new IndexOutOfRangeException();
            }
            _array[tail] = element;
            tail++;
            if (tail == _array.Length)
            {
                tail = 0;
            }
            Length++;
        }
        public int Dequeue()
        {
            int element = _array[head];
            head++;
            head = head % _array.Length;
            Length--;
            return element;
        }
        private void Resize()
        {
            var tempArray = _array;
            _array = new int[_array.Length * 2];
            Array.Copy(tempArray, _array, tempArray.Length);
        }
    }
}

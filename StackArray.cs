using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScience
{
    public class StackArray
    {
        private int[] _array;
        private int _index;

        public StackArray(int size)
        {
            _array = new int[size];
            _index = -1;
        }
        public void Push(int value)
        {
            if (_index == _array.Length - 1)
            {
                Resize();
            }
            _array[++_index] = value;
        }
        private void Resize()
        {
            var tempArray = _array;
            _array = new int[_array.Length * 2];
            Array.Copy(tempArray, _array, tempArray.Length);
        }
        public int Pop()
        {
            if (_index == -1) throw new IndexOutOfRangeException();
            var element = _array[_index];
            _array[_index] = 0;
            _index--;
            return element;
        }
    }
}

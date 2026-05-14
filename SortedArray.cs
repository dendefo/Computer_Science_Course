using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScience
{
    public class SortedArray
    {
        private int[] array;
        private int CurrentLength;

        public SortedArray(int size)
        {
            array = new int[size];
            CurrentLength = 0;
        }

        /// <summary>
        /// O(n+log(n))
        /// </summary>
        /// <param name="element"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void Insert(int element)
        {
            if (CurrentLength >= array.Length)
            {
                throw new IndexOutOfRangeException();
            }
            var index = IndexOfInsertion(element);

            for (int i = CurrentLength; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = element;
            CurrentLength++;
        }

        private int IndexOfInsertion(int element)
        {
            if (CurrentLength == 0) return 0;
            int low = 0; int high = CurrentLength - 1;
            int mid = low + high;
            while (low <= high)
            {
                mid = low + (high - low) / 2;
                if (array[mid] == element) return mid;
                if (array[mid] < element) low = mid + 1;
                else high = mid - 1;
            }
            if (array[mid] > element) return mid;
            else return mid + 1;
        }


        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            for (int i = index; i < CurrentLength; i++)
            {
                array[i] = array[i + 1];
            }
            CurrentLength--;
        }
        public int IndexOf(int element)
        {
            int low = 0; int high = CurrentLength - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (array[mid] == element) return mid;
                if (array[mid] < element) low = mid + 1;
                else high = mid - 1;
            }
            return -1;

        }
    }
}

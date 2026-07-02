using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScience
{
    internal class HashMap<TKey, TValue>
    {
        private const float CAPACITY_THRESHOLD = 0.75f;
        private Node<TKey, TValue>[] _array;
        public int Count;
        public HashMap(int size = 4)
        {
            _array = new Node<TKey, TValue>[size];
        }

        public TValue this[TKey key]
        {
            get
            {
                int hash = Math.Abs(key.GetHashCode());
                int index = hash % _array.Length;
                var bucket = _array[index];
                while (bucket != null)
                {
                    if (bucket.Key.Equals(key)) return bucket.Value;
                    bucket = bucket.Next;
                }
                return default;
            }
            set
            {
                int hash = Math.Abs(key.GetHashCode());
                int index = hash % _array.Length;
                var bucket = _array[index];
                if (bucket == null)
                {
                    _array[index] = new Node<TKey, TValue>(key, value);
                    Count++;
                }
                else
                {
                    if (bucket.Key.Equals(key))
                    {
                        bucket.Value = value;
                        return;
                    }
                    while (bucket.Next != null)
                    {
                        bucket = bucket.Next;
                        if (bucket.Key.Equals(key))
                        {
                            bucket.Value = value;
                            return;
                        }
                    }
                    bucket.Next = new Node<TKey, TValue>(key, value);
                    Count++;
                }
                if (_array.Length * CAPACITY_THRESHOLD < Count) Resize();
            }
        }

        public bool Remove(TKey key)
        {
            int hash = Math.Abs(key.GetHashCode());
            int index = hash % _array.Length;
            var bucket = _array[index];
            if (bucket == null) return false;
            if (bucket.Key.Equals(key))
            {
                _array[index] = bucket.Next;
                Count--;
                return true;
            }
            while (bucket.Next!= null)
            {
                if (bucket.Next.Key.Equals(key))
                {
                    bucket.Next = bucket.Next.Next;
                    Count--;
                    return true;
                }
                bucket = bucket.Next;
            }
            return false;
        }

        private void Resize()
        {
            Node<TKey, TValue>[] _newArray = new Node<TKey, TValue>[_array.Length * 2];
            for (int i = 0; i < _array.Length; i++)
            {
                var bucket = _array[i];
                while (bucket != null)
                {
                    int hash = Math.Abs(bucket.Key.GetHashCode());
                    var value = bucket.Value;
                    int index = hash % _newArray.Length;
                    var newArrayBucket = _newArray[index];
                    if (newArrayBucket == null)
                    {
                        _newArray[index] = new Node<TKey, TValue>(bucket.Key, value);
                    }
                    else
                    {
                        while (newArrayBucket.Next != null)
                        {
                            newArrayBucket = newArrayBucket.Next;
                        }
                        newArrayBucket.Next = new Node<TKey, TValue>(bucket.Key, value);
                    }
                    bucket = bucket.Next;
                }
            }
            _array = _newArray;
        }

        private class Node<TKey, TValue>
        {
            public TKey Key;
            public TValue Value;
            public Node<TKey, TValue> Next;
            public Node(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }
    }
}

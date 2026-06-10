using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScience
{
    internal class BinarySearchTree<T> where T : IComparable<T>
    {
        private BinarySearchTreeNode<T> _root;

        public BinarySearchTree()
        {
            _root = null;
        }
        public void Add(T value)
        {
            var node = new BinarySearchTreeNode<T>(value);
            var currentRoot = _root;
            if (_root == null)
            {
                _root = node;
                return;
            }
            while (HasSpaceInLeftAndLess(currentRoot, value) || HasSpaceInRightAndGreater(currentRoot, value))
            {
                if (HasSpaceInLeftAndLess(currentRoot, value)) currentRoot = currentRoot.Left;
                else currentRoot = currentRoot.Right;
            }
            //value is less than current root and currentRoot.Left is null
            if (currentRoot.Value.CompareTo(value) > 0)
            {
                currentRoot.Left = node;
            }
            else
            {
                currentRoot.Right = node;
            }
        }
        public void Balance()
        {
            BalanceNode(_root);
        }
        private void BalanceNode(BinarySearchTreeNode<T> node)
        {
            var weights = GetWeight(node);
            if (Math.Abs(weights.Item1 - weights.Item2) > 1)
            {

            }

        }
        private Tuple<int, int> GetWeight(BinarySearchTreeNode<T> node)
        {
            if (node.Left == null && node.Right == null) return Tuple.Create(0, 0);
            if (node.Left == null)
            {
                var rightWeight = GetWeight(node.Right);
                int weight = rightWeight.Item1 + rightWeight.Item2 + 1;
                return Tuple.Create(0, weight);
            }
            if (node.Right == null)
            {
                var leftWeight = GetWeight(node.Left);
                int weight = leftWeight.Item1 + leftWeight.Item2 + 1;
                return Tuple.Create(weight, 0);
            }
            var left = GetWeight(node.Left);
            var right = GetWeight(node.Right);
            return Tuple.Create(left.Item1 + left.Item2 + 1, right.Item1 + right.Item2 + 1);
        }
        private bool HasSpaceInLeftAndLess(BinarySearchTreeNode<T> _root, T value)
        {
            return _root.Left != null && _root.Value.CompareTo(value) > 0;
        }
        private bool HasSpaceInRightAndGreater(BinarySearchTreeNode<T> _root, T value)
        {
            return _root.Right != null && _root.Value.CompareTo(value) < 0;
        }


        public class BinarySearchTreeNode<T> where T : IComparable<T>
        {
            public BinarySearchTreeNode<T> Left;
            public BinarySearchTreeNode<T> Right;
            public T Value;
            public BinarySearchTreeNode(T value, BinarySearchTreeNode<T> left = null, BinarySearchTreeNode<T> right = null)
            {
                Value = value;
                Left = left;
                Right = right;
            }
        }
    }
}

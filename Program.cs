namespace ComputerScience
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinarySearchTree<int>();
            tree.Add(5);
            tree.Add(6);
            tree.Add(7);
            tree.Add(1);
            tree.Add(2);
            tree.Add(3);

        }

        static int Fibonacci(int n)
        {
            if (n == 1 || n == 2) return 1;
            if (n == 3) return 2;
            int less1 = 1;
            int less2 = 1;
            int current = 0;
            for (int i = 0; i < n - 2; i++)
            {
                current = less1 + less2;
                less1 = less2;
                less2 = current;
            }
            return current;
        }

        static int[] MergeSort(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1) return nums;
            if (nums.Length == 2)
            {
                if (nums[0] <= nums[1]) return nums;
                return new int[] { nums[1], nums[0] };
            }
            var leftHalf = MergeSort(nums[..(nums.Length / 2)]);
            var rightHalf = MergeSort(nums[(nums.Length / 2)..]);
            int indexInLeft = 0;
            int indexInRight = 0;
            int[] result = new int[nums.Length];
            for (int i = 0; i < result.Length; i++)
            {
                if (indexInLeft >= leftHalf.Length)
                {
                    result[i] = rightHalf[indexInRight];
                    indexInRight++;
                    continue;
                }
                else if (indexInRight >= rightHalf.Length)
                {
                    result[i] = leftHalf[indexInLeft];
                    indexInLeft++;
                    continue;
                }
                if (leftHalf[indexInLeft] >= rightHalf[indexInRight])
                {
                    result[i] = rightHalf[indexInRight];
                    indexInRight++;
                }
                else
                {
                    result[i] = leftHalf[indexInLeft];
                    indexInLeft++;
                }
            }
            return result;
        }
    }
}

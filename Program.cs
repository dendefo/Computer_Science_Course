namespace ComputerScience
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();
            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddFirst(4);
            linkedList.RemoveFirst();
            linkedList.RemoveAt(0);
            linkedList.RemoveAt(1);
            linkedList.AddFirst(5);
            linkedList.AddFirst(5);
            linkedList.AddFirst(5);
            linkedList.AddFirst(5);
            linkedList.AddFirst(5);
            linkedList.RemoveFirst();
            linkedList.RemoveAt(0);
            linkedList.RemoveLast();
            for (int i = 0; i < linkedList.Count; i++)
            {
                Console.WriteLine(linkedList.ElementAt(i).Value);
            }
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
    }
}

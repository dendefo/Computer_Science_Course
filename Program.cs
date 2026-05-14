namespace ComputerScience
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QueueNodes queue = new QueueNodes();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
        }

        static int Fibonacci(int n)
        {
            if (n == 1 || n == 2) return 1;
            if (n == 3) return 2;
            int less1 = 1;
            int less2 = 1;
            int current = 0;
            for (int i = 0; i < n-2; i++)
            {
                current = less1 + less2;
                less1 = less2;
                less2 = current;
            }
            return current;
        }
    }
}

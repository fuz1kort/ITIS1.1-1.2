using System.Diagnostics;

namespace ThreadApp
{
    class Program
    {
        static void Main()
        {
            var r = new Random();
            Console.WriteLine("Введите размер матрицы");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] matrix = new int[n,n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i,j] = r.Next(-100, 100);
                }
            }

            Console.WriteLine("Введите количество потоков");
            var k = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < k; i++)
            {
                Thread thread = new(Work);
                thread.Start();
            }

            void Work() => Console.WriteLine($"Hello {Thread.CurrentThread.ManagedThreadId}");

            object locker = new();
            var maxmatrix = int.MinValue;
            var minmatrix = int.MaxValue;
            var t1 = Stopwatch.StartNew();

            string MinMax(int [] row)
            {
                var min = int.MaxValue;
                var max = int.MinValue;
                for (int i = 0; i < n; i++)
                {
                    max = row[i] > max ? row[i] : max;
                    min = row[i] < min ? row[i] : min;
                }
                return $"{max} {min}";
            }



            //Parallel.For(0, n, i =>
            //{
            //    int min1 = int.MaxValue;
            //    int max1 = int.MinValue;
            //    for (int j = 0; j < n; j++)
            //    {
            //        if (matrix[i, j] > max1)
            //            max1 = matrix[i, j];
            //        if (matrix[i, j] < min1)
            //            min1 = matrix[i, j];
            //    }

            t1.Stop();
            Console.WriteLine($"Max = {maxmatrix}; " +
                              $"Min = {minmatrix}." +
                              $"Time = {t1.Elapsed}");


        }
    }
}
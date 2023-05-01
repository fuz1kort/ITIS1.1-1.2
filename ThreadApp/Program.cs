using System.Diagnostics;

namespace ThreadApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите размер матрицы");
            var m = new Matrix(Convert.ToInt32(Console.ReadLine()));

            var t1 = DateTime.Now;
            Console.WriteLine(m.PoslMins().Max());
            var t2 = DateTime.Now;
            Console.WriteLine($"последовательно - {t2 - t1}");



            var t11 = DateTime.Now;
            Console.WriteLine(m.ParallelMins().Max());
            var t12 = DateTime.Now;
            Console.WriteLine($"потоков {m.size}; время - {t12 - t11}");
        }
    }
}
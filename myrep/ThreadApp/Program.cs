using System.Diagnostics;

namespace ThreadApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите размер матрицы");
            var m = new Matrix(Convert.ToInt32(Console.ReadLine()));

            var t1 = Stopwatch.StartNew();
            var x = m.PoslMins().Max();
;            t1.Stop();
            Console.WriteLine($"{x}\nпоследовательно - {t1.Elapsed}");



            var t11 = Stopwatch.StartNew();
            var x2 = m.ParallelMins().Max();
            t11.Stop();
            Console.WriteLine($"{x2}\nпараллельно - {t11.Elapsed}");
        }
    }
}
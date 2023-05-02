using System.Diagnostics;

namespace ThreadApp
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите размер матрицы");
            var m = new Matrix(Convert.ToInt32(Console.ReadLine()));

            var timep = Stopwatch.StartNew();
            var maxp = m.PoslMaxOfMins();
            timep.Stop();
            Console.WriteLine($"{maxp}\nпараллельно - {timep.Elapsed}");

            var time = Stopwatch.StartNew();
            var max = m.ParallelMaxofMins();
            time.Stop();
            Console.WriteLine($"{max}\nпараллельно - {time.Elapsed}");
        }
    }
}
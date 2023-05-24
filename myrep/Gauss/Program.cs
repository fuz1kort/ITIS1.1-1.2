using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;

namespace Gauss
{
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Введите размер матрицы");
            var size = Convert.ToInt32(Console.ReadLine());

            var mymatrix = GetMatrix(size);

            var myvector = GetVector(size);


            //PrintMatr(mymatrix);
            //foreach(var v in myvector)
            //{
            //    Console.WriteLine(v);
            //}

            for(int i = 1; i<=16; i *= 2)
            {
                Console.WriteLine($"Кол-во потоков - {i}");
                Console.WriteLine("----------------");
                var count = i;
                //Console.WriteLine("Введите количество потоков");
                //var count = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine("----------------");


                var t1 = Stopwatch.StartNew();
                var res = GaussParallelFor.SolveGaussParallelFor(mymatrix, myvector, count);
                t1.Stop();
                Console.WriteLine($"Парал Время - {t1.Elapsed}");

                //PrintMatr(mymatrix);
                Console.WriteLine("----------------");


                var t2 = Stopwatch.StartNew();
                var res2 = GaussThreads.SolveGaussThread(mymatrix, myvector, count);
                t2.Stop();
                Console.WriteLine($"Треды Время - {t2.Elapsed}");

                //PrintMatr(mymatrix);
                Console.WriteLine("----------------");

                var t3 = Stopwatch.StartNew();
                var res3 = GaussTask.SolveGaussTask(mymatrix, myvector, count);
                t3.Stop();
                Console.WriteLine($"Таски Время - {t3.Elapsed}");

                //PrintMatr(mymatrix);
                Console.WriteLine("----------------");
            }








            void PrintMatr(double[][] matr)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                        sb.Append($" {matr[i][j].ToString("N2")}");
                    sb.AppendLine();
                }

                Console.WriteLine(sb.ToString());
            }

            double[][] GetMatrix(int size)
            {
                var r = new Random();
                double[][] matrix = new double[size][];
                for(int i = 0; i < size; i++)
                {
                    matrix[i] = new double[size];
                    for (int j = 0; j < size; j++)
                        matrix[i][j] = Convert.ToDouble(r.Next(100));
                }   

                return matrix;
            }

            double[] GetVector(int size)
            {
                var r = new Random();
                double[] vector = new double[size];
                for (int i = 0; i < size; i++)
                    vector[i] = Convert.ToDouble(r.Next(100));
                return vector;
            }
        }
    }
}
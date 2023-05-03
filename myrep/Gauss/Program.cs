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


            PrintMatr(mymatrix);
            PrintVector(myvector);
            Console.WriteLine("----------------");

            Console.WriteLine("Введите количество потоков");
            var count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("----------------");
            
            GaussParallelFor.SolveGaussParallelFor(mymatrix, myvector, count);

            PrintMatr(mymatrix);
            PrintVector(myvector);
            Console.WriteLine("----------------");

            GaussTask.SolveGaussTask(mymatrix, myvector, count);

            PrintMatr(mymatrix);
            PrintVector(myvector);
            Console.WriteLine("----------------");

            GaussThreads.SolveGaussThread(mymatrix, myvector, count);

            PrintMatr(mymatrix);
            PrintVector(myvector);
            Console.WriteLine("----------------");








            void PrintMatr(int[][] matr)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                        sb.Append($" {matr[i][j]}");
                    sb.AppendLine();
                }

                Console.WriteLine(sb.ToString());
            }

            void PrintVector(int[] vector)
            {
                var sb = new StringBuilder();
                for (int i = 0; i < size; i++)
                    sb.Append($" {vector[i]}");

                Console.WriteLine(sb.ToString());
            }

            int[][] GetMatrix(int size)
            {
                var r = new Random();
                int[][] matrix = new int[size][];
                for(int i = 0; i < size; i++)
                {
                    matrix[i] = new int[size];
                    for (int j = 0; j < size; j++)
                        matrix[i][j] = r.Next(100);
                }   

                return matrix;
            }

            int[] GetVector(int size)
            {
                var r = new Random();
                int[] vector = new int[size];
                for (int i = 0; i < size; i++)
                    vector[i] = r.Next(100);
                return vector;
            }
        }
    }
}
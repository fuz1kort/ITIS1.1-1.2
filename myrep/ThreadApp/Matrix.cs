using System.Text;

namespace ThreadApp
{
    public class Matrix
    {

        int[,] matrix;
        public int size;


        public Matrix(int n)
        {
            size = n;
            matrix = new int[size, size];
            Random r = new Random();

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    matrix[i, j] = r.Next(-10000, 10000);
        }


        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    sb.Append($" {matrix[i, j]}");
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public int[] PoslMins()
        {
            int[] res = new int[size];
            Array.Fill(res, int.MaxValue);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    res[i] = matrix[i, j] < res[i] ? matrix[i, j] : res[i];

            return res;

        }



        public int[] ParallelMins()
        {
            object locker = new object();
            int[] res = new int[size];

            Parallel.For(0, size, i =>
            {
                int min = ParMinRow(i);

                lock (locker)
                {
                    res[i] = min;   
                }

            });

            return res;

        }


        public int ParMinRow(int row)
        {
        int pmin = int.MaxValue;
            for (int j = 0; j < size; j++)
                pmin = matrix[row,j] < pmin ? matrix[row,j] : pmin;
            return (pmin);
        }




    }
}

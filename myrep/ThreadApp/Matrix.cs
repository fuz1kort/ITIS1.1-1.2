using System.Text;

namespace ThreadApp
{
    public class Matrix
    {

        private readonly int[,] matrix;
        private readonly int size;

        public Matrix(int n)
        {
            size = n;
            matrix = new int[size, size];
            Random r = new Random();

            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    matrix[i, j] = r.Next(-10000, 10000);
        }

        public int ParallelMaxofMins()
        {
            int[] res = new int[size];
            object locker = new();
            Parallel.For(0, size, i =>
            {
                int pmin = int.MaxValue;
                for (int j = 0; j < size; j++)
                    pmin = matrix[i, j] < pmin ? matrix[i, j] : pmin;

                lock (locker)
                {
                    res[i] = pmin;
                }
            });
            
            return res.Max();
        }

        public int PoslMaxOfMins()
        {
            int[] res = new int[size];
            Array.Fill(res, int.MaxValue);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    res[i] = matrix[i, j] < res[i] ? matrix[i, j] : res[i];

            return res.Max();

        }

    }
}

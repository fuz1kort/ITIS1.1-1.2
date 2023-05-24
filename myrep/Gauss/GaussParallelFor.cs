namespace Gauss
{
    public static class GaussParallelFor
    {
        public static double[] SolveGaussParallelFor(double[][] matrix, double[] vector, int threadCount)
        {
            int rowCount = matrix.Length;
            int columnCount = matrix[0].Length;
            double[] res = new double[rowCount];

            Parallel.For(0, rowCount - 1, new ParallelOptions { MaxDegreeOfParallelism = threadCount }, k =>
            {
                double max = Math.Abs(matrix[k][k]);
                int maxIndex = k;
                for (int i = k + 1; i < rowCount; i++) 
                {
                    if (Math.Abs(matrix[i][k]) > max) 
                    {
                        max = Math.Abs(matrix[i][k]); 
                        maxIndex = i; 
                    }
                }

                if (maxIndex != k) 
                {
                    for (int j = k; j < columnCount; j++) 
                    {
                        double temp = matrix[k][j]; 
                        matrix[k][j] = matrix[maxIndex][j];
                        matrix[maxIndex][j] = temp;
                    }

                    double temp2 = vector[k]; 
                    vector[k] = vector[maxIndex];
                    vector[maxIndex] = temp2;
                }


                for (int i = k + 1; i < rowCount; i++)
                {
                    double factor = matrix[i][k] / matrix[k][k]; 
                    for (int j = k; j < columnCount; j++) 
                    {
                        matrix[i][j] -= matrix[k][j] * factor; 
                    }

                    vector[i] -= vector[k] * factor; 
                }
            });


            for (int i = rowCount - 1; i >= 0; i--) 
            {
                double sum = 0; 
                for (int j = i + 1; j < rowCount; j++) 
                {
                    sum += matrix[i][j] * res[j]; 
                }
                res[i] = (vector[i] - sum) / matrix[i][i]; 
            }

            return res;
        }
    }
}

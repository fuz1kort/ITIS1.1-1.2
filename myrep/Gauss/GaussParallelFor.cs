namespace Gauss
{
    public static class GaussParallelFor
    {
        public static void SolveGaussParallelFor(int[][] matrix, int[] vector, int threadCount)
        {
            int rowCount = matrix.Length;
            int columnCount = matrix[0].Length;

            Parallel.For(0, rowCount, new ParallelOptions { MaxDegreeOfParallelism = threadCount }, j =>
            {

                int[] row = matrix[j];
                int factor = row[j];
                row[j] = 1;
                for (int k = j + 1; k < columnCount; k++)
                {
                    row[k] /= factor;
                }

                vector[j] /= factor;


                for (int k = j + 1; k < rowCount; k++)
                {
                    int[] nextRow = matrix[k];
                    int nextFactor = nextRow[j];
                    nextRow[j] = 0;
                    for (int l = j + 1; l < columnCount; l++)
                    {
                        nextRow[l] -= row[l] * nextFactor;
                    }
                    vector[k] -= vector[j] * nextFactor;
                }
            });


            for (int i = rowCount - 1; i >= 0; i--)
            {
                int[] row = matrix[i];
                int value = vector[i];
                for (int j = i + 1; j < rowCount; j++)
                {
                    value -= row[j] * vector[j];
                }

                vector[i] = value / row[i];
            }
        }
    }
}

namespace Gauss
{
    public static class GaussTask
    {
        public static double[] SolveGaussTask(double[][] matrix, double[] vector, int taskCount)
        {
            int rowCount = matrix.Length;
            int columnCount = matrix[0].Length;
            double[] res = new double[rowCount];
            Task[] tasks = new Task[taskCount];

            for (int i = 0; i < taskCount; i++)
            {
                int startRow = i * rowCount / taskCount;
                int endRow = (i + 1) * rowCount / taskCount;
                tasks[i] = Task.Run(() =>
                {
                    for (int k = startRow; k < endRow; k++)
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
                }
                });
            }

            Task.WaitAll(tasks);


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

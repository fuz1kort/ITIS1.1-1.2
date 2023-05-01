namespace Gauss
{
    public class GaussTask
    {
        public static void SolveGaussTask(double[][] matrix, double[] vector, int taskCount)
        {
            int rowCount = matrix.Length;
            int columnCount = matrix[0].Length;
            Task[] tasks = new Task[taskCount];

            for (int i = 0; i < taskCount; i++)
            {
                int startRow = i * rowCount / taskCount;
                int endRow = (i + 1) * rowCount / taskCount;
                tasks[i] = Task.Run(() =>
                {
                    for (int j = startRow; j < endRow; j++)
                    {

                        double[] row = matrix[j];
                        double factor = row[j];
                        row[j] = 1;
                        for (int k = j + 1; k < columnCount; k++)
                        {
                            row[k] /= factor;
                        }
                        vector[j] /= factor;

                        for (int k = j + 1; k < rowCount; k++)
                        {
                            double[] nextRow = matrix[k];
                            double nextFactor = nextRow[j];
                            nextRow[j] = 0;
                            for (int l = j + 1; l < columnCount; l++)
                            {
                                nextRow[l] -= row[l] * nextFactor;
                            }
                            vector[k] -= vector[j] * nextFactor;
                        }
                    }
                });
            }

            Task.WaitAll(tasks);


            for (int i = rowCount - 1; i >= 0; i--)
            {
                double[] row = matrix[i];
                double value = vector[i];
                for (int j = i + 1; j < rowCount; j++)
                {
                    value -= row[j] * vector[j];
                }
                vector[i] = value / row[i];
            }
        }
    }
}

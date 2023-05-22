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
                        for (int i = k + 1; i < rowCount; i++) // Для каждой строки ниже текущей
                        {
                            if (Math.Abs(matrix[i][k]) > max) // Если модуль элемента в текущем столбце больше максимального
                            {
                                max = Math.Abs(matrix[i][k]); // Обновляем максимальный элемент
                                maxIndex = i; // Обновляем его индекс
                            }
                        }

                        if (maxIndex != k) // Если главный элемент не находится на главной диагонали
                        {
                            for (int j = k; j < columnCount; j++) // Для каждого элемента в строке
                            {
                                double temp = matrix[k][j]; // Меняем местами элементы в текущей строке и строке с главным элементом
                                matrix[k][j] = matrix[maxIndex][j];
                                matrix[maxIndex][j] = temp;
                            }

                            double temp2 = vector[k]; // Меняем местами элементы в векторе свободных членов
                            vector[k] = vector[maxIndex];
                            vector[maxIndex] = temp2;
                        }

                        for (int i = k + 1; i < rowCount; i++)
                        {
                            double factor = matrix[i][k] / matrix[k][k]; // Вычисляем коэффициент для вычитания строк
                            for (int j = k; j < columnCount; j++) // Для каждого элемента в строке
                            {
                                matrix[i][j] -= matrix[k][j] * factor; // Вычитаем из элемента в текущей строке элемент в верхней строке, умноженный на коэффициент
                            }

                            vector[i] -= vector[k] * factor;
                        }
                }
                });
            }

            Task.WaitAll(tasks);


            for (int i = rowCount - 1; i >= 0; i--) // Для каждой строки матрицы, начиная с последней
            {
                double sum = 0; // Сумма произведений элементов матрицы и вектора решения
                for (int j = i + 1; j < rowCount; j++) // Для каждого элемента правее главной диагонали
                {
                    sum += matrix[i][j] * res[j]; // Добавляем к сумме произведение элемента матрицы и соответствующего элемента вектора решения
                }
                res[i] = (vector[i] - sum) / matrix[i][i]; // Вычисляем значение неизвестной по формуле: x_i = (b_i - sum) / a_ii
            }

            return res;
        }
    }
}

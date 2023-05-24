﻿namespace Gauss
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
            });


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
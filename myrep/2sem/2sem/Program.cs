using System.Diagnostics;

namespace Evolution
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Rows\nCols\nSteps\nThreads");
            var rows = Convert.ToInt32(Console.ReadLine());
            var cols = Convert.ToInt32(Console.ReadLine());
            var steps = Convert.ToInt32(Console.ReadLine());
            var n = Convert.ToInt32(Console.ReadLine());
            Random random = new();
            int[,] field = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = random.Next(2);
                }
            }

            Console.WriteLine("Начальное поле:");
            //PrintField(field);
            for (int k = 0; k < steps; k++)
            {
                Stopwatch t1 = new();
                t1.Start();
                UpdateField(field, n);
                t1.Stop();
                Console.WriteLine(t1.Elapsed);
                Console.WriteLine($"Поле после {k + 1} шага:");
                //PrintField(field);
            }

            static void PrintField(int[,] field)
            {
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        Console.Write(field[i, j] == 1 ? "O" : ".");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            static int CountNeighbors(int[,] field, int x, int y)
            {
                int count = 0;
                for (int i = x - 1; i <= x + 1; i++)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        if (i == x && j == y) continue; 
                        if (i < 0 || i >= field.GetLength(0) || j < 0 || j >= field.GetLength(1)) continue; 
                        if (field[i, j] == 1) count++; 
                    }
                }

                return count;
            }

            static void UpdateField(int[,] field, int n)
            {
                int[,] newField = new int[field.GetLength(0), field.GetLength(1)];
                Array.Copy(field, newField, field.GetLength(0) * field.GetLength(1));
                List<Thread> threads = new();

                int rowsPerThread = field.GetLength(0) / n;
                for (int i = 0; i < n; i++)
                {
                    int threadIndex = i;
                    int[,] subField = new int[rowsPerThread, field.GetLength(1)];
                    Array.Copy(field, threadIndex * rowsPerThread * field.GetLength(1), subField, 0, rowsPerThread * field.GetLength(1));

                    Thread thread = new(() =>
                    {
                        for (int j = 0; j < subField.GetLength(0); j++)
                        {
                            for (int k = 0; k < subField.GetLength(1); k++)
                            {
                                int neighbors = CountNeighbors(field, threadIndex * rowsPerThread + j, k);
                                if (subField[j, k] == 1) 
                                {
                                    if (neighbors < 2 || neighbors > 3)                                    
                                    {
                                        subField[j, k] = 0;
                                    }
                                }

                                else 
                                {
                                    if (neighbors == 3)
                                    {
                                        subField[j, k] = 1;
                                    }
                                }
                            }
                        }

                        Array.Copy(subField, 0, newField, threadIndex * rowsPerThread * field.GetLength(1), rowsPerThread * field.GetLength(1));
                    });

                    threads.Add(thread);
                    thread.Start();
                }

                foreach (Thread thread in threads)
                {
                    thread.Join();
                }

                Array.Copy(newField, field, field.GetLength(0) * field.GetLength(1));
            }
        }
    }
}

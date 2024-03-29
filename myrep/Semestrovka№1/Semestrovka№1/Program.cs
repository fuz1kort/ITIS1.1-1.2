﻿using System.Diagnostics;
using System.Text;

namespace Semestr1
{
    class Program
    {
        public static void Main()
        {
            //Запись файлов
            //FileInfo file;
            //int pcount = 0;
            //var r = new Random();
            //for (int i = 0; i < 100; i++)
            //{
            //    pcount += 100;
            //    file = new FileInfo($@"C:\MySet\Set{i + 1}.txt");
            //    var stringpoint = new StringBuilder();
            //    for (int j = 0; j < pcount; j++)
            //    {
            //        stringpoint.AppendLine($"{r.Next(-100, 100)}, {r.Next(-100, 100)}");
            //    }

            //    using (var sw = file.AppendText())
            //    {
            //        sw.WriteLine(stringpoint.ToString().Trim());
            //    }
            //}

            //Чтение файлов
            string[] Points;
            List<string[]> listofsets = new List<string[]>();

            for (int i = 0; i < 100; i++)
            {
                Points = File.ReadAllLines($@"C:\MySet\Set{i + 1}.txt");
                listofsets.Add(Points);
                var set1 = listofsets[i];
                List<Point> points = new();
                foreach (var p in set1)
                {
                    if (p != "")
                    {
                        points.Add(new Point(Convert.ToInt32((p.Split(",")[0])), Convert.ToInt32((p.Split(",")[1]))));
                    }
                    else break;
                }

                var grahamlist = GrahamScan.ConvexHull(points);
                foreach (var item in grahamlist)
                    Console.WriteLine($"({item.X},{item.Y})");
                Console.WriteLine("-------------");
            }

            //var set1 = listofsets[0];
            //List<Point> points = new();
            //foreach (var p in set1)
            //{
            //    if (p != "")
            //    {
            //        points.Add(new Point(Convert.ToInt32((p.Split(",")[0])), Convert.ToInt32((p.Split(",")[1]))));
            //    }
            //    else break;
            //}


            //foreach (var point in points)
            //{

            //    Console.WriteLine($"Количество итераций - {GrahamScan.iteration}");
            //}
            //var time = new Stopwatch();
            //time.Start();
            //var grahamlist = GrahamScan.ConvexHull(points);
            //time.Stop();
            //foreach (var item in grahamlist)
            //    Console.WriteLine($"({item.X},{item.Y})");
            //Console.WriteLine($"Время - {time.Elapsed}");
            //Console.WriteLine($"Количество итераций - {GrahamScan.iteration}");
        }
    }
}
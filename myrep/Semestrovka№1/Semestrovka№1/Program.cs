using System.Diagnostics;
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
            //        sw.WriteLine(stringpoint.ToString());
            //    }
            //}


            string[] Points;
            List<string[]> listofsets = new List<string[]>();
            for (int i = 0; i < 100; i++)
            {
                Points = File.ReadAllLines($@"C:\MySet\Set{i + 1}.txt");
                listofsets.Add(Points);
            }
            var set1 = listofsets[99];
            List<Point> points = new();
            foreach (var p in set1)
            {
                if (p != "")
                {
                    points.Add(new Point(Convert.ToInt32((p.Split(",")[0])), Convert.ToInt32((p.Split(",")[1]))));
                }
                else break;
            }

            //List<Point> points = new List<Point>
            //{
            //    new Point(0, 3),
            //    new Point(2, 2),
            //    new Point(-1, 1),
            //    new Point(2, 1),
            //    new Point(-300, 0),
            //    new Point(0, 0),
            //    new Point(3, -3)
            //};
            var time = new Stopwatch();
            time.Start();
            var list = GrahamScan.ConvexHull(points);
            time.Stop();
            foreach (var item in list)
                Console.WriteLine($"({item.X},{item.Y})");
            Console.WriteLine($"Время - {time.ElapsedMilliseconds}");
            Console.WriteLine($"Количество итераций - {GrahamScan.iteration}");
        }
    }
}
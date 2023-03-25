using System.Text;

namespace Semestr1
{
    class Program
    {
        public static void Main()
        {
            FileInfo file;
            var r = new Random();
            int pointcount = 0;
            for (int i = 0; i < 100; i++)
            {
                pointcount += 100;
                file = new FileInfo($@"C:\MySet\Set{i + 1}.txt");
                var stringpoint = new StringBuilder();
                for (int j = 0; j < pointcount; j++)
                {
                    stringpoint.AppendLine($"{r.Next(-1000, 1000)}, {r.Next(-1000, 1000)}");
                }
                
                using var sw = file.AppendText();
                {
                    sw.WriteLine(stringpoint.ToString());
                }
                
            }

            //var r = new Random();
            //string[] Points;
            //List<string[]> listofsets = new List<string[]>();
            //for (int i = 0; i < 100; i++)
            //{
            //    Points = File.ReadAllLines($@"C:\MySet\Set{i + 1}.txt");
            //    listofsets.Add(Points);
            //}
            //var set1 = listofsets[5];
            //List<Point> points = new();
            //foreach (var p in set1)
            //{
            //    if (p == "")
            //        break;
            //    points.Add(new Point(Convert.ToInt32((p.Split(",")[0])), Convert.ToInt32((p.Split(",")[1]))));
            //}

            //foreach (var poi in points)
            //{
            //    Console.WriteLine(poi);
            //}



            //List<Point> points = new List<Point>
            //{
            //    new Point(0, 3),
            //    new Point(2, 2),
            //    new Point(3, 0),
            //    new Point(2, 1),
            //    new Point(0, -1),
            //    new Point(0, 0),
            //    new Point(-1, 1),
            //    new Point(1, 1),
            //    new Point(1,0),
            //    new Point(-2, 0)
            //};

            //var list = GrahamScan.ConvexHull(points);
            //foreach (var item in list)
            //    Console.WriteLine($"({item.X},{item.Y})");
        }
    }
}
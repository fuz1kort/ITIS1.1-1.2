namespace Semestr1
{
    class Program
    {
        public static void Main()
        {
            List<Point> points = new()
            {
            new Point(0, 3),
            new Point(2, 2),
            new Point(1, 1),
            new Point(2, 1),
            new Point(3, 0),
            new Point(0, 0),
            new Point(3, 3)
        };

            var list = GrahamScan.ConvexHull(points);
            foreach (var item in list)
                Console.WriteLine($"({item.X},{item.Y})");
        }
    }
}
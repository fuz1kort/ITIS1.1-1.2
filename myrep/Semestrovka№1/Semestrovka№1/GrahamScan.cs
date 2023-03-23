namespace Semestr1
{
    public class GrahamScan
    {
        private static int Orientation(Point p1, Point p2, Point p3)
        {
            int val = (p2.Y - p1.Y) * (p3.X - p2.X) - (p2.X - p1.X) * (p3.Y - p2.Y);
            if (val == 0) return 0;
            return (val > 0) ? 1 : 2;
        }

        private static int Compare(Point p1, Point p2)
        {
            int o = Orientation(p0, p1, p2);
            if (o == 0)
                return (Distance(p0, p2) >= Distance(p0, p1)) ? -1 : 1;
            return (o == 2) ? -1 : 1;
        }

        private static double Distance(Point p1, Point p2) => Math.Sqrt(Math.Pow((p2.Y - p1.Y), 2) + Math.Pow((p2.X - p1.X), 2));

        private static Point p0;

        public static List<Point> ConvexHull(List<Point> points)
        {
            int n = points.Count;

            if (n < 3) return null;

            List<Point> hull = new();

            int ymin = points[0].Y;
            int min = 0;

            for (int i = 1; i < n; i++)
            {
                int y = points[i].Y;

                if ((y < ymin) || (ymin == y && points[i].X < points[min].X))
                {
                    ymin = points[i].Y;
                    min = i;
                }
            }

            Point temp = points[0];
            points[0] = points[min];
            points[min] = temp;

            p0 = points[0];
            points.Sort(new Comparison<Point>(Compare));

            hull.Add(points[0]);
            hull.Add(points[1]);
            hull.Add(points[2]);

            for (int i = 3; i < n; i++)
            {
                while (hull.Count > 1 && Orientation(hull[hull.Count - 2], hull[hull.Count - 1], points[i]) != 2)
                    hull.RemoveAt(hull.Count - 1);
                hull.Add(points[i]);
            }

            return hull;
        }
    }
}

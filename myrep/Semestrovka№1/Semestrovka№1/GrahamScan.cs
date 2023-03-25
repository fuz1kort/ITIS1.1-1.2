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

        private static double Distance(Point p1, Point p2) => Math.Sqrt(Math.Pow((p2.Y - p1.Y), 2) + Math.Pow((p2.X - p1.X), 2));

        private static Point p0;
        public static int iteration;

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

                iteration++;
            }

            Point temp = points[0];
            points[0] = points[min];
            points[min] = temp;

            p0 = points[0];
            points.Sort((p1, p2) =>
            {
                double angle1 = Math.Atan2(p1.Y - p0.Y, p1.X - p0.X);
                double angle2 = Math.Atan2(p2.Y - p0.Y, p2.X - p0.X);
                return angle1.CompareTo(angle2);
            });

            hull.Add(points[0]);
            hull.Add(points[1]);
            hull.Add(points[2]);

            for (int i = 3; i < n; i++)
            {
                while (hull.Count > 1 && Orientation(hull[hull.Count - 2], hull[hull.Count - 1], points[i]) != 2)
                    hull.RemoveAt(hull.Count - 1);
                hull.Add(points[i]);

                iteration++;
            }

            return hull;
        }
    }
}

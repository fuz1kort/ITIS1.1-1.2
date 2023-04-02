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

        private static Point? p0;
        public static int iteration;

        public static List<Point>? ConvexHull(List<Point> points)
        {
            int n = points.Count;

            if (n < 3) return null;


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

            Stack<Point> stack = new Stack<Point>();
            stack.Push(points[0]);
            stack.Push(points[1]);

            for (int i = 2; i < points.Count; i++)
            {
                Point top = stack.Pop();
                while (Orientation(stack.Peek(), top, points[i]) != 2 && stack.Count >= 2)
                {
                    top = stack.Pop();
                    iteration++;
                }

                stack.Push(top);
                stack.Push(points[i]);
                iteration++;
            }

            return new(stack.ToArray());
        }
    }
}

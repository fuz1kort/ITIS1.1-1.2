using System;
using System.Collections.Generic;

namespace Semestr1
{
    class Program
    {
        enum OrientationType
        {
            Collinear,
            LeftTurn,
            RightTurn
        }
        public static void Main()
        {
            List<Point> points = new List<Point>
        {
            new Point(0, 3),
            new Point(2, 2),
            new Point(1, 1),
            new Point(2, 1),
            new Point(3, 0),
            new Point(0, 0),
            new Point(3, 3)
        };

            List<Point> convexHull = GetConvexHull(points);

            // Выводим координаты точек выпуклой оболочки
            foreach (Point point in convexHull)
            {
                Console.WriteLine("({0}, {1})", point.X, point.Y);
            }
        }

        static List<Point> GetConvexHull(List<Point> points)
        {
            // Сортируем список точек по возрастанию координаты X
            points = points.OrderBy(p => p.X).ToList();

            // Создаем стек для хранения точек выпуклой оболочки
            Stack<Point> hull = new Stack<Point>();

            // Добавляем первые две точки в стек
            hull.Push(points[0]);
            hull.Push(points[1]);

            for (int i = 2; i < points.Count; i++)
            {
                Point top = hull.Pop();

                // Пока точки образуют правый поворот, удаляем точки из стека
                while (Orientation(hull.Peek(), top, points[i]) == OrientationType.RightTurn && hull.Count > 2) 
                {
                    top = hull.Pop();
                }

                hull.Push(top);
                hull.Push(points[i]);
            }

            return hull.ToList();
        }

        // Определяем тип поворота трех точек
        static OrientationType Orientation(Point p1, Point p2, Point p3)
        {
            int val = (p2.Y - p1.Y) * (p3.X - p2.X) - (p2.X - p1.X) * (p3.Y - p2.Y);

            if (val == 0) return OrientationType.Collinear;

            return (val > 0) ? OrientationType.LeftTurn : OrientationType.RightTurn;
        }
    }
}
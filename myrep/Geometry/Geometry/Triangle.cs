using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Triangle : IRotatable, IMovable
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public Point Point3 { get; set; }
        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            Point1.X = x1;
            Point1.Y = y1;
            Point2.X = x2;
            Point2.Y = y2;
            Point3.X = x3;
            Point3.Y = y3;
        }

        public void Move(double x, double y)
        {
            Point1.X += x;
            Point1.Y += y;
            Point2.X += x;
            Point2.Y += y;
            Point3.X += x;
            Point3.Y += y;
        }

        public void Rotate(double angle)
        {
            var xr1 = Rectangle.GetRotatedX(Point2.X, Point2.Y, angle);
            Point1.Y = Rectangle.GetRotatedY(Point1.X, Point1.Y, angle);
            Point1.X = xr1;
            var xr2 = Rectangle.GetRotatedX(Point2.X, Point2.Y, angle);
            Point2.Y = Rectangle.GetRotatedY(Point2.X, Point2.Y, angle);
            Point2.X = xr2;
            var xr3 = Rectangle.GetRotatedX(Point3.X, Point3.Y, angle);
            Point3.Y = Rectangle.GetRotatedY(Point3.X,Point3.Y, angle);
            Point3.X = xr3;
        }

        public override string ToString() => $"Координаты треугольника:\n({Point1.X},{Point1.Y})\n({Point2.X},{Point2.Y})\n({Point3.X},{Point3.Y})";
    }
}

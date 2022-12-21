using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Triangle : IRotatable, IMovable
    {
        public double x1;
        public double y1;
        public double x2;
        public double y2;
        public double x3;
        public double y3;
        double X1 { get => x1; set { x1 = Math.Round(value, 5); } }
        double Y1 { get => y1; set { y2 = Math.Round(value, 5); } }
        double X2 { get => x2; set { x2 = Math.Round(value, 5); } }
        double Y2 { get => y2; set { y2 = Math.Round(value, 5); } }
        double X3 { get => x3; set { x3 = Math.Round(value, 5); } }
        double Y3 { get => y3; set { y3 = Math.Round(value, 5); } }
        public Triangle(double xs1, double ys1, double xs2, double ys2, double xs3, double ys3)
        {
            X1 = xs1;
            Y1 = ys1;
            X2 = xs2;
            Y2 = ys2;
            X3 = xs3;
            Y3 = ys3;
        }

        public void Move(double x, double y)
        {
            X1 += x;
            Y1 += y;
            X2 += x;
            Y2 += y;
            X3 += x;
            Y3 += y;
        }

        public void Rotate(double angle)
        {
            var xr1 = Rectangle.GetRotatedX(X1, Y1, angle);
            Y1 = Rectangle.GetRotatedY(X1, Y1, angle);
            X1 = xr1;
            var xr2 = Rectangle.GetRotatedX(X2, Y2, angle);
            Y2 = Rectangle.GetRotatedY(X2, Y2, angle);
            X2 = xr2;
            var xr3 = Rectangle.GetRotatedX(X3, Y3, angle);
            Y3 = Rectangle.GetRotatedY(X3,Y3, angle);
            X3 = xr3;
        }

        public override string ToString() => $"Координаты треугольника:\n({X1},{Y1})\n({X2},{Y2})\n({X3},{Y3})";
    }
}

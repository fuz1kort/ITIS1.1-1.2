using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Rectangle : IRotatable, IMovable
    {
        public double x1;
        public double y1;
        public double x2;
        public double y2;
        double X1 { get => x1; set { x1 = Math.Round(value, 5); } }
        double Y1 { get => y1; set { y2 = Math.Round(value, 5); } }
        double X2 { get => x2; set { x2 = Math.Round(value, 5); } }
        double Y2 { get => y2; set { y2 = Math.Round(value, 5); } }
        public Rectangle(double xs1, double ys1, double xs2, double ys2)
        {
            X1 = xs1;
            Y1 = ys1;
            X2 = xs2;
            Y2 = ys2;
        }

        public static double GetRotatedX(double x, double y, double angle) => x * Math.Cos(angle) - y * Math.Sin(angle);
        public static double GetRotatedY(double x, double y, double angle) => x * Math.Sin(angle) + y * Math.Cos(angle);
        public void Move(double x, double y) 
        {
            X1 += x;
            Y1 += y;
            X2 += x;
            Y2 += y; 
        }

        public void Rotate(double angle) 
        {
            var xr1 = GetRotatedX(X1, Y1, angle);
            Y1 = GetRotatedY(X1, Y1, angle);
            X1 = xr1;
            var xr2 = GetRotatedX(X2, Y2, angle);
            Y2 = GetRotatedY(X2, Y2, angle);
            X2 = xr2;
        }
        
        public override string ToString() => $"Координаты прямоугольника:\n({X1},{Y1})\n({X1},{Y2})\n({X2},{Y2})\n({X2},{Y1})";
    }
}

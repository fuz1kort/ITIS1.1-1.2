using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Circle : IRotatable, IMovable
    {
        public double R { get; set; }
        public double x;
        public double y;
        double X { get => x; set { x = Math.Round(value, 5); } }
        double Y { get => y; set { y = Math.Round(value, 5); } }
        public Circle(double r, double xs, double ys) 
        {
            R = r;
            X = xs;
            Y = ys;
        }
        public void Move(double xm, double ym)
        {
            X += xm;
            Y += ym;
        }
        public void Rotate(double angle)
        {
            var xr = Rectangle.GetRotatedX(X, Y, angle);
            Y = Rectangle.GetRotatedY(X, Y, angle);
            X = xr;
        }

        public override string ToString()
        {
            if (X<0 && Y<0) return $"Координаты точек:\n(x + {-X})^2 + (y + {-Y})^2 = {R}";
            if (X>0 && Y<0) return $"Координаты точек:\n(x - {X})^2 + (y + {-Y})^2 = {R}";
            if (X<0 && Y>0) return $"Координаты точек:\n(x + {-X})^2 + (y - {Y})^2 = {R}";
            return $"Координаты точек:\n(x- {X})^2 + (y - {Y})^2 = {R}";
        }
    }
}

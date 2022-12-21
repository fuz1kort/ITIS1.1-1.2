using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Circle : IRotatable, IMovable
    {
        public double Radius { get; set; }
        public Point Center { get; set; }
        public Circle(double radius, double x, double y) 
        {
            Radius = radius;
            Center.X = x;
            Center.Y = y;
        }
        public void Move(double x, double y)
        {
            Center.X += x;
            Center.Y += y;
        }
        public void Rotate(double angle)
        {
            var xr = Rectangle.GetRotatedX(Center.X, Center.Y, angle);
            Center.Y = Rectangle.GetRotatedY(Center.X, Center.Y, angle);
            Center.X = xr;
        }

        public override string ToString()
        {
            if (Center.X < 0 && Center.Y < 0) return $"Координаты точек:\n(x + {-Center.X})^2 + (y + {-Center.Y})^2 = {Radius}";
            if (Center.X >0 && Center.Y <0) return $"Координаты точек:\n(x - {Center.X})^2 + (y + {-Center.Y})^2 = {Radius}";
            if (Center.X <0 && Center.Y >0) return $"Координаты точек:\n(x + {-Center.X})^2 + (y - {Center.Y})^2 = {Radius}";
            return $"Координаты точек:\n(x- {Center.X})^2 + (y - {Center.Y})^2 = {Radius}";
        }
    }
}

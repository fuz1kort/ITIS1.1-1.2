using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Point : IRotatable, IMovable
    {
        private double x;
        private double y;
        public double X { get => x; set { x = Math.Round(value, 5); } }
        public double Y { get => y; set { y = Math.Round(value, 5); } }
        public Point(double xs, double ys)
        { 
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
            var xr = Rectangle.GetRotatedX(X,Y,angle);
            Y = Rectangle.GetRotatedY(X,Y,angle);
            X = xr;
        }

        public override string ToString() => $"Координаты точки:\n({X},{Y})";
    }
}

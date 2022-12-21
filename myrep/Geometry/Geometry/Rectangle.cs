using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Rectangle : IRotatable, IMovable
    {
        public Point BottomLeft { get; set; }
        public Point TopRight { get; set; }
        public Rectangle(double x1, double y1, double x2, double y2)
        {
            BottomLeft.X = x1;
            BottomLeft.Y = y1;
            TopRight.X = x2;
            TopRight.Y = y2;
        }

        public static double GetRotatedX(double x, double y, double angle) => x * Math.Cos(angle) - y * Math.Sin(angle);
        public static double GetRotatedY(double x, double y, double angle) => x * Math.Sin(angle) + y * Math.Cos(angle);
        public void Move(double x, double y) 
        {
            BottomLeft.X += x;
            BottomLeft.Y += y;
            TopRight.X += x;
            TopRight.Y += y; 
        }

        public void Rotate(double angle) 
        {
            var xr1 = GetRotatedX(BottomLeft.X, BottomLeft.Y, angle);
            BottomLeft.Y = GetRotatedY(BottomLeft.X, BottomLeft.Y, angle);
            BottomLeft.X = xr1;
            var xr2 = GetRotatedX(TopRight.X, TopRight.Y, angle);
            TopRight.Y = GetRotatedY(TopRight.X, TopRight.Y, angle);
            TopRight.X = xr2;
        }
        
        public override string ToString() => $"Координаты прямоугольника:\n({BottomLeft.X},{BottomLeft.Y})\n({BottomLeft.X},{TopRight.Y})\n({TopRight.X},{TopRight.Y})\n({TopRight.X},{BottomLeft.Y})";
    }
}

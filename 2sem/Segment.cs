using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace Lab2
{
    public class Segment
    {
        private readonly int X1;
        private readonly int Y1;
        private readonly int X2;
        private readonly int Y2;

        public Segment(int x1, int y1, int x2, int y2)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }

        public Segment(int[] coordinates)
        {
            this.X1 = coordinates[0];
            this.Y1 = coordinates[1];
            this.X2 = coordinates[2];
            this.Y2 = coordinates[3];
        }

        private double Length => Math.Sqrt((Y2 - Y1) * (Y2 - Y1) + (X2 - X1) * (X2 - X1));

        public override string ToString() => $"Начало - ({X1},{Y1})\nКонец - ({X2},{Y2})\nДлина - {Length}";

        public bool Equals(Segment s1) => s1.X1 == this.X1 && s1.Y1 == this.Y1 && s1.X2 == this.X2 && s1.Y2 == this.Y2;

        public bool IsAngleX45() => (Math.Atan2(SegmentY(), SegmentX()) * 180 / Math.PI) == 45;

        public int SegmentX() => this.X2 - this.X1;

        public int SegmentY() => this.Y2 - this.Y1;

        public bool IsAngleX30() => (Math.Atan2(SegmentY(), SegmentX()) * 180 / Math.PI) == 30;

        public double GetLength() => Length;
    }
}


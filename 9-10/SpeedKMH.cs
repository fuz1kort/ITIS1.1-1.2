using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha910
{
    public class SpeedKMH
    {
        private double kmh;

        public SpeedKMH(double kmh) => this.kmh = kmh;

        public void FromMPS(double mps) => this.kmh = Mps;

        public void FromMPH(double mph) => this.kmh = Mph;

        public double Kmh { get => kmh; set { this.kmh = value; } }

        public double Mps { get => kmh * 3.6; }

        public double Mph { get => kmh * 1.609; }

        public static SpeedKMH operator +(SpeedKMH kmh1, SpeedKMH kmh2) => new SpeedKMH(kmh1.Kmh + kmh2.Kmh);

        public static SpeedKMH operator -(SpeedKMH kmh1, SpeedKMH kmh2) => new SpeedKMH(kmh1.Kmh - kmh2.Kmh);
    }
}

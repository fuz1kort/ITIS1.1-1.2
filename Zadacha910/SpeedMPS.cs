using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha910
{
    public class SpeedMPS
    {
        private double _meterpersecond;
        private SpeedMPS(double mps) => MPS = mps;

        public static SpeedMPS FromMPS(double metersPerSecond) => new SpeedMPS(metersPerSecond);

        public static SpeedMPS FromKPH(double kmPerHour) => new SpeedMPS(kmPerHour * 3.6);

        public static SpeedMPS FromMPH(double milesPerHour) => new SpeedMPS(milesPerHour / 3.6 * 1.609);

        public static double IsZero(double value) => value < 0 ? 0 : value;

        public double KPH
        {
            get { return _meterpersecond; }
            init { _meterpersecond = IsZero(value / 3.6); }
        }

        public double MPS
        {
            get { return _meterpersecond; }
            init { _meterpersecond = IsZero(value); }
        }

        public double MPH
        {
            get { return _meterpersecond; }
            init { _meterpersecond = IsZero(value * 1.609 / 3.6); }
        }

        public static SpeedMPS operator +(SpeedMPS mps1, SpeedMPS mps2) => new SpeedMPS(mps1.MPS + mps2.MPS);

        public static SpeedMPS operator -(SpeedMPS mps1, SpeedMPS mps2) => new SpeedMPS(mps1.MPS - mps2.MPS);

        public override string ToString() => $"{_meterpersecond}";
    }
}

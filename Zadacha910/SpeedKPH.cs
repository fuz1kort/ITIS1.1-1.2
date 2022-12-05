using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha910
{
    public class SpeedKPH
    {
        private double _kilometrpersecond;
        private SpeedKPH(double kph) => KPH = kph;

        public static SpeedKPH FromMPS(double metersPerSecond) => new SpeedKPH(metersPerSecond / 3.6);

        public static SpeedKPH FromKPH(double kmPerHour) => new SpeedKPH(kmPerHour);


        public static SpeedKPH FromMPH(double milesPerHour) => new SpeedKPH(milesPerHour * 1.609);


        public static double IsZero(double value) => value < 0 ? 0 : value;

        public double KPH
        {
            get { return _kilometrpersecond; }
            init { _kilometrpersecond = IsZero(value); }
        }

        public double MPS
        {
            get { return _kilometrpersecond; }
            init { _kilometrpersecond = IsZero(value) * 3.6; }
        }

        public double MPH
        {
            get { return _kilometrpersecond; }
            init { _kilometrpersecond = IsZero(value) * 1.609; }
        }

        public static SpeedKPH operator +(SpeedKPH kph1, SpeedKPH kph2) => new SpeedKPH(kph1.KPH + kph2.KPH);

        public static SpeedKPH operator -(SpeedKPH kph1, SpeedKPH kph2) => new SpeedKPH(kph1.KPH - kph2.KPH);

        public override string ToString() => $"{_kilometrpersecond}";
    }
}

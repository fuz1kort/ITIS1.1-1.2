using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicle
{
    public class Car : Vehicle
    {
        private string townFrom;
        private string townTo;
        public Car(int ms, int cs, string from, string to) : base(ms, cs)
        {
            townFrom = from;
            townTo = to;
        }

        public override void SpeedDown() => CurrSpeed -= 5;
        public override void SpeedUp() => CurrSpeed += 5;
        public override string ToString() => $"Машина едет со скоростью {CurrSpeed} км/ч из {townFrom} в {townTo}";
    }
}

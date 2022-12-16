using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicle
{
    public class Ship : Vehicle
    {
        private string townFrom;
        private string townTo;
        public Ship(int ms, int cs, string from, string to) : base(ms, cs)
        {
            townFrom = from;
            townTo = to;
        }

        public override void SpeedDown() => CurrSpeed -= 1;
        public override void SpeedUp() => CurrSpeed += 1;
        public override string ToString() => $"Корабль плывёт со скоростью {CurrSpeed} км/ч из {townFrom} в {townTo}";
    }
}

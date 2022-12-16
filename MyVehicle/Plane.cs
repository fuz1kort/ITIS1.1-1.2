using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicle
{
    public class Plane : Vehicle
    {
        private string cityFrom;
        private string cityTo;
        public Plane(int ms, int cs, string from, string to) : base(ms, cs)
        {
            cityFrom = from;
            cityTo = to;
        }

        public override void SpeedDown() => CurrSpeed -= 50;
        public override void SpeedUp() => CurrSpeed += 50;
        public override string ToString() => $"Самолет летит со скоростью {CurrSpeed} км/ч из {cityFrom} в {cityTo}";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicle
{
    public class Vehicle
    {
        protected readonly int MaxSpeed;
        protected int currSpeed;

        protected int CurrSpeed
        {
            get => currSpeed;
            set
            {
                currSpeed = value;
                if (value > MaxSpeed) currSpeed = MaxSpeed;
                if (value < 0) currSpeed = 0;
            }
        }

        Vehicle() { }
        public Vehicle(int maxSpeed, int currSpeed)
        {
            MaxSpeed = maxSpeed;
            CurrSpeed = currSpeed;
        }

        public virtual void SpeedUp() => Console.WriteLine("Ускорение");
        public virtual void SpeedDown() => Console.WriteLine("Торможение");
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicle
{
    public class Vehicle
    {
        protected readonly int maxSpeed;
        protected int currSpeed;

        int CurrSpeed
        {
            get => currSpeed;
            set
            {
                currSpeed = value;
                if (value > maxSpeed) currSpeed = maxSpeed;
                if (value < 0) currSpeed = 0;
            }
        }

        Vehicle() { }
        Vehicle(int maxSpeed, int currSpeed)
        {
            this.maxSpeed = maxSpeed;
            CurrSpeed = currSpeed;
        }

        public void SpeedUp(int speed) => CurrSpeed += speed;
        public void SpeedDown(int speed) => CurrSpeed -= speed;
    }
}

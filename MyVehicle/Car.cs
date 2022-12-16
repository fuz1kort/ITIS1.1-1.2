using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicle
{
    public class Car : Vehicle
    {
        Car(int ms, int cs)
        {
            this.maxSpeed = ms;
            currSpeed = cs;
        }
    }
}

namespace MyVehicle
{
    public class Vehicle
    {
        protected int maxSpeed;
        public int currSpeed;

        int MaxSpeed { get; set; }
        int CurrSpeed { get; set; }
        public Vehicle(int ms, int cs)
        {
            maxSpeed = ms;
            currSpeed = cs;
        }

        public virtual void SpeedUp() => CurrSpeed += 5;
        public virtual void SpeedDown() => CurrSpeed -= 5;
    }
}

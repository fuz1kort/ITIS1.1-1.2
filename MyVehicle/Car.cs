namespace MyVehicle
{
    class Car : Vehicle
    {
        private string townFrom;
        private string townTo;

        private static int maxSpeed;
        public int currspeed;
        int MaxSpeed { get => maxSpeed; set { } }
        int Currspeed
        {
            get => currSpeed;
            set
            {
                if (value > MaxSpeed)
                    currSpeed = MaxSpeed;
                else if (value < 0)
                    currSpeed = 0;
                currSpeed = value;
            }
        }
        public Car(int ms, int cs, string from, string to) : base(ms, cs)
        {
            townFrom = from;
            townTo = to;
        }


        public static void Go() => Console.WriteLine("Go Go Go");
        public override void SpeedDown() => Currspeed -= 10;
        public override void SpeedUp() => Currspeed += 10;

        public int SetupSpeed(int speed)
        {
            Currspeed = speed;
            return Currspeed;
        }
       
    }
}

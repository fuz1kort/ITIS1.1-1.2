namespace Robots
{
    public class Robot
    {
        protected string name = "Null";
        protected byte[] coordinates = new byte[3] { 0, 0, 0 };
        protected bool fly = false;

        public string Name{ get { return this.name; } set { this.name = value; } }
        public byte[] Coordinates { get { return this.coordinates; } set { this.coordinates = value; } }
        public bool Fly { get { return fly; } set { fly = value; } }

        public Robot() => Console.WriteLine("Робот успешно создан.\n");

        public void PrintInfo()
        {
            Console.WriteLine($"\nИмя робота:\n{this.name}\n");
            Console.WriteLine("\nКоординаты робота: ");
            for (int i = 0; i < 3; i++)
                Console.Write(this.coordinates[i] + " ");
            Console.WriteLine("\n");
            if (this.fly) Console.WriteLine($"\nРобот {this.name} умеет летать\n-------------------");
            else Console.WriteLine($"\nРобот {this.name} не умеет летать\n-------------------");
        }
        public Robot(string name, byte[] coordinates, bool fly)
        {
            this.name = name;
            this.coordinates = coordinates;
            this.fly = fly;
            PrintInfo();
        }
    }
}

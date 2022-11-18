namespace Robots
{
    class Program
    {
        static void Main()
        {     
            //Robot hui = new Robot();
            //hui.Name = "Test";
            //hui.Coordinates= new byte[] { 1, 1, 1 };
            //hui.Fly = true;
            //hui.PrintInfo();
            //Killer killer = new Killer();
            //killer.Name = "killer";
            //killer.Coordinates = new byte[] { 0, 0, 0 };
            //killer.Fly = true;
            //killer.HP = 100;
            //killer.PrintInfo();
            SetUpRobot();
            SetUpRobotKiller();

        }

        protected static void SetUpRobot()
        {
            Robot robot = new Robot();
            Console.WriteLine("\nВведите имя робота");
            robot.Name  = Console.ReadLine().ToString();
            Console.WriteLine("\nВведите координаты робота");
            byte[] coord = new byte[3];
            for (int i = 0; i < 3; i++)
                robot.Coordinates[i] = byte.Parse(Console.ReadLine());
            //Robot bot = new Robot();
            Console.WriteLine("\nУмеет ли робот летать? (Да, Нет)");
            string ans = Console.ReadLine().ToString();
            bool fly;
            if (ans == "Да") fly = true;
            else fly = false;
            robot.Fly = fly;
            robot.PrintInfo();
        }
        protected static void SetUpRobotKiller()
        {
            Killer term = new Killer();
            Console.WriteLine("\nВведите имя робота-киллера");
            term.Name = Console.ReadLine().ToString();
            Console.WriteLine("\nВведите HealthPoint");
            term.HP = int.Parse(Console.ReadLine());
            Console.WriteLine("\nВведите координаты робота-киллера");
            byte[] coord = new byte[3];
            for (int i = 0; i < 3; i++)
                term.Coordinates[i] = byte.Parse(Console.ReadLine());
            //Robot bot = new Robot();
            Console.WriteLine("\nУмеет ли робот-киллер летать? (Да, Нет)");
            string ans = Console.ReadLine().ToString();
            bool fly;
            if (ans == "Да") fly = true;
            else fly = false;
            term.Fly = fly;
            term.PrintInfo();
        }
    }
}
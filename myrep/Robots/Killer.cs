using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robots
{
    class Killer: Robot
    {
        private int hp = 100;

        public int HP
        {
            get { return hp; }
            set
            {
                if (value <= 0) Console.WriteLine("Робот взорвался");
                else hp = value;
            }
        }

        public Killer(string name, byte[] coord, bool fly, int hp)
        {
            this.name = name;
            this.coordinates = coord;
            this.fly = fly;
            this.hp = hp;
        }

        public Killer() => Console.WriteLine("Робот-киллер успешно создан.");
        public new void PrintInfo()
        {
            Console.WriteLine($"\nИмя робота:\n{this.name}\n");
            Console.WriteLine($"\nУровень здоровья робота {this.name}:\n{this.HP}\n");
            Console.WriteLine("\nКоординаты робота: ");
            for (int i = 0; i < 3; i++)
                Console.Write(this.coordinates[i] + " ");
            Console.Write("\n");
            if (this.fly) Console.WriteLine($"\nРобот {this.name} умеет летать\n-------------------");
            else Console.WriteLine($"\nРобот {this.name} не умеет летать\n-------------------");
        }
    }
}

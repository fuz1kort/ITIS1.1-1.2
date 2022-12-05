using System.Security.Cryptography;

namespace OOP
{

    public class Program
    {
        public static void Main()
        {
            Complexy s = new Complexy(1, 2);
            Complexy x = new Complexy(3, 4);
            Complexy a = new Complexy();
            a.Add(s,x);
            Console.WriteLine(a);
            Console.WriteLine(a.Mod);
            Console.WriteLine(a.Arg);
            Console.WriteLine(a.Div(s, x));
        }

    }

}
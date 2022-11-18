using OOP;
using System.Linq.Expressions;

namespace FractionApp
{
    public class Program
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            Fraction f1 = new Fraction(a, b);
            Fraction f2 = new Fraction(4, b);

            f1.GetProuz();
            f2.GetMinus();
            f2.GetDel();
            f1.GetSum();
            f2.PrintDenom();
            f1.Num2 = 0;
            f1.Num1 = 1;
            f1.GetProuz();

            //Compl s = new Compl(3, 4);
            //s.GetModul();
            //s.PrintModul();
            //s.PrintArg();
        }
    }
}
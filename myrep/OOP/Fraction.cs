using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Fraction
    {
        private double num1;
        private double num2;

        public Fraction() { num1 = 0; num2 = 1; }
        public Fraction(double n) { num1 = n; num2 = 1; }
        public Fraction(double n, double d)
        {
            num1 = n;
            num2 = d;
        }
        public double Num2
        {
            get { return num2; }
            set
            {
                if (value == 0) Console.WriteLine("Знаменатель не может быть 0");
                else num2 = value;
            }
        }
        public void GetSum()
        {
            Console.WriteLine(num1 + num2);
        }

        public void GetMinus()
        {
            Console.WriteLine(num1 - num2);
        }

        public void GetProuz()
        {
            
            Console.WriteLine(num1 * num2);
        }

        public void GetDel()
        {
            Console.WriteLine(num1 / num2);
        }

        public double Num1
        {
            get { return num1; }
            set { num1 = value; }
        }


        public void PrintDenom()
        {
            Console.WriteLine($"{num1}/{num2}");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Compl
    {
        private double re;
        private double im;

        public Compl() { re = 0; im = 0; }
        public Compl(double a) { re = a; im = 0; }
        public Compl(double a, double b) { re = a; im = b; }
        public double GetModul()
        {
            return Math.Sqrt(re * re + im * im);
        }
        public void PrintModul()
        {
            Console.WriteLine(GetModul());
        }
        public void PrintArg()
        {
            Console.WriteLine(Math.Acos(re/GetModul()));
        }

        public double Rez
        {
            get { return re; }
            set { re = value; }
        }
        public double Im
        {
            get { return im; }
            set { im = value; }
        }

    }
}

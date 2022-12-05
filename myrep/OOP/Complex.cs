using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Complexy
    {
        private double rez;
        private double imz;

        public Complexy(double rez, double imz)
        {
            this.rez = rez;
            this.imz = imz;
        }

        public Complexy(double rez)
        {
            this.rez = rez;
            this.imz = 0;
        }
        public Complexy()
        {
            this.rez = 0;
            this.imz = 0;
        }

        public double Rez
        {
            get { return rez; }
            set { rez = value; }
        }
        public double Imz
        {
            get { return imz; }
            set { imz = value; }
        }
        public double Mod
        {
            get { return Math.Sqrt(rez * rez + imz * imz); }
        }

        public double Arg
        {
            get { return Math.Acos(rez / Mod); }
        }

        public void Add(Complexy comp1, Complexy comp2)
        {
            this.rez = comp1.rez + comp2.rez;
            this.imz = comp1.imz + comp2.imz;
        }
        public void Minus(Complexy comp1, Complexy comp2)
        {
            this.rez = comp1.rez - comp2.rez;
            this.imz = comp1.imz - comp2.imz;
        }
        public void Multy(Complexy comp1, Complexy comp2)
        {
            this.rez = comp1.rez * comp2.rez - comp1.imz * comp2.imz;
            this.imz = comp1.imz * comp2.rez + comp2.imz * comp1.rez;
        }
        public Complexy Multy_1(Complexy comp1, Complexy comp2)
        {
            var rez = comp1.rez * comp2.rez + comp1.imz * comp2.imz;
            var imz = comp1.imz * comp2.rez - comp2.imz * comp1.rez;
            return new Complexy(rez, imz);
        }


        public string Div(Complexy comp1, Complexy comp2)
        {
            comp2.Imz = -comp2.Imz;
            Complexy comp3 = Multy_1(comp1, comp2);
            var numerator = comp3;
            var denominator = comp2.Rez * comp2.Rez + comp2.Imz * comp2.Imz;
            return $"({numerator})/{denominator}";
        }

        public override string ToString()
        {
            if (this.Imz == 0) { return $"{Rez}"; }
            if (this.Rez == 0) { return $"{Imz}i"; }
            if (this.Imz < 0) { return $"{Rez} - {-Imz}i"; }
            return $"{Rez} + {Imz}i";
        }
    }
}

﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FractionApp
//{
//    public class Fraction
//    {
//        private int numerator;
//        private int denominator;

//        public int Numerator  // свойство
//        {
//            get
//            {
//                return numerator;
//            }
//            set
//            {
//                numerator = value;
//            }
//        }

//        public int Denominator
//        {
//            get { return denominator; }
//            set
//            {
//                if (value <= 0)
//                    throw new ArgumentException("demominator must by positive");
//                denominator = value;
//            }
//        }




//        public Fraction(int n, int d)
//        {
//            Numerator = n;
//            Denominator = d;
//        }

//        public Fraction(int n) : this(n, 1) { }

//        public Fraction() : this(0, 1) { }


//        public static void StaticMethod()
//        {
//            Console.WriteLine("Static method");
//        }
//        public void SetNum(int n)
//        {
//            numerator = n;
//        }

//        public int GetNum()
//        {
//            return numerator;
//        }

//        public void SetDenom(int d)
//        {
//            if (d == 0)
//                throw new ArgumentException("Нельзя делить на ноль!");
//            denominator = d;
//        }

//        public int GetDen()
//        {
//            return denominator;
//        }

//        public void Print()
//        {
//            Console.WriteLine($"{Numerator}/{Denominator}");
//        }

//        public override string ToString()
//        {
//            if (Denominator == 1)
//                return $"{Numerator}";

//            return $"{Numerator}/{Denominator}";
//        }


//        public void Sokr()
//        {
//            //ToDo
//        }


//        public void Add(Fraction f)
//        {
//            this.numerator = this.numerator * f.denominator +
//                this.denominator * f.numerator;
//            this.denominator = this.denominator * f.denominator;
//            Sokr();
//        }

//        public void Add(Fraction f1, Fraction f2)
//        {
//            this.numerator = f1.numerator * f2.denominator +
//                f1.denominator * f2.numerator;
//            this.denominator = f1.denominator * f2.denominator;
//            Sokr();
//        }


//        public static Fraction operator +(Fraction f1, Fraction f2)
//        {
//            var n = f1.Numerator + f2.Denominator + f1.Denominator + f2.Numerator;
//            var d = f1.Denominator;
//            return new Fraction(n, d);
//        }
//    }
//}
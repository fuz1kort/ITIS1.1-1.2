using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using time;

namespace time
{
    class Time
    {
        private int hour;
        private int minute;
        private int second;

        public Time() { hour = 0; minute = 0; second = 0; }

        public Time(int second) 
        { 
            Second = second;
        }
        public Time(int hour, int minute) 
        { 
            Hour = hour; 
            Minute = minute;
        }
        public Time(int hour, int minute, int second) 
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public int Hour
        {
            get { return hour; }
            set
            {
                if (value > 23)
                {
                    Console.WriteLine("Часы были скорректированы");
                    hour = value % 24;
                }
                else hour = value;
            }
        }

        public int Minute
        {
            get { return minute; }
            set
            {
                if (value >= 60)
                {
                    Console.WriteLine("Минуты были скорректированы");
                    minute = value % 60;
                    Hour += value / 60;
                }
                else minute = value;
            }
        }

        public int Second
        {
            get { return second; }
            set
            {
                if (value >= 60)
                {
                    Console.WriteLine("Секунды были скорректированы");
                    second = value % 60;
                    Minute += value / 60;
                    Hour += Minute / 60;
                }
                else second = value;
            }
        }

        public void InSecond()
        {
            Console.WriteLine(this.hour * 3600 + this.minute * 60 + this.second);
        }

        public int ToSecond()
        {
            return this.hour * 3600 + this.minute * 60 + this.second;
        }

        public override string ToString()
        {
            var str = "";
            if (this.hour < 10) str = $"0{this.hour}:";
            else str = $"{this.hour}:";
            if (this.minute < 10) str += $"0{this.minute}:";
            else str += $"{this.minute}:";
            if (this.second < 10) str += $"0{this.second}";
            else str += $"{this.second}";
            return str+"\n";  
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public static Time operator +(Time f1, Time f2)
        {
            int s = f1.ToSecond() + f2.ToSecond();


            return new Time(s);
        }

        public static Time operator -(Time f1, Time f2)
        {
            int s = f1.ToSecond() - f2.ToSecond();
            if (s <= 0) return new Time(86400+s);
            return new Time(s);
        }

        public static Time operator *(Time f1, int a)
        {
            var s = f1.ToSecond() * a;
            return new Time(s);
        }

        public static Time operator /(Time f1, int a)
        {
            if (a == 0)
            {
                Console.WriteLine("На 0 делить нельзя");
                return new Time(0);
            }
            var s = f1.ToSecond() / a;
            return new Time(s);
        }

        public static bool operator >(Time f1, Time f2)
        {
            int s1 = f1.ToSecond();
            int s2 = f2.ToSecond();
            return s1 > s2;
        }

        public static bool operator <(Time f1, Time f2)
        {
            int s1 = f1.ToSecond();
            int s2 = f2.ToSecond();
            return s1 < s2;
        }

        public static bool operator <=(Time f1, Time f2)
        {
            int s1 = f1.ToSecond();
            int s2 = f2.ToSecond();
            return s1 <= s2;
        }

        public static bool operator >=(Time f1, Time f2)
        {
            int s1 = f1.ToSecond();
            int s2 = f2.ToSecond();
            return s1 >= s2;
        }

        public static bool operator ==(Time f1, Time f2)
        {
            int s1 = f1.ToSecond();
            int s2 = f2.ToSecond();
            return s1 == s2;
        }

        public static bool operator !=(Time f1, Time f2)
        {
            int s1 = f1.ToSecond();
            int s2 = f2.ToSecond();
            return s1 != s2;
        }
    }
}
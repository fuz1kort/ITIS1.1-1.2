﻿using time;

namespace time
{
    class Program
    {
        static void Main()
        {
            Time t = new Time(3, 9, 8);
            Time t2 = new Time(3000);
            Console.WriteLine(t);
            t.InSecond();
            t2.InSecond();
            Console.Write(t + t2);
            Console.WriteLine(t - t2);
            Console.WriteLine(t * 2);
            Console.WriteLine(t / 2);
            Console.WriteLine(t == t2);
            Console.WriteLine(t2 != t);
            Console.WriteLine(t2 > t);
            Console.WriteLine(t2 <= t);
        }
    }
}
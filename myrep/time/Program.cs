using time;

namespace time
{
    class Program
    {
        static void Main()
        {
            Time t = new Time(3, 9, 8);
            t.Hour = 5;
            Console.WriteLine(t);
            //t.InSecond();
            //t2.InSecond();
            //Console.Write(t + t2);
            //Console.WriteLine(t - t2);
            //Console.WriteLine(t*2);
            //Console.WriteLine(t/2);
            //Console.WriteLine(t == t2);
            //Console.WriteLine(t2 != t);
            //Console.WriteLine(t2 > t);
            //Console.WriteLine(t2 <= t);
        }
    }
}
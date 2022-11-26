using Zadacha910;

namespace Zadachi910
{
    class Program
    {
        static void Main()
        {
            SpeedKMH km1 = new SpeedKMH(100);
            //SpeedKMH km2 = new SpeedKMH(150);
            km1.FromMPH(100);
            Console.WriteLine(km1.Kmh);
            //Console.WriteLine(mp1.Kmh);
            //Console.WriteLine(mp1.Mph);
            //Console.WriteLine(mp1.Mps);
            //Console.WriteLine(km1.Mph);
            //Console.WriteLine(km1.Mps);
            //Console.WriteLine(km2.Mph);
            //Console.WriteLine(km1.Kmh+km2.Kmh);
            


        }
    }
}
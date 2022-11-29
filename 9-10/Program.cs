using Zadacha910;

namespace Zadachi910
{
    class Program
    {
        static void Main()
        {
            SpeedKPH f1 = SpeedKPH.FromMPS(2);
            SpeedKPH f2 = SpeedKPH.FromMPH(3);
            SpeedKPH f3 = SpeedKPH.FromKPH(4);
            Console.WriteLine(f1);
            Console.WriteLine(f2);
            Console.WriteLine(f1+f2+f3);
        }
    }
}
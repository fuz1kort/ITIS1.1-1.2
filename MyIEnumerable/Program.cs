namespace LINQ
{
    class Program
    {
        public static void Main()
        {
            //Console.WriteLine("№6 Введите строковую последовательность");

            //Console.WriteLine(Console.ReadLine().Split(" ").Sum(x => x.Length));

            //Console.WriteLine("-------------------");

            //Console.WriteLine("№16 Введите целочисленную последовательность");

            //foreach (int num in Console.ReadLine().Split(" ").Select(x => Convert.ToInt32(x)).Where(x => x > 0).ToArray()) 
            //    Console.Write($"{num} ");

            //Console.WriteLine("-------------------");

            //Console.WriteLine("№26 Введите целые числа K1 и K2 и последовательность непустых строк");

            //var k1 = Convert.ToInt32(Console.ReadLine());
            //var k2 = Convert.ToInt32(Console.ReadLine());
            //var pos = Console.ReadLine().Split(" ").Select(x => Convert.ToInt32(x)).ToList();
            //Console.WriteLine(pos.Where(x => pos.IndexOf(x)<k1-1 || pos.IndexOf(x)>k2-1).Average());

            //Console.WriteLine("-------------------");

            //Console.WriteLine("№36 Введите последовательность непустых строк");

            //var str = Console.ReadLine().Split(" ");
            //List<char> chars = new();
            //chars.AddRange(str.Where(x => x.Length % 2 == 1).Select(x => x[0]));
            //chars.AddRange(str.Where(x => x.Length % 2 == 0).Select(x => x[x.Length - 1]));
            //foreach(var _char in chars.OrderByDescending(x => x.GetHashCode()))
            //    Console.Write(_char);

            //Console.WriteLine("-------------------");

            //Console.WriteLine("№46 Введите последовательность A и B");

            //var A = Console.ReadLine().Split(" ").Select(x => Convert.ToInt32(x));
            //var B = Console.ReadLine().Split(" ").Select(x => Convert.ToInt32(x));
            //var pairs = from a in A
            //            from b in B
            //            where a % 10 == b % 10
            //            orderby a, b
            //            select $"{a}-{b}";

            //foreach (var pair in pairs)
            //{
            //    Console.Write($"{pair} ");
            //}

            //Console.WriteLine("-------------------");

            Console.WriteLine("№56 Введите целочисленную последовательность");

            var A = Console.ReadLine().Split(" ");

        }
    }
}
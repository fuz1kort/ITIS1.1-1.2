using System.Collections.Specialized;

namespace YieldApp
{
    class Program
    {
        public static void Main() 
        {
            var str = "one two three four five six seven eight nine ten eleven twelve";
            var test = new StringEnumerator(str);

            foreach (var item in test)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-------");

            foreach (var item in test.GetOrderedByLength())
            {
                Console.WriteLine(item);
            }
        }
    }
}
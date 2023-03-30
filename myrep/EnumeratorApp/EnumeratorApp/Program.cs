using System.Collections.Specialized;

namespace YieldApp
{
    class Program
    {
        public static void Main() 
        {
            var str = "ber ike och durt bish alty jide sigez tugiz un";
            var test = new StringEnumerator(str);

            foreach (var item in test)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------------------------");

            //foreach (var item in test.GetOrderedByLength())
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
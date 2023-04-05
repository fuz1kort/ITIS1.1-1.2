namespace DelegateApp
{
    public class Program
    {

        public delegate int MyIntDelegate(int a, int b);
        public delegate string MyStringDelegate(string a, string b);
        public delegate bool BoolDelegate<T>(T x);
        static void Main()
        {
            MyList<int> intlist = new() {  };
            intlist.Add(1);
            intlist.Add(2);
            intlist.Add(3);
            intlist.Add(4);
            intlist.Add(5);

            


            DelOper deloper = new DelOper();
            BoolDelegate<int> booldeleg = new BoolDelegate<int>(deloper.IsEven);

            
            Console.WriteLine(intlist.Count(x => !booldeleg(x)));

            MyIntDelegate intdelegate = new(deloper.Sum);

            Console.WriteLine(intlist.Aggregate<int>((x, y) => intdelegate(x,y)));

            intdelegate = deloper.Minus;

            Console.WriteLine(intlist.Aggregate((x, y) => intdelegate(x,y), 100));

            intdelegate = deloper.Mult;

            Console.WriteLine(intlist.Aggregate((x, y) => intdelegate(x,y), 1));

            intdelegate = deloper.Div;

            Console.WriteLine(intlist.Aggregate((x, y) => intdelegate(x,y), 120));

            intdelegate = deloper.Max;

            Console.WriteLine(intlist.Aggregate<int>((x, y) => intdelegate(x, y)));

            intdelegate = deloper.Min;

            Console.WriteLine(intlist.Aggregate((x, y) => intdelegate(x, y),1));


            MyList<String> stringlist = new() { };
            stringlist.Add("abc");
            stringlist.Add("bca");
            stringlist.Add("acdb");
            stringlist.Add("ddss");
            stringlist.Add("cde");

            BoolDelegate<string> boolstrdeleg = new(deloper.LengthIs3);

            MyStringDelegate strdeleg = new(deloper.Sum);

            Console.WriteLine(stringlist.Aggregate<string>((x, y) => strdeleg(x,y)));
            Console.WriteLine(stringlist.Aggregate((x, y) => $"{x} + {y}", "hello"));
            Console.WriteLine(stringlist.Count(x => boolstrdeleg(x)));


            
        }
    }
}
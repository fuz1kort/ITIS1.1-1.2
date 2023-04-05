namespace DelegateApp
{
    public class DelOper
    {
        public int Sum(int x, int y) => x + y;
        public int Minus(int x, int y) => x - y;
        public int Mult(int x, int y) => x * y;
        public int Div(int x, int y) => x / y;
        public int Max(int x, int y) => x > y ? x : y;
        public int Min(int x, int y) => x < y ? x : y;

        public bool IsEven(int x) => x % 2 == 0;

        public bool LengthIs3(string s) => s.Length == 3;

        public string Sum(string x, string y) => x + y;

    }
}

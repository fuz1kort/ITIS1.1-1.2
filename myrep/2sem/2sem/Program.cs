namespace _2sem
{
    class Program
    {
        public void Main()
        {
            MyStack stack = new MyStack(10);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack.Pop());
            stack.Push(4);
            stack.Push(2);
            Console.WriteLine(stack.GetMax());
        }    
    }
}
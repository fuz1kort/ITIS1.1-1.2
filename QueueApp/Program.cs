namespace QueueApp
{
    class Program
    {
        public static void Main()
        {
            Random r = new Random();
            CycledQueue q = new(20);
            for(int i = 0;  i < 20; i++)
                q.Enqueue(r.Next(-100, 100));
            PrintQueue(q);



            void PrintQueue(CycledQueue queue)
            {
                var list = queue.GetNegList();
                foreach (var item in list)
                    Console.WriteLine(item);
                list = queue.GetPosList();
                foreach(var item in list)
                    Console.WriteLine(item);
            }


        }
    }
}
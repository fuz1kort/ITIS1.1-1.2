namespace SortedList
{
    class Program
    {
        public static void Main()
        {
            OrderedList<int> list1 = new();
            list1.Add(1);
            list1.Add(100);
            list1.Add(5);
            PrintList(list1);
            list1.Delete(100);
            PrintList(list1);
            OrderedList<int> list2 = new();
            list2.Add(2);
            list2.Add(400);
            PrintList(list2);
            list1.Merge(list2);
            PrintList(list1);
            list1.Add(83);
            PrintList(list1);
        }

        public static void PrintList(OrderedList<int> list)
        {
            var printlist = list.GetList();
            printlist.ForEach(i => Console.WriteLine(i));
            Console.WriteLine("-----");
        }
    }
}
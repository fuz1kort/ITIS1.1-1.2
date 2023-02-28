namespace SortedList
{
    class Program
    {
        public static void Main()
        {
            OrderedList list1 = new();
            list1.Add(1);
            list1.Add(100);
            list1.Add(5);
            PrintList(list1);
            OrderedList list2 = new();
            list2.Add(2);
            list2.Add(400);
            list1.Merge(list2);
            PrintList(list2);

        }

        public static void PrintList(OrderedList list)
        {
            var printlist = list.GetList();
            printlist.ForEach(i => Console.WriteLine(i));
        }
    }
}
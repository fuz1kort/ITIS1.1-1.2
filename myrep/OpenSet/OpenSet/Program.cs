namespace OpenSet
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("set1, IsContains, ToString");
            var set1 = new MySet();
            set1.Add(1);
            set1.Add(2);
            set1.Add(3);
            set1.Add(4);
            set1.Add(2);
            set1.Delete(2);
            Console.WriteLine(set1);
            Console.WriteLine(set1.IsContains(1));
            Console.WriteLine("--------------");
            Console.WriteLine("ToArray");
            var arr = set1.ToArray();
            foreach (var item in arr)
                Console.Write($"{item} ");
            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine("set2");
            var set2 = new MySet();
            set2.Add(1);
            set2.Add(8);
            set2.Add(15);
            Console.WriteLine(set2);
            Console.WriteLine("--------------");
            Console.WriteLine("set 1 intersection set 2");
            Console.WriteLine(set1.Intersection(set2));
            Console.WriteLine("--------------");
            Console.WriteLine("set 1 unification set 2");
            Console.WriteLine(set1.Unification(set2));
            Console.WriteLine("--------------");
            Console.WriteLine("set 1 difference set 2");
            set1.Difference(set2);
            Console.WriteLine(set1);
            Console.WriteLine("--------------");
            Console.WriteLine("set 1 is supset set 2");
            set2 = set1.Unification(set2);
            Console.WriteLine(set1);
            Console.WriteLine(set2);
            Console.WriteLine(set1.IsSupSet(set2));
        }
    }
}
namespace OpenSet
{
    class Program
    {
        static void Main()
        {
            HashSet<int> set1 = new();
            set1.Add(1);
            set1.Add(2);
            set1.Add(3);

            HashSet<int> set2 = new();
            set2.Add(2);
            set2.Add(3);
            set2.Add(4);

            Console.WriteLine("set1: " + set1); // {1, 2, 3}
            Console.WriteLine("set2: " + set2); // {2, 3, 4}

            HashSet<int> intersection = set1.Intersection(set2);
            Console.WriteLine("intersection: " + intersection); // {2, 3}

            HashSet<int> union = set1.Union(set2);
            Console.WriteLine("union: " + union); // {1, 2, 3, 4}

            HashSet<int> difference = set1.Difference(set2);
            Console.WriteLine("difference: " + difference); // {1}

            HashSet<int> symmetricDifference = set1.SymmetricDifference(set2);
            Console.WriteLine("symmetric difference: " + symmetricDifference); // {1, 4}

            bool isSuperset = intersection.IsSubset(set1);
            Console.WriteLine("is set1 a superset of intersection? " + isSuperset); // True
        }
    }
}
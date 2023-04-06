namespace DelegateApp
{
    public class MyList<T>
    {
        private readonly List<T> list = new();

        public MyList() { }

        public void Add(T item) => list.Add(item);

        public void Clear() => list.Clear();

        public int Count(Func<T, bool> func)
        {
            var count = 0;
            foreach(var item in list)
            {
                if (func(item))
                    count++;
            }

            return count;
        }

        public T1 Aggregate<T1>(Func<T1,T,T1> func)
        {
            T1 res = default;

            foreach(var item in list)
                res = func(res, item);

            return res;
        }

        public T1 Aggregate<T1>(Func<T1, T, T1> func, T1 defval)
        {
            foreach (var item in list)
                defval = func(defval, item);

            return defval;
        }
    }
}

using System;
using System.Collections;
using System.Text;

namespace OpenSet
{
    class HashSet<T>
    {
        private const int InitialCapacity = 16;

        private T[] table;
        private bool[] deleted;
        private int size;

        public HashSet()
        {
            table = new T[InitialCapacity];
            deleted = new bool[InitialCapacity];
            size = 0;
        }

        public void Add(T value)
        {
            if (size * 2 >= table.Length)
            {
                Expand();
            }

            int index = FindIndex(value, true);
            if (table[index] == null)
            {
                table[index] = value;
                size++;
            }
        }

        public bool Contains(T value)
        {
            int index = FindIndex(value, false);
            return index >= 0 && table[index] != null;
        }

        public void Remove(T value)
        {
            int index = FindIndex(value, false);
            if (index >= 0 && table[index] != null)
            {
                table[index] = default;
                deleted[index] = true;
                size--;
            }
        }

        public override string ToString() => "{" + string.Join(", ", ToArray()) + "}";

        public T[] ToArray()
        {
            T[] result = new T[size];
            int j = 0;
            for (int i = 0; i < table.Length; i++)
            {
                if (table[i] != null && !deleted[i])
                {
                    result[j] = table[i];
                    j++;
                }
            }

            return result;
        }

        public HashSet<T> Intersection(HashSet<T> other)
        {
            HashSet<T> result = new HashSet<T>();
            foreach (T value in other.ToArray())
            {
                if (Contains(value))
                {
                    result.Add(value);
                }
            }

            return result;
        }

        public HashSet<T> Union(HashSet<T> other)
        {
            HashSet<T> result = new HashSet<T>();
            foreach (T value in ToArray())
            {
                result.Add(value);
            }

            foreach (T value in other.ToArray())
            {
                result.Add(value);
            }

            return result;
        }

        public HashSet<T> Difference(HashSet<T> other)
        {
            HashSet<T> result = new HashSet<T>();
            foreach (T value in ToArray())
            {
                if (!other.Contains(value))
                {
                    result.Add(value);
                }
            }

            return result;
        }

        public HashSet<T> SymmetricDifference(HashSet<T> other)
        {
            HashSet<T> result = new HashSet<T>();
            foreach (T value in ToArray())
            {
                if (!other.Contains(value))
                {
                    result.Add(value);
                }
            }

            foreach (T value in other.ToArray())
            {
                if (!Contains(value))
                {
                    result.Add(value);
                }
            }

            return result;
        }

        public bool IsSupersetOf(HashSet<T> other)
        {
            foreach (T value in other.ToArray())
            {
                if (!Contains(value))
                {
                    return false;
                }
            }

            return true;
        }

        private int FindIndex(T value, bool insert)
        {
            int hashCode = value.GetHashCode();
            int index = (hashCode & 0x7fffffff) % table.Length;
            int steps = 0;

            while (table[index] != null && (!table[index].Equals(value) || deleted[index]))
            {
                steps++;
                index = (index + steps * steps) % table.Length;
            }

            if (insert)
            {
                return index;
            }

            else if (table[index] != null)
            {
                return index;
            }

            return -1;
        }

        private void Expand()
        {
            T[] oldTable = table;
            bool[] oldDeleted = deleted;
            table = new T[oldTable.Length * 2];
            deleted = new bool[table.Length];
            size = 0;

            foreach (T value in oldTable)
            {
                if (value != null)
                {
                    int index = FindIndex(value, true);
                    table[index] = value;
                }
            }
        }
    }
}

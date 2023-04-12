namespace OpenSet
{
    class HashSet<T>
    {
        private const int DefaultCapacity = 1;

        private int _count;
        private int _capacity;
        private T[] table;
        private bool[] places;
        int Count => _count;
        public HashSet() : this(DefaultCapacity) { }

        public HashSet(int capacity)
        {
            this._count = 0;
            this._capacity = capacity;
            this.table = new T[capacity];
            this.places = new bool[capacity];
        }

        public void Add(T item)
        {
            if (Contains(item))
            {
                return;
            }

            if (_count + 1 > _capacity * 0.75)
            {
                Resize(_capacity * 2);
            }

            int index = GetIndex(item);
            while (places[index])
            {
                index = (index + 1) % _capacity;
            }

            table[index] = item;
            places[index] = true;
            _count++;

        }

        public void Remove(T item)
        {
            int index = GetIndex(item);
            while (places[index])
            {
                if (table[index].Equals(item))
                {
                    Move(index);
                    places[index] = false;
                    _count--;
                    return;
                }

                index = (index + 1) % _capacity;
            }
        }

        private void Move(int index)
        {
            for (int i = index; i < table.Length - 1; i++)
            {
                table[i] = table[i + 1];
            }
        }

        public bool Contains(T item)
        {
            //int index = GetIndex(item);
            //while (places[index])
            //{
            //    if (table[index].Equals(item))
            //    {
            //        return true;
            //    }
            //    index = (index + 1) % _capacity;
            //}

            //return false;

            return table.Contains(item);
        }

        public override string ToString() => "{" + string.Join(",", ToArray()) + "}";


        public T[] ToArray()
        {
            T[] array = new T[_count];
            int index = 0;
            for (int i = 0; i < table.Length; i++)
            {
                if (places[i])
                {
                    array[index++] = table[i];
                }
            }

            return array;
        }

        public HashSet<T> Intersection(HashSet<T> other)
        {
            HashSet<T> result = new();
            for (int i = 0; i < table.Length; i++)
            {
                if (places[i] && other.Contains(table[i]))
                {
                    result.Add(table[i]);
                }
            }

            return result;
        }

        public HashSet<T> Union(HashSet<T> other)
        {
            HashSet<T> result = new();
            for (int i = 0; i < table.Length; i++)
            {
                if (places[i])
                {
                    result.Add(table[i]);
                }
            }

            for (int i = 0; i < other.table.Length; i++)
            {
                if (other.places[i])
                {
                    result.Add(other.table[i]);
                }
            }

            return result;
        }

        public HashSet<T> Difference(HashSet<T> other)
        {
            HashSet<T> result = new();
            for (int i = 0; i < _capacity; i++)
            {
                if (places[i] && !other.Contains(table[i]))
                {
                    result.Add(table[i]);
                }
            }

            return result;
        }

        public HashSet<T> SymmetricDifference(HashSet<T> other)
        {
            HashSet<T> result = new HashSet<T>();
            foreach (T value1 in ToArray())
            {
                if (!other.Contains(value1))
                {
                    result.Add(value1);
                }
            }

            foreach (T value2 in other.ToArray())
            {
                if (!Contains(value2))
                {
                    result.Add(value2);
                }
            }

            return result;
        }

        public bool IsSubset(HashSet<T> other)
        {
            int c = 0;
            for (int i = 0; i < _capacity; i++)
            {
                if (places[i])
                {
                    if (other.Contains(table[i]))
                    {
                        c++;
                    }

                }
            }

            if (c == this.Count)
            {
                return true;
            }

            return false;
        }

        int GetIndex(T item, int capacity = -1)
        {
            if (capacity == -1)
            {
                capacity = _capacity;
            }

            int index = item.GetHashCode() % capacity;
            return Math.Abs(index);
        }

        void Resize(int capacity)
        {
            var oldTable = table;
            var oldPlaces = places;
            table = new T[capacity];
            places = new bool[capacity];
            for (int i = 0; i < oldPlaces.Length; i++)
            {
                if (oldPlaces[i])
                {
                    T item = oldTable[i];
                    int index = GetIndex(item, capacity);
                    while (places[index])
                    {
                        index++;
                    }

                    table[index] = item;
                    places[index] = true;
                }
            }

            _capacity = capacity;
        }
    }
}
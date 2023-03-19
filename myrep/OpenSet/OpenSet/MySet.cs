using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSet
{
    public class MySet
    {
        public Hashtable hashtable = new Hashtable();

        private int count = 0;

        public MySet() { }

        public bool IsContains(int s) => (this.hashtable.ContainsValue(s));

        public void Add(int s)
        {
            if (IsContains(s))
                return;
            hashtable.Add(++count, s);
        }

        public void Delete(int s)
        {
            if (!IsContains(s))
                return;
            hashtable.Remove(s);
            count--;
        }

        public override string ToString()
        {
            var str = new StringBuilder();
            foreach (int s in hashtable.Values)
                str.Append($"{s} ");
            return str.ToString();
        }

        public int[] ToArray()
        {
            var array = new int[count];
            var i = 0;
            foreach (int s in hashtable.Values)
                array[i++] = s;
            return array;
        }

        public MySet Intersection(MySet set)
        {
            var newset = new MySet();
            foreach (int s in set.hashtable.Values)
                if (hashtable.ContainsValue(s))
                    newset.Add(s);
            return newset;
        }

        public MySet Unification(MySet set)
        {
            var newset = new MySet();
            foreach(int s1 in hashtable.Values)
                newset.Add(s1);
            foreach (int s2 in set.hashtable.Values)
                newset.Add(s2);
            return newset;
        }

        public void Difference(MySet set)
        {
            foreach(int s in set.hashtable.Values)
            {
                if(hashtable.ContainsValue(s))
                    hashtable.Remove(s);
            }
        }

        public MySet SymDifference(MySet set)
        {
            var newset = new MySet();
            foreach(int s in set.hashtable.Values)
            {
                if (!hashtable.ContainsValue(s))
                    newset.Add(s);
            }

            foreach(int s in hashtable.Values)
            {
                if(!set.hashtable.ContainsValue(s))
                    newset.Add(s);
            }

            return newset;

        }

        public bool IsSupSet(MySet set)
        {
            foreach(int s in hashtable.Values)
            {
                if (!set.hashtable.ContainsValue(s))
                    return false;
            }
            
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedList
{
    public class OrderedList
    {
        private readonly LinkedList<int> list = new();

        public OrderedList() { }

        public void Add(int value)
        {
            if(list == null)
                list.AddFirst(value);
            if (list.First >= value)
                list.AddFirst(value);
            foreach(int item in list)
            {
                if (item <= value)
                    list.AddAfter(list.Find(item), value);
            }
        }

        public void Delete(int value)
        {
            if (list.Contains(value))
                list.Remove(value);
            else
                throw new ArgumentException("Такого числа нет в списке");
        }

        public void Merge(OrderedList orderedlist)
        {
            var item = orderedlist.list.First;
            if (item == null)
                return;
            while(item != null)
            {
                this.Add(item.Value);
                item = item.Next;
            }
        }

        public List<int> GetList()
        {
            List<int> newlist = new();
            var item = list.First;
            if (item == null)
                return null;
            while (item != null)
            {
                newlist.Add(item.Value);
                item = item.Next;
            }
            return newlist;
        }
    }
}

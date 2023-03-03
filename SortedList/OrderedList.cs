using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SortedList
{
    public class OrderedList<T> where T: IComparable
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
            public Node(T value) => Value = value;
        }

        private Node head;

        public OrderedList() { }

        public void Add(T value)
        {
            Node newelem = new(value);
            if (head == null)
            {
                head = newelem;
                return;
            }

            if (newelem.Value.CompareTo(head.Value) < 0)
            {
                newelem.Next = head;
                head = newelem;
            }
            else
            {
                Node current = head;

                while (current.Next != null && current.Next.Value.CompareTo(newelem.Value) < 0)
                {
                    current = current.Next;
                }
                newelem.Next = current.Next;
                current.Next = newelem;
            }
        }

        public void Delete(T value)
        {
            var elem = head;
            var prev = elem;
            if (head == null)
                return;
            while (elem != null)
            {
                if (elem.Value.CompareTo(value)==0)
                {
                    prev.Next = elem.Next;
                    if (head.Value.CompareTo(value) == 0)
                        head = head.Next;
                    break;
                }
                prev = elem;
                elem = elem.Next;
            }
        }

        public void Merge(OrderedList<T> orderedlist)
        {
            if (orderedlist == null)
                return;                
            Node curr = head;
            Node curr2 = orderedlist.head;
            Node prev = null;

            while(curr != null || curr2 != null)
            {
                if (curr2.Value.CompareTo(curr.Value)<0)
                {
                    var temp = curr2;
                    curr2 = curr2.Next;
                    if(prev == null)
                    {
                        temp.Next = head;
                        head = temp;
                        prev = temp;
                    }

                    else
                    {
                        prev.Next = temp;
                        temp.Next = curr;
                        prev = temp;
                    }
                }

                else
                {
                    if (curr.Next != null)
                    {
                        prev = curr;
                        curr = curr.Next;
                    }
                    else break;
                }
            }

            if (curr2 != null)
                prev.Next = curr2;
        }

        public List<T> GetList()
        {
            List<T> newlist = new() { head.Value };
            var item = head.Next;
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

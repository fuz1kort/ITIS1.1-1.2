using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueApp
{
    public class CycledQueue
    {
        private readonly int[] queue;
        private int head;
        private int tail;
        private readonly int length;
        public CycledQueue(int size)
        {
            head = tail = -1;
            length = size;
            queue = new int[length];
        }

        public bool IsEmpty() => head == -1;

        public void Enqueue(int item)
        {
            if ((head == 0 && tail == length - 1) || (tail + 1 == head))
            {
                Console.WriteLine("Очередь заполнена");
                return;
            }
            else
            {
                if (tail == length - 1)
                    tail = 0;
                else
                    tail++;

                queue[tail] = item;
            }

            if (head == -1)
                head = 0;
        }

        public int Denqueue()
        {
            int value;
            if(IsEmpty())
            {
                Console.WriteLine("Очередь пуста");
                value = -1;
            }

            else
            {
                value = queue[head];
                queue[head] = 0;

                if (head == tail)
                    head = tail - 1;
                else
                {
                    if (head == length - 1)
                        head = 0;
                    else
                        head++;
                }
            }

            return value;
        }

        public List<int> GetNegList()
        {
            List<int> list = new();
            foreach (int item in queue)
                if (item < 0)
                    list.Add(item);
            return list;
        }

        public List<int> GetPosList()
        {
            List<int> list = new();
            foreach (int item in queue)
                if (item > 0)
                    list.Add(item);
            return list;
        }



    }
}

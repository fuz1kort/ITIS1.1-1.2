using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace _2sem
{
    public class MyStack
    {
        private int[] stack;
        private int counter = -1;
        private int max = int.MinValue;

        public MyStack(int maxSize)
        {
            stack = new int[maxSize];
        }

        public void Push(int x)
        {
            if (counter == (++counter - 1)) throw new ArgumentException("The stack is full");
            if (x < max)
            {
                stack[counter + 1] = x;
                counter++;
            }
            else
            {
                stack[counter + 1] = x + max;
                max = x;
            }
        }

        public int Pop()
        {
            var p = Peek();
            counter--;
            if (Math.Abs(p) < Math.Abs(max)) return p;
            else
            {
                max = p - max;
                return max;
            }
        }

        public int GetMax() => max;

        public bool IsEmpty() => counter == -1;
        public void Clear() => counter = -1;
        public int Peek()
        {
            if (IsEmpty()) throw new ArgumentException("The stack is empty");
            return stack[counter];
        }
    }
}

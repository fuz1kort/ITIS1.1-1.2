using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldApp
{
    public class ListEnumerator : IEnumerator
    {

        List<string> lst;
        int cur;

        public ListEnumerator(List<string> lst)
        {
            this.lst = lst;
            cur = -1;
        }


        public string Current => lst[cur];

        object IEnumerator.Current => throw new NotImplementedException();



        public bool MoveNext()
        {
            cur++;
            return cur < lst.Count;
        }

        public void Reset() => cur = -1;
    }
}

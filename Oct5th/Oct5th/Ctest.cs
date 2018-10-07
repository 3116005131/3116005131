using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oct5th
{
    class Ctest : IEnumerable
    {
        object[] objConllection;
        int count;
        public Ctest()
        {
            count = 0;
        }
        public void Add(object obj)
        {
            count++;
            Array.Resize(ref objConllection, count);
            objConllection[count - 1] = obj;
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return objConllection[i];
            }
        }
    }
}

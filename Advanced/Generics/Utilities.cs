using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced.Generics
{
    public class Utilities<T> where T: IComparable, new()
    {
        public int Max(int a, int b) => a > b ? a : b;
        public void DoSmth(T value)
        {
            var obj = new T();
        }
        public T Max(T a, T b) => a.CompareTo(b) > 0 ? a : b;
    }
}

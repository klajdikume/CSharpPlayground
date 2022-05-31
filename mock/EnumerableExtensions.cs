using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mock
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int pageIndex, int pageSize)
        {
            // TODO Fill with your own implementation
            return source.Skip(pageIndex * pageSize).Take(pageSize);
        }
    }
}

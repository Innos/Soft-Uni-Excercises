using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Func
{
    static class Extensions
    {
        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> collection,Func<T, bool> predicate)
        {
            if (collection.Count() == 0)
            {
                throw new ArgumentNullException("collection","Collection is empty.");
            }
            var list = new List<T>();
            foreach (var element in collection)
            {
                if (predicate(element))
                {
                    list.Add(element);
                }
                else
                {
                    break;
                }
            }
            return list;
        }
    }
}

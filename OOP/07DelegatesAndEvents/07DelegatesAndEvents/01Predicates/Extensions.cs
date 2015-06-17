using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Predicates
{
    static class Extensions
    {
        public static T FirstOrDefault<T>(this IEnumerable<T> collection, Predicate<T> condition)
        {
            if (collection.Count() == 0)
            {
                return default(T);
            }

            foreach (var element in collection)
            {
                if (condition(element))
                {
                    return element;
                }
            }
            return default(T);
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> collection)
        {
            if (collection.Count() == 0)
            {
                return default(T);
            }

            return (collection as List<T>)[0];
        }
    }
}

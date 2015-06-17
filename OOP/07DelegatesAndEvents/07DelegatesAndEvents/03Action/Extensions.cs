using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Action
{
    static class _03Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> collection , Action<T> action )
        {
            foreach (var element in collection)
            {
                action(element);
            }
        }
    }
}

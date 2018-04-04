using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKit.MQ.Utils
{
    public static class NoParallel
    {
        public static void ForEach<T>(this IEnumerable<T> src, Action<T> action)
        {
            foreach (T element in src)
            {
                action(element);
            }
        }
    }
}

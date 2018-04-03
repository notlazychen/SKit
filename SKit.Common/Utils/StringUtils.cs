using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SKit.Common.Utils
{
    public static class StringUtils
    {
        public static List<T> StringToMany<T>(this string str, Func<string, T> selecter)
        {
            List<T> result = new List<T>();
            if (string.IsNullOrEmpty(str))
            {
                return result;
            }
            result.AddRange(str.Split(',').Select(selecter));
            return result;
        }

        public static string ManyToString<T>(this List<T> list, Func<T, string> selecter)
        {
            return string.Join(",", list.Select(selecter));
        }
        
    }
}

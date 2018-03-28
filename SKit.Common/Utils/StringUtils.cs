using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SKit.Common
{
    public static class StringUtils
    {
        public static List<int> StringToListInt(this string str)
        {
            List<int> result = new List<int>();
            if (string.IsNullOrEmpty(str))
            {
                return result;
            }
            result.AddRange(str.Split(',').Select(int.Parse));
            return result;
        }

        public static string ListIntToString(this List<int> list)
        {
            return string.Join(",", list);
        }
    }
}

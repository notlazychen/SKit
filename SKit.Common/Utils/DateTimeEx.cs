using System;
using System.Collections.Generic;
using System.Text;

namespace SKit.Common.Utils
{
    public static class DateTimeEx
    {
        /// <summary>
        /// 获取Unix时间戳
        /// </summary>
        /// <param name="time"></param>
        /// <returns>毫秒</returns>
        public static long ToUnixTime(this DateTime time)
        {
            return (time.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        }
    }
}

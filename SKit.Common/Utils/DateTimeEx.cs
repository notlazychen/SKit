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

        private readonly static DateTime UnixTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        /// <summary>
        /// 获取Unix时间
        /// </summary>
        /// <param name="time"></param>
        public static DateTime FromUnixTime(long time)
        {
            return UnixTime.AddMilliseconds(time);
        }
    }
}

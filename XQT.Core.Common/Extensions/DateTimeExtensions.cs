using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQT.Core.Common
{
    /// <summary>
    /// 时间扩展类
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 时间戳起始日期
        /// </summary>
        public static DateTime timestampStart = new DateTime(1970, 1, 1, 0,0,0,0);

        /// <summary>
        /// 转换为时间戳
        /// </summary>
        /// <param name="dateTime">当前时间</param>
        /// <param name="milliseconds">是否转为毫秒</param>
        /// <returns></returns>
        public static long ToTimestamp(this DateTime dateTime, bool milliseconds = false)
        {
           var timestamp = dateTime.ToUniversalTime() - timestampStart;
            return (long)(milliseconds ? timestamp.TotalMilliseconds : timestamp.TotalSeconds);
        }

        /// <summary>
        /// 获取周几
        /// </summary>
        /// <param name="dateTime">当前时间</param>
        /// <returns></returns>
        public static string GetWeekName(this DateTime dateTime)
        {
            var day = (int)dateTime.DayOfWeek;
            var week = new string[] { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };
            return week[day];
        }
    }
}

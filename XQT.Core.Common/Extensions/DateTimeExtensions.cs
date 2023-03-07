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
        /// <param name="dateTime"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        public static long ToTimestamp(this DateTime dateTime, bool milliseconds = false)
        {
           var timestamp = dateTime.ToUniversalTime() - timestampStart;
            return (long)(milliseconds ? timestamp.TotalMilliseconds : timestamp.TotalSeconds);
        }
    }
}

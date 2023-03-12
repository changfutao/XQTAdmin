using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace XQT.Core.Common.Extensions
{
    /// <summary>
    /// 枚举扩展类
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 输出当前枚举值的Description值
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static string ToDescription(this Enum item)
        {
            // 输出的是枚举定义的变量名
            string name = item.ToString();
            // 获取DescriptionAttribute特性实例
            var desc = item.GetType().GetField(name)?.GetCustomAttribute<DescriptionAttribute>();
            // 输出特性实例的属性值
            return desc?.Description ?? name;
        }

        /// <summary>
        /// 将枚举值转为long
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static long ToInt64(this Enum item)
        {
            return Convert.ToInt64(item);
        }
    }
}

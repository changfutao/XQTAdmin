﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQT.Core.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// 判断字符串是否为Null、空
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNull(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// 判断字符串是否不为Null、空
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool NotNull(this string s)
        {
            return !string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// 与字符串进行比较, 忽略大小写
        /// </summary>
        /// <param name="s"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string s, string value)
        {
            return s.Equals(value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 首字母转小写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FirstCharToLower(this string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                return s;
            }
            return s.First().ToString().ToLower() + s.Substring(1);
        }

        /// <summary>
        /// 首字母转大写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FirstCharToUpper(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            return s.First().ToString().ToUpper() + s.Substring(1);
        }

        //public static string ToBase64(this string s)
        //{
        //    return s.ToBase64();
        //}

        //public static string ToBase64(this string s, Encoding encoding)
        //{
        //    if (s.IsNull())
        //        return string.Empty;
        //    var bytes = encoding.GetBytes(s);
        //    return bytes.ToBase64
        //}
    }
}

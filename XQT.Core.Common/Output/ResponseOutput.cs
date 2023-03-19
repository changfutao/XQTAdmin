using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQT.Core.Common.Output
{
    public class ResponseOutput<T> : IResponseOutput<T>
    {

        /// <summary>
        /// 数据
        /// </summary>
        public T? Data { get; private set; }
        /// <summary>
        /// 是否成功标记
        /// </summary>
        public bool Success { get; private set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string? Msg { get; private set; }
        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public ResponseOutput<T> Ok(T data, string msg = null)
        {
            Success = true;
            Msg = msg;
            Data = data;
            return this;
        }
        /// <summary>
        /// 失败
        /// </summary>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public ResponseOutput<T> NotOk(string msg = null, T data = default(T))
        {
            Success = false;
            Msg = msg;
            Data = data;
            return this;
        }
    }

    public static class ResponseOutput
    {
        /// <summary>
        /// 成功
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">数据</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static IResponseOutput Ok<T>(T data = default(T), string msg = null)
        {
            return new ResponseOutput<T>().Ok(data, msg);
        }
        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public static IResponseOutput Ok()
        {
            return Ok<string>();
        }
        /// <summary>
        /// 失败
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static IResponseOutput NotOk<T>(string msg = null, T data = default(T))
        {
            return new ResponseOutput<T>().NotOk(msg, data);
        }
        /// <summary>
        /// 失败
        /// </summary>
        /// <returns></returns>
        public static IResponseOutput NotOk()
        {
            return NotOk<string>();
        }
    }
}

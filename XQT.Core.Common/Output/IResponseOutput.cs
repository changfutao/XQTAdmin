using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQT.Core.Common.Output
{
    /// <summary>
    /// 响应数据输出接口
    /// </summary>
    public interface IResponseOutput
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get;}
        /// <summary>
        /// 消息
        /// </summary>
        public string? Msg { get; }
    }
    /// <summary>
    /// 响应数据输出泛型接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IResponseOutput<T>: IResponseOutput
    {
        /// <summary>
        /// 返回数据
        /// </summary>
       public T? Data { get; }
    }
}

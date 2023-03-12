using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQT.Core.Common
{
    /// <summary>
    /// 新增实体接口
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntityAdd<TKey>
    {
        /// <summary>
        /// 创建人Id
        /// </summary>
        TKey? CreatedUserId { get; set; }
        /// <summary>
        /// 创建人名字
        /// </summary>
        string? CreatedUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime? CreatedTime { get; set; }
    }
}

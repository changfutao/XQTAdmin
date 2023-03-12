using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQT.Core.Common
{
    /// <summary>
    /// 更新实体接口
    /// </summary>
    public interface IEntityUpdate<TKey>
    {
        /// <summary>
        /// 修改人Id
        /// </summary>
        TKey? ModifiedUserId { get; set; }
        /// <summary>
        /// 修改人名字
        /// </summary>
        string? ModifiedUserName { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        DateTime? ModifiedTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQT.Core.Common
{
    /// <summary>
    /// 新增实体
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class EntityAdd<TKey> : IEntityAdd<TKey>
    {
        /// <summary>
        /// 创建人Id
        /// </summary>
        public TKey? CreatedUserId { get; set; }
        /// <summary>
        /// 创建人名字
        /// </summary>
        public string? CreatedUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQT.Core.Common
{
    /// <summary>
    /// 更新实体
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class EntityUpdate<TKey> : IEntityUpdate<TKey>
    {
        /// <summary>
        /// 修改人Id
        /// </summary>
        public TKey? ModifiedUserId { get; set; }
        /// <summary>
        /// 修改人名字
        /// </summary>
        public string? ModifiedUserName { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifiedTime { get; set; }
    }
}

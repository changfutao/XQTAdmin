using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQT.Core.Common
{
    public class EntityFull : Entity<long>, IEntityAdd<long>, IEntityUpdate<long>, ITenant<long>, IEntitySoftDelete
    {
        /// <summary>
        /// 创建人Id
        /// </summary>
        public long? CreatedUserId { get; set; }
        /// <summary>
        /// 创建人名字
        /// </summary>
        public string? CreatedUserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatedTime { get; set; }
        /// <summary>
        /// 修改人Id
        /// </summary>
        public long? ModifiedUserId { get; set; }
        /// <summary>
        /// 修改人名字
        /// </summary>
        public string? ModifiedUserName { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? ModifiedTime { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 租户Id
        /// </summary>
        public long? TenantId { get; set; }
    }
}

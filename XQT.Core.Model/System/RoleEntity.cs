using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.Common;

namespace XQT.Core.Model
{
    /// <summary>
    /// 角色表
    /// </summary>
    [Comment("角色表")]
    public class RoleEntity: EntityFull
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Comment("角色名称")]
        public string Name { get; set; }
        /// <summary>
        /// 角色编码
        /// </summary>
        [Comment("角色编码")]
        public string Code { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Comment("备注")]
        public string? Remark { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        [Comment("是否启用")]
        public bool IsEnable { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        [Comment("排序")]
        public int? Sort { get; set; }
    }
}

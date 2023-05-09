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
    /// 角色菜单表
    /// </summary>
    [Comment("角色菜单表")]
    public class RoleMenuEntity: EntityAdd<long>
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        [Comment("角色Id")]
        public long RoleId { get; set; }
        /// <summary>
        /// 菜单Id
        /// </summary>
        [Comment("菜单Id")]
        public long MenuId { get; set; }
    }
}

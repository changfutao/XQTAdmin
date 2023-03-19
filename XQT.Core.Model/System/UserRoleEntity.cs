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
    /// 用户角色表
    /// </summary>
    [Comment("用户角色表")]
    public class UserRoleEntity : EntityAdd<long>
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        [Comment("用户Id")]
        public long UserId { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        [Comment("角色Id")]
        public long RoleId { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.Common;

namespace XQT.Core.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Comment("用户表")]
    public class UserEntity: EntityFull
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Comment("用户名")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Comment("密码")]
        public string Password { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [Comment("昵称")]
        public string? NickName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Comment("邮箱")]
        public string? Email { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        [Comment("用户状态")]
        public UserStatus UserStatus { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Comment("手机号码")]
        public string? Phone { get; set; }
        /// <summary>
        /// 头像Id
        /// </summary>
        [Comment("头像Id")]
        public long? AvatarId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Comment("备注")]
        public string? Remark { get; set; }
    }

    /// <summary>
    /// 用户状态
    /// </summary>
    public enum UserStatus
    {
        [Description("正常")]
        Normal = 1,
        [Description("锁定")]
        Lock
    }
}

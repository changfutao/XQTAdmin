using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.Common;

namespace XQT.Core.Model
{
    public class UserEntity: EntityFull
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string? NickName { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public UserStatus UserStatus { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string? Phone { get; set; }
        /// <summary>
        /// 头像Id
        /// </summary>
        public long AvatarId { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
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

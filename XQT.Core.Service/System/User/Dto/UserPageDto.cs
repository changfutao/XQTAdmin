using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.Model;

namespace XQT.Core.Service
{
    public class UserPageDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string? UserName { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        public UserStatus? UserStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQT.Core.Service
{
    /// <summary>
    /// 登录验证类
    /// </summary>
    public class AuthLoginDto
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required(ErrorMessage ="用户名必填")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage ="密码必填")]
        [MinLength(6, ErrorMessage ="密码最少6位")]
        public string PassWord { get; set; }
    }
}

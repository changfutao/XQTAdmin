using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.Common;
using XQT.Core.EntityFramework;
using XQT.Core.Model;

namespace XQT.Core.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserToken _userToken;
        private readonly XQTContext _context;

        public AuthService(IUserToken userToken, XQTContext context)
        {
            _userToken = userToken;
            _context = context;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="input">登录信息</param>
        /// <returns></returns>
        public async Task<IResponseOutput> LoginAsync(AuthLoginDto input)
        {
            var user = await _context.UserEntities.FirstOrDefaultAsync(a => a.UserName == input.UserName);
            if (user == null)
            {
               return ResponseOutput.NotOk<string>("用户名或密码错误");
            }
            if (!user.Password.Equals(input.PassWord))
            {
                ResponseOutput.NotOk<string>("用户名或密码错误");
            }
            var token = _userToken.Create(new Claim[]
            {
                new Claim(ClaimAttributes.UserId, user.Id.ToString()),
                new Claim(ClaimAttributes.UserName, user.UserName),
                new Claim(ClaimAttributes.UserNickName, user.NickName ?? ""),
            });
            return ResponseOutput.Ok(new { token });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.Common;
using XQT.Core.Common.Output;
using XQT.Core.Model;
using XQT.Core.Repository;

namespace XQT.Core.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseRepository<UserEntity> _baseUserRepository;
        private readonly IUserToken _userToken;

        public AuthService(IBaseRepository<UserEntity> baseUserRepository, IUserToken userToken)
        {
            _baseUserRepository = baseUserRepository;
            _userToken = userToken;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="input">登录信息</param>
        /// <returns></returns>
        public async Task<IResponseOutput> Login(AuthLoginDto input)
        {
            var user = await _baseUserRepository.FindAsync(a => a.UserName == input.UserName);
            if (user == null)
            {
                ResponseOutput.NotOk<string>("用户名或密码错误");
            }
            if (!user.Password.Equals(MD5Encrypt.MD5Encrypt32(input.PassWord)))
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

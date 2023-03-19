using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XQT.Core.Common.Output;
using XQT.Core.Service;

namespace XQT.Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="input">登录信息</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IResponseOutput> Login(AuthLoginDto input)
        {
            return await _authService.Login(input);
        }
    }
}

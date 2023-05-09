using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XQT.Core.Common;
using XQT.Core.Service;

namespace XQT.Core.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResponseOutput> GetPage(PageInput<UserPageDto> input)
        {
            return await _userService.GetPageAsync(input);
        }
    }
}

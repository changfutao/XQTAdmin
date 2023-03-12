using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace XQT.Core.Common
{
    public interface IUserToken
    {
        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="claims">信息</param>
        /// <returns></returns>
        string Create(IEnumerable<Claim> claims);

        /// <summary>
        /// 解析Token成Claim集合
        /// </summary>
        /// <param name="jwtToken"></param>
        /// <returns></returns>
        IEnumerable<Claim> Decode(string jwtToken);
    }
}

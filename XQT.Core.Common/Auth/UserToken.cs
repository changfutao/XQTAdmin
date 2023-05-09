using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XQT.Core.Common.Attributes;

namespace XQT.Core.Common
{
    /// <summary>
    /// Token操作类
    /// </summary>
    [SingleInstance]
    public class UserToken : IUserToken
    {
        private readonly JwtConfig _jwtConfig;

        public UserToken(JwtConfig jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }

        /// <summary>
        /// 生成Token
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        public string Create(IEnumerable<Claim> claims)
        {
            // 密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.SecurityKey));

            // 凭据
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 时间戳
            var timestamp = DateTime.Now.AddMinutes(_jwtConfig.Expires + _jwtConfig.RefreshExpires).ToTimestamp().ToString();

            claims = claims.Append(new Claim(ClaimAttributes.RefreshExpires, timestamp)).ToArray();

            // notBefore ? 开始时间?
            var token = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer, 
                audience: _jwtConfig.Audience, 
                claims: claims, 
                notBefore: DateTime.Now, // netBefore 表示JWT生效时间
                expires: DateTime.Now.AddMinutes(_jwtConfig.Expires), // 过期时间
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// 解析Token
        /// </summary>
        /// <param name="jwtToken"></param>
        /// <returns></returns>
        public IEnumerable<Claim> Decode(string jwtToken)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = jwtSecurityTokenHandler.ReadJwtToken(jwtToken);
            return jwtSecurityToken?.Claims ?? new List<Claim>();
        }
    }
}

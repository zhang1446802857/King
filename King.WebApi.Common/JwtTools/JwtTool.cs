using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace King.WebApi.Common.JwtTools
{
    public static class JwtTool
    {
        /// <summary>
        /// 生成JwtToken
        /// </summary>
        /// <returns></returns>
        public static string CreateToken()
        {
            IConfiguration build = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var iss = build["Jwt:Iss"] as string ?? "DefaultIss";
            var aud = build["Jwt:Aud"] as string ?? "DefaultAud";
            var key = build["Jwt:Key"] as string ?? "DefaultKey";

            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Aud,aud),
                new(JwtRegisteredClaimNames.Iss,iss),
                new(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                new(JwtRegisteredClaimNames.Iat,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                new(JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds()}"),
                new(JwtRegisteredClaimNames.Sub,"这是假设值0425"),
            };

            var keyCode = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var code = new SigningCredentials(keyCode, SecurityAlgorithms.HmacSha256);

            var jwtObj = new JwtSecurityToken(issuer: iss, claims: claims, signingCredentials: code);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(jwtObj);
            return jwtToken;
        }
    }
}
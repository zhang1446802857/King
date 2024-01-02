using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SqlSugar.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace King.WebApi.Extension.Module
{
    public static class BearerModule
    {
        /// <summary>
        /// Bearer认证模块
        /// </summary>
        /// <param name="services"></param>
        public static void AddBearerModule(this IServiceCollection services)
        {
            services.AddAuthentication(s =>
            {
                s.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(b =>
            {
                IConfiguration build = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var iss = build["Jwt:Iss"] as string ?? "DefaultIss";
                var aud = build["Jwt:Aud"] as string ?? "DefaultAud";
                var key = build["Jwt:Key"] as string ?? "DefaultKey";
                var keyCode = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

                b.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    RequireExpirationTime = true,
                    IssuerSigningKey = keyCode,
                    ValidIssuer = iss,
                    ValidAudience = aud,
                    ClockSkew = TimeSpan.FromSeconds(30),
                };
                b.Events = new JwtBearerEvents()
                {
                    //当JWT Bearer认证失败时，即请求未包含有效的JWT令牌或令牌验证失败，该事件会被触发
                    OnChallenge = context =>
                    {
                        throw new HttpException($"Token无效{context.ErrorDescription},未包含Token或Token验证失败!", 401);
                    },
                    //当JWT Bearer认证过程中出现异常时，例如令牌过期、签名验证失败等情况，该事件会被触发
                    OnAuthenticationFailed = context =>
                    {
                        var jwtHandler = new JwtSecurityTokenHandler();
                        var token = context.Request.Headers["Authorization"].ObjToString().Replace("Bearer ", string.Empty).Replace("bearer", string.Empty).Trim();

                        var jwtToken = jwtHandler.ReadJwtToken(token);

                        if (jwtToken.Issuer != "发行人")
                        {
                            throw new HttpException($"Token无效:ISSUER IS WRONG!", 401);
                        }
                        else if (jwtToken.Audiences.FirstOrDefault() != "受众人")
                        {
                            throw new HttpException($"Token无效:AUDIENCE IS WRONG!", 401);
                        }
                        else if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            throw new HttpException($"Token无效:TOKEN-EXPPIRED!", 401);
                        }
                        return Task.CompletedTask;
                    }
                };
            });
        }

        /// <summary>
        /// 开启权限认证
        /// </summary>
        /// <param name="app"></param>
        public static void UseBearerModule(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
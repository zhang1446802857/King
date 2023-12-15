using King.WebApi.Extension.Enum;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace King.WebApi.Extension.Module
{
    public static class SwaggerModule
    {
        public static void AddSwaggerModule(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(s =>
            {
                typeof(Versions).GetEnumNames().ToList().ForEach(v =>
                {
                    int version = (int)Enum.Versions.Parse(typeof(Versions), v);
                    var description = string.Empty;
                    switch (version)
                    {
                        case 0:
                            description = "开发版本API";
                            break;

                        case 1:
                            description = "正式版本API";
                            break;

                        case 2:
                            description = "测试(自定义)版本API";
                            break;
                    }
                    s.SwaggerDoc(v, new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Version = v,
                        Description = description,
                        Title = description
                    });
                    var basePath = AppDomain.CurrentDomain.BaseDirectory;
                    var xmlPath = Path.Combine(basePath, "Readme.xml");
                    s.IncludeXmlComments(xmlPath);
                });

                s.OperationFilter<AddResponseHeadersFilter>();
                s.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                s.OperationFilter<SecurityRequirementsOperationFilter>();
                s.AddSecurityDefinition("oauth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Description = "Jwt授权(Bearer+空格+Token)",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Name = "JwtAuthoriza"
                });
            });

            services.AddAuthentication(s =>
            {
                s.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                s.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(b =>
            {
                IConfiguration build = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var iss = build["Jwt:Iss"] as string ?? "DefaultIss";
                var aud = build["Jwt:Aud"] as string ?? "DefaultAud";
                var key = build["Jwt:Key"] as string ?? "DefaultKey";
                var keyCode = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var code = new SigningCredentials(keyCode, SecurityAlgorithms.HmacSha256);

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
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void UseSwaggerModule(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                typeof(Versions).GetEnumNames().ToList().ForEach(v =>
                {
                    int version = (int)Enum.Versions.Parse(typeof(Versions), v);
                    var description = string.Empty;
                    switch (version)
                    {
                        case 0:
                            description = "开发版本API";
                            break;

                        case 1:
                            description = "正式版本API";
                            break;

                        case 2:
                            description = "测试(自定义)版本API";
                            break;
                    }
                    s.SwaggerEndpoint($"swagger/{v}/swagger.json", $"{description}");
                    s.RoutePrefix = string.Empty;
                });
            });

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
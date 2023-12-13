using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King.WebApi.Extension
{
    public static class SwaggerModule
    {
        public static void AddSwaggerModule(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(s =>
            {
                typeof(Version).GetEnumNames().ToList().ForEach(v =>
                {
                    int version = (int)Enum.Parse(typeof(Version), v);
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
                        Title=description
                    });
                    var basePath = AppDomain.CurrentDomain.BaseDirectory;
                    var xmlPath = Path.Combine(basePath,"Readme.xml");
                    s.IncludeXmlComments(xmlPath);
                });
            });
        }

        public static void UseSwaggerModule(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                typeof(Version).GetEnumNames().ToList().ForEach(v =>
                {
                    int version = (int)Enum.Parse(typeof(Version), v);
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
                    s.SwaggerEndpoint($"swagger/{v}/swagger.json",$"{description}");
                    s.RoutePrefix=string.Empty;
                });
            });
        }

        #region Version
        private enum Version
        {
            Dev = 0,
            Pro = 1,
            Test = 2
        }
        #endregion
    }
}

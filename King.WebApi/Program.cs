using Autofac;
using Autofac.Extensions.DependencyInjection;
using King.WebApi.Extension.Module;

namespace King.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerModule();//swagger
            builder.Services.AddSqlSugarModule();//sqlsugar
            builder.Services.AddNlogModule();//nlog
            builder.Services.AddGlobalExceptionModule();//全局异常
            builder.Services.AddActionFilterModule();//过滤器

            #region autofac

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(B =>
            {
                B.RegisterModule(new AutofacModule());
            });

            #endregion autofac

            var app = builder.Build();

            app.UseSwaggerModule();

            app.MapControllers();
            app.Run();
        }
    }
}
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
            builder.Services.AddGlobalExceptionModule();//È«¾ÖÒì³£

            #region autofac
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()) ;
            builder.Host.ConfigureContainer<ContainerBuilder>(B =>
            {
                B.RegisterModule(new AutofacModule());
            });
            #endregion

            var app = builder.Build();


            app.UseSwaggerModule();

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}

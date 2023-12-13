using Autofac;
using Autofac.Extensions.DependencyInjection;
using King.WebApi.Extension;

namespace King.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSwaggerModule();//swagger
            builder.Services.AddSqlSugarModule();//sqlsugar

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

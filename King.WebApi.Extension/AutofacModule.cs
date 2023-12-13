using Autofac;
using System.Reflection;

namespace King.WebApi.Extension
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //程序集目录
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

            //服务层and仓储层位置
            var repositoryPath = Path.Combine(basePath, "King.WebApi.Repository.dll");
            var servicePath = Path.Combine(basePath, "King.WebApi.Service.dll");

            //加载程序集
            var repository = Assembly.LoadFrom(repositoryPath);
            var service = Assembly.LoadFrom(servicePath);

            //注入
            builder.RegisterAssemblyTypes(service, repository)
                .AsImplementedInterfaces();
        }
    }
}
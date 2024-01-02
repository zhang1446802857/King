using King.WebApi.Extension.Filter;
using Microsoft.Extensions.DependencyInjection;

namespace King.WebApi.Extension.Module
{
    public static class GlobalExceptionModule
    {
        /// <summary>
        /// 添加(程序级别)全局异常拦截记录过滤器
        /// </summary>
        /// <param name="services"></param>
        public static void AddGlobalExceptionModule(this IServiceCollection services)
        {
            services.AddControllers(e =>
            {
                e.Filters.Add<GlobalExceptionFilter>();
            });
        }
    }
}
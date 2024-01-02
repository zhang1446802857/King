using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;

namespace King.WebApi.Extension.Module
{
    public static class NlogModule
    {
        /// <summary>
        /// 添加Nlog日志记录
        /// </summary>
        /// <param name="services"></param>
        public static void AddNlogModule(this IServiceCollection services)
        {
            services.AddLogging(log =>
            {
                log.AddNLog();
            });
        }
    }
}
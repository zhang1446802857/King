using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;

namespace King.WebApi.Extension.Module
{
    public static class NlogModule
    {
        public static void AddNlogModule(this IServiceCollection services)
        {
            services.AddLogging(log =>
            {
                log.AddNLog();
            });
        }
    }
}
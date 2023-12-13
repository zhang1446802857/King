using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;

namespace King.WebApi.Extension
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

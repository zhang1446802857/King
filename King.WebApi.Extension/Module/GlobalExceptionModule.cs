using King.WebApi.Extension.Filter;
using Microsoft.Extensions.DependencyInjection;

namespace King.WebApi.Extension.Module
{
    public static class GlobalExceptionModule
    {
        public static void AddGlobalExceptionModule(this IServiceCollection services)
        {
            services.AddControllers(e =>
            {
                e.Filters.Add<GlobalExceptionFilter>();
            });
        }
    }
}
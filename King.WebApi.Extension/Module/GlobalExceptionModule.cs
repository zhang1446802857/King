using King.WebApi.Extension.Filter;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

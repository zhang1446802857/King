using King.WebApi.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace King.WebApi.Extension.Filter
{
    public class ActionFilter(ILoggingService loggingService) : IAsyncActionFilter
    {
        private readonly ILoggingService _loggingService = loggingService;
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await _loggingService.InsertAsync(new Model.Models.LoggingModel
            {
                Content = "日志",
                CreateTime = DateTime.Now,
                Level = 1,
                Name = "测试",
                Source = context.HttpContext.Request.Path
            });
            await next();
        }
    }
    public static class ActionFilterModule
    {
        public static void AddActionFilterModule(this IServiceCollection services)
        {
            services.AddControllers(option =>
            {
                option.Filters.Add(typeof(ActionFilter));
            });
        }
    }
}

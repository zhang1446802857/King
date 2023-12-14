using King.WebApi.Model.Models;
using King.WebApi.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace King.WebApi.Extension.Filter
{
    public class ActionFilter(ILoggingService loggingService) : IAsyncActionFilter
    {
        private readonly ILoggingService _loggingService = loggingService;
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var result = await next();
            var log = new LogModel
            {
                Content = result.Exception == null ? "操作记录" : result.Exception.Message,
                CreateTime = DateTime.Now,
                Level = result.Exception == null ? 0 : 1,
                Controller = result.HttpContext.Request.RouteValues["controller"] as string ?? "",
                Action = result.HttpContext.Request.RouteValues["action"] as string ?? "",
                Source = result.HttpContext.Request.Path,
                Name = "测试用户"
            };
            await _loggingService.InsertAsync(log);
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

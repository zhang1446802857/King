using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King.WebApi.Extension.Filter
{
    public class GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger) : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger = logger;

        public void OnException(ExceptionContext context)
        {
            StringBuilder exMsg = new();
            exMsg.AppendLine($"【异常方法:】{context.HttpContext.Request.Path}");
            exMsg.AppendLine($"【请求类型:】{context.HttpContext.Request.Method}");
            exMsg.AppendLine($"【异常错误:】{context.Exception.Message}");
            exMsg.AppendLine($"【堆栈跟踪:】{context.Exception.StackTrace}");
            _logger.LogError(exMsg.ToString());
            context.Result = new ObjectResult(new { error = context.Exception.Message })
            {
                StatusCode = 400
            };
            context.ExceptionHandled = true;
        }
    }
}

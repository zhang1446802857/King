using King.WebApi.Model.Entitys;
using King.WebApi.Model.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Text;

namespace King.WebApi.Extension.Filter
{
    /// <summary>
    /// 全局异常拦截处理
    /// </summary>
    public class GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger) : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionFilter> _logger = logger;

        /// <summary>
        /// 全局拦截程序异常
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            StringBuilder exMsg = new();
            exMsg.AppendLine($"【异常方法:】{context.HttpContext.Request.Path}");
            exMsg.AppendLine($"【请求类型:】{context.HttpContext.Request.Method}");
            exMsg.AppendLine($"【异常错误:】{context.Exception.Message}");
            exMsg.AppendLine($"【堆栈跟踪:】{context.Exception.StackTrace}");
            _logger.LogError(exMsg.ToString());

            var result = new R
            {
                Code = StateCode.ERROR,
                Data = null,
                Msg = context.Exception.Message
            };

            context.Result = new ObjectResult(result)
            {
                StatusCode = 400
            };

            context.ExceptionHandled = true;
        }
    }
}
using King.WebApi.Model.Entitys;
using King.WebApi.Model.Enum;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace King.WebApi.Extension.Module
{
    public static class AopModule
    {
        /// <summary>
        /// 统一添加中间件
        /// 1.捕捉中间件级别异常
        /// </summary>
        /// <param name="builder"></param>
        public static void UseAopModule(this IApplicationBuilder builder)
        {
            //添加中间件
            builder.Use(async (context, next) =>
            {
                try
                {
                    await next.Invoke(context);
                }
                catch (HttpException ex)
                {
                    //过滤中间件异常
                    context.Response.StatusCode = ex.StatusCode;
                    context.Response.ContentType = "application/json";
                    var errorResponse = new R
                    {
                        Code = StateCode.ERROR,
                        Data = null,
                        Msg = ex.Message
                    };
                    var jsonErrorResponse = JsonConvert.SerializeObject(errorResponse);
                    await context.Response.WriteAsync(jsonErrorResponse);
                }
            });
        }
    }

    #region 自定义错误异常类

    public class HttpException(string msg, int code = 400) : Exception(msg)
    {
        public int StatusCode { get; } = code switch
        {
            400 => 400,
            401 => 401,
            404 => 404,
            _ => 500,// 默认状态码
        };
    }

    #endregion 自定义错误异常类
}
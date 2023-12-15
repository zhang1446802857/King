using King.WebApi.Model.Enum;

namespace King.WebApi.Model.Entitys
{
    public class R
    {
        /// <summary>
        /// 请求状态码
        /// </summary>
        public StateCode Code { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public string? Data { get; set; }

        /// <summary>
        /// 返回消息体
        /// </summary>
        public string? Msg { get; set; }
    }
}
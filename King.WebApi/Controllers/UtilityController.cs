

namespace King.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilityController : ControllerBase
    {
        /// <summary>
        /// 生成四层类[仓储-服务]
        /// </summary>
        /// <param name="name">文件名</param>
        /// <param name="model">实体名</param>
        /// <returns></returns>
        [HttpGet]
        [RouteFilter(Versions.Dev, "CodeGenerationClass")]
        public R CodeGenerationClass(string name, string model)
        {
            ScribanTool.CodeGenerationClass(name, model);
            return new R
            {
                Code = Model.Enum.StateCode.OK,
                Data = null,
                Msg = "操作成功"
            };
        }
    }
}

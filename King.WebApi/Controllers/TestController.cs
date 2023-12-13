using King.WebApi.Extension.Filter;
using King.WebApi.Model.Models;
using King.WebApi.Service.IService;
using Microsoft.AspNetCore.Mvc;
using King.WebApi.Extension.Enum;

namespace King.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public TestController(ITestService testService, ILogger<TestController> logger)
        {
            _testService = testService;
            _logger = logger;
        }
        private readonly ILogger<TestController> _logger;
        private readonly ITestService _testService;

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Routes(Versions.Dev)]
        public async Task<bool> insert()
        {
            var result = await _testService.InsertAsync(new TestModel
            {
                Description = "Test",
                Name = "赵云"
            });
            return result;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("query")]
        public async Task<List<TestModel>> query()
        {
            return await _testService.QueryAsync();
        }
    }
}
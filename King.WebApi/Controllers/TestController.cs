using King.WebApi.Model.Models;
using King.WebApi.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace King.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        private readonly ITestService _testService;

        /// <summary>
        /// 新增
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> insert()
        {
            var result = await _testService.InsertAsync(new TestModel
            {
                Description = "Test",
                Name = "Test1"
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
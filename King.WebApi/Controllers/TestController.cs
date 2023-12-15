namespace King.WebApi.Controllers
{
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
        [RouteFilter(Versions.Dev)]
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
        [HttpPost]
        [RouteFilter(Versions.Dev, "Query")]
        public async Task<List<TestModel>> query()
        {
            return await _testService.QueryAsync();
        }

        [HttpPost]
        [RouteFilter(Versions.Dev, "CodeGenerationClass")]
        public void CodeGenerationClass(string name, string model)
        {
            ScribanTool.CodeGenerationClass(name, model);
        }
    }
}
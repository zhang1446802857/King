namespace King.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController(ILoggingService loggingService) : ControllerBase
    {
        private readonly ILoggingService _loggingService = loggingService;

        [HttpGet]
        [RouteFilter(Versions.Dev, "GetLogs")]
        public async Task<List<LogModel>> GetLogs()
        {
            return await _loggingService.QueryAsync();
        }
    }
}
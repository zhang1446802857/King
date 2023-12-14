using King.WebApi.Model.Models;
using King.WebApi.Repository.IRepository;
using King.WebApi.Service.IService;

namespace King.WebApi.Service.Service
{
    public class LoggingService : BaseService<LoggingModel>, ILoggingService
    {
        public LoggingService(IBaseRepository<LoggingModel> baseRepository):base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
        private readonly IBaseRepository<LoggingModel> _baseRepository;   
    }
}

using King.WebApi.Model.Models;
using King.WebApi.Repository.IRepository;
using King.WebApi.Service.IService;

namespace King.WebApi.Service.Service
{
    public class LoggingService : BaseService<LogModel>, ILoggingService
    {
        public LoggingService(IBaseRepository<LogModel> baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        private readonly IBaseRepository<LogModel> _baseRepository;
    }
}
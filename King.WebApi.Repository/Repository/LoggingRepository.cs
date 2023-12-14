using King.WebApi.Model.Models;
using King.WebApi.Repository.IRepository;
using SqlSugar;

namespace King.WebApi.Repository.Repository
{
    public class LoggingRepository : BaseRepository<LoggingModel>, ILoggingRepository
    {
        public LoggingRepository(ISqlSugarClient db) : base(db)
        {
        }
    }
}

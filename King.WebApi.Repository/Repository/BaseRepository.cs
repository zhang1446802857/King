using King.WebApi.Repository.IRepository;
using SqlSugar;

namespace King.WebApi.Repository.Repository
{
    public class BaseRepository<T> : SimpleClient<T>, IBaseRepository<T> where T : class, new()
    {
        public BaseRepository(ISqlSugarClient db)
        {
            base.Context = db;
            _db = db;
        }

        private readonly ISqlSugarClient _db;

        public async Task<bool> AddAsync(T entity)
        {
            return await base.InsertAsync(entity);
        }

        public async Task<List<T>> QueryAsync()
        {
            return await base.GetListAsync();
        }
    }
}
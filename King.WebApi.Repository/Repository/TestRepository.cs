using King.WebApi.Model.Models;
using King.WebApi.Repository.IRepository;
using SqlSugar;

namespace King.WebApi.Repository.Repository
{
    public class TestRepository : BaseRepository<TestModel>, ITestRepository
    {
        public TestRepository(ISqlSugarClient db) : base(db)
        {
        }
    }
}
using King.WebApi.Model.Models;
using King.WebApi.Repository.IRepository;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King.WebApi.Repository.Repository
{
    public class TestRepository : BaseRepository<TestModel>, ITestRepository
    {
        public TestRepository(ISqlSugarClient db) : base(db)
        {
        }
    }
}

using King.WebApi.Model.Models;
using King.WebApi.Repository.IRepository;
using King.WebApi.Repository.Repository;
using King.WebApi.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King.WebApi.Service.Service
{
    public class TestService : BaseService<TestModel>, ITestService
    {
        public TestService(IBaseRepository<TestModel> baseRepository):base(baseRepository)
        {
            _baseRepository = baseRepository;
        }
        private readonly IBaseRepository<TestModel> _baseRepository;   
    }
}

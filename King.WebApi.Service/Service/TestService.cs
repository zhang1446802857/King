using King.WebApi.Model.Models;
using King.WebApi.Repository.IRepository;
using King.WebApi.Service.IService;

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

using King.WebApi.Model.Models;
using King.WebApi.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King.WebApi.Repository.IRepository
{
    public interface ITestRepository:IBaseRepository<TestModel>
    {
    }
}

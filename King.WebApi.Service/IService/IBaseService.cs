using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace King.WebApi.Service.IService
{
    public interface IBaseService<T>where T : class
    {
        Task<bool> InsertAsync(T entity);

        Task<List<T>> QueryAsync();
    }
}

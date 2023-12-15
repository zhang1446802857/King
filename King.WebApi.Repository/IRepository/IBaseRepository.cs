namespace King.WebApi.Repository.IRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<bool> AddAsync(T entity);

        Task<List<T>> QueryAsync();
    }
}
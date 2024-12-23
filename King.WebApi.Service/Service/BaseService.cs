﻿using King.WebApi.Repository.IRepository;
using King.WebApi.Service.IService;

namespace King.WebApi.Service.Service
{
    public class BaseService<T>(IBaseRepository<T> baseRepository) : IBaseService<T> where T : class, new()
    {
        private readonly IBaseRepository<T> _baseRepository = baseRepository;

        public async Task<bool> InsertAsync(T entity)
        {
            return await _baseRepository.AddAsync(entity);
        }

        public async Task<List<T>> QueryAsync()
        {
            return await _baseRepository.QueryAsync();
        }
    }
}
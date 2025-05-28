using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Repository;

namespace Backend.Business
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> repository;
        public GenericService(IGenericRepository<T> repository)
        {
            this.repository = repository;
        }
        public async Task<T> AddAsync(T entity)
        {
            return await repository.AddAsync(entity);
        }

        public async Task<T> DeleteAsync(Guid id)
        {
            return await  repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<T> UpdateAsync(Guid id, T entity)
        {
            return await repository.UpdateAsync(id, entity);
        }
    }
}
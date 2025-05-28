

using Backend.Data;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business
{
    public class GenericRepository<T>:IGenericRepository<T> where T:class
    {
        private readonly EMSDbContext eMSDbContext;
        private readonly DbSet<T> dbSet;
        public GenericRepository(EMSDbContext eMSDbContext)
        {
            this.eMSDbContext = eMSDbContext;
            dbSet = eMSDbContext.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            var user = typeof(T).GetProperty("Id");
            if (user != null)
            {
                await dbSet.AddAsync(entity);
                await eMSDbContext.SaveChangesAsync();
                return entity;
            }
            return null;
        }


        public async Task<T> DeleteAsync(Guid id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                eMSDbContext.Remove(entity);
                await eMSDbContext.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var checkedId = await dbSet.FindAsync(id);
            if (checkedId == null)
            {
                return null;
            }
            return checkedId;
        }

        public async Task<T> UpdateAsync(Guid id,T entity)
        {
            var existingEntity = await dbSet.FindAsync(id);
            if (existingEntity != null)
            {
                eMSDbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
                await eMSDbContext.SaveChangesAsync();
                return entity;
            }
            return null;
        }
    }
}
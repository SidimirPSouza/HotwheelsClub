using HotwheelsClub.Data;
using HotwheelsClub.Repository.Entity;
using HotwheelsClub.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotwheelsClub.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T: BaseEntity 
    {
        public readonly DbContext _DbContext;
        public readonly DbSet<T> _DbSet;
        public BaseRepository(DbContext DBContext) 
        {
            _DbContext = DBContext;
            _DbSet = DBContext.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _DbSet
            .ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _DbSet
            .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<T> AddAsync(T entity)
        {
            await _DbSet.AddAsync(entity);
            await _DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _DbSet.Update(entity);
            await _DbContext.SaveChangesAsync();
            return entity;
        }
        
        public async Task<bool> DeleteByIdAsync(int id)
        {
            T t = await GetByIdAsync(id);
            if (t == null)
            {
                throw new Exception($"Hotwheels com o ID: {id} não foi encontrada no banco de dados");
            }

            _DbContext.Remove(t);
            await _DbContext.SaveChangesAsync();
            return true;
        }
    }
}

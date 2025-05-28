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

        public async Task<List<T>> GetAll()
        {
            return await _DbSet
            // .Include(x => x.Members)
            .ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _DbSet
            // .Include(x => x.Members)
            .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<T> Add(T entity)
        {
            await _DbContext.AddAsync(entity);
            await _DbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _DbSet.Update(entity);
            await _DbContext.SaveChangesAsync();
            return entity;
        }
        
        public async Task<bool> DeleteById(int id)
        {
            T t = await GetById(id);
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

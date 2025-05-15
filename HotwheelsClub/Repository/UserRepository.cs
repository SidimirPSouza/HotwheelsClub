using HotwheelsClub.Data;
using HotwheelsClub.Models;
using HotwheelsClub.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotwheelsClub.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly HotwheelsClubDBContext _DbContext;
        public UserRepository(HotwheelsClubDBContext hotwheelsClubDBContext) 
        {
            _DbContext = hotwheelsClubDBContext;
        }
        public async Task<List<UserModel>> GetAllUser()
        {
            return await _DbContext.User.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _DbContext.User.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<UserModel> Add(UserModel user)
        {
            await _DbContext.User.AddAsync(user);
            await _DbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userId = await GetById(id);
            if (userId == null)
            {
                throw new Exception($"Hotwheels com o ID: {id} não foi encontrada no banco de dados");
            }

            userId.Name = user.Name;
            

            _DbContext.User.Update(userId);
            await _DbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteById(int id)
        {
            UserModel userId = await GetById(id);
            if(userId == null)
            {
                throw new Exception($"Hotwheels com o ID: {id} não foi encontrada no banco de dados");
            }

            _DbContext.Remove(userId);
            await _DbContext.SaveChangesAsync();
            return true;
        }
    }
}

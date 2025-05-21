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

        public async Task<UserDto> Add(UserRequestDto dto)
        {
            var user = new UserModel
            {
                Name = dto.Name,
                MonthlyFees = dto.MonthlyFees,
            };

            await _DbContext.User.AddAsync(user);
            await _DbContext.SaveChangesAsync();

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                MonthlyFees = user.MonthlyFees,
                ClubId = user.ClubId
            };
        }

        public async Task<UserDto> Update(UserUpdateDto dto, int id)
        {
            UserModel userId = await GetById(id);
            if (userId == null)
            {
                throw new Exception($"Hotwheels com o ID: {id} não foi encontrada no banco de dados");
            }

            userId.Name = dto.Name;
            userId.ClubId = dto.ClubId;
            userId.MonthlyFees = dto.MonthlyFees;

            _DbContext.User.Update(userId);
            await _DbContext.SaveChangesAsync();
            return new UserDto
            {
                Id = userId.Id,
                Name = userId.Name,
                ClubId = userId.ClubId,
                MonthlyFees = userId.MonthlyFees
            };
        }
        public async Task<UserDto> Transference(UserTransferDto dto, int id)
        {
            UserModel userId = await GetById(id);
            if (userId == null)
            {
                throw new Exception($"Hotwheels com o ID: {id} não foi encontrada no banco de dados");
            }

            userId.ClubId = dto.ClubId;

            _DbContext.User.Update(userId);
            await _DbContext.SaveChangesAsync();
            return new UserDto
            {
                Id = userId.Id,
                ClubId = userId.ClubId,
            };
        }
        // public async Task<UserDto> payment(UserUpdateDto dto, int id)
        // {
        //     UserModel userId = await GetById(id);
        //     if (userId == null)
        //     {
        //         throw new Exception($"Hotwheels com o ID: {id} não foi encontrada no banco de dados");
        //     }

        //     userId.Name = dto.Name;
        //     userId.ClubId = dto.ClubId;
        //     userId.MonthlyFees = dto.MonthlyFees;

        //     _DbContext.User.Update(userId);
        //     await _DbContext.SaveChangesAsync();
        //     return new UserDto
        //     {
        //         Id = userId.Id,
        //         Name = userId.Name,
        //         ClubId = userId.ClubId,
        //         MonthlyFees = userId.MonthlyFees
        //     };
        // }

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

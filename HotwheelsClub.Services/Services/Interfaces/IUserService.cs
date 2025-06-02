using HotwheelsClub.Service.Models;

namespace HotwheelsClub.Service.Interface
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllUserAsync();
        Task<UserModel> GetUserByIdAsync(int id);
        Task<UserModel> AddUserAsync(UserModel user);
        Task<UserModel> UpdateUserAsync(UserModel user);
        Task<bool> DeleteUserById(int id);
    }
}

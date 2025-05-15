using HotwheelsClub.Models;

namespace HotwheelsClub.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUser();
        Task<UserModel> GetById(int id);
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> DeleteById(int id);
    }
}

using HotwheelsClub.Service.Models;

namespace HotwheelsClub.Service.Interface
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllUser();
        Task<UserModel> GetById(int id);
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user);
        Task<bool> DeleteById(int id);
    }
}

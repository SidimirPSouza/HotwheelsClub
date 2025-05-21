using HotwheelsClub.Models;

namespace HotwheelsClub.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUser();
        Task<UserModel> GetById(int id);
        Task<UserDto> Add(UserRequestDto dto);
        Task<UserDto> Update(UserUpdateDto dto, int id);
        Task<UserDto> Transference(UserTransferDto dto, int id);
        Task<bool> DeleteById(int id);
    }
}

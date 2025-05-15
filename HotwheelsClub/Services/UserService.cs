using HotwheelsClub.Models;
using HotwheelsClub.Repository.Interface;
using HotwheelsClub.Service.Interface;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public Task<UserModel> Add(UserModel user)
    {
        return _userRepository.Add(user);
    }

    public Task<bool> DeleteById(int id)
    {
        return _userRepository.DeleteById(id);
    }

    public Task<List<UserModel>> GetAllUser()
    {
        return _userRepository.GetAllUser();
    }

    public Task<UserModel> GetById(int id)
    {
        return _userRepository.GetById(id);
    }

    public Task<UserModel> Update(UserModel user, int id)
    {
        return _userRepository.Update(user,id);
    }
}

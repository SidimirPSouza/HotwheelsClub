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
    public Task<UserDto> Add(UserRequestDto dto)
    {
        return _userRepository.Add(dto);
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

    public Task<UserDto> Update(UserUpdateDto dto, int id)
    {
        return _userRepository.Update(dto, id);
    }

    public async Task<UserDto> Transference(UserTransferDto dto, int id)
    {
        UserModel userId = await GetById(id);
        if (userId == null)
        {
            throw new Exception($"Hotwheels com o ID: {id} não foi encontrada no banco de dados");
        }

        if (userId.MonthlyFees)
        {
            return await _userRepository.Transference(dto, id);
        }
        else
        {
            throw new Exception($"O usuario não pode ser transferido pois não está com o pagamento em dia");
        }
    }
}

using HotwheelsClub.Repository;
using HotwheelsClub.Repository.Entity;
using HotwheelsClub.Repository.Interface;
using HotwheelsClub.Service.Interface;
using HotwheelsClub.Service.Models;

namespace HotwheelsClub.Service
{ 
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserModel>> GetAllUserAsync()
        {
            var userEntity = await _userRepository.GetAllAsync();
            return userEntity.Select(item =>
                           new UserModel
                           {
                               Id = item.Id,
                               Name = item.Name,
                               MonthlyFees = item.MonthlyFees,
                               ClubId = item.ClubId,
                           }).ToList();
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            var userEntity = await _userRepository.GetByIdAsync(id);
            if (userEntity == null)
                throw new Exception($"Usuario com o ID: {id} não foi encontrado no banco de dados");
            return new UserModel
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                MonthlyFees = userEntity.MonthlyFees,
                ClubId = userEntity.ClubId,
            };
        }
        public async Task<UserModel> AddUserAsync(UserModel user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                MonthlyFees = user.MonthlyFees,
                ClubId = user.ClubId,
            };

            var created = await _userRepository.AddAsync(userEntity);
            return user;
        }



        public async Task<UserModel> UpdateUserAsync(UserModel user)
        {
            var userEntity = await _userRepository.GetByIdAsync(user.Id);
            if (userEntity == null)
                throw new Exception($"Usuario com o ID: {user.Id} não foi encontrada no banco de dados");
            userEntity.Id = user.Id;
            userEntity.Name = user.Name;
            userEntity.MonthlyFees = user.MonthlyFees;
            userEntity.ClubId = user.ClubId;
            await _userRepository.UpdateAsync(userEntity);
            return user;
        }

        public Task<bool> DeleteUserById(int id)
        {
            return _userRepository.DeleteByIdAsync(id);
        }
    }
}
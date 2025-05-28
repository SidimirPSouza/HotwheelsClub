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
        public async Task<UserModel> Add(UserModel user)
        {
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Name = user.Name,
                MonthlyFees = user.MonthlyFees,
                ClubId = user.ClubId,
            };

            var created = await _userRepository.Add(userEntity);
            return user;
        }

        public Task<bool> DeleteById(int id)
        {
            return _userRepository.DeleteById(id);
        }

        public async Task<List<UserModel>> GetAllUser()
        {
            var userEntity = await _userRepository.GetAll();
            var userModel = new List<UserModel>();
            return userEntity.Select(item =>
                           new UserModel
                           {
                               Id = item.Id,
                               Name = item.Name,
                               MonthlyFees = item.MonthlyFees,
                               ClubId = item.ClubId,
                           }).ToList();
        }

        public async Task<UserModel> GetById(int id)
        {
            var userEntity = await _userRepository.GetById(id);
            var userModel = new UserModel();
            return new UserModel
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                MonthlyFees = userEntity.MonthlyFees,
                ClubId = userEntity.ClubId,
            };
        }

        public async Task<UserModel> Update(UserModel user)
        {
            var userEntity = await _userRepository.GetById(user.Id);
            if (userEntity == null)
                throw new Exception($"Hotwheels com o ID: {user.Id} não foi encontrada no banco de dados");
            userEntity.Id = user.Id;
            userEntity.Name = user.Name;
            userEntity.MonthlyFees = user.MonthlyFees;
            userEntity.ClubId = user.ClubId;
            await _userRepository.Update(userEntity);
            return user;
        }
    }
}
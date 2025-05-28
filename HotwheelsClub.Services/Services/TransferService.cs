using HotwheelsClub.Repository.Entity;
using HotwheelsClub.Repository.Interface;
using HotwheelsClub.Service.Interface;
using HotwheelsClub.Service.Models;

namespace HotwheelsClub.Service 
{ 
    public class TransferService : ITransferService
    {
        // private readonly IClubService _clubService;
        private readonly IHotwheelsRepository _hotwheelsRepository;
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        public TransferService(IClubService clubService, IHotwheelsRepository hotwheelsRepository, IUserService userService, IUserRepository userRepository)
        {
            // _clubService = clubService;
            _hotwheelsRepository = hotwheelsRepository;
            _userService = userService;
            _userRepository = userRepository;
        }

        public async Task<HotwheelsModel> TransferHotwheels(HotwheelsTransferModel transfer)
        {
            HotwheelsEntity hotwheelsId = await _hotwheelsRepository.GetById(transfer.Id);
            if (hotwheelsId == null)
            {
                throw new Exception($"Hotwheels com o ID: {transfer.Id} não foi encontrada no banco de dados");
            }
            hotwheelsId.ProprietorId = transfer.ProprietorId;
            await _hotwheelsRepository.Update(hotwheelsId);
            return new HotwheelsModel
            {
                Id = hotwheelsId.Id,
                Name = hotwheelsId.Name,
                ProprietorId = hotwheelsId.ProprietorId,
                Color = hotwheelsId.Color,
                Price = hotwheelsId.Price,
                Model = hotwheelsId.Model,
                Year = hotwheelsId.Year,
            };
        }
    
        public async Task<UserModel> TransferUser(UserTransferModel transfer)
        {
            UserEntity userId = await _userRepository.GetById(transfer.Id);
            if (userId == null)
            {
                throw new Exception($"Hotwheels com o ID: {transfer.Id} não foi encontrada no banco de dados");
            }

            if (userId.MonthlyFees)
            {
                userId.ClubId = transfer.ClubId;
                await _userRepository.Update(userId);
                return new UserModel
                {
                    Id = userId.Id,
                    Name = userId.Name,
                    MonthlyFees = userId.MonthlyFees,
                    ClubId = userId.ClubId,
                };
            }
            else
            {
                throw new Exception($"O usuario não pode ser transferido pois não está com o pagamento em dia");
            }
        }
    }
}
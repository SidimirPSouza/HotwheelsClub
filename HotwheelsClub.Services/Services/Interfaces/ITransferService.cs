using HotwheelsClub.Service.Models;

namespace HotwheelsClub.Service.Interface
{
    public interface ITransferService
    {
        Task<HotwheelsModel> TransferHotwheels(HotwheelsTransferModel hotwheels);
        Task<UserModel> TransferUser(UserTransferModel dto);
    }
}

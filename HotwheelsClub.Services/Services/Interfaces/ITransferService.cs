using HotwheelsClub.Service.Models;

namespace HotwheelsClub.Service.Interface
{
    public interface ITransferService
    {
        Task<HotwheelsModel> TransferHotwheelsAsync(HotwheelsTransferModel hotwheels);
        Task<UserModel> TransferUserAsync(UserTransferModel dto);
    }
}

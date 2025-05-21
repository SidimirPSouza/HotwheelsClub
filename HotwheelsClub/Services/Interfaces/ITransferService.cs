using HotwheelsClub.Models;

namespace HotwheelsClub.Service.Interface
{
    public interface ITransferService
    {
        // Task<HotwheelsModel> TransferHotwheels(HotwheelsModel hotwheels, int id);
        Task<HotwheelsModel> TransferMembers(HotwheelsModel hotwheels, int id);
    }
}

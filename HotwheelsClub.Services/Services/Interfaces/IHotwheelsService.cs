using HotwheelsClub.Service.Models;

namespace HotwheelsClub.Service.Interface
{
    public interface IHotwheelsService
    {
        Task<List<HotwheelsModel>> GetAllHotwheelsAsync();
        Task<HotwheelsModel> GetHotwheelsByIdAsync(int id);
        Task<HotwheelsModel> AddHotwheelsAsync(HotwheelsModel hotwheels);
        Task<HotwheelsModel> UpdateHotwheelsAsync(HotwheelsModel hotwheels);
        Task<bool> DeleteHotwheelsById(int id);

    }
}

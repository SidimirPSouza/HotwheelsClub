using HotwheelsClub.Models;

namespace HotwheelsClub.Service.Interface
{
    public interface IHotwheelsService
    {
        Task<List<HotwheelsModel>> GetAllHotwheels();
        Task<HotwheelsModel> GetById(int id);
        Task<HotwheelsModel> Add(HotwheelsModel hotwheels);
        Task<HotwheelsModel> Update(HotwheelsModel hotwheels, int id);
        Task<bool> DeleteById(int id);

    }
}

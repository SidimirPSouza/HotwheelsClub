using HotwheelsClub.Service.Models;

namespace HotwheelsClub.Service.Interface
{
    public interface IClubService
    {
        Task<List<ClubModel>> GetAllClubsAsync();
        Task<ClubModel> GetClubByIdAsync(int id);
        Task<ClubModel> AddClubAsync(ClubModel club);
        Task<ClubModel> UpdateClubAsync(ClubModel club);
        Task<bool> DeleteClubById(int id);

    }
}
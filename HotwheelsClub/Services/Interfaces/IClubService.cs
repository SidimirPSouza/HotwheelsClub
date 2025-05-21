using HotwheelsClub.Models;

namespace HotwheelsClub.Service.Interface
{
    public interface IClubService
    {
        Task<List<ClubModel>> GetAllClubs();
        Task<ClubModel> GetById(int id);
        Task<ClubModel> Add(ClubModel club);
        Task<ClubModel> Update(ClubModel club, int id);
        Task<bool> DeleteById(int id);

    }
}

using HotwheelsClub.Models;
using HotwheelsClub.Repository.Interface;
using HotwheelsClub.Service.Interface;

public class ClubService : IClubService
{
    private readonly IClubRepository _clubRepository;
    public ClubService(IClubRepository clubRepository)
    {
        _clubRepository = clubRepository;
    }

    public Task<List<ClubModel>> GetAllClubs()
    {
        return _clubRepository.GetAllClubs();
    }

    public Task<ClubModel> GetById(int id)
    {
        return _clubRepository.GetById(id);
    }

    public Task<ClubModel> Update(ClubModel club, int id)
    {
        return _clubRepository.Update(club, id);
    }

    public Task<ClubModel> Add(ClubModel club)
    {
        return _clubRepository.Add(club);
    }

    public Task<bool> DeleteById(int id)
    {
        return _clubRepository.DeleteById(id);
    }
}
using HotwheelsClub.Service.Models;
using HotwheelsClub.Service.Interface;
using HotwheelsClub.Repository.Interface;
using HotwheelsClub.Repository.Entity;

namespace HotwheelsClub.Service
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _clubRepository;
        public ClubService(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }

        public async Task<List<ClubModel>> GetAllClubs()
        {
            var clubsEntity = await _clubRepository.GetAll();
            var clubsModel = new List<ClubModel>();
            return clubsEntity.Select(item =>
                           new ClubModel
                           {
                               Id = item.Id,
                               Name = item.Name,
                               Description = item.Description,
                               ProprietorId = item.ProprietorId,
                           }).ToList();

        }

        public async Task<ClubModel> GetById(int id)
        {
            var clubEntity = await _clubRepository.GetById(id);
            var clubModel = new ClubModel();
            return new ClubModel
                   {
                       Id = clubEntity.Id,
                       Name = clubEntity.Name,
                       Description = clubEntity.Description,
                       ProprietorId = clubEntity.ProprietorId,
                   };
        }


        public async Task<ClubModel> Add(ClubModel club)
        {
            var clubEntity = new ClubEntity
            {
                Name = club.Name,
                Description = club.Description,
                ProprietorId = club.ProprietorId,
            };

            var created = await _clubRepository.Add(clubEntity);
            return club;
        }
        public async Task<ClubModel> Update(ClubModel club)
        {
            var clubEntity = await _clubRepository.GetById(club.Id);
            if (clubEntity == null)
                throw new Exception($"Hotwheels com o ID: {club.Id} não foi encontrada no banco de dados");
            clubEntity.Id = club.Id;
            clubEntity.Name = club.Name;
            clubEntity.ProprietorId = club.ProprietorId;
            clubEntity.Description = club.Description;
            await _clubRepository.Update(clubEntity);
            return club;
        }

        public Task<bool> DeleteById(int id)
        {
            return _clubRepository.DeleteById(id);
        }
    }
}
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

        public async Task<List<ClubModel>> GetAllClubsAsync()
        {
            var clubsEntity = await _clubRepository.GetAllAsync();
            if (clubsEntity == null)
                throw new Exception($"Nenhum club foi encontrado no banco de dados");
            return clubsEntity.Select(item =>
                           new ClubModel
                           {
                               Id = item.Id,
                               Name = item.Name,
                               Description = item.Description,
                               ProprietorId = item.ProprietorId,
                           }).ToList();

        }

        public async Task<ClubModel> GetClubByIdAsync(int id)
        {
            var clubEntity = await _clubRepository.GetByIdAsync(id);
            if (clubEntity == null)
                throw new Exception($"Club com o ID: {id} não foi encontrada no banco de dados");
            return new ClubModel
                   {
                       Id = clubEntity.Id,
                       Name = clubEntity.Name,
                       Description = clubEntity.Description,
                       ProprietorId = clubEntity.ProprietorId,
                   };
        }


        public async Task<ClubModel> AddClubAsync(ClubModel club)
        {
            var clubEntity = new ClubEntity
            {
                Name = club.Name,
                Description = club.Description,
                ProprietorId = club.ProprietorId,
            };

            var created = await _clubRepository.AddAsync(clubEntity);
            return club;
        }
        public async Task<ClubModel> UpdateClubAsync(ClubModel club)
        {
            var clubEntity = await _clubRepository.GetByIdAsync(club.Id);
            if (clubEntity == null)
                throw new Exception($"Club com o ID: {club.Id} não foi encontrado no banco de dados");
            clubEntity.Id = club.Id;
            clubEntity.Name = club.Name;
            clubEntity.ProprietorId = club.ProprietorId;
            clubEntity.Description = club.Description;
            await _clubRepository.UpdateAsync(clubEntity);
            return club;
        }

        public Task<bool> DeleteClubById(int id)
        {
            return _clubRepository.DeleteByIdAsync(id);
        }
    }
}
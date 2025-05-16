using HotwheelsClub.Data;
using HotwheelsClub.Models;
using HotwheelsClub.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotwheelsClub.Repository
{
    public class ClubRepository : IClubRepository
    {
        public readonly HotwheelsClubDBContext _DbContext;
        public ClubRepository(HotwheelsClubDBContext hotwheelsClubDBContext) 
        {
            _DbContext = hotwheelsClubDBContext;
        }

        public async Task<List<ClubModel>> GetAllClubs()
        {
            return await _DbContext.Club
            .Include(x => x.Members)
            .ToListAsync();
        }

        public async Task<ClubModel> GetById(int id)
        {
            return await _DbContext.Club
            .Include(x => x.Members)
            .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<ClubModel> Add(ClubModel club)
        {
            await _DbContext.AddAsync(club);
            await _DbContext.SaveChangesAsync();

            return club;
        }

        public async Task<ClubModel> Update(ClubModel club, int id)
        {
            ClubModel clubId = await GetById(id);
            if (clubId == null)
            {
                throw new Exception($"Hotwheels com o ID: {id} não foi encontrada no banco de dados");
            }

            clubId.Name = club.Name;
            clubId.Description = club.Description;
            clubId.ProprietorId = club.ProprietorId;
            clubId.Members = club.Members;


            _DbContext.Club.Update(clubId);
            await _DbContext.SaveChangesAsync();
            return club;
        }
        
        public async Task<bool> DeleteById(int id)
        {
            ClubModel clubId = await GetById(id);
            if (clubId == null)
            {
                throw new Exception($"Hotwheels com o ID: {id} não foi encontrada no banco de dados");
            }

            _DbContext.Remove(clubId);
            await _DbContext.SaveChangesAsync();
            return true;
        }
    }
}

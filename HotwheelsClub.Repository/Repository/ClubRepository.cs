using HotwheelsClub.Data;
using HotwheelsClub.Repository.Entity;
using HotwheelsClub.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotwheelsClub.Repository
{
    public class ClubRepository : BaseRepository<ClubEntity>, IClubRepository
    {
        public ClubRepository(HotwheelsClubDBContext DBContext) : base(DBContext)
        {
        }
    }
}

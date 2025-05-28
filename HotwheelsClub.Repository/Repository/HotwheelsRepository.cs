using HotwheelsClub.Data;
using HotwheelsClub.Repository.Entity;
using HotwheelsClub.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotwheelsClub.Repository
{
    public class HotwheelsRepository : BaseRepository<HotwheelsEntity>, IHotwheelsRepository
    {
        public HotwheelsRepository(HotwheelsClubDBContext DBContext) : base(DBContext)
        {
        }

    }
}

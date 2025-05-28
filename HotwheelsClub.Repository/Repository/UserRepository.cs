using HotwheelsClub.Data;
using HotwheelsClub.Repository.Entity;
using HotwheelsClub.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotwheelsClub.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(HotwheelsClubDBContext DBContext) : base(DBContext)
        {
        }
    }
}

using HotwheelsClub.Data.Map;
using HotwheelsClub.Models;
using Microsoft.EntityFrameworkCore;

namespace HotwheelsClub.Data
{
    public class HotwheelsClubDBContext : DbContext
    {
        public HotwheelsClubDBContext(DbContextOptions<HotwheelsClubDBContext> options) 
            :base(options)
        { 
        }

        public DbSet<HotwheelsModel> Hotwheels { get; set; }
        public DbSet<UserModel> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HotwheelsMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

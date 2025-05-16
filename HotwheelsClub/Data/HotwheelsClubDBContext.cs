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
        public DbSet<ClubModel> Club { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HotwheelsMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ClubMap());

            modelBuilder.Entity<HotwheelsModel>()
                .HasOne(h => h.Proprietor)
                .WithMany(u => u.hotwheels)
                .HasForeignKey(h => h.ProprietorId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<UserModel>()
                .HasOne(u => u.Club)
                .WithMany(c => c.Members)
                .HasForeignKey(u => u.ClubId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

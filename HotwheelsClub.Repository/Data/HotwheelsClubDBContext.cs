using HotwheelsClub.Data.Map;
using HotwheelsClub.Repository.Entity;
using Microsoft.EntityFrameworkCore;

namespace HotwheelsClub.Data
{
    public class HotwheelsClubDBContext : DbContext
    {
        public HotwheelsClubDBContext(DbContextOptions<HotwheelsClubDBContext> options)
            :base(options)
        { 
        }

        public DbSet<HotwheelsEntity> Hotwheels { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<ClubEntity> Club { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HotwheelsMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new ClubMap());

            modelBuilder.Entity<HotwheelsEntity>()
                .HasOne(h => h.Proprietor)
                .WithMany(u => u.hotwheels)
                .HasForeignKey(h => h.ProprietorId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<UserEntity>()
                .HasOne(u => u.Club)
                .WithMany(c => c.Members)
                .HasForeignKey(u => u.ClubId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

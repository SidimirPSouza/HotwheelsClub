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
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

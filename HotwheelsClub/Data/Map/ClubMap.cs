using HotwheelsClub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotwheelsClub.Data.Map
{
    public class ClubMap : IEntityTypeConfiguration<ClubModel>
    {
        public void Configure(EntityTypeBuilder<ClubModel> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);


            builder.HasOne(x => x.Proprietor)
                .WithMany() 
                .HasForeignKey(x => x.ProprietorId)
                .OnDelete(DeleteBehavior.SetNull);


            builder.HasMany(x => x.Members)
                .WithOne(x => x.Club)
                .HasForeignKey(x => x.ClubId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

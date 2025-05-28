using HotwheelsClub.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotwheelsClub.Data.Map
{
    public class HotwheelsMap : IEntityTypeConfiguration<HotwheelsEntity>
    {
        public void Configure(EntityTypeBuilder<HotwheelsEntity> builder)
        {
            builder.ToTable("Hotwheels");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Model).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.Color).IsRequired().HasMaxLength(200);
            builder.Property(x => x.ProprietorId).IsRequired();

            builder.HasOne(x => x.Proprietor);
        }
    }
}

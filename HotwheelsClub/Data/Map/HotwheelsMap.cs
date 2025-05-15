using HotwheelsClub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotwheelsClub.Data.Map
{
    public class HotwheelsMap : IEntityTypeConfiguration<HotwheelsModel>
    {
        public void Configure(EntityTypeBuilder<HotwheelsModel> builder)
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

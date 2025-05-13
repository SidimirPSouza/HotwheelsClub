using HotwheelsClub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotwheelsClub.Data.Map
{
    public class HotwheelsMap : IEntityTypeConfiguration<HotwheelsModel>
    {
        public void Configure(EntityTypeBuilder<HotwheelsModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Modelo).IsRequired().HasMaxLength(200);
            builder.Property(x => x.preco).IsRequired();
            builder.Property(x => x.Ano).IsRequired();
            builder.Property(x => x.Cor).IsRequired().HasMaxLength(200);
        }
    }
}

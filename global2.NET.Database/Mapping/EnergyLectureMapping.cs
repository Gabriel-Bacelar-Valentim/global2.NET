using global2.NET.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace global2.NET.Database.Mapping
{
    public class EnergyLectureMapping : IEntityTypeConfiguration<EnergyLecture>
    {
        public void Configure(EntityTypeBuilder<EnergyLecture> builder)
        {
            builder.ToTable("leitura_energia");

            builder.HasKey(el => el.Id);

            builder.Property(el => el.Consumo)
                .IsRequired();

            builder.Property(el => el.ProducaoEnergia)
                .IsRequired();

            builder.Property(el => el.DataLeitura)
                .IsRequired();
        }
    }
}

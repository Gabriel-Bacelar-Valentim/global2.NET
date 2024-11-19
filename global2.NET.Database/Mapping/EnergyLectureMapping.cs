using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using global2.NET.Database.Models;

namespace global2.NET.Database.Mapping
{
    public class EnergyLectureMapping : IEntityTypeConfiguration<EnergyLecture>
    {
        public void Configure(EntityTypeBuilder<EnergyLecture> builder)
        {
            builder.ToTable("leitura_energia");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Consumo).HasMaxLength(40);
            builder.Property(e => e.ProducaoEnergia).HasMaxLength(40);
            builder.Property(e => e.DataLeitura).IsRequired(false);

            builder.HasMany(e => e.Devices)
                   .WithMany(d => d.EnergyLectures)
                   .UsingEntity(j => j.ToTable("obter"));
        }
    }
}
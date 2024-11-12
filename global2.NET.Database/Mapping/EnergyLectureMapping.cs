using global2.NET.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace global2.NET.Database.Mapping
{
    public class EnergyLectureMapping : IEntityTypeConfiguration<EnergyLecture>
    {
        public void Configure(EntityTypeBuilder<EnergyLecture> builder)
        {
            builder.ToTable("InovaX_Tb_EnergyLecture");

            builder.HasKey(el => el.Id);

            builder.Property(el => el.Consumption)
                .IsRequired();

            builder.Property(el => el.EnergyProduction)
                .IsRequired();

            builder.Property(el => el.LectureDate)
                .IsRequired();
        }
    }
}

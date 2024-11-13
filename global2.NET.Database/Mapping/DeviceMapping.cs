using global2.NET.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace global2.NET.Database.Mapping
{
    public class DeviceMapping : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("dispositivo");

            builder.HasKey(d => d.IdDisp);

            builder.Property(d => d.NomeDispositivo)
                .IsRequired();

            builder.Property(d => d.TipoDispositivo)
                .IsRequired();

            builder.Property(d => d.StatusDispositivo)
                .IsRequired();
        }
    }
}

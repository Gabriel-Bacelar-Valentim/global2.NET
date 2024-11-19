using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using global2.NET.Database.Models;

namespace global2.NET.Database.Mapping
{
    public class DeviceMapping : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("dispositivo");
            builder.HasKey(d => d.IdDisp);

            builder.Property(d => d.IdDisp).IsRequired();
            builder.Property(d => d.NomeDispositivo).HasMaxLength(50);
            builder.Property(d => d.TipoDispositivo).HasMaxLength(50);
            builder.Property(d => d.StatusDispositivo).HasMaxLength(50);

            builder.HasOne(d => d.Usuario)
                   .WithMany(u => u.Devices)
                   .HasForeignKey(d => d.UsuarioIdUsua)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
using global2.NET.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace global2.NET.Database.Mapping
{
    public class DeviceMapping : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("InovaX_Tb_Device");

            builder.HasKey(d => d.DeviceId);

            builder.Property(d => d.DeviceName)
                .IsRequired();

            builder.Property(d => d.DeviceType)
                .IsRequired();

            builder.Property(d => d.DeviceStatus)
                .IsRequired();
        }
    }
}

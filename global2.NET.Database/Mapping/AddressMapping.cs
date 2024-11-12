using global2.NET.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace global2.NET.Database.Mapping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("InovaX_Tb_Address");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Street)
                .IsRequired();

            builder.Property(e => e.CEP)
                .IsRequired();

            builder.Property(e => e.Number)
                .IsRequired();

            builder.Property(e => e.Complement);

            builder.Property(e => e.Neighborhood)
                .IsRequired();

            builder.Property(e => e.City)
                .IsRequired();

            builder.Property(e => e.State)
                .IsRequired();
        }
    }
}

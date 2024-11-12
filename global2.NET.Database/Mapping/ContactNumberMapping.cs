using global2.NET.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace global2.NET.Database.Mapping
{
    public class ContactNumberMapping : IEntityTypeConfiguration<ContactNumber>
    {
        public void Configure(EntityTypeBuilder<ContactNumber> builder)
        {
            builder.ToTable("InovaX_Tb_ContactNumber");

            builder.HasKey(cn => cn.PhoneId);

            builder.Property(cn => cn.DDD)
                .IsRequired();

            builder.Property(cn => cn.PhoneNumber)
               .IsRequired();

            builder.Property(cn => cn.CountryCode)
                .IsRequired();
        }
    }
}

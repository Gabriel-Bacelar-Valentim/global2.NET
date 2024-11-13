using global2.NET.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace global2.NET.Database.Mapping
{
    public class ContactNumberMapping : IEntityTypeConfiguration<ContactNumber>
    {
        public void Configure(EntityTypeBuilder<ContactNumber> builder)
        {
            builder.ToTable("telefone");

            builder.HasKey(cn => cn.IdTelef);

            builder.Property(cn => cn.DDD)
                .IsRequired();

            builder.Property(cn => cn.NumeroTelefone)
               .IsRequired();

            builder.Property(cn => cn.CodigoPais)
                .IsRequired();
        }
    }
}

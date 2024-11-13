using global2.NET.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace global2.NET.Database.Mapping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("endereco");

            builder.HasKey(e => e.IdEnde);

            builder.Property(e => e.Logradouro)
                .IsRequired();

            builder.Property(e => e.CEP)
                .IsRequired();

            builder.Property(e => e.Numero)
                .IsRequired();

            builder.Property(e => e.Complemento);

            builder.Property(e => e.Bairro)
                .IsRequired();

            builder.Property(e => e.Cidade)
                .IsRequired();

            builder.Property(e => e.Estado)
                .IsRequired();
        }
    }
}

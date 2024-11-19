using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using global2.NET.Database.Models;

namespace global2.NET.Database.Mapping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("endereco");
            builder.HasKey(a => a.IdEnde);

            builder.Property(a => a.IdEnde).IsRequired();
            builder.Property(a => a.Logradouro).HasMaxLength(200);
            builder.Property(a => a.CEP).HasMaxLength(10);
            builder.Property(a => a.Numero).HasMaxLength(5);
            builder.Property(a => a.Complemento).HasMaxLength(50);
            builder.Property(a => a.Bairro).HasMaxLength(50);
            builder.Property(a => a.Cidade).HasMaxLength(50);
            builder.Property(a => a.Estado).HasMaxLength(50);

            builder.HasOne(a => a.Usuario)
                   .WithMany(u => u.Addresses)
                   .HasForeignKey(a => a.UsuarioIdUsua)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
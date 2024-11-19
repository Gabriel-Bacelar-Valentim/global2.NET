using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using global2.NET.Database.Models;

namespace global2.NET.Database.Mapping
{
    public class ContactNumberMapping : IEntityTypeConfiguration<ContactNumber>
    {
        public void Configure(EntityTypeBuilder<ContactNumber> builder)
        {
            builder.ToTable("telefone");
            builder.HasKey(t => t.IdTelef);

            builder.Property(t => t.IdTelef).IsRequired();
            builder.Property(t => t.CodigoPais).HasMaxLength(3);
            builder.Property(t => t.DDD).HasMaxLength(3);
            builder.Property(t => t.NumeroTelefone).IsRequired();

            builder.HasOne(t => t.Usuario)
                   .WithMany(u => u.ContactNumbers)
                   .HasForeignKey(t => t.UsuarioIdUsua)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
using global2.NET.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace global2.NET.Database.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<PrincipalUser>
    {
        public void Configure(EntityTypeBuilder<PrincipalUser> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(u => u.IdUsua);

            builder.Property(u => u.NomeUsua)
                .IsRequired();

            builder.Property(u => u.EmailUsua)
                .IsRequired();

            builder.Property(u => u.SenhaUsua)
                .IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using global2.NET.Database.Models;

namespace global2.NET.Database.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<PrincipalUser>
    {
        public void Configure(EntityTypeBuilder<PrincipalUser> builder)
        {
            builder.ToTable("usuario");
            builder.HasKey(u => u.IdUsua);

            builder.Property(u => u.IdUsua).IsRequired();
            builder.Property(u => u.NomeUsua).HasMaxLength(50);
            builder.Property(u => u.EmailUsua).HasMaxLength(70);
            builder.Property(u => u.SenhaUsua).HasMaxLength(50);

            builder.HasOne(u => u.IncentiveScore)
                   .WithOne(i => i.Usuario)
                   .HasForeignKey<PrincipalUser>(u => u.IncentiveScoreId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
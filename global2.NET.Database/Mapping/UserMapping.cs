using global2.NET.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace global2.NET.Database.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("InovaX_Tb_User");

            builder.HasKey(u => u.UserId);

            builder.Property(u => u.Name)
                .IsRequired();

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Password)
                .IsRequired();
        }
    }
}

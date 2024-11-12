using global2.NET.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace global2.NET.Database.Mapping
{
    public class IncentiveScoreMapping : IEntityTypeConfiguration<IncentiveScore>
    {
        public void Configure(EntityTypeBuilder<IncentiveScore> builder)
        {
            builder.ToTable("InovaX_Tb_IncentiveScore");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.AcquiredScore)
                .IsRequired();

            builder.Property(s => s.GoalAchieved);

            builder.Property(s => s.GoalAchievedData);
        }
    }
}

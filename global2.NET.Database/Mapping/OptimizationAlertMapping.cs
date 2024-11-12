using global2.NET.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace global2.NET.Database.Mapping
{
    public class OptimizationAlertMapping : IEntityTypeConfiguration<OptimizationAlert>
    {
        public void Configure(EntityTypeBuilder<OptimizationAlert> builder)
        {
            builder.ToTable("InovaX_Tb_OptimizationAlert");

            builder.HasKey(oa => oa.Id);

            builder.Property(oa => oa.AlertType)
                .IsRequired();

            builder.Property(oa => oa.AlertDescription);

            builder.Property(oa => oa.AlertDate);
                
        }
    }
}

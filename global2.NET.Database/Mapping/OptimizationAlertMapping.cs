using global2.NET.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace global2.NET.Database.Mapping
{
    public class OptimizationAlertMapping : IEntityTypeConfiguration<OptimizationAlert>
    {
        public void Configure(EntityTypeBuilder<OptimizationAlert> builder)
        {
            builder.ToTable("alerta_otimizacao");

            builder.HasKey(oa => oa.IdAler);

            builder.Property(oa => oa.TipoAlerta)
                .IsRequired();

            builder.Property(oa => oa.Descricao);

            builder.Property(oa => oa.DataAlerta);
                
        }
    }
}

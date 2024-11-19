using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using global2.NET.Database.Models;

namespace global2.NET.Database.Mapping
{
    public class OptimizationAlertMapping : IEntityTypeConfiguration<OptimizationAlert>
    {
        public void Configure(EntityTypeBuilder<OptimizationAlert> builder)
        {
            builder.ToTable("alerta_otimizacao");
            builder.HasKey(o => o.IdAler);

            builder.Property(o => o.IdAler).IsRequired();
            builder.Property(o => o.TipoAlerta).HasMaxLength(100);
            builder.Property(o => o.Descricao).HasMaxLength(200);
            builder.Property(o => o.DataAlerta);

            builder.HasOne(o => o.Telefone)
                   .WithMany(t => t.OptimizationAlerts)
                   .HasForeignKey(o => o.TelefoneIdTelef)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
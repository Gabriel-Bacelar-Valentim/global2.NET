using global2.NET.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace global2.NET.Database.Mapping
{
    public class IncentiveScoreMapping : IEntityTypeConfiguration<IncentiveScore>
    {
        public void Configure(EntityTypeBuilder<IncentiveScore> builder)
        {
            builder.ToTable("incetivo_pontuacao");

            builder.HasKey(s => s.IdPont);

            builder.Property(s => s.PontosAdquiridos)
                .IsRequired();

            builder.Property(s => s.MetaAlcancada);

            builder.Property(s => s.DataPontuacao);
        }
    }
}

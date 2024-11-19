using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using global2.NET.Database.Models;

namespace global2.NET.Database.Mapping
{
    public class IncentiveScoreMapping : IEntityTypeConfiguration<IncentiveScore>
    {
        public void Configure(EntityTypeBuilder<IncentiveScore> builder)
        {
            builder.ToTable("incentivo_pontuacao");
            builder.HasKey(i => i.IdPont);

            builder.Property(i => i.IdPont).IsRequired();
            builder.Property(i => i.PontosAdquiridos);
            builder.Property(i => i.MetaAlcancada);
            builder.Property(i => i.DataPontuacao);
        }
    }
}
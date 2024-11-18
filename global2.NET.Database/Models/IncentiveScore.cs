using System.ComponentModel.DataAnnotations.Schema;

namespace global2.NET.Database.Models
{
    [Table("incentivo_pontuacao")]
    public class IncentiveScore
    {
        public long IdPont { get; set; }
        public long PontosAdquiridos { get; set; }
        public long MetaAlcancada { get; set; }
        public DateTime? DataPontuacao { get; set; }

        public PrincipalUser Usuario { get; set; }
    }
}
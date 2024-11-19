namespace global2.NET.Database.Models
{
    public class IncentiveScore
    {
        public long IdPont { get; set; }
        public long PontosAdquiridos { get; set; }
        public long MetaAlcancada { get; set; }
        public DateTime? DataPontuacao { get; set; }

        public PrincipalUser Usuario { get; set; }
    }
}
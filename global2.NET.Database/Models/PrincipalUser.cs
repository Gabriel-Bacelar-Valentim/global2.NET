namespace global2.NET.Database.Models
{
    public class PrincipalUser
    {
        public long IdUsua { get; set; }
        public string NomeUsua { get; set; }
        public string EmailUsua { get; set; }
        public string SenhaUsua { get; set; }
        public IncentiveScore? IncentiveScore { get; set; }
    }
}

namespace global2.NET.Database.Models
{
    public class Device
    {
        public long IdDisp { get; set; }
        public string NomeDispositivo { get; set; }
        public string TipoDispositivo { get; set; }
        public string StatusDispositivo { get; set; }

        public long UsuarioIdUsua { get; set; }
        public PrincipalUser Usuario { get; set; }

        public ICollection<EnergyLecture> EnergyLectures { get; set; } = new List<EnergyLecture>();
    }
}
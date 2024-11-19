namespace global2.NET.Service.ServiceModel
{
    public class DispositivoRequest
    {
        public int IdDispositivo { get; set; }
        public string TipoDispositivo { get; set; }
        public string NomeDispositivo { get; set; }
        public bool StatusDispositivo { get; set; }
        public int IdUsuario { get; set; }
    }
}

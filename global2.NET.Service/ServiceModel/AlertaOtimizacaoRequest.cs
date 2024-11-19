namespace global2.NET.Service.ServiceModel
{
    public class AlertaOtimizacaoRequest
    {
        public int IdAlerta { get; set; }
        public string TipoAlerta { get; set; }
        public DateTime DataAlerta { get; set; }
        public string Descricao { get; set; }
        public int IdTelefone { get; set; }
    }
}

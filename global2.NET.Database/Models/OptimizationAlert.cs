namespace global2.NET.Database.Models
{
    public class OptimizationAlert
    {
        public long IdAler { get; set; }
        public string TipoAlerta { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataAlerta { get; set; }

        public long TelefoneIdTelef { get; set; }
        public ContactNumber Telefone { get; set; }
    }
}
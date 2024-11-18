using System.ComponentModel.DataAnnotations.Schema;

namespace global2.NET.Database.Models
{
    [Table("alerta_otimizacao")]
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
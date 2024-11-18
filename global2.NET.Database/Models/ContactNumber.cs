using System.ComponentModel.DataAnnotations.Schema;

namespace global2.NET.Database.Models
{
    [Table("telefone")]
    public class ContactNumber
    {
        public long IdTelef { get; set; }
        public string CodigoPais { get; set; }
        public string DDD { get; set; }
        public string NumeroTelefone { get; set; }

        public long UsuarioIdUsua { get; set; }
        public PrincipalUser Usuario { get; set; }

        public ICollection<OptimizationAlert> OptimizationAlerts { get; set; } = new List<OptimizationAlert>();
    }
}
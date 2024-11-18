using System.ComponentModel.DataAnnotations.Schema;

namespace global2.NET.Database.Models
{
    [Table("endereco")]
    public class Address
    {
        public long IdEnde { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public long UsuarioIdUsua { get; set; }
        public PrincipalUser Usuario { get; set; }
    }
}
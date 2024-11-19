namespace global2.NET.Service.ServiceModel
{
    public class EnderecoRequest
    {
        public int IdEndereco { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int IdUsuario { get; set; }
    }
}

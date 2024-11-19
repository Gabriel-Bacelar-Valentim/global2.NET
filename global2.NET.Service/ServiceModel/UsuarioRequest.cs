namespace global2.NET.Service.ServiceModel
{
    public class UsuarioRequest
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public int IdPontuacao { get; set; }
    }
}

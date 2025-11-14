namespace SistemaChamados.Api.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";
        public string Email { get; set; } = "";
        public string Senha { get; set; } = "";
        public string Tipo { get; set; } = "";   // Admin, Tecnico, Usuario
        public string Setor { get; set; } = "";
    }
}

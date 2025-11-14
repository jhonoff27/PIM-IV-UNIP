namespace SistemaChamados.Api.Models
{
    public class Faq
    {
        public int Id { get; set; }
        public string Pergunta { get; set; } = "";
        public string Resposta { get; set; } = "";
        public int? CategoriaId { get; set; }
    }
}

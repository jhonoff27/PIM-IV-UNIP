namespace SistemaChamadosWeb.Services;

public class ChamadoDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime DataAbertura { get; set; }
    public int UsuarioAberturaId { get; set; }
}

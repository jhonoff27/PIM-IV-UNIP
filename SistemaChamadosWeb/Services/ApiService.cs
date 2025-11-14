using System.Net.Http.Json;

namespace SistemaChamadosWeb.Services;

public class ApiService
{
    private readonly HttpClient _http;
    private readonly string _apiUrl;

    public ApiService(IConfiguration config)
    {
        _apiUrl = config["ApiUrl"]!;
        _http = new HttpClient();
    }

    // LOGIN
    public async Task<UsuarioDto?> Login(string email, string senha)
    {
        var result = await _http.GetFromJsonAsync<UsuarioDto>(
            $"{_apiUrl}api/Usuarios/login?email={email}&senha={senha}");

        return result;
    }

    // ABRIR CHAMADO
    public async Task<bool> AbrirChamado(ChamadoDto dto)
    {
        var response = await _http.PostAsJsonAsync($"{_apiUrl}api/Chamados", dto);
        return response.IsSuccessStatusCode;
    }

    // MEUS CHAMADOS
    public async Task<List<ChamadoDto>?> MeusChamados(int idUsuario)
    {
        return await _http.GetFromJsonAsync<List<ChamadoDto>>(
            $"{_apiUrl}api/Chamados/usuario/{idUsuario}");
    }

    // FAQ
    public async Task<FaqDto?> BuscarFaq(string termo)
    {
        return await _http.GetFromJsonAsync<FaqDto>(
            $"{_apiUrl}api/Faq/buscar?pergunta={termo}");
    }
}

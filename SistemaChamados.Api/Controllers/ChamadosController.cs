using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper; // Adicione esta linha
using SistemaChamados.Api.Models;

[ApiController]
[Route("api/[controller]")]
public class ChamadosController : ControllerBase
{
    private readonly IDbConnection _db;

    public ChamadosController(IDbConnection db)
    {
        _db = db;
    }

    [HttpPost]
    public async Task<IActionResult> Criar(Chamado c)
    {
        var sql = @"INSERT INTO Chamados 
        (Titulo,Descricao,CategoriaId,UsuarioAberturaId,Status,Prioridade)
        VALUES (@Titulo,@Descricao,@CategoriaId,@UsuarioAberturaId,'Aberto','Média')";

        await _db.ExecuteAsync(sql, c);
        return Ok(new { mensagem = "Chamado criado com sucesso!" });
    }

    [HttpGet("usuario/{id}")]
    public async Task<IActionResult> MeusChamados(int id)
    {
        var sql = "SELECT * FROM Chamados WHERE UsuarioAberturaId=@id";
        return Ok(await _db.QueryAsync<Chamado>(sql, new { id }));
    }
}

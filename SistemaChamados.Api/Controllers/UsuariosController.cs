using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using SistemaChamados.Api.Models;


[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly IDbConnection _db;

    public UsuariosController(IDbConnection db)
    {
        _db = db;
    }

    [HttpGet("login")]
    public async Task<IActionResult> Login(string email, string senha)
    {
        var sql = "SELECT * FROM Usuarios WHERE Email=@email AND Senha=@senha";
        var user = await _db.QueryFirstOrDefaultAsync<Usuario>(sql, new { email, senha });

        if (user == null) return Unauthorized();

        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _db.QueryAsync<Usuario>("SELECT * FROM Usuarios"));
    }
}

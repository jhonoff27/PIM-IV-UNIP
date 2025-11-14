using Microsoft.AspNetCore.Mvc;
using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.Data.SqlClient;
using SistemaChamados.Api.Models;


[ApiController]
[Route("api/[controller]")]
public class FaqController : ControllerBase
{
    private readonly IDbConnection _db;

    public FaqController(IDbConnection db)
    {
        _db = db;
    }

    [HttpGet("buscar")]
    public async Task<IActionResult> Buscar(string termo)
    {
        var sql = @"SELECT TOP 1 * FROM Faq 
                    WHERE Pergunta LIKE '%' + @termo + '%' 
                    OR Resposta LIKE '%' + @termo + '%'";

        var result = await _db.QueryFirstOrDefaultAsync<Faq>(sql, new { termo });

        return Ok(result);
    }
}

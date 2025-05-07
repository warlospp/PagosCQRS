using Microsoft.AspNetCore.Mvc;
using PagosCQRS.Commands;
using PagosCQRS.Persistence;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class PagosQueryController : ControllerBase
{
    private readonly QueryDbContext _context;

    public PagosQueryController(QueryDbContext context)
    {
        _context = context;
    }

    [HttpGet("todos")]
    public async Task<IActionResult> ObtenerPagos()
    {
        var pagos = await _context.Pagos
            .OrderByDescending(p => p.FechaPago)
            .ToListAsync();

        return Ok(pagos);
    }

    [HttpGet("por-cliente")]
    public async Task<IActionResult> ObtenerPagosPorCliente([FromQuery] string idCliente)
    {
        var pagos = await _context.Pagos
            .Where(p => p.ClienteId == idCliente)
            .OrderByDescending(p => p.FechaPago)
            .ToListAsync();

        return Ok(pagos);
    }
}
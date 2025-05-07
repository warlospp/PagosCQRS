using Microsoft.AspNetCore.Mvc;
using PagosCQRS.Commands;
using PagosCQRS.Persistence;
using PagosCQRS.Models;

[ApiController]
[Route("api/[controller]")]
public class PagosCommandController : ControllerBase
{
    private readonly CommandDbContext _context;

    public PagosCommandController(CommandDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CrearPago([FromBody] Pago pago)
    {

        var random1 = new Random();
        pago.ClienteId = random1.Next(1, 5).ToString();

        pago.FechaPago = DateTime.UtcNow;

        var metodosPago = new[] { "Tarjeta", "Efectivo" , "Transferencia"};
        var random2 = new Random();
        pago.MetodoPago = metodosPago[random2.Next(metodosPago.Length)];

        var estado = new[] { "Procesado", "Reversado" };
        var random3 = new Random();
        pago.Estado = estado[random3.Next(estado.Length)];

        var random4 = new Random();
        pago.Monto = random4.Next(1, 101);

        _context.Pagos.Add(pago);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(CrearPago), new { id = pago.Id }, pago);
    }
}

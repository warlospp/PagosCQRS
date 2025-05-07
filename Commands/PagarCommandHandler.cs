using PagosCQRS.Persistence;
using PagosCQRS.Models;

namespace PagosCQRS.Commands
{
    public class PagarCommandHandler
    {
        private readonly CommandDbContext _context;

        public PagarCommandHandler(CommandDbContext context)
        {
            _context = context;
        }

        public async Task<int> HandleAsync(PagarCommand command)
        {
            var pago = new Pago
            {
                ClienteId = command.ClienteId,
                Monto = command.Monto,
                MetodoPago = command.MetodoPago,
                FechaPago = DateTime.UtcNow
            };

            _context.Pagos.Add(pago);
            await _context.SaveChangesAsync();
            return pago.Id;
        }
    }
}
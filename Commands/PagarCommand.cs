namespace PagosCQRS.Commands
{
    public class PagarCommand
    {
        public string ClienteId { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
    }
}
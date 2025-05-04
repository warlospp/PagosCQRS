namespace PagosCQRS.Models
{
    public class Pago
    {
        public int Id { get; set; }
        public string ClienteId { get; set; } = string.Empty;
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; } = DateTime.UtcNow;
        public string MetodoPago { get; set; } = string.Empty;
        public string Estado { get; set; } = "Procesado";
    }
}
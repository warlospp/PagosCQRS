using Microsoft.EntityFrameworkCore;
using PagosCQRS.Models;

namespace PagosCQRS.Persistence
{
    public class CommandDbContext : DbContext
    {
        public CommandDbContext(DbContextOptions<CommandDbContext> options) : base(options) { }

        public DbSet<Pago> Pagos { get; set; }
    }

    public class QueryDbContext : DbContext
    {
        public QueryDbContext(DbContextOptions<QueryDbContext> options) : base(options) { }

        public DbSet<Pago> Pagos { get; set; }
    }
}
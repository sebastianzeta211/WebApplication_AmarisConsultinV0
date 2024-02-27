using Microsoft.EntityFrameworkCore;
using WebApplication_AmarisConsultinV0.Clases;

namespace WebApplication_AmarisConsultinV0.Models
{
    public class ConexionSQLServer : DbContext
    {
        public ConexionSQLServer(DbContextOptions<ConexionSQLServer> options) : base(options)
        {
        }
        public DbSet<Reserva> IReserva { get; set; }
        public DbSet<Sede> Sede { get; set; }

    }
}

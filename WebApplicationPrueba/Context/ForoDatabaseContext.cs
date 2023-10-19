using Microsoft.EntityFrameworkCore;
using WebApplicationPrueba.Models;


namespace WebApplicationPrueba.Context
   
{
    public class ForoDatabaseContext : DbContext
    {
        public ForoDatabaseContext(DbContextOptions<ForoDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Entrada> Entrada { get; set; }
        public DbSet<Espectaculo> Espectaculo{ get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}

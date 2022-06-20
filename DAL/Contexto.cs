using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL
{
    public partial class Contexto : DbContext
    {
        public DbSet<Compras> Compras {get;set;}
        public DbSet< CompraDetalles> CompraDetalles { get; set; }
        public DbSet< Productos> Productos { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base (options){}
    }
}
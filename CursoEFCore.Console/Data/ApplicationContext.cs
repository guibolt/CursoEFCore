using CursoEFCore.Console.Data.Configurations;
using CursoEFCore.Console.Domain;
using CursoEFCore.Console.Extensions;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Console.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<PedidoItem> Itens { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>  optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CursoEfDb;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}

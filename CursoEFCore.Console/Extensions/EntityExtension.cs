using CursoEFCore.Console.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Console.Extensions
{
    public static class EntityExtension
    {
        public static void ConfigurarModelos(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(c =>
            {
                c.ToTable("Clientes");
                c.HasKey(c => c.Id);
                c.Property(c => c.Nome).HasColumnName("VARCHAR(80)").IsRequired();
                c.Property(c => c.Telefone).HasColumnName("CHAR(11)").IsRequired();
                c.Property(c => c.Cep).HasColumnName("CHAR(8)").IsRequired();
                c.Property(c => c.Estado).HasColumnName("CHAR(2)").IsRequired();

                c.HasIndex(i => i.Telefone).HasName("idx_cliente_telefone");
            });

            modelBuilder.Entity<Produto>(c =>
            {
                c.ToTable("Produtos");
                c.HasKey(c => c.Id);
                c.Property(c => c.CodigoBarras).HasColumnName("VARCHAR(14)").IsRequired();
                c.Property(c => c.Descricao).HasColumnName("VARCHAR(60)").IsRequired();
                c.Property(c => c.Valor).IsRequired();
                c.Property(c => c.TipoProduto).HasConversion<string>();
            });

            modelBuilder.Entity<Pedido>(c =>
            {
                c.ToTable("Pedidos");
                c.HasKey(c => c.Id);
                c.Property(c => c.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                c.Property(c => c.Status).HasConversion<string>().IsRequired();
                c.Property(c => c.TipoFrete).HasConversion<int>().IsRequired();
                c.Property(c => c.Observacao).HasColumnType("VARCHAR(512)");

                c.HasMany(c => c.Itens)
                .WithOne(c => c.Pedido)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PedidoItem>(c => 
            {
                c.ToTable("PedidoItens");
                c.HasKey(c => c.Id);
                c.Property(c => c.Quantidade).HasDefaultValue(1).IsRequired();
                c.Property(c => c.Valor).IsRequired();
                c.Property(c => c.Desconto).IsRequired();
            });
        }
    }
}

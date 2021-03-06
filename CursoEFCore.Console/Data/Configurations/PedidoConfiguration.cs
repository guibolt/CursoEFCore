using CursoEFCore.Console.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Console.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(c => c.Status).HasConversion<string>().IsRequired();
            builder.Property(c => c.TipoFrete).HasConversion<int>().IsRequired();
            builder.Property(c => c.Observacao).HasColumnType("VARCHAR(512)");

            builder.HasMany(c => c.Itens)
            .WithOne(c => c.Pedido)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using CursoEFCore.Console.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Console.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CodigoBarras).HasColumnName("VARCHAR(14)").IsRequired();
            builder.Property(c => c.Descricao).HasColumnName("VARCHAR(60)").IsRequired();
            builder.Property(c => c.Valor).IsRequired();
            builder.Property(c => c.TipoProduto).HasConversion<string>();
        }
    }
}

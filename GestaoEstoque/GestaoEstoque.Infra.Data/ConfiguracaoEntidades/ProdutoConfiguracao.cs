using GestaoEstoque.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoEstoque.Infra.Data.ConfiguracaoEntidades
{
    public class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Preco).HasPrecision(10, 2);
            // declarando um para muitos usando HasOne e WithMany
            // uma categoria pode conter muitos produtos
            builder.HasOne(c => c.Categoria).WithMany(p => p.Produtos).HasForeignKey(p => p.CategoriaId);
        }
    }
}

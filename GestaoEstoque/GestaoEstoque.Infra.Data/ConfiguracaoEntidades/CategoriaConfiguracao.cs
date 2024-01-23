using GestaoEstoque.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoEstoque.Infra.Data.ConfiguracaoEntidades
{
    public class CategoriaConfiguracao : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            // configurando as propriedades da tabela
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Categoria(1, "Material Escolar"),
                new Categoria(2, "Eletronicos"),
                new Categoria(3, "Acessórios")
                );
        }
    }
}

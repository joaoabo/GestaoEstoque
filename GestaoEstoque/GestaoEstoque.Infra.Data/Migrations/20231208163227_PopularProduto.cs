using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoEstoque.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class PopularProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("insert into produtos(Nome, Descricao, Preco, Estoque, Imagem, CategoriaId) " + 
                "values('Caderno espiral', 'Caderno espiral 100 folhas', 7.45, 50, 'caderno.jpg', 1)");

            mb.Sql("insert into produtos(Nome, Descricao, Preco, Estoque, Imagem, CategoriaId) " +
                "values('Estojo escolar', 'Estojo escolar cinza', 5.65, 70, 'estojo.jpg', 1)");

            mb.Sql("insert into produtos(Nome, Descricao, Preco, Estoque, Imagem, CategoriaId) " +
                "values('Borracha escolar', 'Borracha escolar pequena', 3.35, 70, 'borracha.jpg', 1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Produtos");
        }
    }
}

using GestaoEstoque.Domain.Entidades;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GestaoEstoque.Application.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Nome é obrigatorio")]
        //[MinLength(3)]
        //[MaxLength(100)]
        //[DisplayName("Nome")]
        public string? Nome { get; set; }

        //[Required(ErrorMessage = "Descrição é obrigatorio")]
        //[MinLength(5)]
        //[MaxLength(100)]
        //[DisplayName("Descrição")]
        public string? Descricao { get; set; }

        //[Required(ErrorMessage = "Preço é obrigatorio")]
        //[Column(TypeName = "decimal(18,2)")]
        //[DisplayFormat(DataFormatString = "{0:C2}")]
        //[DataType(DataType.Currency)]
        //[DisplayName("Preço")]
        public decimal Preco { get; set; }

        //[Required(ErrorMessage = "Estoque é obrigatorio")]
        //[Range(1, 9999)]
        //[MaxLength(100)]
        //[DisplayName("Estoque")]
        public int Estoque { get; set; }

        //[MaxLength(250)]
        //[DisplayName("Imagem do produto")]
        public string? Imagem { get; set; }


        // Propriedades de navegação entre as classe

        //[DisplayName("Categoria")]
        public int CategoriaId { get; set; }

        [JsonIgnore]
        public Categoria? Categoria { get; set; }
    }
}

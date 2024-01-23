using System.ComponentModel.DataAnnotations;

namespace GestaoEstoque.Application.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatorio")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Nome { get; set; }
    }
}

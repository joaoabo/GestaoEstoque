using System.ComponentModel.DataAnnotations;

namespace GestaoEstoque.WebUI.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email é obrigatorio")]
        [EmailAddress(ErrorMessage = "E-mail com formato inválido")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatoria")]
        [StringLength(20, ErrorMessage = "O {0} deve ser no mínimo {2} e no máximo " +
             "{1} caracteres de comprimento.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}

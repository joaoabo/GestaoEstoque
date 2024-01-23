using System.ComponentModel.DataAnnotations;

namespace GestaoEstoque.WebUI.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar senha")]
        [Compare("Password", ErrorMessage = "Senha errada")]
        public string? ConfirmPassword { get; set; }
    }
}

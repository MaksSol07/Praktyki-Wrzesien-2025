using System.ComponentModel.DataAnnotations;

namespace kreator_pomieszczen.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email jest wymagany.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [DataType(DataType.Password)]

        public string Password { get; set; }

        [Display(Name = "Zapamiać dane logowania?")]

        public bool RememberMe { get; set; }
    }
}

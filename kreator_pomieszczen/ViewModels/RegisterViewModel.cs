using System.ComponentModel.DataAnnotations;

namespace kreator_pomieszczen.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Nazwa jest wymagana.")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Email jest wymagany.")]
        [EmailAddress]

        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Hasło musi mieć co najmniej {2} i maksymalnie {1} znaków.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Hasła nie są zgodne.")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Potwierdzenie Hasła jest wymagane.")]
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź Hasło")]

        public string ConfirmPassword { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace kreator_pomieszczen.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Email jest wymagany.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Hasło musi mieć co najmniej {8} i maksymalnie {1} znaków.")]
        [DataType(DataType.Password)]
        [Display(Name = "Nowe Hasło")]
        [Compare("ConfirmNewPassword", ErrorMessage = "Hasła nie są zgodne.")]

        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Potwierdzenie nowego hasła jest wymagane.")]
        [DataType(DataType.Password)]
        [Display(Name = "Potwierdź Nowe Hasło")]

        public string ConfirmNewPassword { get; set; }
    }
}

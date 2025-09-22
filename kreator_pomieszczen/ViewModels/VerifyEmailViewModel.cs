using System.ComponentModel.DataAnnotations;

namespace kreator_pomieszczen.ViewModels
{
    public class VerifyEmailViewModel
    {
        [Required(ErrorMessage = "Email jest wymagany.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace MusicAPI.ViewModel
{
    public class SignInModels
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

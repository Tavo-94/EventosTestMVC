using System.ComponentModel.DataAnnotations;

namespace EventosTestMVC.Models.ViewModel
{
    public class LogInViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

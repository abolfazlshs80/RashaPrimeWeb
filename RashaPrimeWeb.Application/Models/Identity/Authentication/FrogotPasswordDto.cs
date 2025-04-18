using System.ComponentModel.DataAnnotations;

namespace RashaPrimeWeb.Application.Models.Identity.Authentication
{
    public class FrogotPasswordDto
    {
        [Required]
        [Display(Name = "ایمیل")]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Message { get; set; } = " ";
    }
}

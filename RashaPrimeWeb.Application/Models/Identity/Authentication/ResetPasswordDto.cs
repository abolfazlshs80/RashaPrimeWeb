using System.ComponentModel.DataAnnotations;

namespace RashaPrimeWeb.Application.Models.Identity.Authentication
{
    public class ResetPasswordDto
    {
        [Required]
        [Display(Name = "رمزعبور")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required]
        [Display(Name = "تکرار رمزعبور")]
        [Compare(nameof(NewPassword))]
        [DataType(DataType.Password)]
        public string ConfirmNewPassword { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public string Email { get; set; }

        public string? Message { get; set; }
        public bool? Status { get; set; }
    }
}

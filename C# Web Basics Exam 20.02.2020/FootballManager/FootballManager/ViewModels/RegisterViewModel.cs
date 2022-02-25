using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels
{
    public class RegisterViewModel
    {
        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Username { get; set; }

        [StringLength(60, MinimumLength = 10, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }
    }
}

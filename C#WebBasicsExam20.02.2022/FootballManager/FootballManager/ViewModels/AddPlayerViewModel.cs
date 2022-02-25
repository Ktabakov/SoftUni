using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels
{
    public class AddPlayerViewModel
    {

        [StringLength(80, MinimumLength = 5, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Position { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "{0} must be in the range of {1}, {2}")]
        public byte Speed { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "{0} must be in the range of {1}, {2}")]
        public byte Endurance { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1, ErrorMessage = "{0} must be between {2} and {1} characters")]
        public string Description { get; set; }
    }
}

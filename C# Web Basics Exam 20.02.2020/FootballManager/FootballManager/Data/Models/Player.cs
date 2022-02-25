using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class Player
    {
        public Player()
        {
            UserPlayers = new List<UserPlayer>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 5)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Position { get; set; }

        [Required]
        [Range(0, 10)]
        public byte Speed { get; set; }

        [Required]
        [Range(0, 10)]
        public byte Endurance { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        public string Description { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; }
    }
}

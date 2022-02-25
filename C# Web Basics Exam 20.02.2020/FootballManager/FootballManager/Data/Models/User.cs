using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            UserPlayers = new List<UserPlayer>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [StringLength(60, MinimumLength = 10)]

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; }
    }
}

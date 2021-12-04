using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            PlayerStatistics = new HashSet<PlayerStatistic>();
            Bets = new HashSet<Bet>();
        }
        [Key]
        public int GameId { get; set; }

        [Required]
        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }
        public virtual Team HomeTeam { get; set; }

        [Required]
        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; set; }
        public virtual Team AwayTeam { get; set; }

        [Required]
        public byte HomeTeamGoals { get; set; }

        [Required]
        public byte AwayTeamGoals { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public decimal HomeTeamBetRate { get; set; }

        [Required]
        public decimal AwayTeamBetRate { get; set; }

        [Required]
        public decimal DrawBetRate { get; set; }

        [MaxLength(6)]
        [Required]
        public string Result { get; set; }
        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        public virtual ICollection<Bet> Bets { get; set; }
    }
}

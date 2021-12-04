using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Theatre.Data.Models
{
    public class Theatre
    {
        public Theatre()
        {
            Tickets = new HashSet<Ticket>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Name  { get; set; }

        [Range(1, 10)]
        [Required]
        public sbyte NumberOfHalls  { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Director  { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}

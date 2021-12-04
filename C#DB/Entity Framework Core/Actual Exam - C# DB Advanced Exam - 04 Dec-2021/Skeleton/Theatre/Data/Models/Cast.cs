using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Theatre.Data.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string FullName  { get; set; }

        [Required]
        public bool IsMainCharacter  { get; set; }

        [Required]
        public string PhoneNumber   { get; set; }

        [ForeignKey(nameof(Play))]
        [Required]
        public int PlayId  { get; set; }

        [Required]
        public Play Play { get; set; }
    }
}

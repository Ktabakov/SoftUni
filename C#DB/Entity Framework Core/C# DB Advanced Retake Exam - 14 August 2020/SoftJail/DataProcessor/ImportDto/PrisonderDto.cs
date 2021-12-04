using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonderDto
    {

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"^The\s[A-Z][a-z]+$")]
        public string Nickname { get; set; }

        [Required]
        [Range(18, 65)]
        public int Age { get; set; }

        [Required]
        public string IncarcerationDate { get; set; }
        //parse and validate
        public string ReleaseDate { get; set; }
        //parse and validate

        [Range(0, int.MaxValue)]
        public decimal? Bail { get; set; }
        //parse and validate

        public int? CellId { get; set; }

        public ICollection<PrisonerMailDto> Mails { get; set; }

    }
}

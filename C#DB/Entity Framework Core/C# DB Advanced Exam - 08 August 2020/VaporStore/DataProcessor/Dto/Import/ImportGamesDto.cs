﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VaporStore.DataProcessor.Dto
{
    public class ImportGamesDto
    {
        public ImportGamesDto()
        {
            Tags = new HashSet<string>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, (double)decimal.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Genre { get; set; }

        [MinLength(1)]
        [Required]
        public ICollection<string> Tags { get; set; }
    }
}

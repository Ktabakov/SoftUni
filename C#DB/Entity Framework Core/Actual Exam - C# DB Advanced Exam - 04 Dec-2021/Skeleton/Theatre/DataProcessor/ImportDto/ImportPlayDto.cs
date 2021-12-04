﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayDto
    {

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        [XmlElement("Title")]
        public string Title { get; set; }

        [Required]
        [XmlElement("Duration")]
        //maybe?
        [RegularExpression(@"^0[1-9]:[0-9][0-9]:[0-9][0-9]$")]
        public string Duration { get; set; }

        [Required]
        [XmlElement("Rating")]
        [Range(0.00, 10.00)]
        public float Rating { get; set; }

        [Required]
        [XmlElement("Genre")]
        //validate 
        public string Genre { get; set; }

        [Required()]
        [MaxLength(700)]
        [XmlElement("Description")]
        public string Description { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        [XmlElement("Screenwriter")]
        public string Screenwriter { get; set; }
    }
}

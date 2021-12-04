﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentCellsDto
    {
        [Range(1, 1000)]
        [Required]
        public int CellNumber { get; set; }

        [Required]
        public string HasWindow { get; set; }

      
    }
}

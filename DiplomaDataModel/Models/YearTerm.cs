﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiplomaDataModel.Models
{
    public class YearTerm
    {
        [Required]
        public int YearTermId { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Term { get; set; }

        [Required]
        public bool IsDefault { get; set; }
        [Required]
        public List<Choice> Choices { get; set; }
    }
}

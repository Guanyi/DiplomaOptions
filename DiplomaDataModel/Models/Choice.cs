using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiplomaDataModel.Models
{
    public class Choice
    {
        public int ChoiceId { get; set; }

        [Required]
        [StringLength(9), RegularExpression("A[0-9]{8}")]
        public string StudentId { get; set; }

        [Required]
        [MaxLength(40)]
        [Display(Name="First Name")]
        public string StudentFirstName { get; set; }

        [Required]
        [MaxLength(40)]
        [Display(Name = "Last Name")]
        public string StudentLastName { get; set; }

        [Required]
        [Display(Name = "First Choice")]
        public int FirstChoiceOptionId { get; set; }

        [Required]
        [Display(Name = "Second Choice")]
        public int SecondChoiceOptionId { get; set; }

        [Required]
        [Display(Name = "Third Choice")]
        public int ThirdChoiceOptionId { get; set; }

        [Required]
        [Display(Name = "Fourth Choice")]
        public int FourthChoiceOptionId { get; set; }

        [Required]
        public DateTime SelectionDate { get; set; }

        public YearTerm YearTerm { get; set; }
        public List<Option> Options { get; set; }
    }
}
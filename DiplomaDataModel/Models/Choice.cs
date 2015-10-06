using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiplomaDataModel.Models
{
    public class Choice
    {
        [Required]
        public int ChoiceId { get; set; }
        [Required]
        [StringLength(9), RegularExpression("A[0-9]{8}")]
        public string StudentId { get; set; }
        [Required]
        [MinLength(2), MaxLength(30)]
        public string StudentFirstName { get; set; }
        [Required]
        [MinLength(2), MaxLength(30)]
        public string StudentLastName { get; set; }
        [Required]
        public int FirstChoiceOptionId { get; set; }
        [Required]
        public int SecondChoiceOptionId { get; set; }
        [Required]
        public int ThirdChoiceOptionId { get; set; }
        [Required]
        public int FourthChoiceOptionId { get; set; }
        [Required]
        public DateTime SelectionDate { get; set; }

        public YearTerm YearTerm { get; set; }
        public List<Option> Options { get; set; }
    }
}
using midTerm.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace midTerm.Models.Models
{
    public class SurveyUserModelExtended
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Date of birth is required")]
        [DisplayName("Date of birth")]
        public DateTime? DoB { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [DisplayName("Gender")]
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace midTerm.Models.Models.AnswerModels
{
    public class AnswerUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        public int OptionId { get; set; }
    }
}

using midTerm.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace midTerm.Models.Models.AnswerModels
{
    public class AnswerModelExtended
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }

        public int OptionId { get; set; }
    }
}

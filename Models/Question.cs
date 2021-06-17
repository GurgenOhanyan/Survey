using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Header is Required")]
        public string Header { get; set; }
        public List<Option> Options { get; set; }
        public QuestionType QuestionType { get; set; }
        [Required]
        [ForeignKey("Survey")]
        public int SurveyId { get; set; }

        public List<Answer> Answers { get; set; }
    }
}

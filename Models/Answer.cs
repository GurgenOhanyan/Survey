using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [Display(Name = "Answer text")]
        public string AnswerText { get; set; }
        [Display(Name = "Choice option")]
        public int? AnswerValue { get; set; }
        [Display(Name = "Yes or No")]
        public bool AnswerBool { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public int ParticipantID { get; set; }
        public virtual Participant Participant { get; set; }

    }
}

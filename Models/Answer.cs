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

        public string AnswerText { get; set; }
        public int AnswerValue { get; set; }
        public bool AnswerBool { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public virtual Participant Participant { get; set; }

    }
}

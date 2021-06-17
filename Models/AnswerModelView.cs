using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models
{
    public class AnswerModelView
    {
        public string Header { get; set; }
        public QuestionType QuestionType { get; set; }
        public string AnswerText { get; set; }
        public int AnswerValue { get; set; }
        public bool AnswerBool { get; set; }
    }
}

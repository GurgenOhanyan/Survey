using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models
{
    public class QuestionModelView
    {
        public string Header { get; set; }
        public QuestionType QuestionType { get; set; }
        public Option Options1 { get; set; }
        public Option Options2 { get; set; }
        public Option Options3 { get; set; }
        public Option Options4 { get; set; }
        public Option Options5 { get; set; }
        
        //public int SurveyId { get; set; }
    }
}

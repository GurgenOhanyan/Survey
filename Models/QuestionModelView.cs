using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models
{
    public class QuestionModelView
    {
        [Required(ErrorMessage = "Header is Required")]
        public string Header { get; set; }
        public QuestionType QuestionType { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string Option5 { get; set; }
        
        //public string SurveyId { get; set; }
    }
}

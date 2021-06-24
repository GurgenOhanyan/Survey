using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models
{
    public class AnswerViewModel
    {
        // [BindProperty]
        //   public List<Answer> Answers { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public Participant participant { get; set; }
    }
}

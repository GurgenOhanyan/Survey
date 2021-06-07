using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models
{
    public enum QuestionType
    {
        Text = 1,
        YesNo = 2,
        Options = 3
    }

    public class QuestionTypes
    {
        public int Id { get; set; }
        public QuestionType Name { get; set; }
    }
}

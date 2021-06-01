using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models
{
    public enum QuestionTypes
    {
        Text = 1,
        YesNo = 2,
        Options = 3
    }

    public class QuestionType
    {
        public int Id { get; set; }
        public QuestionTypes Name { get; set; }
    }
}

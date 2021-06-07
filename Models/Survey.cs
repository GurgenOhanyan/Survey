using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public int QuestionsCount { get; set; }
        public List<Question> Questions { get; set; }
        public Status status { get; set; }
        public string CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}

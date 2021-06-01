using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
    }
}

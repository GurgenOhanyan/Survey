using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public List<Answer> Answers  { get; set; }
    }
}

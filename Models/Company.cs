using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public virtual Survey Survey { get; set; }
    }
}

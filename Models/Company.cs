using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models
{
    public class Company :IdentityUser
    {
        public Company(): base()
        {
                
        }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public virtual List<Survey> Surveys { get; set; }
    }
}

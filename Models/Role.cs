using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models
{
    public class Role : IdentityRole
    {
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public Role():base()
        {
        }
        public Role(string role):base(role)
        { 
        }
        public Role(string role,string description,DateTime creationTime):base(role)
        {
            this.Description = description;
            this.CreationTime = creationTime;
        }
    }
}

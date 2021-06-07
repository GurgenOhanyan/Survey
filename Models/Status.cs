using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models
{
    public enum Status
    {
        Draft = 1,
        Completed = 2
    }
    public class Statuses
    {
        public int Id { get; set; }
        public Status Name { get; set; }
    }
}

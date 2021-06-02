using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Models.Repository
{
    public interface IQuestionRepository : IRepository<Question, int>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Aggregates;
using Jobag.src.Shared.Domain.Result;

namespace Jobag.src.Resume.Domain.Result
{
    public class SkillPostulantResult : BaseResult<SkillPostulant>
    {
        public SkillPostulantResult(SkillPostulant resource) : base(resource)
        {
        }

        public SkillPostulantResult(string message) : base(message)
        {
        }
    }
}
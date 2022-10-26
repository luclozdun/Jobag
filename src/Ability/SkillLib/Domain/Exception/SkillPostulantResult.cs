using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Aggregate;
using Jobag.src.Shared.Domain.Exception;

namespace Jobag.src.Ability.SkillLib.Domain.Exception
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Aggregate;
using Jobag.src.Shared.Domain.Exception;

namespace Jobag.src.Ability.SkillLib.Domain.Exception
{
    public class ListSkillPostulantResult : BaseResult<IEnumerable<SkillPostulant>>
    {
        public ListSkillPostulantResult(IEnumerable<SkillPostulant> resource) : base(resource)
        {
        }

        public ListSkillPostulantResult(string message) : base(message)
        {
        }
    }
}
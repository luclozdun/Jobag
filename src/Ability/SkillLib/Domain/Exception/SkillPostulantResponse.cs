using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Aggregate;
using Jobag.src.Shared.Domain.Exception;

namespace Jobag.src.Ability.SkillLib.Domain.Exception
{
    public class SkillPostulantResponse : BaseReponse<SkillPostulant>
    {
        public SkillPostulantResponse(SkillPostulant resource) : base(resource)
        {
        }

        public SkillPostulantResponse(string message) : base(message)
        {
        }
    }
}
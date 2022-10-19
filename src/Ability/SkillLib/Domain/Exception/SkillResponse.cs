using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Entity;
using Jobag.src.Shared.Domain.Exception;

namespace Jobag.src.Ability.SkillLib.Domain.Exception
{
    public class SkillResponse : BaseReponse<Skill>
    {
        public SkillResponse(Skill resource) : base(resource)
        {
        }

        public SkillResponse(string message) : base(message)
        {
        }
    }
}
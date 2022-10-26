using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Entity;
using Jobag.src.Shared.Domain.Exception;

namespace Jobag.src.Ability.SkillLib.Domain.Exception
{
    public class SkillResult : BaseResult<Skill>
    {
        public SkillResult(Skill resource) : base(resource)
        {
        }

        public SkillResult(string message) : base(message)
        {
        }
    }
}
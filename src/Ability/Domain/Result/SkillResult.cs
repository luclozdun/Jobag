using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Result;

namespace Jobag.src.Ability.Domain.Result
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
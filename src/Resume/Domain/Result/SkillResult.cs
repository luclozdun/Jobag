using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Result;

namespace Jobag.src.Resume.Domain.Result
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
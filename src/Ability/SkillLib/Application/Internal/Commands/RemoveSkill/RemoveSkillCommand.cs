using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.SkillLib.Application.Internal.Commands.RemoveSkill
{
    public class RemoveSkillCommand : ICommand<SkillResult>
    {
        public RemoveSkillCommand(int Id)
        {
            this.Id = Id;
        }

        public int Id { get; private set; }
    }
}
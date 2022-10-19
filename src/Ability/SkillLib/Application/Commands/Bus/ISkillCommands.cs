using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Application.Commands.CreateSkill;
using Jobag.src.Ability.SkillLib.Domain.Exception;

namespace Jobag.src.Ability.SkillLib.Application.Commands.Bus
{
    public interface ISkillCommands
    {
        Task<SkillResponse> Create(CreateSkillCommand command);
    }
}
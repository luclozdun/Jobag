using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.SkillLib.Application.Internal.Commands.CreateSkillPostulant
{
    public class CreateSkillPostulantCommand : ICommand<SkillPostulantResult>
    {
        public CreateSkillPostulantCommand(int postulantId, int skillId)
        {
            this.postulantId = postulantId;
            this.skillId = skillId;
        }

        public int postulantId { get; }
        public int skillId { get; }
    }
}
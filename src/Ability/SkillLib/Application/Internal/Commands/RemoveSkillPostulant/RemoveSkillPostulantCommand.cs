using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.SkillLib.Application.Internal.Commands.RemoveSkillPostulant
{
    public class RemoveSkillPostulantCommand : ICommand<SkillPostulantResult>
    {
        public RemoveSkillPostulantCommand(int skillId, int postulantId)
        {
            this.skillId = skillId;
            this.postulantId = postulantId;
        }

        public int skillId { get; private set; }

        public int postulantId { get; private set; }
    }
}
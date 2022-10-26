using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Aggregate;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Ability.SkillLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Ability.SkillLib.Application.Internal.Commands.CreateSkillPostulantByListSkill
{
    public class CreateListSkillPostulantCommand : ICommand<ListSkillPostulantResult>
    {
        public int postulantId { get; set; }

        public IList<SkillId> skillIds { get; set; }

        public CreateListSkillPostulantCommand(int postulantId, IList<SkillId> skillIds)
        {
            this.postulantId = postulantId;
            this.skillIds = skillIds;
        }
    }
}
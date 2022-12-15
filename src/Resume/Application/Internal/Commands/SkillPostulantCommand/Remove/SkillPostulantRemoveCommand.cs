using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.ValueObjects;
using Jobag.src.Resume.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Resume.Application.Internal.Commands.SkillPostulantCommand.Remove
{
    public class SkillPostulantRemoveCommand : ICommand<SkillPostulantResult>
    {
        public SkillId SkillId { get; }
        public PostulantId PostulantId { get; }

        public SkillPostulantRemoveCommand(int skillId, int postulantId)
        {
            SkillId = new SkillId(skillId);
            PostulantId = new PostulantId(postulantId);
        }
    }
}
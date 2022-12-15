using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Resume.Application.Internal.Commands.SkillPostulantCommand.Save
{
    public class SkillPostulantSaveCommand : ICommand<SkillPostulantResult>
    {
        public int SkillId { get; }
        public int PostulantId { get; }

        public SkillPostulantSaveCommand()
        {
        }

        public SkillPostulantSaveCommand(int skillId, int postulantId)
        {
            SkillId = skillId;
            PostulantId = postulantId;
        }
    }
}
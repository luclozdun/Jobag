using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Resume.Domain.Model.ValueObjects
{
    public class SkillPostulantId
    {
        public int SkillId { get; }
        public int PostulantId { get; }

        public SkillPostulantId(int skillId, int postulantId)
        {
            SkillId = skillId;
            PostulantId = postulantId;
        }
    }
}
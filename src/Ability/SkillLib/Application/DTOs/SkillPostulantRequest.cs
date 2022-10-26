using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Ability.SkillLib.Application.DTOs
{
    public class SkillPostulantRequest
    {
        public SkillPostulantRequest(int skillId, int postulantId)
        {
            this.skillId = skillId;
            this.postulantId = postulantId;
        }

        public int skillId { get; set; }
        public int postulantId { get; set; }
    }
}
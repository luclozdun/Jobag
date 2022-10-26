using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.ValueObject;

namespace Jobag.src.Ability.SkillLib.Application.DTOs
{
    public class ListSkillIdAndPostulantIdRequest
    {
        public ListSkillIdAndPostulantIdRequest(int postulantId, IList<SkillId> skillIds)
        {
            this.postulantId = postulantId;
            this.skillIds = skillIds;
        }

        public int postulantId { get; set; }
        public IList<SkillId> skillIds { get; set; }
    }
}
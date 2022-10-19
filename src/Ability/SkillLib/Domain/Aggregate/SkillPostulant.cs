using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Ability.SkillLib.Domain.Entity;
using Jobag.src.Ability.SkillLib.Domain.ValueObject;

namespace Jobag.src.Ability.SkillLib.Domain.Aggregate
{
    public class SkillPostulant
    {
        private SkillPostulant()
        {
        }

        public SkillPostulant(int skillId, int postulantId)
        {
            this.skillId = skillId;
            this.postulantId = postulantId;
        }

        public int skillId { get; private set; }
        public int postulantId { get; private set; }

        public Skill skill { get; set; }

        public Postulant postulant { get; set; }
    }
}
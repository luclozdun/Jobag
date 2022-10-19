using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.SkillLib.Domain.Entity;

namespace Jobag.src.Ability.SkillLib.Domain.Resource
{
    public class SkillPostulantResource
    {
        public int skillId { get; private set; }
        public int postulantId { get; private set; }
        public Skill skill { get; private set; }
        public Postulant postulant { get; private set; }
    }
}
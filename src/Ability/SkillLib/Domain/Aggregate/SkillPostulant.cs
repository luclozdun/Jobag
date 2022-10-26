using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
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

        public SkillPostulant(SkillId skillId, PostulantId postulantId)
        {
            this.SkillId = (int)skillId;
            this.PostulantId = (int)postulantId;
        }

        public int SkillId { get; private set; }
        public int PostulantId { get; private set; }

        public Skill Skill { get; }

        [JsonIgnore]
        public Postulant Postulant { get; }
    }
}
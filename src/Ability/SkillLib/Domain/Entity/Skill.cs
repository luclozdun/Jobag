using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Aggregate;
using Jobag.src.Ability.SkillLib.Domain.ValueObject;

namespace Jobag.src.Ability.SkillLib.Domain.Entity
{
    public class Skill
    {
        public int Id { get; private set; }
        public SkillName Name { get; private set; }
        public SkillDescription Description { get; private set; }
        public IList<SkillPostulant> skillPostulants { get; set; }
        private Skill(int id, SkillName name, SkillDescription description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        private Skill()
        {
        }

        public static Skill Create(SkillName name, SkillDescription description)
        {
            return new Skill(0, name, description);
        }

        public void setId(SkillId id)
        {
            this.Id = id;
        }

        public void setName(SkillName name)
        {
            this.Name = name;
        }

        public void setDescription(SkillDescription description)
        {
            this.Description = description;
        }
    }
}
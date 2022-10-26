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
        public string Name { get; private set; }
        public string Description { get; private set; }

        [JsonIgnore]
        public IList<SkillPostulant> SkillPostulants { get; set; }
        private Skill(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        private Skill()
        {
        }

        public static Skill Create(string name, string description)
        {
            return new Skill(0, name, description);
        }

        public void setId(SkillId id)
        {
            this.Id = id;
        }

        public void setName(string name)
        {
            this.Name = name;
        }

        public void setDescription(string description)
        {
            this.Description = description;
        }

        public void Update(Skill request)
        {
            this.Name = request.Name;
            this.Description = request.Description;
        }
    }
}
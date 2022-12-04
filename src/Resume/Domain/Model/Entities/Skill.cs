using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Aggregates;
using Jobag.src.Shared.Domain.Model.Entities;

namespace Jobag.src.Resume.Domain.Model.Entities
{
    public class Skill : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        [JsonIgnore]
        public IList<SkillPostulant> SkillPostulants { get; set; }
        private Skill(string name, string description)
        {
            Name = name;
            Description = description;
        }

        private Skill()
        {
        }

        public static Skill Create(string name, string description)
        {
            return new Skill(name, description);
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
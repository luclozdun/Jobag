using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Resume.Domain.Model.ValueObjects;
using Jobag.src.Resume.Domain.Repositories;

namespace Jobag.src.Resume.Domain.Model.Aggregates
{
    public class SkillPostulant
    {
        public int SkillId { get; private set; }
        public int PostulantId { get; private set; }

        public Skill Skill { get; }

        [JsonIgnore]
        public Postulant Postulant { get; }

        private SkillPostulant()
        {
        }

        private SkillPostulant(SkillId SkillId, PostulantId PostulantId)
        {
            this.SkillId = (int)SkillId;
            this.PostulantId = (int)PostulantId;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Aggregate;
using Jobag.src.Ability.SkillLib.Domain.Entity;

namespace Jobag.src.Ability.SkillLib.Application.DTOs
{
    public class SkillResponse
    {
        private SkillResponse(Skill skill)
        {
            Id = skill.Id;
            Name = skill.Name;
            Description = skill.Description;
        }

        public static SkillResponse Convert(Skill skill)
        {
            return new SkillResponse(skill);
        }

        public static List<SkillResponse> ConvertToList(IList<SkillPostulant> skills)
        {
            List<SkillResponse> res = new List<SkillResponse>();

            foreach (SkillPostulant skillPostulant in skills)
            {
                res.Add(new SkillResponse(skillPostulant.Skill));
            }

            return res;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
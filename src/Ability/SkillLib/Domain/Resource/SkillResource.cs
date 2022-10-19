using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Aggregate;
using Jobag.src.Ability.SkillLib.Domain.Entity;

namespace Jobag.src.Ability.SkillLib.Domain.Resource
{
    public class SkillResource
    {
        private SkillResource(Skill skill)
        {
            Id = skill.Id;
            Name = skill.Name;
            Description = skill.Description;
        }

        public static SkillResource Convert(Skill skill)
        {
            return new SkillResource(skill);
        }

        public static List<SkillResource> ConvertToList(IList<SkillPostulant> skills)
        {
            List<SkillResource> res = new List<SkillResource>();

            foreach (SkillPostulant skillPostulant in skills)
            {
                res.Add(new SkillResource(skillPostulant.skill));
            }

            return res;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.SkillLib.Domain.Entity;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Ability.SkillLib.Domain.ValueObject;

namespace Jobag.src.Ability.SkillLib.Domain.Repository
{
    public interface ISkillRepository
    {
        Task<Skill> FindSkillById(SkillId id);

        Task<Skill> FindSkillByName(SkillName name);

        Task CreateSkill(Skill skill);

        void UpdateSkill(Skill skill);

        void RemoveSkill(Skill id);
    }
}
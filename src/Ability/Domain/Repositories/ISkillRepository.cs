using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.Entities;
using Jobag.src.Ability.Domain.Model.ValueObjects;

namespace Jobag.src.Ability.Domain.Repositories
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> FindAll();

        Task Save(Skill skill);

        Task<Skill> FindByName(string Name);

        Task<Skill> FindById(SkillId skillId);

        void Remove(Skill skill);
    }
}
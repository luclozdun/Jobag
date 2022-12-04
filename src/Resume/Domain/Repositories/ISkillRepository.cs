using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Resume.Domain.Model.ValueObjects;

namespace Jobag.src.Resume.Domain.Repositories
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
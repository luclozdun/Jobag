using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Aggregates;

namespace Jobag.src.Resume.Domain.Repositories
{
    public interface ISkillPostulantRepository
    {
        Task Save(SkillPostulant skillPostulant);

        Task SaveList(IList<SkillPostulant> skillPostulants);

        void Remove(SkillPostulant skillPostulant);
    }
}
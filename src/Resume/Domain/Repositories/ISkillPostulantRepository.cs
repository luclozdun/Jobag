using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Aggregates;
using Jobag.src.Resume.Domain.Model.ValueObjects;

namespace Jobag.src.Resume.Domain.Repositories
{
    public interface ISkillPostulantRepository
    {
        Task Save(SkillPostulant skillPostulant);

        Task SaveList(IList<SkillPostulant> skillPostulants);

        void Remove(SkillPostulant skillPostulant);

        void Remove(IEnumerable<SkillPostulant> skillPostulant);

        Task<SkillPostulant> FindBySkillIdAndPostulantId(SkillId skillId, PostulantId postulantId);

        Task<IEnumerable<SkillPostulant>> FindByPostulantId(PostulantId postulantId);
    }
}
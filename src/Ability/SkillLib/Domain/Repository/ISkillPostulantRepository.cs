using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Ability.SkillLib.Domain.Aggregate;
using Jobag.src.Ability.SkillLib.Domain.Exception;
using Jobag.src.Ability.SkillLib.Domain.ValueObject;

namespace Jobag.src.Ability.SkillLib.Domain.Repository
{
    public interface ISkillPostulantRepository
    {
        Task AddSkillByIdAndPostulantById(SkillPostulant skillPostulant);

        Task AddSkillPostulantByPostulantIdAndListSkillId(IList<SkillPostulant> skillPostulants);

        void RemoveSkillPostulant(SkillPostulant skillPostulant);

        void RemoveSkillPostulantBySkillId(List<SkillPostulant> skillPostulants);

        Task<List<SkillPostulant>> FindSkillPostulantBySkillId(SkillId skillId);

        Task<SkillPostulant> FindSkillPostulantBySkillIdAndPostulantId(PostulantId postulantId, SkillId skillId);
    }
}
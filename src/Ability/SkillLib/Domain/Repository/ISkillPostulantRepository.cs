using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Ability.SkillLib.Domain.Aggregate;
using Jobag.src.Ability.SkillLib.Domain.Exception;

namespace Jobag.src.Ability.SkillLib.Domain.Repository
{
    public interface ISkillPostulantRepository
    {
        Task AddSkillByIdAndPostulantById(SkillPostulant skillPostulant);

        Task<IList<SkillPostulant>> FindAllSkillByPostulantId(PostulantId postulantId);
    }
}
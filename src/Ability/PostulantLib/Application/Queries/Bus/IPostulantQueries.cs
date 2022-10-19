using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Application.Queries.FindById;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Resource;
using Jobag.src.Ability.SkillLib.Domain.Resource;

namespace Jobag.src.Ability.PostulantLib.Application.Queries.Bus
{
    public interface IPostulantQueries
    {
        Task<PostulantResponse> FindById(int id);
        Task<IEnumerable<Postulant>> FindAll();

        Task<List<SkillResource>> FindInformacionById(int id);
    }
}
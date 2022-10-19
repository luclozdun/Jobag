using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Application.Queries.FindAll;
using Jobag.src.Ability.PostulantLib.Application.Queries.FindById;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Repository;
using Jobag.src.Ability.PostulantLib.Domain.Resource;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Ability.SkillLib.Domain.Resource;

namespace Jobag.src.Ability.PostulantLib.Application.Queries.Bus
{
    public class PostulantQueries : IPostulantQueries
    {
        private readonly IPostulantRepository postulantRepository;

        public PostulantQueries(IPostulantRepository postulantRepository)
        {
            this.postulantRepository = postulantRepository;
        }

        public async Task<PostulantResponse> FindById(int id)
        {
            FindByIdPostulantQuery query = new FindByIdPostulantQuery(id);
            FindByIdPostulantQueryHandler handler = new FindByIdPostulantQueryHandler(new PostulantFinderById(postulantRepository));
            return await handler.Handle(query);
        }

        public async Task<IEnumerable<Postulant>> FindAll()
        {
            FindAllPostulantQueryHandler handler = new FindAllPostulantQueryHandler(new PostulantFinderAll(postulantRepository));
            return await handler.Handle();
        }

        public async Task<List<SkillResource>> FindInformacionById(int id)
        {
            var a = await postulantRepository.FindPostulantInformationById(new PostulantId(id));
            return PostulantInformationResource.dw(a);
        }
    }
}
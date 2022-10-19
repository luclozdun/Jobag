using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Repository;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;

namespace Jobag.src.Ability.PostulantLib.Application.Queries.FindById
{
    public class PostulantFinderById
    {
        private readonly IPostulantRepository postulantRepository;

        public PostulantFinderById(IPostulantRepository postulantRepository)
        {
            this.postulantRepository = postulantRepository;
        }

        public async Task<PostulantResponse> FindById(FindByIdPostulantQuery query)
        {
            PostulantId id = PostulantId.Create(query.id);
            Postulant postulant = await postulantRepository.FindPostulantById(id);
            if (postulant == null)
                return new PostulantResponse("Postulant not found");
            return new PostulantResponse(postulant);
        }
    }
}
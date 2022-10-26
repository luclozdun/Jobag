using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Application.Internal.Queries.FindPostulantById;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Repository;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Ability.PostulantLib.Application.Internal.Queries.FindPostulantInformationById
{
    internal sealed class FindPostulantByIdQueryHandler : IQueryHandler<FindPostulantByIdQuery, PostulantResult>
    {
        private readonly IPostulantRepository postulantRepository;

        public FindPostulantByIdQueryHandler(IPostulantRepository postulantRepository)
        {
            this.postulantRepository = postulantRepository;
        }

        public async Task<PostulantResult> Handle(FindPostulantByIdQuery request, CancellationToken cancellationToken)
        {
            PostulantId id = PostulantId.Create(request.Id);
            Postulant postulant = await postulantRepository.FindPostulantById(id);
            if (postulant == null)
                return new PostulantResult("Postulant not found");
            return new PostulantResult(postulant);
        }
    }
}
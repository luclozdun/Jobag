using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.PostulantLib.Application.Internal.Queries.FindPostulantInformationById;
using Jobag.src.Ability.PostulantLib.Domain.Entity;
using Jobag.src.Ability.PostulantLib.Domain.Exception;
using Jobag.src.Ability.PostulantLib.Domain.Repository;
using Jobag.src.Ability.PostulantLib.Domain.ValueObject;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Ability.PostulantLib.Application.Internal.Queries.FindInformationById
{
    public sealed class FindPostulantInformationByIdQueryHandler : IQueryHandler<FindPostulantInformationByIdQuery, PostulantResult>
    {
        private readonly IPostulantRepository postulantRepository;

        public FindPostulantInformationByIdQueryHandler(IPostulantRepository postulantRepository)
        {
            this.postulantRepository = postulantRepository;
        }

        public async Task<PostulantResult> Handle(FindPostulantInformationByIdQuery request, CancellationToken cancellationToken)
        {
            Postulant postulant = await postulantRepository.FindPostulantInformationById(new PostulantId(request.Id));
            if (postulant == null)
            {
                return new PostulantResult($"Postulant not found by Id: {request.Id}");
            }
            return new PostulantResult(postulant);
        }
    }
}
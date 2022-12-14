using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Model.Entities;
using Jobag.src.Resume.Domain.Result;
using Jobag.src.Resume.Domain.Model.ValueObjects;
using Jobag.src.Resume.Domain.Repositories;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Resume.Application.Internal.Queries.PostulantQueries.PostulantInformation
{
    public class PostulantInformationQueryHandler : IQueryHandler<PostulantInformationQuery, PostulantResult>
    {
        private readonly IPostulantRepository postulantRepository;

        public PostulantInformationQueryHandler(IPostulantRepository postulantRepository)
        {
            this.postulantRepository = postulantRepository;
        }

        public async Task<PostulantResult> Handle(PostulantInformationQuery request, CancellationToken cancellationToken)
        {
            PostulantId postulantId = new PostulantId(request.Id);
            Postulant postulant = await postulantRepository.FindById(postulantId);
            if (postulant == null)
                return new PostulantResult("Postulant not exist");
            return new PostulantResult(postulant);
        }
    }
}
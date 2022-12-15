using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Aggregates;
using Jobag.src.Job.Domain.Repository;
using Jobag.src.Job.Domain.Result;
using Jobag.src.Resume.Domain.Model.ValueObjects;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Job.Application.Internal.Queries.JobOfferPostulantQueries.FindMyPostulantions
{
    public class FindMyPostulantionsCommandHandler : ICommandHandler<FindMyPostulantionsCommand, IEnumerable<JobOfferPostulant>>
    {
        private readonly IJobOfferPostulantRepository jobOfferPostulantRepository;

        public FindMyPostulantionsCommandHandler(IJobOfferPostulantRepository jobOfferPostulantRepository)
        {
            this.jobOfferPostulantRepository = jobOfferPostulantRepository;
        }

        public async Task<IEnumerable<JobOfferPostulant>> Handle(FindMyPostulantionsCommand request, CancellationToken cancellationToken)
        {
            PostulantId postulantId = new PostulantId(request.PostulantId);
            return await jobOfferPostulantRepository.FindByPostulantId(postulantId);
        }
    }
}
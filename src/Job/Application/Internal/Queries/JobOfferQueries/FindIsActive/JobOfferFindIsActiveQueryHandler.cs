using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Entities;
using Jobag.src.Job.Domain.Repository;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Job.Application.Internal.Queries.JobOfferQueries.FindIsActive
{
    public class JobOfferFindIsActiveQueryHandler : IQueryHandler<JobOfferFindIsActiveQuery, IEnumerable<JobOffer>>
    {
        private readonly IJobOfferRepository jobOfferRepository;

        public JobOfferFindIsActiveQueryHandler(IJobOfferRepository jobOfferRepository)
        {
            this.jobOfferRepository = jobOfferRepository;
        }

        public async Task<IEnumerable<JobOffer>> Handle(JobOfferFindIsActiveQuery request, CancellationToken cancellationToken)
        {
            return await jobOfferRepository.FindAllIsActive();
        }
    }
}
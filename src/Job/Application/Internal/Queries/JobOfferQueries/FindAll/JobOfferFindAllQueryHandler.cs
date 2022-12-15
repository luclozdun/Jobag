using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Entities;
using Jobag.src.Job.Domain.Repository;
using Jobag.src.Job.Domain.Result;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Job.Application.Internal.Queries.JobOfferQueries.FindAll
{
    public class JobOfferFindAllQueryHandler : IQueryHandler<JobOfferFindAllQuery, IEnumerable<JobOffer>>
    {
        private readonly IJobOfferRepository jobOfferRepository;

        public JobOfferFindAllQueryHandler(IJobOfferRepository jobOfferRepository)
        {
            this.jobOfferRepository = jobOfferRepository;
        }

        public Task<IEnumerable<JobOffer>> Handle(JobOfferFindAllQuery request, CancellationToken cancellationToken)
        {
            return jobOfferRepository.FindAll();
        }
    }
}
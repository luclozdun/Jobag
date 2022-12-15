using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Entities;
using Jobag.src.Job.Domain.Model.ValueObjects;
using Jobag.src.Job.Domain.Repository;
using Jobag.src.Job.Domain.Result;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Job.Application.Internal.Queries.JobOfferQueries.FindById
{
    public class JobOfferFindByIdQueryHandler : IQueryHandler<JobOfferFindByIdQuery, JobOfferResult>
    {
        private readonly IJobOfferRepository jobOfferRepository;

        public JobOfferFindByIdQueryHandler(IJobOfferRepository jobOfferRepository)
        {
            this.jobOfferRepository = jobOfferRepository;
        }

        public async Task<JobOfferResult> Handle(JobOfferFindByIdQuery request, CancellationToken cancellationToken)
        {
            JobOfferId jobOfferId = new JobOfferId(request.Id);
            JobOffer jobOffer = await jobOfferRepository.FindById(jobOfferId);
            if(jobOffer == null){
                return new JobOfferResult("Not found the job offer by Id");
            }
            return new JobOfferResult(jobOffer);
        }
    }
}
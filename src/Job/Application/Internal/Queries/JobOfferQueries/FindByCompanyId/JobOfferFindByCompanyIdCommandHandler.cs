using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Job.Domain.Model.Entities;
using Jobag.src.Job.Domain.Repository;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Job.Application.Internal.Queries.JobOfferQueries.FindByCompanyId
{
    public class JobOfferFindByCompanyIdCommandHandler : ICommandHandler<JobOfferFindByCompanyIdCommand, IEnumerable<JobOffer>>
    {
        private readonly IJobOfferRepository jobOfferRepository;

        public JobOfferFindByCompanyIdCommandHandler(IJobOfferRepository jobOfferRepository)
        {
            this.jobOfferRepository = jobOfferRepository;
        }

        public async Task<IEnumerable<JobOffer>> Handle(JobOfferFindByCompanyIdCommand request, CancellationToken cancellationToken)
        {
            CompanyId companyId = new CompanyId(request.CompanyId);
            return await jobOfferRepository.FindByCompanyId(companyId);
        }
    }
}
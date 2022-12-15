using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Entities;
using Jobag.src.Job.Domain.Model.ValueObjects;
using Jobag.src.Job.Domain.Repository;
using Jobag.src.Job.Domain.Result;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;
using Jobag.src.Shared.Infraestructure.Resource;

namespace Jobag.src.Job.Application.Internal.Commands.JobOfferCommands.Remove
{
    public class JobOfferRemoveHandler : ICommandHandler<JobOfferRemove, JobOfferResult>
    {
        private readonly IJobOfferRepository jobOfferRepository;
        private readonly IUnitOfWork unitOfWork;

        public JobOfferRemoveHandler(IUnitOfWork unitOfWork, IJobOfferRepository jobOfferRepository)
        {
            this.unitOfWork = unitOfWork;
            this.jobOfferRepository = jobOfferRepository;
        }

        public async Task<JobOfferResult> Handle(JobOfferRemove request, CancellationToken cancellationToken)
        {
            JobOffer jobOffer = await jobOfferRepository.FindById(new JobOfferId(request.JobOfferId));

            try{
                jobOfferRepository.Remove(jobOffer);
                await unitOfWork.CompleteAsync();
                return new JobOfferResult(jobOffer);
            }catch(Exception e){
                return new JobOfferResult($"Error ocurred while removing job offer: {e.Message}");
            }
        }
    }
}
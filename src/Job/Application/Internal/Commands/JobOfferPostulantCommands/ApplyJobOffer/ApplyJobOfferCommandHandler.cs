using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Aggregates;
using Jobag.src.Job.Domain.Model.ValueObjects;
using Jobag.src.Job.Domain.Repository;
using Jobag.src.Job.Domain.Result;
using Jobag.src.Resume.Domain.Model.ValueObjects;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Job.Application.Internal.Commands.JobOfferPostulantCommands.ApplyJobOffer
{
    public class ApplyJobOfferCommandHandler : ICommandHandler<ApplyJobOfferCommand, JobOfferPostulantResult>
    {
        private readonly IJobOfferPostulantRepository jobOfferPostulantRepository;
        private readonly IUnitOfWork unitOfWork;

        public ApplyJobOfferCommandHandler(IJobOfferPostulantRepository jobOfferPostulantRepository, IUnitOfWork unitOfWork)
        {
            this.jobOfferPostulantRepository = jobOfferPostulantRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<JobOfferPostulantResult> Handle(ApplyJobOfferCommand request, CancellationToken cancellationToken)
        {
            JobOfferId jobOfferId = new JobOfferId(request.JobOfferId);
            PostulantId postulantId = new PostulantId(request.PostulantId);
            JobOfferPostulant jobOfferPostulant = JobOfferPostulant.ApplyJobOffer(postulantId, jobOfferId);

            try
            {
                await jobOfferPostulantRepository.AddJobOffer(jobOfferPostulant);
                await unitOfWork.CompleteAsync();
                return new JobOfferPostulantResult(jobOfferPostulant);
            }
            catch (Exception e)
            {
                return new JobOfferPostulantResult($"Error ocurred while applying job offer: {e.Message}");
            }




        }
    }
}
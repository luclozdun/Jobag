using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Aggregates;
using Jobag.src.Job.Domain.Model.ValueObjects;
using Jobag.src.Job.Domain.Repository;
using Jobag.src.Shared.Application.Commands;
using Jobag.src.Shared.Domain.Repository;

namespace Jobag.src.Job.Application.Internal.Commands.JobOfferCourseCommands.RemoveRange
{
    public class JobOfferCourseRemoveRangeCommandHandler : ICommandHandler<JobOfferCourseRemoveRangeCommand, IEnumerable<JobOfferCourse>>
    {
        private readonly IJobOfferCourseRepository jobOfferCourseRepository;

        private readonly IUnitOfWork unitOfWork;

        public JobOfferCourseRemoveRangeCommandHandler(IJobOfferCourseRepository jobOfferCourseRepository, IUnitOfWork unitOfWork)
        {
            this.jobOfferCourseRepository = jobOfferCourseRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<JobOfferCourse>> Handle(JobOfferCourseRemoveRangeCommand request, CancellationToken cancellationToken)
        {
            JobOfferId jobOfferId = new JobOfferId(request.JobOfferId);
            IEnumerable<JobOfferCourse> jobOfferCourses = await jobOfferCourseRepository.FindByJobOfferId(jobOfferId);

            jobOfferCourseRepository.Remove(jobOfferCourses);
            await unitOfWork.CompleteAsync();
            return jobOfferCourses;
        }
    }
}
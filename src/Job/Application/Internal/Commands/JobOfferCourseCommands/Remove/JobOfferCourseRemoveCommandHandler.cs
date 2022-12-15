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

namespace Jobag.src.Job.Application.Internal.Commands.JobOfferCourseCommands.Remove
{
    public class JobOfferCourseRemoveCommandHandler : ICommandHandler<JobOfferCourseRemoveCommand, JobOfferCourseResult>
    {
        private readonly IJobOfferCourseRepository jobOfferCourseRepository;

        private readonly IUnitOfWork unitOfWork;

        public JobOfferCourseRemoveCommandHandler(IJobOfferCourseRepository jobOfferCourseRepository, IUnitOfWork unitOfWork)
        {
            this.jobOfferCourseRepository = jobOfferCourseRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<JobOfferCourseResult> Handle(JobOfferCourseRemoveCommand request, CancellationToken cancellationToken)
        {
            JobOfferId jobOfferId = new JobOfferId(request.JobOfferId);
            CourseId courseId = new CourseId(request.JobOfferId);

            JobOfferCourse jobOfferCourse = await jobOfferCourseRepository.FindByJobOfferIdAndCourseId(jobOfferId, courseId);

            if (jobOfferCourse == null)
                return new JobOfferCourseResult("Job offer course not found");

            try
            {
                jobOfferCourseRepository.Remove(jobOfferCourse);
                await unitOfWork.CompleteAsync();
                return new JobOfferCourseResult(jobOfferCourse);
            }
            catch (Exception e)
            {
                return new JobOfferCourseResult($"Error ocurred while removing a job offer course: {e.Message}");
            }

        }
    }
}
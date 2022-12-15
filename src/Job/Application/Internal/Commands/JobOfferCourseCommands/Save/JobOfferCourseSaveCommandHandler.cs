using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Job.Application.Internal.Commands.JobOfferCourseCommands.Save
{
    public class JobOfferCourseSaveCommandHandler : ICommandHandler<JobOfferCourseSaveCommand, JobOfferCourseResult>
    {
        public Task<JobOfferCourseResult> Handle(JobOfferCourseSaveCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
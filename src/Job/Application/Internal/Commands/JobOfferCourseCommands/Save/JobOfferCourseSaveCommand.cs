using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Job.Application.Internal.Commands.JobOfferCourseCommands.Save
{
    public class JobOfferCourseSaveCommand : ICommand<JobOfferCourseResult>
    {
        public int JobOfferId { get; private set; }

        public int CourseId { get; private set; }

        public JobOfferCourseSaveCommand()
        {
        }
    }
}
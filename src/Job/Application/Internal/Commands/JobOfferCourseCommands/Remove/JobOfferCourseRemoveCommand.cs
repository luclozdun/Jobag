using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Job.Application.Internal.Commands.JobOfferCourseCommands.Remove
{
    public class JobOfferCourseRemoveCommand : ICommand<JobOfferCourseResult>
    {
        public int JobOfferId { get; }
        public int CourseId { get; }

        public JobOfferCourseRemoveCommand()
        {
        }
    }
}
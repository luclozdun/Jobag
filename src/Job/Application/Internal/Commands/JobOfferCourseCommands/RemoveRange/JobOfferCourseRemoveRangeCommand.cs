using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Aggregates;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Job.Application.Internal.Commands.JobOfferCourseCommands.RemoveRange
{
    public class JobOfferCourseRemoveRangeCommand : ICommand<IEnumerable<JobOfferCourse>>
    {
        public int JobOfferId { get; }

        public JobOfferCourseRemoveRangeCommand(int jobOfferId)
        {
            JobOfferId = jobOfferId;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Aggregates;
using Jobag.src.Shared.Domain.Result;

namespace Jobag.src.Job.Domain.Result
{
    public class JobOfferCourseResult : BaseResult<JobOfferCourse>
    {
        public JobOfferCourseResult(JobOfferCourse resource) : base(resource)
        {
        }

        public JobOfferCourseResult(string message) : base(message)
        {
        }
    }
}
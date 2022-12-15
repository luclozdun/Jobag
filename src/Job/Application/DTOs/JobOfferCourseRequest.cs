using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Job.Application.DTOs
{
    public class JobOfferCourseRequest
    {
        public int JobOfferId { get; }

        public int CourseId { get; }

        public JobOfferCourseRequest()
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Entities;
using Jobag.src.Resume.Domain.Model.Entities;

namespace Jobag.src.Job.Domain.Model.Aggregates
{
    public class JobOfferCourse
    {
        public int JobOfferId { get; private set; }

        public int CourseId { get; private set; }

        public JobOffer JobOffer { get; private set; }

        public Course Course { get; private set; }

        private JobOfferCourse()
        {
        }
    }
}
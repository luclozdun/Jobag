using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Result;

namespace Jobag.src.Job.Domain.Result
{
    public class JobOfferResult : BaseResult<JobOffer>
    {
        public JobOfferResult(JobOffer resource) : base(resource)
        {
        }

        public JobOfferResult(string message) : base(message)
        {
        }
    }
}
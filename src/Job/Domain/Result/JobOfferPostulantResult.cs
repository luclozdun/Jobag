using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Job.Domain.Model.Aggregates;
using Jobag.src.Shared.Domain.Result;

namespace Jobag.src.Job.Domain.Result
{
    public class JobOfferPostulantResult : BaseResult<JobOfferPostulant>
    {
        public JobOfferPostulantResult(JobOfferPostulant resource) : base(resource)
        {
        }

        public JobOfferPostulantResult(string message) : base(message)
        {
        }
    }
}
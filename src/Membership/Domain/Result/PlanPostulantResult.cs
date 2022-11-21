using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Result;

namespace Jobag.src.Membership.Domain.Result
{
    public class PlanPostulantResult : BaseResult<PlanPostulant>
    {
        public PlanPostulantResult(PlanPostulant resource) : base(resource)
        {
        }

        public PlanPostulantResult(string message) : base(message)
        {
        }
    }
}
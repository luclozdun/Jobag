using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Result;

namespace Jobag.src.Membership.Domain.Result
{
    public class PlanEmployeeResult : BaseResult<PlanEmployee>
    {
        public PlanEmployeeResult(PlanEmployee resource) : base(resource)
        {
        }

        public PlanEmployeeResult(string message) : base(message)
        {
        }
    }
}
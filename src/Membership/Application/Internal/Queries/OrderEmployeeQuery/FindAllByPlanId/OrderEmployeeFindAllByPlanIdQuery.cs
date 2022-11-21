using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Membership.Application.Internal.Queries.OrderEmployeeQuery.FindAllByPlanId
{
    public class OrderEmployeeFindAllByPlanIdQuery : IQuery<IEnumerable<OrderEmployee>>
    {
        public int PlanId { get; }

        public OrderEmployeeFindAllByPlanIdQuery(int planId)
        {
            PlanId = planId;
        }
    }
}
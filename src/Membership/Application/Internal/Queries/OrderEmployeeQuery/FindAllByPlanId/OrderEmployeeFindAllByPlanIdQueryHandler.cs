using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Model.ValueObject;
using Jobag.src.Membership.Domain.Repository;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Membership.Application.Internal.Queries.OrderEmployeeQuery.FindAllByPlanId
{
    public class OrderEmployeeFindAllByPlanIdQueryHandler : IQueryHandler<OrderEmployeeFindAllByPlanIdQuery, IEnumerable<OrderEmployee>>
    {
        private readonly IOrderEmployeeRepository orderEmployeeRepository;

        public OrderEmployeeFindAllByPlanIdQueryHandler(IOrderEmployeeRepository orderEmployeeRepository)
        {
            this.orderEmployeeRepository = orderEmployeeRepository;
        }

        public async Task<IEnumerable<OrderEmployee>> Handle(OrderEmployeeFindAllByPlanIdQuery request, CancellationToken cancellationToken)
        {
            PlanEmployeeId planEmployeeId = new PlanEmployeeId(request.PlanId);
            return await orderEmployeeRepository.FindAllByPlanId(planEmployeeId);
        }
    }
}
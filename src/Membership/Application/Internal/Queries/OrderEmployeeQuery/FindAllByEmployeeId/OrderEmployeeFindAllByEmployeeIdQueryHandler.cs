using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Repository;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Membership.Application.Internal.Queries.OrderEmployeeQuery.FindAllByEmployeeId
{
    public class OrderEmployeeFindAllByEmployeeIdQueryHandler : IQueryHandler<OrderEmployeeFindAllByEmployeeIdQuery, IEnumerable<OrderEmployee>>
    {
        private readonly IOrderEmployeeRepository orderEmployeeRepository;

        public OrderEmployeeFindAllByEmployeeIdQueryHandler(IOrderEmployeeRepository orderEmployeeRepository)
        {
            this.orderEmployeeRepository = orderEmployeeRepository;
        }

        public async Task<IEnumerable<OrderEmployee>> Handle(OrderEmployeeFindAllByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            EmployeeId employeeId = new EmployeeId(request.EmployeeId);
            return await orderEmployeeRepository.FindAllByEmployeeId(employeeId);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Membership.Application.Internal.Queries.OrderEmployeeQuery.FindAllByEmployeeId
{
    public class OrderEmployeeFindAllByEmployeeIdQuery : IQuery<IEnumerable<OrderEmployee>>
    {
        public int EmployeeId { get; }

        public OrderEmployeeFindAllByEmployeeIdQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}
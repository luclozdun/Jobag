using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Membership.Application.Internal.Commands.OrderEmployeeCommand.Create
{
    public class OrderEmployeeCreateCommand : ICommand<OrderEmployeeResult>
    {
        public int EmployeeId { get; }
        public int PlanEmployeeId { get; }

        public OrderEmployeeCreateCommand(int employeeId, int planEmployeeId)
        {
            EmployeeId = employeeId;
            PlanEmployeeId = planEmployeeId;
        }
    }
}
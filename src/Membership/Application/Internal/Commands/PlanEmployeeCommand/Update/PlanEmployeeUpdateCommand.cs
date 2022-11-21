using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Membership.Application.Internal.Commands.PlanEmployeeCommand.Remove
{
    public class PlanEmployeeRemoveCommand : ICommand<PlanEmployeeResult>
    {
        public int Id { get; }

        public PlanEmployeeRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
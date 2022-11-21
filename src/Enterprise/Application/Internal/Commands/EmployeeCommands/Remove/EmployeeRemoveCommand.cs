using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Enterprise.Application.Internal.Commands.EmployeeCommands.Remove
{
    public class EmployeeRemoveCommand : ICommand<EmployeeResult>
    {
        public int Id { get; }

        public EmployeeRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
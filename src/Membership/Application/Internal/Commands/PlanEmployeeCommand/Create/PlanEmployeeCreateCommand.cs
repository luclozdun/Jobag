using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Membership.Application.Internal.Commands.PlanEmployeeCommand.Create
{
    public class PlanEmployeeCreateCommand : ICommand<PlanEmployeeResult>
    {
        public double Price { get; }
        public string Name { get; }
        public string Description { get; }

        public PlanEmployeeCreateCommand(double price, string name, string description)
        {
            Price = price;
            Name = name;
            Description = description;
        }
    }
}
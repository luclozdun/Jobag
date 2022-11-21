using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Membership.Application.Internal.Commands.PlanPostulantCommand.Update
{
    public class PlanPostulantUpdateCommand : ICommand<PlanPostulantResult>
    {
        public int Id { get; }
        public double Price { get; }
        public string Name { get; }
        public string Description { get; }

        public PlanPostulantUpdateCommand(int id, double price, string name, string description)
        {
            Id = id;
            Price = price;
            Name = name;
            Description = description;
        }
    }
}
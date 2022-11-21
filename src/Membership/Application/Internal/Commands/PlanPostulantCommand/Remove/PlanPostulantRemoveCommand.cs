using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Membership.Application.Internal.Commands.PlanPostulantCommand.Remove
{
    public class PlanPostulantRemoveCommand : ICommand<PlanPostulantResult>
    {
        public int Id { get; }

        public PlanPostulantRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
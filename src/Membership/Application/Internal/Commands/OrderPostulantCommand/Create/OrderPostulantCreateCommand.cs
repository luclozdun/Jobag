using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Result;
using Jobag.src.Shared.Application.Commands;

namespace Jobag.src.Membership.Application.Internal.Commands.OrderPostulantCommand.Create
{
    public class OrderPostulantCreateCommand : ICommand<OrderPostulantResult>
    {
        public int PostulantId { get; }
        public int PlanPostulantId { get; }

        public OrderPostulantCreateCommand(int postulantId, int planPostulantId)
        {
            PostulantId = postulantId;
            PlanPostulantId = planPostulantId;
        }
    }
}
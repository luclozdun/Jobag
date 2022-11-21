using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Model.ValueObject;
using Jobag.src.Membership.Domain.Repository;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Membership.Application.Internal.Queries.OrderPostulantQuery.FindAllByPlanId
{
    public class OrderPostulantFindAllByPlanIdQueryHandler : IQueryHandler<OrderPostulantFindAllByPlanIdQuery, IEnumerable<OrderPostulant>>
    {
        private readonly IOrderPostulantRepository orderPostulantRepository;

        public OrderPostulantFindAllByPlanIdQueryHandler(IOrderPostulantRepository orderPostulantRepository)
        {
            this.orderPostulantRepository = orderPostulantRepository;
        }

        public async Task<IEnumerable<OrderPostulant>> Handle(OrderPostulantFindAllByPlanIdQuery request, CancellationToken cancellationToken)
        {
            PlanPostulantId planPostulantId = new PlanPostulantId(request.PlanId);
            return await orderPostulantRepository.FindAllByPlanId(planPostulantId);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.ValueObjects;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Repository;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Membership.Application.Internal.Queries.OrderPostulantQuery.FindAllByPostulantId
{
    public class OrderPostulantFindAllByPostulantIdQueryHandler : IQueryHandler<OrderPostulantFindAllByPostulantIdQuery, IEnumerable<OrderPostulant>>
    {
        private readonly IOrderPostulantRepository orderPostulantRepository;

        public OrderPostulantFindAllByPostulantIdQueryHandler(IOrderPostulantRepository orderPostulantRepository)
        {
            this.orderPostulantRepository = orderPostulantRepository;
        }

        public async Task<IEnumerable<OrderPostulant>> Handle(OrderPostulantFindAllByPostulantIdQuery request, CancellationToken cancellationToken)
        {
            PostulantId postulantId = new PostulantId(request.PostulantId);
            return await orderPostulantRepository.FindAllByPostulantId(postulantId);
        }
    }
}
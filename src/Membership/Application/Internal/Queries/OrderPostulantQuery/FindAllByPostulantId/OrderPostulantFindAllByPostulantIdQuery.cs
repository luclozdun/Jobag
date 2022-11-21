using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Result;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Membership.Application.Internal.Queries.OrderPostulantQuery.FindAllByPostulantId
{
    public class OrderPostulantFindAllByPostulantIdQuery : IQuery<IEnumerable<OrderPostulant>>
    {
        public int PostulantId { get; }

        public OrderPostulantFindAllByPostulantIdQuery(int postulantId)
        {
            PostulantId = postulantId;
        }
    }
}
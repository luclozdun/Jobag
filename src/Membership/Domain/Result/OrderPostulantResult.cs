using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Result;

namespace Jobag.src.Membership.Domain.Result
{
    public class OrderPostulantResult : BaseResult<OrderPostulant>
    {
        public OrderPostulantResult(OrderPostulant resource) : base(resource)
        {
        }

        public OrderPostulantResult(string message) : base(message)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Result;

namespace Jobag.src.Membership.Domain.Result
{
    public class OrderEmployeeResult : BaseResult<OrderEmployee>
    {
        public OrderEmployeeResult(OrderEmployee resource) : base(resource)
        {
        }

        public OrderEmployeeResult(string message) : base(message)
        {
        }
    }
}
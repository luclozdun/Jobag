using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Membership.Domain.Model.ValueObject
{
    public class OrderPostulantId : IdValueObject
    {
        public OrderPostulantId(int Id) : base(Id)
        {
        }
    }
}
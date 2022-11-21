using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Shared.Domain.Model.ValueObject;

namespace Jobag.src.Enterprise.Domain.Model.ValueObjects
{
    public class CompanyId : IdValueObject
    {
        public CompanyId(int Id) : base(Id)
        {
        }
    }
}
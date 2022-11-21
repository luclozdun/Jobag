using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Entities;
using Jobag.src.Shared.Domain.Result;

namespace Jobag.src.Enterprise.Domain.Result
{
    public class CompanyResult : BaseResult<Company>
    {
        public CompanyResult(Company resource) : base(resource)
        {
        }

        public CompanyResult(string message) : base(message)
        {
        }
    }
}
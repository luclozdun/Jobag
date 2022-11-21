using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Aggregates;
using Jobag.src.Shared.Domain.Result;

namespace Jobag.src.Enterprise.Domain.Result
{
    public class EmployeeResult : BaseResult<Employee>
    {
        public EmployeeResult(Employee resource) : base(resource)
        {
        }

        public EmployeeResult(string message) : base(message)
        {
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Aggregates;
using Jobag.src.Enterprise.Domain.Result;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Enterprise.Application.Internal.Queries.EmployeeQueries.FindByCompanyId
{
    public class EmployeeFindByCompanyIdQuery : IQuery<IEnumerable<Employee>>
    {
        public int CompanyId { get; }

        public EmployeeFindByCompanyIdQuery(int companyId)
        {
            CompanyId = companyId;
        }
    }
}
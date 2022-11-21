using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Aggregates;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Enterprise.Domain.Repository;
using Jobag.src.Enterprise.Domain.Result;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Enterprise.Application.Internal.Queries.EmployeeQueries.FindByCompanyId
{
    public class EmployeeFindByCompanyIdQueryHandler : IQueryHandler<EmployeeFindByCompanyIdQuery, IEnumerable<Employee>>
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeFindByCompanyIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> Handle(EmployeeFindByCompanyIdQuery request, CancellationToken cancellationToken)
        {
            CompanyId companyId = new CompanyId(request.CompanyId);
            return await employeeRepository.FindByCompanyId(companyId);
        }
    }
}
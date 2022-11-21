using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Repository;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Membership.Application.Internal.Queries.PlanEmployeeQuery.FindAll
{
    public class PlanEmployeeFindAllQueryHandler : IQueryHandler<PlanEmployeeFindAllQuery, IEnumerable<PlanEmployee>>
    {
        private readonly IPlanEmployeeRepository planEmployeeRepository;

        public PlanEmployeeFindAllQueryHandler(IPlanEmployeeRepository planEmployeeRepository)
        {
            this.planEmployeeRepository = planEmployeeRepository;
        }

        public async Task<IEnumerable<PlanEmployee>> Handle(PlanEmployeeFindAllQuery request, CancellationToken cancellationToken)
        {
            return await planEmployeeRepository.FindAll();
        }
    }
}
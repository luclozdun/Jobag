using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Repository;
using Jobag.src.Shared.Application.Queries;

namespace Jobag.src.Membership.Application.Internal.Queries.PlanPostulantQuery.FindAll
{
    public class PlanPostulantFindAllQueryHandler : IQueryHandler<PlanPostulantFindAllQuery, IEnumerable<PlanPostulant>>
    {
        private readonly IPlanPostulantRepository planPostulantRepository;

        public PlanPostulantFindAllQueryHandler(IPlanPostulantRepository planPostulantRepository)
        {
            this.planPostulantRepository = planPostulantRepository;
        }

        public async Task<IEnumerable<PlanPostulant>> Handle(PlanPostulantFindAllQuery request, CancellationToken cancellationToken)
        {
            return await planPostulantRepository.FindAll();
        }
    }
}
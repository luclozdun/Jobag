using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Model.ValueObject;

namespace Jobag.src.Membership.Domain.Repository
{
    public interface IPlanEmployeeRepository
    {
        Task<IEnumerable<PlanEmployee>> FindAll();

        Task<PlanEmployee> FindById(PlanEmployeeId planEmployeeId);

        Task Save(PlanEmployee planEmployee);

        void Update(PlanEmployee planEmployee);

        void Remove(PlanEmployee planEmployee);
    }
}
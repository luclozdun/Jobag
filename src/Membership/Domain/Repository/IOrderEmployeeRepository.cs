using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Model.ValueObject;

namespace Jobag.src.Membership.Domain.Repository
{
    public interface IOrderEmployeeRepository
    {
        Task<IEnumerable<OrderEmployee>> FindAllByEmployeeId(EmployeeId employeeId);

        Task<IEnumerable<OrderEmployee>> FindAllByPlanId(PlanEmployeeId planEmployeeId);

        Task Save(OrderEmployee order);

        Task<OrderEmployee> FindById(OrderEmployeeId orderEmployeeId);
    }
}
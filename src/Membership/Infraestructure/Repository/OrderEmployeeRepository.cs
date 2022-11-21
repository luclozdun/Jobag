using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Model.ValueObject;
using Jobag.src.Membership.Domain.Repository;
using Jobag.src.Shared.Infraestructure.Resource;
using Microsoft.EntityFrameworkCore;

namespace Jobag.src.Membership.Infraestructure.Repository
{
    public class OrderEmployeeRepository : IOrderEmployeeRepository
    {
        private readonly DataBaseContext context;

        public OrderEmployeeRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<OrderEmployee>> FindAllByEmployeeId(EmployeeId employeeId)
        {
            return await context.OrderEmployees.Where(x => x.EmployeeId == (int)employeeId).ToListAsync();
        }

        public async Task<IEnumerable<OrderEmployee>> FindAllByPlanId(PlanEmployeeId planEmployeeId)
        {
            return await context.OrderEmployees.Where(x => x.PlanEmployeeId == (int)planEmployeeId).ToListAsync();
        }

        public async Task<OrderEmployee> FindById(OrderEmployeeId orderEmployeeId)
        {
            return await context.OrderEmployees.Where(x => x.Id == (int)orderEmployeeId).FirstOrDefaultAsync();
        }

        public async Task Save(OrderEmployee order)
        {
            await context.OrderEmployees.AddAsync(order);
        }
    }
}
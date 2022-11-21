using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Model.ValueObject;
using Jobag.src.Membership.Domain.Repository;
using Jobag.src.Shared.Infraestructure.Resource;
using Microsoft.EntityFrameworkCore;

namespace Jobag.src.Membership.Infraestructure.Repository
{
    public class PlanEmployeeRepository : IPlanEmployeeRepository
    {
        private readonly DataBaseContext context;

        public PlanEmployeeRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PlanEmployee>> FindAll()
        {
            return await context.PlanEmployees.ToListAsync();
        }

        public async Task<PlanEmployee> FindById(PlanEmployeeId planEmployeeId)
        {
            return await context.PlanEmployees.Where(x => x.Id == (int)planEmployeeId).FirstOrDefaultAsync();
        }

        public void Remove(PlanEmployee planEmployee)
        {
            context.PlanEmployees.Remove(planEmployee);
        }

        public async Task Save(PlanEmployee planEmployee)
        {
            await context.PlanEmployees.AddAsync(planEmployee);
        }

        public void Update(PlanEmployee planEmployee)
        {
            context.PlanEmployees.Update(planEmployee);
        }
    }
}
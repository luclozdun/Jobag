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
    public class PlanPostulantRepository : IPlanPostulantRepository
    {
        private readonly DataBaseContext context;

        public PlanPostulantRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PlanPostulant>> FindAll()
        {
            return await context.PlanPostulants.ToListAsync();
        }

        public async Task<PlanPostulant> FindById(PlanPostulantId planPostulantId)
        {
            return await context.PlanPostulants.Where(x => x.Id == (int)planPostulantId).FirstOrDefaultAsync();
        }

        public void Remove(PlanPostulant planPostulant)
        {
            context.PlanPostulants.Remove(planPostulant);
        }

        public async Task Save(PlanPostulant planPostulant)
        {
            await context.PlanPostulants.AddAsync(planPostulant);
        }

        public void Update(PlanPostulant planPostulant)
        {
            context.PlanPostulants.Update(planPostulant);
        }
    }
}
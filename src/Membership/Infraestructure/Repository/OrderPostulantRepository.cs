using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Ability.Domain.Model.ValueObjects;
using Jobag.src.Membership.Domain.Model.Entities;
using Jobag.src.Membership.Domain.Model.ValueObject;
using Jobag.src.Membership.Domain.Repository;
using Jobag.src.Shared.Infraestructure.Resource;
using Microsoft.EntityFrameworkCore;

namespace Jobag.src.Membership.Infraestructure.Repository
{
    public class OrderPostulantRepository : IOrderPostulantRepository
    {
        private readonly DataBaseContext context;

        public OrderPostulantRepository(DataBaseContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<OrderPostulant>> FindAllByPostulantId(PostulantId postulantId)
        {
            return await context.OrderPostulants.Where(x => x.PostulantId == (int)postulantId).ToListAsync();
        }

        public async Task<IEnumerable<OrderPostulant>> FindAllByPlanId(PlanPostulantId planPostulantId)
        {
            return await context.OrderPostulants.Where(x => x.PlanPostulantId == (int)planPostulantId).ToListAsync();
        }

        public async Task<OrderPostulant> FindById(OrderPostulantId orderPostulantId)
        {
            return await context.OrderPostulants.Where(x => x.Id == (int)orderPostulantId).FirstOrDefaultAsync();
        }

        public async Task Save(OrderPostulant order)
        {
            await context.OrderPostulants.AddAsync(order);
        }
    }
}